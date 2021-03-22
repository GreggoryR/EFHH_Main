using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    LevelLoaderManager levelLoader;

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
}
