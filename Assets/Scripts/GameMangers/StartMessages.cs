//////////////////////////////////////////////////////////////
//FileName: StartMessages.cs
//Author : Greggory Reed
//Description : Display the correct message
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class StartMessages : MonoBehaviour
{
    [SerializeField] MessageSO startMessageInformation;
    [SerializeField] MessageSO oneMessage;
    [SerializeField] MessageSO twoMessage;
    [SerializeField] MessageSO threeMessage;
    [SerializeField] MessageSO fourMessage;
    [SerializeField] MessageSO fiveMessage;
    [SerializeField] MessageSO sixMessage;

    public void Start()
    {
        switch (GameManager.instance.chapter)
        {
            case 0:
                NotificationBroker.GameStartBeginsCall(startMessageInformation);
                GameManager.instance.GetComponent<CheckpointManager>().CreateCheckpoint();
                break;
            case 1:
                NotificationBroker.NewChapterBeginsCall(oneMessage);
                GameManager.instance.GetComponent<CheckpointManager>().CreateCheckpoint();
                break;
            case 2:
                NotificationBroker.NewChapterBeginsCall(twoMessage);
                GameManager.instance.GetComponent<CheckpointManager>().CreateCheckpoint();
                break;
            case 3:
                if (!StoryManager.instance.chapterThreeStarted)
                {
                    NotificationBroker.NewChapterBeginsCall(threeMessage);
                    GameManager.instance.GetComponent<CheckpointManager>().CreateCheckpoint();
                    StoryManager.instance.chapterThreeStarted = true;

                }
                break;
            case 4:
                if (!StoryManager.instance.chapterFourStarted)
                {
                    NotificationBroker.NewChapterBeginsCall(fourMessage);
                    StoryManager.instance.chapterFourStarted = true;
                    GameManager.instance.GetComponent<CheckpointManager>().CreateCheckpoint();
                }
                break;
            case 5:
                if (!StoryManager.instance.chapterFiveStarted)
                {
                    NotificationBroker.NewChapterBeginsCall(fiveMessage);
                    StoryManager.instance.chapterFiveStarted = true;
                    GameManager.instance.GetComponent<CheckpointManager>().CreateCheckpoint();
                }
                break;
            case 6:
                NotificationBroker.NewChapterBeginsCall(sixMessage);
                break;
            default:
                break;
        }
    }
}
