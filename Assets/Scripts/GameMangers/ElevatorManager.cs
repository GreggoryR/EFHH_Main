///////////////////////////////////////////////////////////////////////////
//FileName: ElevatorManager.cs
//Author : Greggory Reed
//Description : Will handle the elevator transitions and keypad 
////////////////////////////////////////////////////////////////////////////

using System.Collections;
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

    [SerializeField] GameObject playerButtonCanvas;
    [SerializeField] Material[] doorRadarColors;
    [SerializeField] GameObject doorRadar;


    void Start()
    {
        //switch (doorLocked)
        //{
        //    case DoorLocked.locked:
        //        doorRadar.GetComponent<SpriteRenderer>().material = doorRadarColors[0];
        //        break;
        //    case DoorLocked.unlocked:
        //        doorRadar.GetComponent<SpriteRenderer>().material = doorRadarColors[1];
        //        break;
        //    default:
        //        break;
        //}
        //doorCollider = GetComponent<BoxCollider2D>();

        keyPadComponent = keyPadParentGO.GetComponent<ElevatorKeypad>();
        keyPadComponent.KeyPadDelegate += OpenElevator;
        
    }
    private void OpenElevator()
    {
        if(GameManager.instance.talkedToJose && SceneManager.GetActiveScene().name.Equals("Chapter_3_b_Basement")){
            if (!GameManager.instance.sawAlien)
            {
                AlienCinematicManager.instance.Begin();
                GameManager.instance.sawAlien = true;
                elevatorBlocker.enabled = false;
                unlocked = true;
                elevatorFloorTransfer.enabled = true;
            }
            else
            {
                elevatorBlocker.enabled = false;
                unlocked = true;
                elevatorFloorTransfer.enabled = true;
            }
        }
        else
        {
            elevatorBlocker.enabled = false;
            unlocked = true;
            elevatorFloorTransfer.enabled = true;
        }
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
        if (collision.CompareTag("PlayerFoundCollider"))
        {
            canUseKeypad = true;
        }

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
            LevelLoaderManager.instance.LoadScene("Chapter_" + GameManager.instance.chapter + "_b_Basement");
        }
        else
        {
            LevelLoaderManager.instance.LoadScene("Chapter_" + GameManager.instance.chapter + "_a_Floor_One");
        }
    }
}
