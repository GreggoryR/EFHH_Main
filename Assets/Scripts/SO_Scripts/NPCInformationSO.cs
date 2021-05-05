using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Stats", fileName = "Character Stats")]
public class NPCInformationSO : ScriptableObject
{
    public string characterName = "name";
    public DialogueFrameSO story;
    public bool givenItem = false;
    public List<StoryItemThanks> itemThanks;
    public enum NPC { Bishop, Zhao, Barry, Sam, Oliver, Kwan, Jose, Ayako, Afua};
    [SerializeField] public NPC nameNPC;

}
