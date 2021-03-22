using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;
    //Game Start
    [SerializeField] GameObject gameStartNotifcaton;
    [SerializeField] GameObject gameStartText;
    //Chapter Start
    [SerializeField] GameObject chapterStartNotifcaton;
    [SerializeField] GameObject chapterStartText;
    //Door Locked
    [SerializeField] GameObject doorLockedNotifcaton;
    [SerializeField] GameObject doorLockText;
    //Recieved an item
    [SerializeField] GameObject recieveItemNotifcaton;
    [SerializeField] GameObject recieveItemText;

    enum ActiveNotification { gameStart, chapterStart, doorLocked, receiveItem};
    ActiveNotification activeNotication;


    [SerializeField] public static bool notificationIsOpen = false;
    public GameObject inventoryUIButton;

    public string message;

    public delegate void OnResumeClicked();
    public OnResumeClicked onResumeClicked;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        message = "";
        //DialogueManager.instance.onDialogueFinished += ActivateNotifcationCallback; //onDialogueFinished
        NotificationBroker.GameStartBegins += ActivateGameStartNotification;
        NotificationBroker.ItemRecievedFromNPC += ActivateRecieveItemNotification;
        NotificationBroker.DoorIsLocked += ActivateDoorLockedNotification;
        NotificationBroker.NewChapterBegins += ActivateNewChapterNotification;
    }

    private void ActivateNewChapterNotification()
    {
        throw new NotImplementedException();
    }

    private void ActivateDoorLockedNotification()
    {
        throw new NotImplementedException();
    }

    private void ActivateGameStartNotification()
    {
        throw new NotImplementedException();
    }

    private void ActivateRecieveItemNotification()
    {
        if (!notificationIsOpen)
        {
            activeNotication = ActiveNotification.receiveItem;
            recieveItemNotifcaton.SetActive(true);
            GameManager.instance.isTalking = true;
            GameManager.instance.canMove = false;
            recieveItemText.GetComponent<Text>().text = message;
            //Time.timeScale = 0;
            notificationIsOpen = true;
        }
       
    }

    //public void ActivateNotifcationUI()
    //{
    //    if (!notificationIsOpen)
    //    {
    //        Resume();
    //    }
    //    else
    //    {
    //        Pause();
    //    }
    //}

    public void Resume()
    {
        switch (activeNotication)
        {
            case ActiveNotification.gameStart:
                gameStartNotifcaton.SetActive(false);
                break;
            case ActiveNotification.chapterStart:
                chapterStartNotifcaton.SetActive(false);
                break;
            case ActiveNotification.doorLocked:
                doorLockedNotifcaton.SetActive(false);
                break;
            case ActiveNotification.receiveItem:
                recieveItemNotifcaton.SetActive(false);
                break;
            default:
                break;
        }
        GameManager.instance.isTalking = false;
        GameManager.instance.canMove = true;
        message = "";
        Time.timeScale = 1f;
        notificationIsOpen = false;
        CheckToLoadNextLevel();
    }

    //public void Pause()
    //{
    //    GameManager.instance.isTalking = true;
    //    GameManager.instance.canMove = false;
    //    //Time.timeScale = 0;
    //    notificationIsOpen = true;
    //}

    public void CheckToLoadNextLevel()
    {
        if (StoryManager.instance.canLoadNextLevel)
        {
            LevelLoaderManager.instance.GetComponent<LevelLoaderManager>().LoadNextLevel(); // music fade, screen fade, and load level occurs here
        }
    }
}
