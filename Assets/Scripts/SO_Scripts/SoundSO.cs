using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UI_Sounds { main_Start, main_Controls, item_Hud, pause_Hud, item_Select, item_Use, inventory_Exit, resume, main_Return };
public enum Player_Sounds { step_First, step_Basement, step_Outside, punch, item_Pickup, chase_sigh, damage_Recieved, drinks_coffee, takes_medicine };

public enum Enemy_Sounds { step_Orderly, attack_Orderly, grunt_Orderly, nevermind_Orderly,step_Alien, attack_Alien };

[CreateAssetMenu(menuName ="Sound Collection", fileName = "Sound Collection")]
public class SoundSO : ScriptableObject
{
    #region UI Buttons
    [SerializeField] public AudioClip main_Start;
    [SerializeField] public AudioClip main_Controls;
    [SerializeField] public AudioClip item_Hud;
    [SerializeField] public AudioClip pause_Hud;
    [SerializeField] public AudioClip item_Select;
    [SerializeField] public AudioClip item_Use;
    [SerializeField] public AudioClip inventory_Exit;
    [SerializeField] public AudioClip resume;
    [SerializeField] public AudioClip main_Return;
    #endregion
    #region Player Sounds
    [SerializeField] public AudioClip step_First;
    [SerializeField] public AudioClip step_Outside;
    [SerializeField] public AudioClip step_Basement;
    [SerializeField] public AudioClip punch;
    [SerializeField] public AudioClip item_Pickup;
    [SerializeField] public AudioClip chase_Sigh;
    [SerializeField] public AudioClip damage_Recieved;
    [SerializeField] public AudioClip drinks_Coffee;
    [SerializeField] public AudioClip takes_medicine;
    #endregion

    #region Bishop Sounds
    [SerializeField] public AudioClip step_Bishop;
    [SerializeField] public AudioClip tool_Sounds;
    #endregion

    #region Enemy Sounds
    [SerializeField] public AudioClip step_Orderly;
    [SerializeField] public AudioClip attack_Orderly;
    [SerializeField] public AudioClip grunt_Orderly;
    [SerializeField] public AudioClip nevermind_Orderly;

    [SerializeField] public AudioClip step_Alien;
    [SerializeField] public AudioClip attack_Alien;
    #endregion

    #region NPC Character Sounds

    #endregion

    #region Environment Sounds
    [SerializeField] AudioClip door_open;
    [SerializeField] AudioClip elevator_Doors;
    [SerializeField] AudioClip elevator_Button_Number;
    [SerializeField] AudioClip elevator_Button_Submit;
    [SerializeField] AudioClip elevator_Success;
    [SerializeField] AudioClip elevator_Fail;
    #endregion

}
