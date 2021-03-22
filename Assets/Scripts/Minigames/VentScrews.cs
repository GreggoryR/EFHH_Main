using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentScrews : MonoBehaviour
{
    int tlScrew;
    int trScrew;
    int blScrew;
    int brScrew;


    void Update()
    {
        
    }

    public void IncrementScrew(Button button)
    {
        string name = button.name;
        switch (button.name)
        {
            case "TL":
            tlScrew++;
            if (tlScrew == 10)
            {
                button.gameObject.SetActive(false);
            }
            break;
            case "TR":
            trScrew++;
            if (trScrew == 10)
            {
                button.gameObject.SetActive(false);
            }
            break;
            case "BL":
            blScrew++;
            if (blScrew == 10)
            {
                button.gameObject.SetActive(false);
            }
            break;
            case "BR":
            brScrew++;
            if (brScrew == 10)
            {
                button.gameObject.SetActive(false);
            }
            break;
            default:
            break;
        }
        
    }
}
