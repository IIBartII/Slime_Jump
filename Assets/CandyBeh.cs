using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBeh : MonoBehaviour
{
    private int candyAmmount = 0;
    [SerializeField] private CandySpawn candySpawn;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        candySpawn = player.GetComponent<CandySpawn>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            candyAmmount = PlayerPrefs.GetInt("CandyA");
            candyAmmount++;
            PlayerPrefs.SetInt("CandyA", candyAmmount);
            Debug.Log("Candy");
            candySpawn.canSpawn = true;
            Destroy(gameObject);
        }
    }
}
