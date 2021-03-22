using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class ElevatorKeypad : MonoBehaviour
{
    public delegate void ElevatorKeypadCodeCorrect();
    public event ElevatorKeypadCodeCorrect KeyPadDelegate;

    public Text keypadInGame;
    string correctKeypadValue = "5189141";
    StringBuilder sb = new StringBuilder(7);

    private void Start()
    {
    }
    public void Update()
    {
        keypadInGame.text = sb.ToString();
    }

    public void AddNumberToKeypad(Button button)
    {
        if(sb.Length <= 7)
        {
            sb.Append(button.GetComponentInChildren<Text>().text.ToString());
        }
    }

    public void ResetKeypad()
    {
        sb.Clear();
    }

    public void CheckUnlock()
    {
        //check number
        //if false, red light
        //if true, activate in elevator manager
        //open door
        if (sb.ToString().Equals(correctKeypadValue))
        {
            UnlockElevator();
        }
        else
        {
            Debug.Log("nope");
            sb.Clear();
        }
        

    }

    private void UnlockElevator()
    {
        this.gameObject.SetActive(false);
        KeyPadDelegate.Invoke();
    }
}
