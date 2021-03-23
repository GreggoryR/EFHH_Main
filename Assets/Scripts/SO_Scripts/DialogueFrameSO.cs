using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueFrame", menuName = "DialogueFrame")]
public class DialogueFrameSO : ScriptableObject
{
    public string characterName = "Name";
    public List<DialogueSectionsSO> storyDialogues = new List<DialogueSectionsSO>();
}
