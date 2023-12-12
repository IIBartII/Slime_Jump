using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WynikNormal : MonoBehaviour
{
    public float timerDelay = 5f;
    private float timer;
    public int wynik = 0;
    [HideInInspector] public int CaveWynDEBUG = 0;
    public int wynikCave;
    public Text wynikTxt;
    public Text WynikCaveText;
    public Text RekordText;
    public Text RekordHardText;
    public Text RekordCaveText;
    public int Rekord = 0;
    public int RekordHard = 0;
    public int RekordCave = 0;
    public string mode = "Normal";
    public AudioSource odbicie;
    public bool juzSkoczyl = false;
    public SpikeBehNormal spikeBehNormal;
    private void Awake()
    {
        Rekord = PlayerPrefs.GetInt("Rekord",Rekord);
        RekordHard = PlayerPrefs.GetInt("RekordHard", RekordHard);
        RekordCave = PlayerPrefs.GetInt("RekordCave", RekordCave);
        RekordText.text = "Rekord: " + Rekord.ToString();
        RekordHardText.text = "Rekord: " + RekordHard.ToString();
        RekordCaveText.text = "Rekord: " + RekordCave.ToString() + "M";
    }
    private void Update()
    {
        if (mode == "Cave" && juzSkoczyl)
        {
            timer += Time.deltaTime;
            if (timer > timerDelay)
            {
                wynikCave += 1;
                WynikCaveText.text = wynikCave.ToString() + "M";
                timer = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if(Rekord < wynik && mode == "Normal")
        {
            Debug.Log("New Record");
            Rekord = wynik;
            RekordText.text = "Rekord: " + Rekord.ToString();
            PlayerPrefs.SetInt("Rekord", Rekord );
        }
        if (RekordHard < wynik && mode == "Hard")
        {
            Debug.Log("New Hard Record");
            RekordHard = wynik;
            RekordHardText.text = "Rekord: " + RekordHard.ToString();
            PlayerPrefs.SetInt("RekordHard", RekordHard);
        }
        if (RekordCave < wynikCave && mode == "Cave")
        {
            Debug.Log("New Cave Record");
            RekordCave = wynikCave;
            RekordCaveText.text = "Rekord: " + RekordCave.ToString() + "M";
            PlayerPrefs.SetInt("RekordCave", RekordCave);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lewo") || collision.gameObject.CompareTag("Prawo"))
        {
            odbicie.Play();
            if (mode == "Normal" || mode == "Hard")
            {
                wynik++;
                wynikTxt.text = wynik.ToString();
            }
            else if (mode == "Cave")
            {
                CaveWynDEBUG++;
                spikeBehNormal.wynik = CaveWynDEBUG;
            }
            //if (mode == "Cave") spikeBehNormal.CaveWynik(CaveWynDEBUG);
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            wynik = 0;
            wynikCave = 0;
            wynikTxt.text = wynik.ToString();
            WynikCaveText.text = wynikCave.ToString();
            CaveWynDEBUG = 0;
            spikeBehNormal.wynik = CaveWynDEBUG;
        }
    }
}
