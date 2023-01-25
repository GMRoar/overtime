using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public static float levelTimeRemaining;
    public bool Overtime;
    public static bool OvertimeMode;
    public int difficulty;
    public int level;
    public GameObject pauseMenu;


    public TMP_Text timerText;
    void Start()
    {
        difficulty = PlayerPrefs.GetInt("gameDifficulty");
        level = PlayerPrefs.GetInt("playerLevel");
        levelTimeRemaining = (150 / difficulty / level) + (150 - level * 2);
        Overtime = false;
        OvertimeMode = false;
    }
    void Update()
    {    
        if (GameMechanics.clockedIn & levelTimeRemaining >= 0 & !Overtime & !pauseMenu.activeSelf)
        {
            levelTimeRemaining = levelTimeRemaining - Time.deltaTime;
        }
        else if (GameMechanics.clockedIn & levelTimeRemaining <= 0)
        {
            Overtime = true;
            OvertimeMode = true;
            levelTimeRemaining = 0f;
            Debug.Log("Time is Out");
        }
        else
        {
            Overtime = false;
        }
        if (Overtime)
        {
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(levelTimeRemaining / 60f);
        int seconds = Mathf.FloorToInt(levelTimeRemaining - minutes * 60);
        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = formattedTime;
    }
}


