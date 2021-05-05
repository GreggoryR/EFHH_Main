using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIBroker : MonoBehaviour
{
    public static event Action GameIsOver; //subscribers subscribe to the action
    public static void GameIsOverCall() //this method is called by the publisher
    {
        if (GameIsOver != null)
        {
            GameIsOver();
        }
    }
}
