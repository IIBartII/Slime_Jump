using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    bool PanelOn = false;
    public GameObject Panel;
    public GameObject[] ToDisable = new GameObject[0];
    public GameObject infoButton;
    private int clicks = 0;
    public GameObject WhiteLock;
    public GameObject WhiteSkin;
    public GameObject Firework;

    private void Awake()
    {
        WhiteSkin.SetActive(false);
        if (PlayerPrefs.GetString("WhiteUnlocked") == "WhiteUnlocked")
        {
            WhiteLock.SetActive(false);
            WhiteSkin.SetActive(true);
        }
    }
    public void PanelBeh()
    {
        if (!PanelOn)
        {
            Panel.SetActive(true);
            PanelOn = true;
            foreach (GameObject go in ToDisable)
            {
                go.SetActive(false);
            }
        }
        else if (PanelOn)
        {
            Panel.SetActive(false);
            PanelOn = false;
            foreach (GameObject go in ToDisable)
            {
                go.SetActive(true);
            }
            clicks = 0;
        }
    }
    public void Secret()
    {
        clicks++;
        if (clicks == 5)
        {
            PlayerPrefs.SetString("WhiteUnlocked", "WhiteUnlocked");
            Debug.Log("Unlocked");
            WhiteLock.SetActive(false);
            WhiteSkin.SetActive(true);
            Instantiate(Firework,new Vector3(transform.localPosition.x, transform.localPosition.y -1.25f ,1), Quaternion.identity);
        }
    }
}