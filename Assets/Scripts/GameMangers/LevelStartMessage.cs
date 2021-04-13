///////////////////////////////////////////////////////////////////////////
//FileName: LevelStartMessages.cs
//Author : Greggory Reed
//Description : Class for start messages
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelStartMessage : MonoBehaviour
{
    [SerializeField] GameObject brochure;
    [SerializeField] GameObject chapterMessage;

    [SerializeField] Image[] chapters;
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Chapter_0_Floor_One"))
        {
            DisplayBrochure();
        }
        //next chapter
    }

    private void DisplayBrochure()
    {
        brochure.SetActive(true);
    }

    public void TurnOffBrochure()
    {
        brochure.SetActive(false);
    }

}
