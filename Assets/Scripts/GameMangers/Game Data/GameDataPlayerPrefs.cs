using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataPlayerPrefs : MonoBehaviour
{
    //chapter;
    //health;
    //items;
    //chracterStorySections;
    int totalChapters = 6;
    enum Characters { Bishop, Barry, Zhao, Sam, Oliver, Kwan, Jose, Ayako, Afua }
    
    public void SaveGame()
    {
        //regular PlayerPrefs for simple values
        PlayerPrefs.SetInt("chapter", GameManager.instance.chapter);
        Debug.Log(PlayerPrefs.HasKey("chapter"));
        PlayerPrefs.SetInt("chapter", GameManager.instance.chapter);
        PlayerPrefs.SetInt("health", GameManager.instance.playerHealth);
        //advanced PlayerPrefsX for complicated stuff

        //Bishop, Barry, Zhao, Sam, Oliver, Kwan, Jose, Ayako, Afua
        PlayerPrefsX.SetIntArray("bishopStory",GetCharacterStoryArray((int)Characters.Bishop));
        PlayerPrefsX.SetIntArray("barryStory", GetCharacterStoryArray((int)Characters.Barry));
        PlayerPrefsX.SetIntArray("zhaoStory", GetCharacterStoryArray((int)Characters.Zhao));
        PlayerPrefsX.SetIntArray("samStory", GetCharacterStoryArray((int)Characters.Sam));
        PlayerPrefsX.SetIntArray("oliverStory", GetCharacterStoryArray((int)Characters.Oliver));
        PlayerPrefsX.SetIntArray("kwanStory", GetCharacterStoryArray((int)Characters.Kwan));
        PlayerPrefsX.SetIntArray("joseStory", GetCharacterStoryArray((int)Characters.Jose));
        PlayerPrefsX.SetIntArray("ayakoStory", GetCharacterStoryArray((int)Characters.Ayako));
        PlayerPrefsX.SetIntArray("afuaStory", GetCharacterStoryArray((int)Characters.Afua));
        PlayerPrefs.Save();
    }

    private int[] GetCharacterStoryArray(int character)
    {
        int[] characterStoryPoints = new int[totalChapters];

        for(int i = 0; i < totalChapters; i++)
        {
            characterStoryPoints[i] = GameManager.instance.chapterWithSections[i][character];
        }
        return characterStoryPoints;
    }

    public void LoadGame()
    {
        Debug.Log(PlayerPrefs.HasKey("chapter"));
        GameManager.instance.chapter = PlayerPrefs.GetInt("chapter");
        Debug.Log(PlayerPrefs.GetInt("chapter"));
        GameManager.instance.chapter = PlayerPrefs.GetInt("chapter");

        GameManager.instance.playerHealth = PlayerPrefs.GetInt("health");
        LoadCharacterStoryPoints();
        //load item checks
        //load story moment checks
        LevelLoaderManager.instance.LoadScene(GameManager.instance.chapter + 1);//quick fix, will need to change later
        
    }

    private void LoadCharacterStoryPoints()
    {
        //bishop
        int[] bishop = PlayerPrefsX.GetIntArray("bishopStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = bishop[i];
        }
        //barry
        int[] barry = PlayerPrefsX.GetIntArray("barryStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = barry[i];
        }
        //zhao
        int[] zhao = PlayerPrefsX.GetIntArray("zhaoStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = zhao[i];
        }
        //sam
        int[] sam = PlayerPrefsX.GetIntArray("samStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = sam[i];
        }
        //oliver
        int[] oliver = PlayerPrefsX.GetIntArray("oliverStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = oliver[i];
        }
        //kwan
        int[] kwan = PlayerPrefsX.GetIntArray("kwanStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = kwan[i];
        }
        //jose
        int[] jose = PlayerPrefsX.GetIntArray("joseStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = jose[i];
        }
        //ayako
        int[] ayako = PlayerPrefsX.GetIntArray("ayakoStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = ayako[i];
        }
        //afua
        int[] afua = PlayerPrefsX.GetIntArray("afuaStory");
        for (int i = 0; i < totalChapters; i++)
        {
            GameManager.instance.chapterWithSections[i][(int)Characters.Bishop] = afua[i];
        }
    }
}
