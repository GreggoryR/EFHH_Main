///////////////////////////////////////////////////////////////////////////
//FileName: LevelCanvasManager.cs
//Author : Greggory Reed
//Description : Class for start menu canvas
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class LevelCanvasManager : MonoBehaviour
{
    LevelLoaderManager levelLoader;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoaderManager>();
    }
    
    public void OnStartButtonClicked()
    {
        levelLoader.LoadScene("Chapter_0_Floor_One");
    }

    public void OnMainMenuButtonClicked()
    {
        levelLoader.LoadScene("x_StartMenu");
    }

}
