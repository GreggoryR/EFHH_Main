using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{

    [SerializeField] SoundSO soundSO;
    [SerializeField] AudioSource ui_AudioSource;
    [SerializeField] AudioSource playerWalk_AudioSource;
    [SerializeField] AudioSource playerAction_AudioSource;
    [SerializeField] AudioSource playerSound_AudioSource;


    void Start()
    {
        SoundBroker.onUISoundPlayed += UISoundPlayed;
        SoundBroker.onPlayerSoundPlayed += PlayerSoundPlayed;
    }
    private void OnDestroy()
    {
        SoundBroker.onUISoundPlayed -= UISoundPlayed;
        SoundBroker.onPlayerSoundPlayed -= PlayerSoundPlayed;
    }


    public void UISoundPlayed(UI_Sounds ui_Sound)
    {
        switch (ui_Sound)
        {
            case UI_Sounds.main_Start:
                ui_AudioSource.PlayOneShot(soundSO.main_Start);
                break;
            case UI_Sounds.main_Controls:
                ui_AudioSource.PlayOneShot(soundSO.main_Controls);
                break;
            case UI_Sounds.item_Hud:
                ui_AudioSource.PlayOneShot(soundSO.item_Hud);
                break;
            case UI_Sounds.pause_Hud:
                ui_AudioSource.PlayOneShot(soundSO.pause_Hud);
                break;
            case UI_Sounds.item_Select:
                ui_AudioSource.PlayOneShot(soundSO.item_Select);
                break;
            case UI_Sounds.item_Use:
                ui_AudioSource.PlayOneShot(soundSO.item_Use);
                break;
            case UI_Sounds.inventory_Exit:
                ui_AudioSource.PlayOneShot(soundSO.inventory_Exit);
                break;
            case UI_Sounds.resume:
                ui_AudioSource.PlayOneShot(soundSO.resume);
                break;
            case UI_Sounds.main_Return:
                ui_AudioSource.PlayOneShot(soundSO.main_Return);
                break;
            default:
                break;
        }
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
            case Player_Sounds.punch:
                playerAction_AudioSource.PlayOneShot(soundSO.punch);
                break;
            case Player_Sounds.item_Pickup:
                playerSound_AudioSource.PlayOneShot(soundSO.item_Pickup);
                break;
            case Player_Sounds.chase_sigh:
                playerSound_AudioSource.PlayOneShot(soundSO.chase_Sigh);
                break;
            case Player_Sounds.damage_Recieved:
                playerSound_AudioSource.PlayOneShot(soundSO.damage_Recieved);
                break;
            case Player_Sounds.drinks_coffee:
                playerSound_AudioSource.PlayOneShot(soundSO.drinks_Coffee);
                break;
            case Player_Sounds.takes_medicine:
                playerSound_AudioSource.PlayOneShot(soundSO.takes_medicine);
                break;
            default:
                break;
        }
    }

    public void EnemySoundPlayer(AudioSource enemySource, Enemy_Sounds enemy_sound)
    {
        switch (enemy_sound)
        {
            case Enemy_Sounds.step_Orderly:
                enemySource.PlayOneShot(soundSO.step_Orderly);
                break;
            case Enemy_Sounds.attack_Orderly:
                enemySource.PlayOneShot(soundSO.step_Orderly);
                break;
            case Enemy_Sounds.grunt_Orderly:
                enemySource.PlayOneShot(soundSO.step_Orderly);
                break;
            case Enemy_Sounds.nevermind_Orderly:
                enemySource.PlayOneShot(soundSO.step_Orderly);
                break;
            case Enemy_Sounds.step_Alien:
                enemySource.PlayOneShot(soundSO.step_Orderly);
                break;
            case Enemy_Sounds.attack_Alien:
                enemySource.PlayOneShot(soundSO.step_Orderly);
                break;
            default:
                break;
        }
    }

    
}
