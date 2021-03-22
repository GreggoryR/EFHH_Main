using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<string> sentences;
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private GameObject ui_Dialogue;

    [Header("UI")]
    [SerializeField] public GameObject ui_Inventory;
    [SerializeField] public GameObject ui_Player;

    public delegate void OnDialogueFinished();
    public OnDialogueFinished onDialogueFinished;

    public bool isNextChapter;
    private bool isGiftDialogue;

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
        sentences = new Queue<string>();
    }


    public void StartCoversation(string[] chapterSectionDialogue, string name, bool isNextChapter)
    {
        nameText.text = name;
        this.isNextChapter = isNextChapter;
        sentences.Clear();
        ui_Dialogue.SetActive(true);
        foreach (string sentence in chapterSectionDialogue)
        {
            sentences.Enqueue(sentence);
        }
        string firstSentence = sentences.Dequeue();
        dialogueText.text = firstSentence;
    }


    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && !isGiftDialogue)
        {
            EndDialogue();
            return;
        }
        else if(sentences.Count == 0 && isGiftDialogue)
        {
            EndGiftDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        GameManager.instance.isTalking = false;
        GameManager.instance.canMove = true;
        ui_Dialogue.SetActive(false);
        onDialogueFinished.Invoke();
    }

    public void StartGiftCoversation(string[] message, string name, string itemMessage, bool isNextChapter)
    {
        NotificationManager.instance.message = itemMessage;
        isGiftDialogue = true;
        this.isNextChapter = isNextChapter;
        nameText.text = name;
        sentences.Clear();
        ui_Dialogue.SetActive(true);
        foreach (string sentence in message)
        {
            sentences.Enqueue(sentence);
        }
        string firstSentence = sentences.Dequeue();
        dialogueText.text = firstSentence;
    }
    private void EndGiftDialogue()
    {
        GameManager.instance.isTalking = false;
        GameManager.instance.canMove = true;
        isGiftDialogue = false;
        ui_Dialogue.SetActive(false);
        NotificationBroker.ItemRecievedFromNPCCall();
        //onDialogueFinished.Invoke();
        
    }

}
