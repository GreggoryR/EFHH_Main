///////////////////////////////////////////////////////////////////////////
//FileName: NotificationBrokerr.cs
//Author : Greggory Reed
//Description : Publisher/Subscriber Broker for game notifications
////////////////////////////////////////////////////////////////////////////

using System;

public class NotificationBroker 
{
    public delegate void GameStartBegins(MessageSO message); //subscribers subscribe
    public static event GameStartBegins gameStartBegins;
    public static void GameStartBeginsCall(MessageSO message) //this method is called by the publisher
    {
        if (gameStartBegins != null)
        {
            gameStartBegins(message);
        }
    }


    public delegate void NewChapterBegins(MessageSO message); //subscribers subscribe
    public static event NewChapterBegins newChapterBegins;
    public static void NewChapterBeginsCall(MessageSO message)
    {
        if (newChapterBegins != null)
        {
            newChapterBegins(message);
        }
    }

    public delegate void ItemRecievedFromNPC(MessageSO message); //subscribers subscribe
    public static event ItemRecievedFromNPC itemRecievedFromNPC;
    public static void ItemRecievedFromNPCCall(MessageSO message) 
    {
        if (itemRecievedFromNPC != null)
        {
            itemRecievedFromNPC(message);
        }
    }

    public delegate void DoorIsLocked(MessageSO message); //subscribers subscribe
    public static event DoorIsLocked doorIsLocked;
    public static void DoorIsLockedCall(MessageSO message)
    {
        if (doorIsLocked != null)
        {
            doorIsLocked(message);
        }
    }

    public delegate void TurnOffButtons(); //subscribers subscribe
    public static event TurnOffButtons turnOffButtons;
    public static void TurnOffButtonsCall()
    {
        if (turnOffButtons != null)
        {
            turnOffButtons();
        }
    }



}
