using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameColors : MonoBehaviour
{
    public int wynik;
    public int wynikCave;
    [SerializeField] private WynikNormal wynikNormal;
    public Text DotknijAby;
    public Text GameTitle;
    public Text wynikTxt;
    public SpriteRenderer[] front = new SpriteRenderer[0];
    Color StartowyBG, KoncowyBG, KameraStart, KameraKoniec;
    public int StartZmianyKoloru = 0;
    float f = 0f;
    public float fplus = 0.01f;
    private bool gameStart = true;
    public string mode = "Normal";
    public Image[] greenOnStartup;
    public Image[] whiteOnStartup;
    public SpriteRenderer[] SpriteWhiteOnStartup;
    private void Awake()
    {
        KameraKoniec = new Color(0, 0, 0);
        KoncowyBG = new Color(0, 0, 0);
        foreach(Image image in whiteOnStartup)
        {
            image.color = Color.black;
        }
        foreach(SpriteRenderer sr in SpriteWhiteOnStartup)
        {
            sr.color = Color.black;
        }
    }
    private void FixedUpdate()
    {
        wynik = wynikNormal.wynik;
        if (mode == "Normal" || mode == "Hard")
            Kolory();
        if (mode == "Cave")
        {
            if(wynik == 0)
            {
                if (StartZmianyKoloru == 0)
                {
                    f = 0;
                    StartZmianyKoloru = 1;
                    StartowyBG = KoncowyBG;
                    KameraStart = KameraKoniec;
                }
                f += fplus;
                KoncowyBG = new Color(0f, 0f, 0f); //szarawy
                KameraKoniec = new Color(0f, 0f, 0f);
                for (int i = 0; i < front.Length; i++)
                {
                    front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
                }
            }
        }
    }
    public void Kolory()
    {
        if (wynik == 0)
        {
            if (StartZmianyKoloru == 0) // po smierci ustawia na 0 Death.cs
            {
                f = 0f;
                StartZmianyKoloru = 1;
                StartowyBG = KoncowyBG;
                KameraStart = KameraKoniec;
            }
            f += fplus;
            if (gameStart)
            {
                foreach(Image img in greenOnStartup)
                {
                    img.color = Color.Lerp(StartowyBG, new Color(0, 0.5f, 0), f);
                }
                foreach (Image img in whiteOnStartup)
                {
                    img.color = Color.Lerp(StartowyBG, Color.white, f);
                }
                foreach (SpriteRenderer sr in SpriteWhiteOnStartup)
                {
                    sr.color = Color.Lerp(StartowyBG, Color.white, f);
                }
                DotknijAby.color = Color.Lerp(StartowyBG, new Color(0, 0.5f, 0), f);
                GameTitle.color = Color.Lerp(StartowyBG, new Color(0, 0.5f, 0), f);
                if (f >=1) gameStart = false;
            }
            KoncowyBG = new Color(0.2f, 0.2f, 0.2f); //szarawy
            KameraKoniec = new Color(0.55f, 0.55f, 0.55f);
            for (int i = 0; i < front.Length; i++)
            {
                front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
            }
            Camera.main.backgroundColor = Color.Lerp(KameraStart, KameraKoniec, f);
            wynikTxt.color = Color.Lerp(KameraStart, KameraKoniec, f);
        }
        if (wynik == 5)
        {
            if(StartZmianyKoloru == 1)
            {
                f = 0f;
                StartZmianyKoloru = 0;
                StartowyBG = KoncowyBG;
                KameraStart = KameraKoniec;
            }
            KoncowyBG = new Color(0.4f, 0.45f, 0.50f); //Niebieskawy
            KameraKoniec = new Color(0.8f, 0.8f, 0.9f);
            f += fplus;
            for (int i = 0; i < front.Length; i++)
            {
                front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
            }
            Camera.main.backgroundColor = Color.Lerp(KameraStart, KameraKoniec, f);
            wynikTxt.color = Color.Lerp(KameraStart, KameraKoniec, f);
        }
        if (wynik == 10)
        {
            if (StartZmianyKoloru == 0)
            {
                f = 0f;
                StartZmianyKoloru = 1;
                StartowyBG = KoncowyBG;
                KameraStart = KameraKoniec;
            }
            KoncowyBG = new Color(0.5f, 0.4f, 0.4f); //czerwonyawy
            KameraKoniec = new Color(0.9f, 0.8f, 0.8f);
            f += fplus;
            for (int i = 0; i < front.Length; i++)
            {
                front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
            }
            Camera.main.backgroundColor = Color.Lerp(KameraStart, KameraKoniec, f);
            wynikTxt.color = Color.Lerp(KameraStart, KameraKoniec, f);
        }
        if (wynik == 15)
        {
            if (StartZmianyKoloru == 1)
            {
                f = 0f;
                StartZmianyKoloru = 0;
                StartowyBG = KoncowyBG;
                KameraStart = KameraKoniec;
            }
            KoncowyBG = new Color(0.45f, 0.5f, 0.4f); //zielonkawy
            KameraKoniec = new Color(0.85f, 1f, 0.85f);
            f += fplus;
            for (int i = 0; i < front.Length; i++)
            {
                front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
            }
            Camera.main.backgroundColor = Color.Lerp(KameraStart, KameraKoniec, f);
            wynikTxt.color = Color.Lerp(KameraStart, KameraKoniec, f);
        }
        if (wynik == 20)
        {
            if (StartZmianyKoloru == 0)
            {
                f = 0f;
                StartZmianyKoloru = 1;
                StartowyBG = KoncowyBG;
                KameraStart = KameraKoniec;
            }
            KoncowyBG = new Color(0.4f, 0.4f, 0.5f); //lekko purpurowy
            KameraKoniec = new Color(0.8f, 0.8f, 1f);
            f += fplus;
            for (int i = 0; i < front.Length; i++)
            {
                front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
            }
            Camera.main.backgroundColor = Color.Lerp(KameraStart, KameraKoniec, f);
            wynikTxt.color = Color.Lerp(KameraStart, KameraKoniec, f);
        }
        if (wynik == 25)
        {
            if (StartZmianyKoloru == 1)
            {
                f = 0f;
                StartZmianyKoloru = 0;
                StartowyBG = KoncowyBG;
                KameraStart = KameraKoniec;
            }
            KoncowyBG = new Color(1f, 1f, 1f); //czarno bialy
            KameraKoniec = new Color(0.55f, 0.55f, 0.55f);
            f += fplus;
            for (int i = 0; i < front.Length; i++)
            {
                front[i].color = Color.Lerp(StartowyBG, KoncowyBG, f);
            }
            Camera.main.backgroundColor = Color.Lerp(KameraStart, KameraKoniec, f);
            wynikTxt.color = Color.Lerp(KameraStart, KameraKoniec, f);
        }
    }
}
