///////////////////////////////////////////////////////////////////////////
//FileName: LevelLoaderManager.cs
//Author : Greggory Reed
//Description : Class for loading levels
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderManager : MonoBehaviour
{
    public static LevelLoaderManager instance;
    public GameObject loadingBars;
    public Slider loadingBar;
    


    enum SceneType { name, buildIndex, scene};
    SceneType sceneType;

    public string sceneName;
    public int buildIndex;
    Scene sceneScene;

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

    //load scene overloads depending on how the index is given
    public void LoadScene(string name)
    {
        sceneType = SceneType.name;
        sceneName = name;
        StartCoroutine(nameof(LoadLoadingScene));
    }
    public void LoadScene(int buildIndex)
    {
        sceneType = SceneType.buildIndex;
        this.buildIndex = buildIndex;
        StartCoroutine(nameof(LoadLoadingScene));
    }
    public void LoadScene(Scene scene)
    {
        sceneType = SceneType.scene;
        sceneScene = scene;
        StartCoroutine(nameof(LoadLoadingScene));
    }
    //the coroutine that begins everything
    //loads the loading scene while the scene loads in the background
    IEnumerator LoadLoadingScene()
    {
        yield return SceneManager.LoadSceneAsync("x_Loading");
        StartCoroutine(SceneLoad());

    }
    IEnumerator SceneLoad()
    {
        switch (sceneType)
        {
            case SceneType.name:
                AsyncOperation sceneLoadingName = SceneManager.LoadSceneAsync(sceneName);
                sceneLoadingName.allowSceneActivation = false;

                while (!sceneLoadingName.isDone)
                {
                    float progress = Mathf.Clamp01(sceneLoadingName.progress / .9f);
                    loadingBars.SetActive(true);
                    loadingBar.value = progress;
                if (sceneLoadingName.progress >= 0.9f)
                {
                    loadingBar.value = progress;
                    StartCoroutine(WaitForBar(sceneLoadingName));
                }
                yield return null;

                }
            break;
            case SceneType.buildIndex:
                AsyncOperation sceneLoadingIndex = SceneManager.LoadSceneAsync(buildIndex);
                sceneLoadingIndex.allowSceneActivation = false;

                while (!sceneLoadingIndex.isDone)
                {
                    float progress = Mathf.Clamp01(sceneLoadingIndex.progress / .9f);
                    loadingBars.SetActive(true);
                    loadingBar.value = progress;
                    if (sceneLoadingIndex.progress >= 0.9f)
                    {
                        loadingBar.value = progress;
                        StartCoroutine(WaitForBar(sceneLoadingIndex));
                    }
                    yield return null;

                }
            break;
            case SceneType.scene:
                AsyncOperation sceneLoadinScene = SceneManager.LoadSceneAsync(sceneScene.buildIndex);
                while (!sceneLoadinScene.isDone)
                {
                    float progress = Mathf.Clamp01(sceneLoadinScene.progress / .9f);
                    loadingBars.SetActive(true);
                    loadingBar.value = progress;
                if (sceneLoadinScene.progress >= 0.9f)
                {
                    loadingBar.value = progress;
                    StartCoroutine(WaitForBar(sceneLoadinScene));
                }
                yield return null;

                }
            break;
            default:
            break;
        }
    }
    IEnumerator WaitForBar(AsyncOperation sceneLoadingIndex)
    {
        yield return null;
        loadingBars.SetActive(false);
        sceneLoadingIndex.allowSceneActivation = true;
    }
}
