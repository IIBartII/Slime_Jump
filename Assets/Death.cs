using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Vector2 startPos;
    public Rigidbody2D PRB;
    public GameObject PGO;
    public Movement movement;
    public WynikNormal wynikNormal;
    public GameObject wynikTxt;
    public GameObject RekordHardTxt;
    public SpikeBehNormal spikeBehNormal;
    public GameColors gameColors;
    public GameObject[] toEnable;
    public GameObject[] toEnableHard;
    public string mode = "Normal";
    public GameObject[] CaveEnable;
    public GameObject[] CaveDisable;
    public GameObject LightL;
    public GameObject LightR;
    private Animator anim;
    public CandySpawn candySpawn;
    public Text candyAmmountText;
    public int candyAmmount;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        movement = GetComponent<Movement>();
        startPos = new Vector3(0,1,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            anim.SetTrigger("Died");
            LightL.SetActive(false);
            LightR.SetActive(false);
            PRB.gravityScale = 0;
            PRB.velocity = Vector2.zero;
            PGO.transform.position = startPos;
            movement.start = false;
            wynikTxt.SetActive(false);
            wynikNormal.juzSkoczyl = false;
            if (mode == "Normal")
            {
                foreach (GameObject go in toEnable)
                {
                    go.SetActive(true);
                }
            }
            else if (mode == "Hard")
            {
                foreach (GameObject go in toEnableHard)
                {
                    go.SetActive(true);
                }
            }
            else if (mode == "Cave")
            {
                foreach (GameObject go in CaveEnable)
                {
                    go.SetActive(true);
                }
                foreach (GameObject go in CaveDisable)
                {
                    go.SetActive(false);
                }
            }
            //candy
            Destroy(GameObject.FindGameObjectWithTag("Candy"));
            candySpawn.canSpawn = true;
            candyAmmount = PlayerPrefs.GetInt("CandyA");
            candyAmmountText.text = candyAmmount.ToString();

            spikeBehNormal.Restart();
            gameColors.StartZmianyKoloru = 0;
        }
    }
}
