using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCController : MonoBehaviour
{
    bool canInteract = false;
    [SerializeField] NPCInformationSO npcInfo;
    [SerializeField] GameObject npcIntroduction;
    bool hasMet = false;
    

    

    public void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !GameManager.instance.isTalking)
        {
            if (GameManager.instance.beingChased)
            {
                GameManager.instance.beingChased = false;
                GameManager.instance.StopChasing();
            }
            GameManager.instance.canMove = false;
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
                GameManager.instance.isTalking = true;
                GameManager.instance.StopChasing();
                string[] chapterSectionDialogue = GetChapterSectionDialogue();
                ItemManager.instance.residentItemCollection.TryGetValue("ayakoTelescope", out ItemSO ayakoTeleReturnedItem);
                ItemManager.instance.ResidentGivesItem(ayakoTeleReturnedItem, chapterSectionDialogue, false);
            } 
            else 
            {
                npcInfo.givenItem = true;
                GameManager.instance.isTalking = true;
                GameManager.instance.StopChasing();
                string[] chapterSectionDialogue = GetChapterSectionDialogue();
                ItemManager.instance.residentItemCollection.TryGetValue("ayakoNote", out ItemSO ayakoNote);
                ItemManager.instance.ResidentGivesItem(ayakoNote, chapterSectionDialogue, false);
            }
        }
        else if (npcInfo.characterName.Equals("Jose"))
        {
            GameManager.instance.isTalking = true;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            ItemManager.instance.residentItemCollection.TryGetValue("joseRope", out ItemSO joseRopeReturnedItem);
            ItemManager.instance.ResidentGivesItem(joseRopeReturnedItem, chapterSectionDialogue, false);
        }
        else if (npcInfo.characterName.Equals("Kwan"))
        {
            GameManager.instance.isTalking = true;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            ItemManager.instance.residentItemCollection.TryGetValue("kwanRose", out ItemSO kwanRoseReturnedItem);
            ItemManager.instance.ResidentGivesItem(kwanRoseReturnedItem, chapterSectionDialogue, false);
        }
        else
        {
            GameManager.instance.isTalking = true;
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFoundCollider"))
        {
            canInteract = false;
            GameManager.instance.isTalking = false;
            GameManager.instance.currentNPC = null;
        }
        
    }
}
