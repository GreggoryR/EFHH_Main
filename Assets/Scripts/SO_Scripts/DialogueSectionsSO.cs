using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSection", menuName = "DialogueSection")]
public class DialogueSectionsSO : ScriptableObject
{
   
    public string chapter = "chapter";
    public List<DialogueForSectionSO> sectionDialogues = new List<DialogueForSectionSO>();

}
