///////////////////////////////////////////////////////////////////////////
//FileName: SoundBroker.cs
//Author : Greggory Reed
//Description : Publisher/Subscriber Broker for playing all sounds
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class SoundBroker : MonoBehaviour
{
    public delegate void OnUISoundPlayed(UI_Sounds ui_Sound); //enums match variable names in scriptable objects for audio
    public static event OnUISoundPlayed onUISoundPlayed; //subscribers subscribe to the event
    public static void UISoundCall(UI_Sounds ui_Sound) //this method is called by the publisher
    {
        if (onUISoundPlayed != null)
        {
            onUISoundPlayed(ui_Sound);
        }
    }

    public delegate void OnPlayerSoundPlayed(Player_Sounds player_Sound);
    public static event OnPlayerSoundPlayed onPlayerSoundPlayed;
    public static void PlayerSoundCall(Player_Sounds player_Sound) //this method is called by the publisher
    {
        if (onPlayerSoundPlayed != null)
        {
            onPlayerSoundPlayed(player_Sound);
        }
    }

    //more to come

}
