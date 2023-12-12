using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CandySpawn : MonoBehaviour
{
    public GameObject CandyPrefab;
    private Vector2 spawnPointL;
    private Vector2 spawnPointR;
    public bool canSpawn = true;
    public Text candyAmmountText;
    public int candyAmmount;
    public AudioSource sound;
    public string mode;
    private void Awake()
    {
        candyAmmount = PlayerPrefs.GetInt("CandyA");
        candyAmmountText.text = candyAmmount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lewo") && mode != "Cave")
        {
            if (canSpawn)
            {
                SpawnR();
                Instantiate(CandyPrefab, spawnPointR, Quaternion.identity);
                canSpawn = false;
            }
        }
        if(collision.gameObject.CompareTag("Prawo") && mode != "Cave")
        {
            if (canSpawn)
            {
                SpawnL();
                Instantiate(CandyPrefab, spawnPointL, Quaternion.identity);
                canSpawn = false;
            }
        }
        if(collision.gameObject.CompareTag("Candy"))
        {
            sound.Play();
        }
    }
    private void SpawnL()
    {
        spawnPointL = new(-2.35f, Random.Range(-2.75f, 5));
    }
    private void SpawnR()
    {
        spawnPointR = new(2.35f, Random.Range(-2.75f, 5));
    }
}
