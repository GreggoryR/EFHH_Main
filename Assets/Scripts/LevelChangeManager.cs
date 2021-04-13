using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeManager : MonoBehaviour
{
    [SerializeField] public GameObject fade;
    [SerializeField] public AudioSource audioSource;

    private void Start()
    {
        DialogueManager.instance.onDialogueFinished += LoadNextLevel;
    }

    public void Resubscribe()
    {
        DialogueManager.instance.onDialogueFinished += LoadNextLevel;
    }

    private void OnDestroy()
    {
        DialogueManager.instance.onDialogueFinished -= LoadNextLevel;
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().name.Equals("x_StartMenu") || StoryManager.instance.canLoadNextLevel)
        {
            StoryManager.instance.canLoadNextLevel = false;
            GameManager.instance.chapter++;
            //look for current music and fade it out
            //will need to prevent radar cam from being first found--uses GDFS
            //AudioSource audio = FindObjectOfType<Camera>().GetComponent<AudioSource>(); //will change each level
            StartCoroutine(FadeOutAudio(audioSource, .5f));
            //fade out to black
            fade.SetActive(true);
            fade.GetComponent<FadeManager>().FadeOut();
            //start loading
            StartCoroutine(PauseBeforeLoad());
        }
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0.02)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;

    }
    IEnumerator PauseBeforeLoad()
    {
        yield return new WaitForSeconds(1f);
        var thisScene = SceneManager.GetActiveScene();
        var nextScene = thisScene.buildIndex + 1;
        switch (GameManager.instance.chapter)
        {
            case 0:
                LevelLoaderManager.instance.LoadScene(nextScene);
                break;
            case 1:
                LevelLoaderManager.instance.LoadScene(nextScene);
                break;
            case 2:
                LevelLoaderManager.instance.LoadScene(nextScene);
                break;
            case 3:
                LevelLoaderManager.instance.LoadScene(nextScene);
                break;
            case 4:
                LevelLoaderManager.instance.LoadScene("Chapter_4_a_Floor_One");
                break;
            case 5:
                LevelLoaderManager.instance.LoadScene("Chapter_5_a_Floor_One");
                break;
            case 6:
            default:
                break;

        }
    }
}
