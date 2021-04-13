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
                break;
            case 1:
                NotificationBroker.NewChapterBeginsCall(oneMessage);
                break;
            case 2:
                NotificationBroker.NewChapterBeginsCall(twoMessage);
                break;
            case 3:
                if (!StoryManager.instance.chapterThreeStarted)
                {
                    NotificationBroker.NewChapterBeginsCall(threeMessage);
                    StoryManager.instance.chapterThreeStarted = true;
                }
                break;
            case 4:
                if (!StoryManager.instance.chapterFourStarted)
                {
                    NotificationBroker.NewChapterBeginsCall(fourMessage);
                    StoryManager.instance.chapterFourStarted = true;
                }
                break;
            case 5:
                if (!StoryManager.instance.chapterFiveStarted)
                {
                    NotificationBroker.NewChapterBeginsCall(fiveMessage);
                    StoryManager.instance.chapterFiveStarted = true;
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
