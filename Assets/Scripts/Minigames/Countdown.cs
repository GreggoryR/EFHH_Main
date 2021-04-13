using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] Text timerText;
    float timeRemaining = 179;
    bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                string minutes = (timeRemaining / 60).ToString("00");
                string seconds = (timeRemaining % 60).ToString("00");
                string miliseconds = ((timeRemaining * 60)%60).ToString("00");
                timerText.text = minutes + ":" + seconds + ":" + miliseconds;
            }
            else
            {
                Debug.Log("Time is out");
                timeRemaining = 0;
                
                timerText.text = timeRemaining.ToString();
                timerIsRunning = false;
            }
        }
    }

}
