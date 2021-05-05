using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CheerSO", fileName = "CheerSO")]
public class CheerSO : ScriptableObject
{
    [TextArea(5, 5)]
    public string[] messages;
}
