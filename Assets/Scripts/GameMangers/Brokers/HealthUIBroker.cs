///////////////////////////////////////////////////////////////////////////
//FileName: HealthUIBroker.cs
//Author : Greggory Reed
//Description : Publisher/Subscriber Broker for changing the health UI
////////////////////////////////////////////////////////////////////////////

using System;

public class HealthUIBroker 
{
    public static event Action HealthIsLost; //subscribers subscribe to the action
    public static void HealthIsLostCall() //this method is called by the publisher
    {
        if (HealthIsLost != null)
        {
            HealthIsLost();
        }
    }

    public static event Action HealthIsGained;
    public static void HealthIsGainedCall()
    {
        if (HealthIsGained != null)
        {
            HealthIsGained();
        }
    }
}
