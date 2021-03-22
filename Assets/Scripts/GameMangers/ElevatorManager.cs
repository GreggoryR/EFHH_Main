using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField] GameObject keyPadParentGO;
    ElevatorKeypad keyPadComponent;
    [SerializeField] GameObject keypadKeypad;
    public bool inElavator;
    public bool unlocked = false;
    public bool canUseKeypad = false;
    public bool keyPadHidden = true;
    [SerializeField] BoxCollider2D elevatorBlocker;
    [SerializeField] BoxCollider2D elevatorFloorTransfer;

    
    void Start()
    {
        keyPadComponent = keyPadParentGO.GetComponent<ElevatorKeypad>();
        keyPadComponent.KeyPadDelegate += OpenElevator;
    }

    private void OpenElevator()
    {
        elevatorBlocker.enabled = false;
        unlocked = true;
        elevatorFloorTransfer.enabled = true;
    }


    void Update()
    {
        if (canUseKeypad && keyPadHidden && Input.GetKeyDown(KeyCode.E))
        {
            keypadKeypad.SetActive(true);
            keyPadHidden = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canUseKeypad = true;
        if (unlocked)
        {
            if (collision.CompareTag("PlayerFoundCollider"))
            {
                inElavator = true;
                StartCoroutine(MoveToBasement());
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFoundCollider"))
        {
            canUseKeypad = false;
        }
            
        if (unlocked)
        {
            if (collision.CompareTag("PlayerFoundCollider"))
        {
            inElavator = false;
        }
        }
        
    }

   

    IEnumerator MoveToBasement()
    {

        yield return new WaitForSeconds(2f);
        string sceneName = SceneManager.GetActiveScene().name;
        if (inElavator && sceneName.Contains("Floor"))
        {
            LevelLoaderManager.instance.LoadScene("Chapter_" + GameManager.instance.chapter + "_Basement");
        }
        else
        {
            LevelLoaderManager.instance.LoadScene("Chapter_" + GameManager.instance.chapter + "_Floor_One");
        }
    }
}
