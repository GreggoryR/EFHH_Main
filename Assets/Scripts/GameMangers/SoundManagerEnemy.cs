using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyNumber { one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fiftee, sixteen };
public class SoundManagerEnemy : MonoBehaviour
{
    [SerializeField] SoundSO soundSO;
    [SerializeField] AudioSource enemyWalk_AudioSource;
    [SerializeField] AudioSource enemyAction_AudioSource;
    [SerializeField] AudioSource enemyVocal_AudioSource;
   
    [SerializeField] public EnemyNumber enemyNumber;
    void Start()
    {
        SoundBroker.onEnemySoundPlayed += EnemySoundPlayer;
    }
    private void OnDestroy()
    {
        SoundBroker.onEnemySoundPlayed -= EnemySoundPlayer;
    }

    public void EnemySoundPlayer(Enemy_Sounds enemy_sound, EnemyNumber enemyNumber)
    {
        if(this.enemyNumber == enemyNumber)
        {
            switch (enemy_sound)
            {
                case Enemy_Sounds.step_Orderly:
                    enemyWalk_AudioSource.PlayOneShot(soundSO.step_Orderly);
                    break;
                case Enemy_Sounds.attack_Orderly:
                    enemyAction_AudioSource.PlayOneShot(soundSO.step_Orderly);
                    break;
                case Enemy_Sounds.grunt_Orderly:
                    enemyVocal_AudioSource.PlayOneShot(soundSO.step_Orderly);
                    break;
                case Enemy_Sounds.nevermind_Orderly:
                    enemyVocal_AudioSource.PlayOneShot(soundSO.step_Orderly);
                    break;
                case Enemy_Sounds.step_Alien:
                    enemyWalk_AudioSource.PlayOneShot(soundSO.step_Orderly);
                    break;
                case Enemy_Sounds.attack_Alien:
                    enemyAction_AudioSource.PlayOneShot(soundSO.step_Orderly);
                    break;
                default:
                    break;
            }
        }
        
    }

}
