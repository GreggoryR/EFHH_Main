using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] MusicSO musicCollection;
    AudioSource musicSource;
    enum Songs { title, intro, gamePlay, basement, countdown, laser, credits};
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
        if (SceneManager.GetActiveScene().buildIndex == (int)Songs.title)
        {
            currentSongNum = Songs.title;
            musicSource.clip = musicCollection.intro;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            currentSongNum = Songs.title;
            musicSource.clip = musicCollection.chapter0;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            currentSongNum = Songs.title;
            musicSource.clip = musicCollection.chapter1;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Chapter_3_Basement"))
        {
            currentSongNum = Songs.title;
            musicSource.clip = musicCollection.intro;
        }
        musicSource.Play();
    }

    void Update()
    {
        
    }

    public void ChangeSong()
    {

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
