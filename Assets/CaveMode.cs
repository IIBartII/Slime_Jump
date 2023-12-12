using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMode : MonoBehaviour
{
    public SpikeBehNormal spikeBehNormal;
    public GameColors gameColors;
    public SpikeMovement spikeMovement;
    public WynikNormal wynikNormal;
    public Death death;
    public Movement movement;
    public GameObject[] CaveModeDisable;
    public GameObject[] CaveModeEnable;
    public CandySpawn candySpawn;
    bool CaveModeB = false;
    public void CaveModeV()
    {
        if (!CaveModeB)
        {
            CaveModeB = true;
            spikeBehNormal.Mode = "Cave";
            gameColors.mode = "Cave";
            spikeMovement.mode = "Cave";
            wynikNormal.mode = "Cave";
            death.mode = "Cave";
            candySpawn.mode = "Cave";
            movement.Cave = true;
            foreach (GameObject go in CaveModeDisable)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in CaveModeEnable)
            {
                go.SetActive(true);
            }
        }
        else if (CaveModeB)
        {
            CaveModeB = false;
            spikeBehNormal.Mode = "Normal";
            gameColors.mode = "Normal";
            spikeMovement.mode = "Normal";
            wynikNormal.mode = "Normal";
            death.mode = "Normal";
            candySpawn.mode = "Normal";
            movement.Cave = false;
            foreach (GameObject go in CaveModeDisable)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in CaveModeEnable)
            {
                go.SetActive(false);
            }
        }
    }
}
