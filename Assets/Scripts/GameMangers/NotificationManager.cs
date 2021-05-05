///////////////////////////////////////////////////////////////////////////
//FileName: NotificationManager.cs
//Author : Greggory Reed
//Description : Class for game notifications
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NotificationManager : MonoBehaviour
{
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

    [SerializeField] MessageSO startMessageInformation;

    enum ActiveNotification { gameStart, chapterStart, doorLocked, receiveItem};
    ActiveNotification activeNotication;


    [SerializeField] public bool notificationIsOpen = false;
    public GameObject inventoryUIButton;

    [SerializeField] GameObject levelChangeManger;

    [SerializeField] GameObject countDown;

    public string message;


    private void Awake()
    {
        NotificationBroker.gameStartBegins += GameStartNotification;
        NotificationBroker.newChapterBegins += NewChapterNotification;
        NotificationBroker.itemRecievedFromNPC += RecieveItemNotification;
        NotificationBroker.doorIsLocked += DoorLockedNotification;
        NotificationBroker.itemRecievedFromDesk += RecieveItemNotification;
    }

    private void OnDestroy()
    {
        NotificationBroker.gameStartBegins -= GameStartNotification;
        NotificationBroker.newChapterBegins -= NewChapterNotification;
        NotificationBroker.itemRecievedFromNPC -= RecieveItemNotification;
        NotificationBroker.doorIsLocked -= DoorLockedNotification;
        NotificationBroker.itemRecievedFromDesk -= RecieveItemNotification;
    }

    void Start()
    {
        message = "";
        //DialogueManager.instance.onDialogueFinished += ActivateNotifcationCallback; //onDialogueFinished
    }

    private void GameStartNotification(MessageSO message)
    {
        this.message = message.message;
        if (!notificationIsOpen)
        {
            activeNotication = ActiveNotification.gameStart;
            BeginNotification(ActiveNotification.gameStart, message);
        }
    }


    private void NewChapterNotification(MessageSO message)
    {
        this.message = message.message;
        if (!notificationIsOpen)
        {
            activeNotication = ActiveNotification.chapterStart;
            BeginNotification(ActiveNotification.chapterStart, message);
        }
    }

    private void DoorLockedNotification(MessageSO message)
    {
        this.message = message.message;
        if (!notificationIsOpen)
        {
            activeNotication = ActiveNotification.doorLocked;
            BeginNotification(ActiveNotification.doorLocked, message);
        }
    }
    private void RecieveItemNotification(MessageSO message)
    {
        this.message = message.message;
        if (!notificationIsOpen)
        {
            activeNotication = ActiveNotification.receiveItem;
            BeginNotification(ActiveNotification.receiveItem, message);
            //activeNotication = ActiveNotification.receiveItem;
            //recieveItemNotifcaton.SetActive(true);
            //GameManager.instance.isTalking = true;
            //GameManager.instance.canMove = false;
            //recieveItemText.GetComponent<Text>().text = message.message;
            ////Time.timeScale = 0;
            //notificationIsOpen = true;
        }
    }

    private void BeginNotification(ActiveNotification version, MessageSO message)
    {
        GameManager.instance.isTalking = true;
        GameManager.instance.canMove = false;
        switch (version)
        {
            case ActiveNotification.gameStart:
                //gameStartNotifcaton.SetActive(true);
                //gameStartText.GetComponent<TMP_Text>().text = message.message;
                break;
            case ActiveNotification.chapterStart:
                chapterStartNotifcaton.SetActive(true);
                chapterStartText.GetComponent<Text>().text = message.message;
                break;
            case ActiveNotification.doorLocked:
                doorLockedNotifcaton.SetActive(true);
                doorLockText.GetComponent<Text>().text = message.message;
                break;
            case ActiveNotification.receiveItem:
                recieveItemNotifcaton.SetActive(true);
                recieveItemText.GetComponent<Text>().text = message.message;
                break;
            default:
                break;
        }
        notificationIsOpen = true;
    }

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
        if (SceneManager.GetActiveScene().name.Equals("Chapter_5_a_Floor_One"))
        {
            countDown.SetActive(true);
        }
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
            levelChangeManger.GetComponent<LevelChangeManager>().LoadNextLevel(); // music fade, screen fade, and load level occurs here
        }
    }


    public void GameStartLetter()
    {
        gameStartNotifcaton.SetActive(true);
        gameStartText.GetComponent<TMP_Text>().text = startMessageInformation.message;
    }

}
