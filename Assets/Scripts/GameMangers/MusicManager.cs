///////////////////////////////////////////////////////////////////////////
//FileName: MusicManager.cs
//Author : Greggory Reed
//Description : Class for game music
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] MusicSO musicCollection;
    AudioSource musicSource;
    public enum Songs { newHome, wheels, o2, basement, forgotten, theship, scary};
    [SerializeField] Songs currentSongNum;

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
        // need to subscribe to level change
        //change song to correct level if need be
        //not sure how this will be implemented when scenes are made
        musicSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name.Equals("x_StartMenu"))
        {
            currentSongNum = Songs.newHome;
            musicSource.clip = musicCollection.intro;
        }
        else if(SceneManager.GetActiveScene().name.Equals("Chapter_0_Floor_One"))
        {
            currentSongNum = Songs.newHome;
            musicSource.clip = musicCollection.chapter0;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_1_Floor_One"))
        {
            currentSongNum = Songs.wheels;
            musicSource.clip = musicCollection.chapter1;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_2_Floor_One"))
        {
            currentSongNum = Songs.o2;
            musicSource.clip = musicCollection.chapter2;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_3_a_Floor_One"))
        {
            currentSongNum = Songs.o2;
            musicSource.clip = musicCollection.chapter2;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_3_b_Basement"))
        {
            currentSongNum = Songs.basement;
            musicSource.clip = musicCollection.chapter3;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_4_a_Floor_One"))
        {
            currentSongNum = Songs.basement;
            musicSource.clip = musicCollection.chapter4;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_4_b_Basement"))
        {
            currentSongNum = Songs.forgotten;
            musicSource.clip = musicCollection.chapter4;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_5_a_Floor_One"))
        {
            currentSongNum = Songs.theship;
            musicSource.clip = musicCollection.chapter5;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_5_b_Basement"))
        {
            currentSongNum = Songs.theship;
            musicSource.clip = musicCollection.chapter5;
        }
        musicSource.Play();
    }

    void Update()
    {
        
    }

    public void ChangeSong(Songs song)
    {
        switch (song)
        {
            case Songs.scary:
                currentSongNum = Songs.scary;
                musicSource.clip = musicCollection.scary;
                musicSource.Play();
                break;
            default:
                break;
        }
        
    }


    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }
}
