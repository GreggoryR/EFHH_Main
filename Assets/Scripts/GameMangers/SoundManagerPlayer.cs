///////////////////////////////////////////////////////////////////////////
//FileName: SoundManager.cs
//Author : Greggory Reed
//Description : Class for sounds in game
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour
{

    [SerializeField] SoundSO soundSO;
    [SerializeField] SoundManagerSnapshots snapshotManager;
    [SerializeField] AudioSource playerWalk_AudioSource;
    [SerializeField] AudioSource playerAction_AudioSource;
    [SerializeField] AudioSource playerVocal_AudioSource;
    


    void Start()
    {
        SoundBroker.onPlayerSoundPlayed += PlayerSoundPlayed;
        
    }
    private void OnDestroy()
    {
        SoundBroker.onPlayerSoundPlayed -= PlayerSoundPlayed;
    }


    public void PlayerSoundPlayed(Player_Sounds player_Sound)
    {
        switch (player_Sound)
        {
            case Player_Sounds.step_First:
                playerWalk_AudioSource.PlayOneShot(soundSO.step_First);
                break;
            case Player_Sounds.step_Outside:
                playerWalk_AudioSource.PlayOneShot(soundSO.step_Outside);
                break;
            case Player_Sounds.step_Basement:
                playerWalk_AudioSource.PlayOneShot(soundSO.step_Basement);
                break;
            case Player_Sounds.throwPunch:
                playerAction_AudioSource.PlayOneShot(soundSO.throwPunch);
                break;
            case Player_Sounds.punchHit:
                playerAction_AudioSource.PlayOneShot(soundSO.punchHit);
                break;
            case Player_Sounds.superHit:
                playerAction_AudioSource.PlayOneShot(soundSO.superHit);
                break;
            case Player_Sounds.item_Pickup:
                playerAction_AudioSource.PlayOneShot(soundSO.item_Pickup);
                break;
            case Player_Sounds.chase_sigh:
                playerVocal_AudioSource.PlayOneShot(soundSO.chase_Sigh);
                break;
            case Player_Sounds.damage_Recieved:
                playerVocal_AudioSource.PlayOneShot(soundSO.damage_Recieved);
                break;
            case Player_Sounds.drinks_coffee:
                playerVocal_AudioSource.PlayOneShot(soundSO.drinks_Coffee);
                break;
            case Player_Sounds.takes_medicine:
                playerVocal_AudioSource.PlayOneShot(soundSO.takes_medicine);
                break;
            case Player_Sounds.getColor:
                playerAction_AudioSource.PlayOneShot(soundSO.getColor);
                break;
            default:
                break;
        }
    }

    

    
}
