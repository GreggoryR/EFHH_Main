using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueForSection", menuName = "DialogueForSection")]
public class DialogueForSection : ScriptableObject
{
    [Header("Where the dialogue goes")]
    public string sectionName = "Name";
    [TextArea(3,10)]
    public string[] storyDialoguesForSection;
}
