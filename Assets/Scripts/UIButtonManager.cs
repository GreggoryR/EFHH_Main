using System.Collections;
using System.Collections.Generic;
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
