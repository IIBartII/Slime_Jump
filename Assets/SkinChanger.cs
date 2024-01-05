using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public Rigidbody2D prb;
    public GameObject NormalUI;
    public GameObject circle;
    public GameObject SkinChangerUI;
    bool skinMode = false;
    public Image pImg;
    Color kolorGracza;
    Color loadedColor;
    public GameObject infob;
    public GameObject unlockPanel;
    public Text candyammount;
    public bool OpenQmark = false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Kolor"))
        {
            string colorString = PlayerPrefs.GetString("Kolor");
            if (ColorUtility.TryParseHtmlString("#" + colorString, out loadedColor))
            {
                kolorGracza = loadedColor;
                pImg.color = kolorGracza;
            }
        }
    }
    public void SkinMode()
    {
        if (!skinMode)
        {
            skinMode = true;
            PlayerPrefs.SetString("Skin", "True");
            NormalUI.SetActive(false);
            circle.SetActive(false);
            SkinChangerUI.SetActive(true);
            prb.transform.position = new Vector2 (0f, -2);
            infob.SetActive(false);
        }
        else if (skinMode)
        {
            PlayerPrefs.SetString("Skin", "False");
            Destroy(GameObject.FindGameObjectWithTag("UnlockPanel"));
            skinMode = false;
            NormalUI.SetActive(true);
            circle.SetActive(true);
            prb.transform.position = new Vector2(0, 1);
            SkinChangerUI.SetActive(false);
            infob.SetActive(true);
            int candy = PlayerPrefs.GetInt("CandyA");
            candyammount.text = candy.ToString();

        }
    }
    public void Unlock(string kolor)
    {
        if(!OpenQmark)
        {
        OpenQmark = true;
        Instantiate(unlockPanel,new Vector3 (0,0,0), Quaternion.identity);
        PlayerPrefs.SetString("WhatToUnlock", kolor);
        //PlayerPrefs.SetString(kolor,kolor);
        }
    }
    #region kolory
    public void Zielony()
    {
            kolorGracza = new Color(0, 1, 0);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
    }
    public void Czerwony()
    {
        if (PlayerPrefs.GetString("Czerwony") == "Czerwony")
        {
            kolorGracza = new Color(1, 0, 0);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("Czerwony");
    }
    public void Niebieski()
    {
        if (PlayerPrefs.GetString("Niebieski") == "Niebieski")
        {
            kolorGracza = new Color(0, 0, 1);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("Niebieski");
    }
    public void JasnoNiebieski()
    {
        if (PlayerPrefs.GetString("JasnoNiebieski") == "JasnoNiebieski")
        {
            kolorGracza = new Color(0, 1, 1);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("JasnoNiebieski");
    }
    public void Zolty()
    {
        if (PlayerPrefs.GetString("Zolty") == "Zolty")
        {
            kolorGracza = new Color(1, 1, 0);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("Zolty");
    }
    public void Pomaranczowy()
    {
        if (PlayerPrefs.GetString("Pomaranczowy") == "Pomaranczowy")
        {
            kolorGracza = new Color(1, 0.55f, 0);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("Pomaranczowy");
    }
    public void Fiolet()
    {
        if (PlayerPrefs.GetString("Fiolet") == "Fiolet")
        {
            kolorGracza = new Color(0.5f, 0, 1);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("Fiolet");
    }
    public void CiemnyZiel()
    {
        if (PlayerPrefs.GetString("CiemnyZiel") == "CiemnyZiel")
        {
            kolorGracza = new Color(0, 0.5f, 0);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("CiemnyZiel");
    }
    public void Roz()
    {
        if (PlayerPrefs.GetString("Roz") == "Roz")
        {
            kolorGracza = new Color(1, 0, 0.75f);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
        else Unlock("Roz");
    }
    public void Bialy()
    {
        if (PlayerPrefs.GetString("WhiteUnlocked") == "WhiteUnlocked")
        {
            kolorGracza = new Color(1, 1, 1);
            pImg.color = kolorGracza;
            string colorString = ColorUtility.ToHtmlStringRGBA(kolorGracza);
            PlayerPrefs.SetString("Kolor", colorString);
        }
    }
    #endregion
}
