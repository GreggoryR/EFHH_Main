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
                RectTransform valueTL = button.GetComponent<RectTransform>();
                valueTL.Rotate(new Vector3(0, 0, -45));
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
                RectTransform valueTR = button.GetComponent<RectTransform>();
                valueTR.Rotate(new Vector3(0, 0, -45));
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
                RectTransform valueBL = button.GetComponent<RectTransform>();
                valueBL.Rotate(new Vector3(0, 0, -45));
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
                RectTransform valueBR = button.GetComponent<RectTransform>();
                valueBR.Rotate(new Vector3(0, 0, -45));
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
