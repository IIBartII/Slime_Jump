using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody2D pRB;
    public float Si³aSkoku = 5;
    public float speed = 3;
    private int StartDir;
    private Animator anim;
    [HideInInspector] public bool start = false;
    public GameObject wynikTxt;
    public GameObject RekordTxt;
    public GameObject DotknijAby;
    public GameObject GameTitle;
    public GameObject[] disableonstart;
    public AudioSource skok;
    public string Skin;
    public bool Cave;
    public GameObject[] caveDisable;
    public GameObject[] caveEnable;
    public WynikNormal wynikNormal;
    public GameObject LightL;
    public GameObject LightR;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        pRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Skin = PlayerPrefs.GetString("Skin");
        if (Skin == "True") return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.GetKeyDown(KeyCode.Space) || !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                skok.Play();
                GStart();
                Skok();
                wynikNormal.juzSkoczyl = true;
                if(Cave)
                {
                    foreach (GameObject go in caveDisable)
                    {
                        go.SetActive(false);
                    }
                    foreach (GameObject go in caveEnable)
                    {
                        go.SetActive(true);
                    }
                }
            }
        }
    }
    private void GStart()
    {
        if (!start)
        {
            foreach(GameObject go in disableonstart)
            {
                go.SetActive(false);
            }
            anim.SetTrigger("Jump");
            pRB.gravityScale = 1.75f;
            wynikTxt.SetActive(true);
            start = true;
            StartDir = Random.Range(0, 2) * 2 - 1;
            pRB.velocity = new Vector2(speed * StartDir, Si³aSkoku);
            if (Cave && StartDir == -1)
            {
                LightL.SetActive(true);
            }
            else if (Cave && StartDir == 1)
            {
                LightR.SetActive(true);
            }

        }
    }
    private void Skok()
    {
        if (start)
        {
            anim.SetTrigger("Jump");
            pRB.velocity = new Vector2(pRB.velocity.x, Si³aSkoku);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            if (collision.gameObject.CompareTag("Lewo"))
            {
                pRB.velocity = new Vector2(speed, pRB.velocity.y);
                LightR.SetActive(true);
                LightL.SetActive(false);
            }
            else if (collision.gameObject.CompareTag("Prawo"))
            {
                pRB.velocity = new Vector2(-speed, pRB.velocity.y);
                LightR.SetActive(false);
                LightL.SetActive(true);
            }
        }
    }
}