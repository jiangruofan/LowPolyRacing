using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject UIRacePanel;

    public Text UITextCurrentLap;
    public Text UITextCurrentTime;
    public Text UITextLastLapTime;
    public Text UITextBestLapTime;

    public Player UpdataUIForPlayer;

    private int currentlap = 0;
    private float currentlaptime;
    private float lastlaptime;
    private float bestlaptime;
    // Update is called once per frame
    void Update()
    {
        if (UpdataUIForPlayer == null)
            return;

        if (UpdataUIForPlayer.CurrentLap != currentlap)
        {
            currentlap = UpdataUIForPlayer.CurrentLap;
            UITextCurrentLap.text = $"LAP: {currentlap}";
        }

        if (UpdataUIForPlayer.CurrentLapTime != currentlaptime)
        {
            currentlaptime = UpdataUIForPlayer.CurrentLapTime;
            UITextCurrentTime.text = $"TIME: {(int)currentlaptime / 60}:{(currentlaptime) % 60:00.000}";
        }

        if (UpdataUIForPlayer.LastLaptime != lastlaptime)
        {
            lastlaptime = UpdataUIForPlayer.LastLaptime;
            UITextLastLapTime.text = $"LAST: {(int)lastlaptime / 60}:{(lastlaptime) % 60:00.000}";
        }

        if (UpdataUIForPlayer.BestLapTime != bestlaptime)
        {
            bestlaptime = UpdataUIForPlayer.BestLapTime;
            UITextBestLapTime.text = bestlaptime < 1000000 ? $"BEST: {(int)bestlaptime / 60}:{(bestlaptime) % 60:00.000}" : "BEST: NONE";
        }

    }
}
