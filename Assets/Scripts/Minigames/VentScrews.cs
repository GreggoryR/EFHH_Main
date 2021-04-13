///////////////////////////////////////////////////////////////////////////
//FileName: VentScrews.cs
//Author : Greggory Reed
//Description : Class for the vent screws
////////////////////////////////////////////////////////////////////////////
///
using UnityEngine;
using UnityEngine.UI;

public class VentScrews : MonoBehaviour
{
    [SerializeField] VentManager vm;
    int tlScrew;
    int trScrew;
    int blScrew;
    int brScrew;
    int unscrewed = 0;

    public void IncrementScrew(Button button)
    {
        string name = button.name;
        switch (button.name)
        {
            case "TL":
                tlScrew++;
                if (tlScrew == 10)
                {
                    unscrewed++;
                    button.gameObject.SetActive(false);
                    if(unscrewed == 4)
                    {
                        GameManager.instance.beingChased = false;
                        vm.BeginVentCrawl();
                    }
                }
                break;
            case "TR":
                trScrew++;
                if (trScrew == 10)
                {
                    unscrewed++;
                    button.gameObject.SetActive(false);
                    if (unscrewed == 4)
                    {
                        GameManager.instance.beingChased = false;
                        vm.BeginVentCrawl();
                    }
                }
                break;
            case "BL":
                blScrew++;
                if (blScrew == 10)
                {
                    unscrewed++;
                    button.gameObject.SetActive(false);
                    if (unscrewed == 4)
                    {
                        GameManager.instance.beingChased = false;
                        vm.BeginVentCrawl();
                    }
                }
                break;
            case "BR":
                brScrew++;
                if (brScrew == 10)
                {
                    unscrewed++;
                    button.gameObject.SetActive(false);
                    if (unscrewed == 4)
                    {
                        GameManager.instance.beingChased = false;
                        vm.BeginVentCrawl();
                    }
                }
                break;
            default:
            break;
        }
        
    }
}
