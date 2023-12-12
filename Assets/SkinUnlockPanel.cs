using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinUnlockPanel : MonoBehaviour
{
    private string WhatToUnlock;
    public int Candy;

    public delegate void KolorOdblokowany(string kolor);
    public static event KolorOdblokowany OnKolorOdblokowany;

    public GameObject NotEnoughMoney;
    public void No()
    {
        Destroy(this.gameObject);
    }
    public void Yes()
    {
        WhatToUnlock = PlayerPrefs.GetString("WhatToUnlock");
        Candy = PlayerPrefs.GetInt("CandyA");
#if UNITY_EDITOR
        PlayerPrefs.SetInt("CandyA", Candy);
        KolorUnl();
        Destroy(this.gameObject);
#else
        if (Candy >= 25)
        {
            Candy-=25;
            PlayerPrefs.SetInt("CandyA", Candy);
            KolorUnl();
            Destroy(this.gameObject);
        }else
        {
        NotEnoughMoney.SetActive(true);
        StartCoroutine(NotEnoughMoneyTimer());
        }
#endif
    }
    private IEnumerator NotEnoughMoneyTimer()
    {
        yield return new WaitForSeconds(1.5f);
            NotEnoughMoney.SetActive(false);
    }
    public void KolorUnl()
    {
        if (WhatToUnlock == "Czerwony")
        {
            PlayerPrefs.SetString("Czerwony", "Czerwony");
            OnKolorOdblokowany("Czerwony");
        }
        else if (WhatToUnlock == "Niebieski")
        {
            PlayerPrefs.SetString("Niebieski", "Niebieski");
            OnKolorOdblokowany("Niebieski");
        }
        else if (WhatToUnlock == "JasnoNiebieski")
        {
            PlayerPrefs.SetString("JasnoNiebieski", "JasnoNiebieski");
            OnKolorOdblokowany("JasnoNiebieski");
        }
        else if (WhatToUnlock == "Zolty")
        {
            PlayerPrefs.SetString("Zolty", "Zolty");
            OnKolorOdblokowany("Zolty");
        }
        else if (WhatToUnlock == "Pomaranczowy")
        {
            PlayerPrefs.SetString("Pomaranczowy", "Pomaranczowy");
            OnKolorOdblokowany("Pomaranczowy");
        }
        else if (WhatToUnlock == "Fiolet")
        {
            PlayerPrefs.SetString("Fiolet", "Fiolet");
            OnKolorOdblokowany("Fiolet");
        }
        else if (WhatToUnlock == "CiemnyZiel")
        {
            PlayerPrefs.SetString("CiemnyZiel", "CiemnyZiel");
            OnKolorOdblokowany("CiemnyZiel");
        }
        else if (WhatToUnlock == "Roz")
        {
            PlayerPrefs.SetString("Roz", "Roz");
            OnKolorOdblokowany("Roz");
        }
    }
}
