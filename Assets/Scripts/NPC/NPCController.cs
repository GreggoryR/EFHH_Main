///////////////////////////////////////////////////////////////////////////
//FileName: NPCCOntroller.cs
//Author : Greggory Reed
//Description : Class to manage NPCs (residents)
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    bool canInteract = false;
    [SerializeField] NPCInformationSO npcInfo;
    [SerializeField] GameObject npcIntroduction;
    bool hasMet = false;
    [SerializeField] GameObject playerButtonCanvas;


    public void Start()
    {
        NotificationBroker.turnOffButtons += TurnOffPlayerButton;
    }
    private void OnDestroy()
    {
        NotificationBroker.turnOffButtons -= TurnOffPlayerButton;
    }

    public void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !GameManager.instance.isTalking)
        {
            GameManager.instance.canMove = false;
            playerButtonCanvas.SetActive(false);
            if (!hasMet)
            {
                StartCoroutine(IntroAndConversation());
            }
            else
            {
                HaveConversation();
            }
        }
    }
    IEnumerator IntroAndConversation()
    {
        npcIntroduction.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        npcIntroduction.SetActive(false);
        yield return new WaitForSeconds(.2f);
        HaveConversation();
    }
    private void HaveConversation()
    {
        if (npcInfo.characterName.Equals("Ayako"))
        {
            if (npcInfo.characterName.Equals("Ayako") && npcInfo.givenItem && GameManager.instance.talkedToAfua)
            {
                playerButtonCanvas.SetActive(false);
                GameManager.instance.isTalking = true;
                GameManager.instance.beingChased = false;
                GameManager.instance.StopChasing();
                string[] chapterSectionDialogue = GetChapterSectionDialogue();

                ItemManager.instance.residentItemCollection.TryGetValue("AyakoTelescope", out ItemSO ayakoTeleReturnedItem);
                ItemManager.instance.ResidentGivesItem(ayakoTeleReturnedItem, chapterSectionDialogue, false);
            } 
            else 
            {
                playerButtonCanvas.SetActive(false);
                npcInfo.givenItem = true;
                GameManager.instance.isTalking = true;
                GameManager.instance.beingChased = false;
                GameManager.instance.StopChasing();
                string[] chapterSectionDialogue = GetChapterSectionDialogue();
                ItemManager.instance.residentItemCollection.TryGetValue("AyakoNote", out ItemSO ayakoNote);
                ItemManager.instance.ResidentGivesItem(ayakoNote, chapterSectionDialogue, false);
            }
        }
        else if (npcInfo.characterName.Equals("Jose"))
        {
            playerButtonCanvas.SetActive(false);
            GameManager.instance.isTalking = true;
            GameManager.instance.beingChased = false;
            GameManager.instance.talkedToJose = true;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            ItemManager.instance.residentItemCollection.TryGetValue("JoseRope", out ItemSO joseRopeReturnedItem);
            ItemManager.instance.ResidentGivesItem(joseRopeReturnedItem, chapterSectionDialogue, false);
        }
        else if (npcInfo.characterName.Equals("Kwan"))
        {
            playerButtonCanvas.SetActive(false);
            GameManager.instance.isTalking = true;
            GameManager.instance.beingChased = false;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            ItemManager.instance.residentItemCollection.TryGetValue("KwanRose", out ItemSO kwanRoseReturnedItem);
            ItemManager.instance.ResidentGivesItem(kwanRoseReturnedItem, chapterSectionDialogue, false);
        }
        else
        {
            playerButtonCanvas.SetActive(false);
            GameManager.instance.isTalking = true;
            GameManager.instance.beingChased = false;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            DialogueManager.instance.StartCoversation(chapterSectionDialogue, npcInfo.characterName, false);
        }
    }
    private string[] GetChapterSectionDialogue()
    {
        //check place in story // game manager
        int currentChapter = GameManager.instance.chapter;
        //pull dialogue info from character based on the chapter
        DialogueSectionsSO characterDialogue = npcInfo.story.storyDialogues[currentChapter];
        //pull the character dialogue based on where they are in the chapter
        int characterSection = StoryManager.instance.GetCharacterSection(npcInfo.characterName);
        DialogueForSectionSO dialogueForSection =  characterDialogue.sectionDialogues[characterSection];
        return dialogueForSection.storyDialoguesForSection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFoundCollider") && canInteract == false)
        {
            canInteract = true;
            GameManager.instance.nextToNPC = true;
            GameManager.instance.currentNPC = npcInfo;
            if (!GameManager.instance.isTalking)
            {
                playerButtonCanvas.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFoundCollider"))
        {
            canInteract = false;
            GameManager.instance.isTalking = false;
            GameManager.instance.currentNPC = null;
            playerButtonCanvas.SetActive(false);
        }
    }
    public void TurnOffPlayerButton()
    {
        playerButtonCanvas.SetActive(false);
    }
}
