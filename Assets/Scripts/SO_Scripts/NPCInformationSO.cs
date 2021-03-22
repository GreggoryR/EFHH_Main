using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Stats", fileName = "Character Stats")]
public class NPCInformationSO : ScriptableObject
{
    public string characterName = "name";
    public DialogueFrame story;
    public bool givenItem = false;
    public List<StoryItemThanks> itemThanks;

}
