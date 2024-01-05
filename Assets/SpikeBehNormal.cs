using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehNormal : MonoBehaviour
{
    public WynikNormal wynikNormal;
    public GameObject[] SpikesLewo = new GameObject[0];
    public GameObject[] SpikesPrawo = new GameObject[0];
    private int JakiKolec;
    public int wynik;
    public string Mode = "Normal";
    int liczbaKolcow;
    public Animator animL;
    public Animator animR;
    public Animator animRTop;
    public Animator animLTop;
    private int odJakiego = 0;
    int a = 0;
    public int caveWynik;
    public void CaveWynik(int CaveWynik)
    {
        wynik = CaveWynik;
    }
    public void Restart()
    {
        foreach (GameObject spike in SpikesPrawo)
        {
            spike.SetActive(false);
        }
        foreach (GameObject spike in SpikesLewo)
        {
            spike.SetActive(false);
        }
    }
    private IEnumerator LewoDisable()
    {
        animL.SetTrigger("Hide");
        if (Mode != "Cave") yield return new WaitForSeconds(0.6f);
        foreach (GameObject spike in SpikesLewo)
        {
            spike.SetActive(false);
        }
    }
    private void Lewo()
    {
        wynik = wynikNormal.wynik;
        if (Mode == "Hard")
        {
            liczbaKolcow = 9; odJakiego = 1;
        }
        else odJakiego = 0;
        if (Mode == "Normal") liczbaKolcow = 10;
        else if (Mode == "Cave")
        {
            liczbaKolcow = 17;
            wynik = wynikNormal.CaveWynDEBUG;
        }
        Debug.Log(wynik);
        StartCoroutine(LewoDisable());
        #region ify
        if (wynik <= 4) a = 2;
        if (wynik >=5 && wynik <= 9) a = 3;
        if (wynik >=10 && wynik <= 14) a = 4;
        if (wynik >= 15 && wynik <= 19) a = 5;
        if (wynik >=20 && wynik <= 24) a = 6;
        if (wynik >=25 && wynik <= 29) a = 7;
        if (wynik >=30 && wynik <= 34) a = 8;
        if (wynik >= 35) a = 9;
        List<int> availableIndexes = new();
        for (int i = 0; i < liczbaKolcow; i++)
        {
            availableIndexes.Add(i);
        }
        while (a > 0 && availableIndexes.Count > 0)
        {
            JakiKolec = Random.Range(odJakiego, availableIndexes.Count);
            int selectedKolecIndex = availableIndexes[JakiKolec];
            SpikesPrawo[selectedKolecIndex].SetActive(true);
            availableIndexes.RemoveAt(JakiKolec);
            a--;
        }
        #endregion
    }
    private IEnumerator PrawoDisable()
    {
        animR.SetTrigger("Hide");
        if (Mode != "Cave") yield return new WaitForSeconds(0.6f);
        foreach (GameObject spike in SpikesPrawo)
        {
            spike.SetActive(false);
        }
    }
    private void Prawo()
    {
        wynik = wynikNormal.wynik;
        if (Mode == "Hard")
        {
            liczbaKolcow = 9; odJakiego = 1;
        }
        else odJakiego = 0;
        if (Mode == "Normal") liczbaKolcow = 10;
        else if (Mode == "Cave")
        {
            liczbaKolcow = 17;
            wynik = wynikNormal.CaveWynDEBUG;
        }
        Debug.Log(wynik);
        StartCoroutine(PrawoDisable());
        #region ify
        if (wynik <= 4) a = 2;
        if (wynik >=5 && wynik <= 9) a = 3;
        if (wynik >=10 && wynik <= 14) a = 4;
        if (wynik >= 15 && wynik <= 19) a = 5;
        if (wynik >=20 && wynik <= 24) a = 6;
        if (wynik >=25 && wynik <= 29) a = 7;
        if (wynik >=30 && wynik <= 34) a = 8;
        if (wynik >= 35 && wynik <= 39) a = 9;

        List<int> availableIndexes = new();
        for (int i = 0; i < liczbaKolcow; i++)
        {
            availableIndexes.Add(i);
        }
        while (a > 0 && availableIndexes.Count > 0)
        {
            JakiKolec = Random.Range(odJakiego, availableIndexes.Count);
            int selectedKolecIndex = availableIndexes[JakiKolec];
            SpikesLewo[selectedKolecIndex].SetActive(true);
            availableIndexes.RemoveAt(JakiKolec);
            a--;
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lewo"))
        {
            Lewo();
                animR.SetTrigger("Touch");
            if (Mode == "Hard")
            {
                animRTop.SetTrigger("Shake");
            }
        }

        else if (collision.gameObject.CompareTag("Prawo"))
        {
            Prawo();
                animL.SetTrigger("Touch");
            if (Mode == "Hard")
            {
                animLTop.SetTrigger("Shake");
            }
        }
    }
}