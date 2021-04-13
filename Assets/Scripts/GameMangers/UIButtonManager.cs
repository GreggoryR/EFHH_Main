///////////////////////////////////////////////////////////////////////////
//FileName: UIButtonManager.cs
//Author : Greggory Reed
//Description : Class for UI Buttons
////////////////////////////////////////////////////////////////////////////
///
using UnityEngine;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    public Button button;
    [SerializeField] UI_Sounds ui_sound;

    public void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SoundBroker.UISoundCall(ui_sound); });
    }
}
