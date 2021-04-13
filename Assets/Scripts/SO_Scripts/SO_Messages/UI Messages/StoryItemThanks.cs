using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="itemThanks", fileName ="itemThanks")]
public class StoryItemThanks : ScriptableObject
{
    public string storyItemName = "";
    [TextArea(3,10)]
    public string[] thanks = { };
}
