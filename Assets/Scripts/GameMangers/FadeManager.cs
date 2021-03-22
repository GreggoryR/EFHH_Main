using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [SerializeField] Animator fadeAni;
    [SerializeField] GameObject fadeCanvas;
    void Start()
    {
        GetFound();
        StartCoroutine(FadeInAndLoad());
    }

    private void GetFound()
    {
        LevelLoaderManager parent = FindObjectOfType<LevelLoaderManager>().gameObject.GetComponent<LevelLoaderManager>();

    }

    void Update()
    {
        
    }
    IEnumerator FadeInAndLoad()
    {
        fadeAni.Play("FadeIn");
        yield return new WaitForSeconds(4f);
        fadeCanvas.SetActive(false);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    IEnumerator FadeOutAndLoad()
    {
        fadeCanvas.SetActive(true);
        fadeAni.Play("FadeOut");
        yield return null;
    }


}
