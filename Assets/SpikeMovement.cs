using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Rigidbody2D Lewo;
    public Rigidbody2D Prawo;
    private Vector2 lStart;
    private Vector2 rStart;
    public float speed = 1;
    public string mode = "Normal";
    private void Awake()
    {
        lStart = Lewo.transform.position;
        rStart = Prawo.transform.position;
    }
    private void LewoGora()
    {
        Lewo.transform.position = lStart;
        Lewo.velocity = Vector2.zero;
        Prawo.velocity = new Vector2(0, speed);
    }
    private void PrawoGora()
    {
        Prawo.transform.position = rStart;
        Prawo.velocity = Vector2.zero;
        Lewo.velocity = new Vector2(0,speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lewo"))
        {
            if (mode == "Cave")
            {
                LewoGora();
            }
        }
        else if (collision.gameObject.CompareTag("Prawo"))
        {
            if (mode == "Cave")
            {
                PrawoGora();
            }
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            Reset();
        }
    }
    private void Reset()
    {
        Lewo.transform.position = lStart;
        Lewo.velocity = Vector2.zero;
        Prawo.transform.position = rStart;
        Prawo.velocity = Vector2.zero;
    }
}
