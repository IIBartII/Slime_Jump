using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeButton : MonoBehaviour
{
    public SpikeBehNormal spikeBehNormal;
    public GameColors gameColors;
    public SpikeMovement spikeMovement;
    public WynikNormal wynikNormal;
    public CandySpawn candySpawn;
    public Death death;
    public GameObject[] hardmodeDisable;
    public GameObject[] hardmodeEnable;
    bool hardmode = false;
    public void HardMode()
    {
        if (!hardmode)
        {
            hardmode = true;
            spikeBehNormal.Mode = "Hard";
            gameColors.mode = "Hard";
            spikeMovement.mode = "Hard";
            wynikNormal.mode = "Hard";
            death.mode = "Hard";
            candySpawn.mode = "Hard";
            foreach (GameObject go in hardmodeDisable)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in hardmodeEnable)
            {
                go.SetActive(true);
            }
        }
        else if (hardmode)
        {
            hardmode = false;
            spikeBehNormal.Mode = "Normal";
            gameColors.mode = "Normal";
            spikeMovement.mode = "Normal";
            wynikNormal.mode = "Normal";
            death.mode = "Normal";
            candySpawn.mode = "Normal";
            foreach (GameObject go in hardmodeDisable)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in hardmodeEnable)
            {
                go.SetActive(false);
            }
        }
    }
}
