///////////////////////////////////////////////////////////////////////////
//FileName: PauseMenu.cs
//Author : Greggory Reed
//Description : Class for pause menu
////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    LevelLoaderManager levelLoader;
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] GameObject musicSlider;
    [SerializeField] GameObject effectsSlider;
    private void Awake()
    {
        levelLoader = GameObject.FindObjectOfType<LevelLoaderManager>();
    }

    public void OnMenuButtonCLicked()
    {
        Time.timeScale = 1f;
        levelLoader.LoadScene("x_StartMenu");
    }


    public void OnClickedPauseButton()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void OnRestartButtonCLicked()
    {
        GameManager.instance.GetComponent<CheckpointManager>().LoadCheckpoint();
        Time.timeScale = 1f;
        gameIsPaused = false;
        switch (GameManager.instance.chapter)
        {
            case 0:
                levelLoader.LoadScene("Chapter_0_Floor_One");
                break;
            case 1:
                levelLoader.LoadScene("Chapter_1_Floor_One");
                break;
            case 2:
                levelLoader.LoadScene("Chapter_2_Floor_One");
                break;
            case 3:
                levelLoader.LoadScene("Chapter_3_a_Floor_One");
                break;
            case 4:
                levelLoader.LoadScene("Chapter_4_a_Floor_One");
                break;
            case 5:
                levelLoader.LoadScene("Chapter_5_a_Floor_One");
                break;
            default:
                break;
        }

    }

    //SOUNDS STUFF

    public void SetMusicSlider()
    {
        masterMixer.SetFloat("musicVol", musicSlider.GetComponent<Slider>().value);
    }

    public void SetEffectsSlider()
    {
        masterMixer.SetFloat("effectsVol", effectsSlider.GetComponent<Slider>().value);
    }
}
