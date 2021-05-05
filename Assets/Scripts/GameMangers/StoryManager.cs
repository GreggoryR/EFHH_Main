///////////////////////////////////////////////////////////////////////////
//FileName: StoryManager.cs
//Author : Greggory Reed
//Description : Class for story moments
////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    public bool canLoadNextLevel;
    enum Characters { Bishop, Barry, Zhao, Sam, Oliver, Kwan, Jose, Ayako, Afua }
    public bool chapterThreeStarted = false;
    public bool chapterFourStarted = false;
    public bool chapterFiveStarted = false;

    public bool hasMetBishop = false;
    public bool hasMetZhao = false;
    public bool hasMetBarry = false;
    public bool hasMetSam = false;
    public bool hasMetOliver = false;
    public bool hasMetKwan = false;
    public bool hasMetJose = false;
    public bool hasMetAyako = false;
    public bool hasMetAfua = false;

    public bool gotColorBishop = false;
    public bool gotColorZhao = false;
    public bool gotColorBarry = false;
    public bool gotColorSam = false;
    public bool gotColorOliver = false;
    public bool gotColorKwan = false;
    public bool gotColorJose = false;
    public bool gotColorAyako = false;
    public bool gotColorAfua = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameManager.instance.chapterWithSections = new List<List<int>> {new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                        new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 }}; 

    }

    public int GetCharacterSection(string characterName)
    {
        int chapter = GameManager.instance.chapter;
        switch (characterName)
        {
            case "Bishop":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Bishop];
            case "Barry":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Barry];
            case "Zhao":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Zhao];
            case "Sam":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Sam];
            case "Oliver":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Oliver];
            case "Kwan":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Kwan];
            case "Jose":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Jose];
            case "Ayako":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Ayako];
            case "Afua":
            return GameManager.instance.chapterWithSections[chapter][(int)Characters.Afua];
            default:
            break;
        }
        return -1;
    }

    public void checkIfNeedColorChange(NPCInformationSO.NPC nameNPC, out bool colorValue)
    {
        switch (nameNPC)
        {
            case NPCInformationSO.NPC.Bishop:
                if (gotColorBishop)
                {
                    colorValue = true;
                } else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Zhao:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Barry:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Sam:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Oliver:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Kwan:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Jose:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Ayako:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            case NPCInformationSO.NPC.Afua:
                if (gotColorBishop)
                {
                    colorValue = true;
                }
                else
                {
                    colorValue = false;
                }
                break;
            default:
                colorValue = false;
                break;
        }
    }

    public void ColorChanged(NPCInformationSO.NPC nameNPC)
    {
        switch (nameNPC)
        {
            case NPCInformationSO.NPC.Bishop:
                gotColorBishop = true;
                break;
            case NPCInformationSO.NPC.Zhao:
                gotColorZhao = true;
                break;
            case NPCInformationSO.NPC.Barry:
                gotColorBarry = true;
                break;
            case NPCInformationSO.NPC.Sam:
                gotColorSam = true;
                break;
            case NPCInformationSO.NPC.Oliver:
                gotColorOliver = true;
                break;
            case NPCInformationSO.NPC.Kwan:
                gotColorKwan = true;
                break;
            case NPCInformationSO.NPC.Jose:
                gotColorJose = true;
                break;
            case NPCInformationSO.NPC.Ayako:
                gotColorAyako = true;
                break;
            case NPCInformationSO.NPC.Afua:
                gotColorAfua = true;
                break;
            default:
                break;
        }
    }
}
