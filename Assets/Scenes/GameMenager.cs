using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour
{
    public int MaxFPs = 75;
    public int avgFrameRate;
    public Text display_Text;
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = MaxFPs;
    }
    private void FixedUpdate()
    {
        float current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}
