///////////////////////////////////////////////////////////////////////////
//FileName: ElevatorKeypad.cs
//Author : Greggory Reed
//Description : Class for elevator keypad
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;



public class ElevatorKeypad : MonoBehaviour
{
    public delegate void ElevatorKeypadCodeCorrect();
    public event ElevatorKeypadCodeCorrect KeyPadDelegate;

    public  TextMeshPro keypadInGame;
    string correctKeypadValue = "5189141";
    StringBuilder sb = new StringBuilder(7);

    [SerializeField] ElevatorManager keypadManager;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject greenLight;

    Ray ray;
    RaycastHit2D hit;

    [SerializeField] Animator animator;
     
    private void Start()
    {
        redLight.GetComponent<Light2D>().enabled = true;
    }
    public void Update()
    {
        keypadInGame.text = sb.ToString();
        if (!keypadManager.keyPadHidden && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, -10);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Button"))
                {
                    AddNumberToKeypad(hit.collider);
                }
                else if(hit.collider.CompareTag("Enter"))
                {
                    CheckUnlock();
                }
                else if(hit.collider.CompareTag("Reset"))
                {
                    ResetKeypad();
                }
                else if (hit.collider.CompareTag("Exit"))
                {
                    animator.Play("KeypadExit");
                }
            }
        }
    }

    public void AddNumberToKeypad(Collider2D button)
    {
        StartCoroutine(ChangeSpriteColor(button));
        if(sb.Length <= 7)
        {
            sb.Append(button.gameObject.name.Substring(0,1));
        }
    }

    public IEnumerator ChangeSpriteColor(Collider2D button)
    {
        button.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(.2f);
        button.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }

    public void ResetKeypad()
    {
        sb.Clear();
    }

    public void CheckUnlock()
    {
        //check number
        //if false, red light
        //if true, activate in elevator manager
        //open door
        if (GameManager.instance.chapter >= 3 && sb.ToString().Equals(correctKeypadValue))
        {
            StartCoroutine(UnlockElevator());
        }
        else
        {
            Debug.Log("nope");
            sb.Clear();
        }
        

    }

    public IEnumerator UnlockElevator()
    {
        redLight.GetComponent<Light2D>().enabled = false;
        greenLight.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        KeyPadDelegate.Invoke();
        yield return null;
    }

    public void Deactivate()
    {
        keypadManager.keyPadHidden = true;
        gameObject.SetActive(false);
    }
}
