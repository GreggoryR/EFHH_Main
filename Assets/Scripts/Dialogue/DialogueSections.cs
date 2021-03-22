using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSection", menuName = "DialogueSection")]
public class DialogueSections : ScriptableObject
{
   
    public string chapter = "chapter";
    public List<DialogueForSection> sectionDialogues = new List<DialogueForSection>();

}
