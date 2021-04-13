///////////////////////////////////////////////////////////////////////////
//FileName: StoryManager.cs
//Author : Greggory Reed
//Description : Class for story moments
////////////////////////////////////////////////////////////////////////////

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
}
