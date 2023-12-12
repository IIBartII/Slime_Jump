using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUnlockMenager : MonoBehaviour
{
    private void OnEnable()
    {
        SkinUnlockPanel.OnKolorOdblokowany += HandleKolorOdblokowany;
    }
    private void HandleKolorOdblokowany(string kolor)
    {
        if (kolor == "Czerwony") UCzerwony.SetActive(false);
        if (kolor == "Niebieski") UNiebieski.SetActive(false);
        if (kolor == "JasnoNiebieski") UJasnoNiebieski.SetActive(false);
        if (kolor == "Zolty") UZolty.SetActive(false);
        if (kolor == "Pomaranczowy") UPomaranczowy.SetActive(false);
        if (kolor == "Fiolet") Ufiolet.SetActive(false);
        if (kolor == "CiemnyZiel") UCiemnyZiel.SetActive(false);
        if (kolor == "Roz") URoz.SetActive(false);
    }

    [Header("Lockers")]
    public GameObject UCzerwony;
    public GameObject UNiebieski;
    public GameObject UJasnoNiebieski;
    public GameObject UZolty;
    public GameObject UPomaranczowy;
    public GameObject Ufiolet;
    public GameObject UCiemnyZiel;
    public GameObject URoz;

    private void Start()
    {
        if (PlayerPrefs.GetString("Czerwony") == "Czerwony") UCzerwony.SetActive(false);
        if (PlayerPrefs.GetString("Niebieski") == "Niebieski") UNiebieski.SetActive(false);
        if (PlayerPrefs.GetString("JasnoNiebieski") == "JasnoNiebieski") UJasnoNiebieski.SetActive(false);
        if (PlayerPrefs.GetString("Zolty") == "Zolty") UZolty.SetActive(false);
        if (PlayerPrefs.GetString("Pomaranczowy") == "Pomaranczowy") UPomaranczowy.SetActive(false);
        if (PlayerPrefs.GetString("Fiolet") == "Fiolet") Ufiolet.SetActive(false);
        if (PlayerPrefs.GetString("CiemnyZiel") == "CiemnyZiel") UCiemnyZiel.SetActive(false);
        if (PlayerPrefs.GetString("Roz") == "Roz") URoz.SetActive(false);
    }
}
