using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBroker 
{
    public static event Action HealthIsLost; //subscribers subscribe to the action
    public static void HealthIsLostCall() //this method is called by the publisher
    {
        if (HealthIsLost != null)
        {
            HealthIsLost();
        }
    }

    public static event Action HealthIsGained; //subscribers subscribe to the action
    public static void HealthIsGainedCall() //this method is called by the publisher
    {
        if (HealthIsGained != null)
        {
            HealthIsGained();
        }
    }
}
