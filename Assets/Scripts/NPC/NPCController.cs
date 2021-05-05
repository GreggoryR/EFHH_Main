///////////////////////////////////////////////////////////////////////////
//FileName: NPCCOntroller.cs
//Author : Greggory Reed
//Description : Class to manage NPCs (residents)
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    bool canInteract = false;
    [SerializeField] NPCInformationSO npcInfo;
    [SerializeField] GameObject npcIntroduction;
    [SerializeField] GameObject npcColor;
    bool hasMet = false;
    [SerializeField] GameObject playerButtonCanvas;
    [SerializeField] GameObject uiItems;
    [SerializeField] GameObject uiPause;
    [SerializeField] Animator animator;

    public void Start()
    {
        NotificationBroker.turnOffButtons += TurnOffPlayerButton;
        switch (npcInfo.nameNPC)
        {
            case NPCInformationSO.NPC.Bishop:
                if (SceneManager.GetActiveScene().name.Equals("Chapter_0_Floor_One"))
                {
                    animator.Play("bishop_bw");
                }
                else
                {
                    animator.Play("bishop_color_game");
                }
                break;
            case NPCInformationSO.NPC.Zhao:
                if (SceneManager.GetActiveScene().buildIndex < 3)
                {
                    animator.Play("Zhao_idle");
                }
                else
                {
                    animator.Play("zhao_color_game");
                }
                break;
            case NPCInformationSO.NPC.Barry:
                if (SceneManager.GetActiveScene().buildIndex < 3)
                {
                    animator.Play("barry_idle");
                }
                else
                {
                    animator.Play("barry_color_game");
                }
                break;
            case NPCInformationSO.NPC.Sam:
                if (SceneManager.GetActiveScene().buildIndex < 3)
                {
                    animator.Play("sam_idle");
                }
                else
                {
                    animator.Play("sam_color_game");
                }
                break;
            case NPCInformationSO.NPC.Oliver:
                if (SceneManager.GetActiveScene().buildIndex < 4)
                {
                    animator.Play("oliver_idle_bw");
                }
                else
                {
                    animator.Play("oliver_color_game");
                }
                break;
            case NPCInformationSO.NPC.Kwan:
                if (SceneManager.GetActiveScene().buildIndex < 4)
                {
                    animator.Play("kwan_idle_bw");
                }
                else
                {
                    animator.Play("kwan_color_game");
                }
                break;
            case NPCInformationSO.NPC.Jose:
                if (SceneManager.GetActiveScene().buildIndex < 6)
                {
                    animator.Play("bishop_bw");
                }
                else
                {
                    animator.Play("bishop_color_game");
                }
                break;
            case NPCInformationSO.NPC.Ayako:
                if (SceneManager.GetActiveScene().buildIndex < 8)
                {
                    animator.Play("bishop_bw");
                }
                else
                {
                    animator.Play("bishop_color_game");
                }
                break;
            case NPCInformationSO.NPC.Afua:
                if (SceneManager.GetActiveScene().buildIndex < 8)
                {
                    animator.Play("bishop_bw");
                }
                else
                {
                    animator.Play("bishop_color_game");
                }
                break;
            default:
                break;
        }
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
            switch (npcInfo.nameNPC)
            {
                case NPCInformationSO.NPC.Bishop:
                    if (StoryManager.instance.hasMetBishop)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Zhao:
                    if (StoryManager.instance.hasMetZhao)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Barry:
                    if (StoryManager.instance.hasMetBarry)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Sam:
                    if (StoryManager.instance.hasMetSam)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Oliver:
                    if (StoryManager.instance.hasMetOliver)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Kwan:
                    if (StoryManager.instance.hasMetKwan)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Jose:
                    if (StoryManager.instance.hasMetJose)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Ayako:
                    if (StoryManager.instance.hasMetAyako)
                    {
                        hasMet = true;
                    }
                    break;
                case NPCInformationSO.NPC.Afua:
                    if (StoryManager.instance.hasMetAfua)
                    {
                        hasMet = true;
                    }
                    break;
                default:
                    break;
            }
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
        uiItems.SetActive(false);
        uiPause.SetActive(false);
        npcIntroduction.SetActive(true);
        yield return new WaitForSeconds(3.15f);
        npcIntroduction.SetActive(false);
        uiItems.SetActive(true);
        uiPause.SetActive(true);
        switch (npcInfo.nameNPC)
        {
            case NPCInformationSO.NPC.Bishop:
                StoryManager.instance.hasMetBishop = true;
                break;
            case NPCInformationSO.NPC.Zhao:
                StoryManager.instance.hasMetZhao = true;
                break;
            case NPCInformationSO.NPC.Barry:
                StoryManager.instance.hasMetBarry = true;
                break;
            case NPCInformationSO.NPC.Sam:
                StoryManager.instance.hasMetSam = true;
                break;
            case NPCInformationSO.NPC.Oliver:
                StoryManager.instance.hasMetOliver = true;
                break;
            case NPCInformationSO.NPC.Kwan:
                StoryManager.instance.hasMetKwan = true;
                break;
            case NPCInformationSO.NPC.Jose:
                StoryManager.instance.hasMetJose = true;
                break;
            case NPCInformationSO.NPC.Ayako:
                StoryManager.instance.hasMetAyako = true;
                break;
            case NPCInformationSO.NPC.Afua:
                StoryManager.instance.hasMetAfua = true;
                break;
            default:
                break;
        }
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
                GameManager.instance.storyMoment = true;
                GameManager.instance.beingChased = false;
                GameManager.instance.StopChasing();
                string[] chapterSectionDialogue = GetChapterSectionDialogue();
                //Ayakocolor
                ItemManager.instance.residentItemCollection.TryGetValue("AyakoTelescope", out ItemSO ayakoTeleReturnedItem);
                StoryManager.instance.checkIfNeedColorChange(npcInfo.nameNPC, out bool colorValue);
                ItemManager.instance.ResidentGivesItem(ayakoTeleReturnedItem, chapterSectionDialogue, false, colorValue, npcInfo);
            } 
            else 
            {
                playerButtonCanvas.SetActive(false);
                npcInfo.givenItem = true;
                GameManager.instance.isTalking = true;
                GameManager.instance.storyMoment = true;
                GameManager.instance.beingChased = false;
                GameManager.instance.StopChasing();
                string[] chapterSectionDialogue = GetChapterSectionDialogue();
                ItemManager.instance.residentItemCollection.TryGetValue("AyakoNote", out ItemSO ayakoNote);
                StoryManager.instance.checkIfNeedColorChange(npcInfo.nameNPC, out bool colorValue);
                ItemManager.instance.ResidentGivesItem(ayakoNote, chapterSectionDialogue, false, colorValue, npcInfo);
            }
        }
        else if (npcInfo.characterName.Equals("Jose"))
        {
            playerButtonCanvas.SetActive(false);
            GameManager.instance.isTalking = true;
            GameManager.instance.storyMoment = true;
            GameManager.instance.beingChased = false;
            GameManager.instance.talkedToJose = true;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            ItemManager.instance.residentItemCollection.TryGetValue("JoseRope", out ItemSO joseRopeReturnedItem);
            StoryManager.instance.checkIfNeedColorChange(npcInfo.nameNPC, out bool colorValue);
            ItemManager.instance.ResidentGivesItem(joseRopeReturnedItem, chapterSectionDialogue, false, colorValue, npcInfo);
        }
        else if (npcInfo.characterName.Equals("Kwan"))
        {
            playerButtonCanvas.SetActive(false);
            GameManager.instance.isTalking = true;
            GameManager.instance.storyMoment = true;
            GameManager.instance.beingChased = false;
            GameManager.instance.StopChasing();
            string[] chapterSectionDialogue = GetChapterSectionDialogue();
            ItemManager.instance.residentItemCollection.TryGetValue("KwanRose", out ItemSO kwanRoseReturnedItem);
            //StoryManager.instance.checkIfNeedColorChange(npcInfo.nameNPC, out bool colorValue);
            ItemManager.instance.ResidentGivesItem(kwanRoseReturnedItem, chapterSectionDialogue, false, false, npcInfo);
        }
        else
        {
            playerButtonCanvas.SetActive(false);
            GameManager.instance.isTalking = true;
            GameManager.instance.storyMoment = true;
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
            GameManager.instance.nextToNPC = false;
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
