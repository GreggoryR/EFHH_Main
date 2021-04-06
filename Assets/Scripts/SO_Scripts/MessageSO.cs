using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MessageSO", fileName ="MessageSO")]
public class MessageSO : ScriptableObject
{
    [TextArea(20,20)]
    public string message = "";

    public Sprite icon = null;
}
