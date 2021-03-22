using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//PUBLISHER / SUBSCRIBER NOTIFICATIONS
//<summary>
//<para> This will handle the publishing and subscribing of the notifications </para>
//</summary>
public class NotificationBroker 
{
    public static event Action GameStartBegins; //subscribers subscribe to the action
    public static void GameStartBeginsCall() //this method is called by the publisher
    {
        if (GameStartBegins != null)
        {
            GameStartBegins();
        }
    }

    public static event Action NewChapterBegins; //subscribers subscribe to the action
    public static void NewChapterBeginsCall() //this method is called by the publisher
    {
        if (NewChapterBegins != null)
        {
            NewChapterBegins();
        }
    }

    public static event Action ItemRecievedFromNPC;
    public static void ItemRecievedFromNPCCall() 
    {
        if (ItemRecievedFromNPC != null)
        {
            ItemRecievedFromNPC();
        }
    }

    public static event Action DoorIsLocked;
    public static void DoorIsLockedCall()
    {
        if (DoorIsLocked != null)
        {
            DoorIsLocked();
        }
    }

}
