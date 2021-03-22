using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueFrame", menuName = "DialogueFrame")]
public class DialogueFrame : ScriptableObject
{
    public string characterName = "Name";
    public List<DialogueSections> storyDialogues = new List<DialogueSections>();
}
