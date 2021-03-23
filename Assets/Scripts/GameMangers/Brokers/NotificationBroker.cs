///////////////////////////////////////////////////////////////////////////
//FileName: NotificationBrokerr.cs
//Author : Greggory Reed
//Description : Publisher/Subscriber Broker for game notifications
////////////////////////////////////////////////////////////////////////////

using System;

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

    public static event Action NewChapterBegins;
    public static void NewChapterBeginsCall()
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
