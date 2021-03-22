using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioSync : MonoBehaviour
{ 
    //hello github
    //hello desktop
    public enum CurrentMovement { Right, Left, Up, Down};
    public void PlayerHorizontalStepTaken()
    {

        switch (GameManager.instance.location)
        {
            case GameManager.Location.first:
                SoundBroker.PlayerSoundCall(Player_Sounds.step_First);
                break;
            case GameManager.Location.basement:
                break;
            case GameManager.Location.outside:
                break;
            default:
                break;
        }
        
    }
    public void PlayerVerticalStepTaken()
    {
        if(GameManager.instance.playerMoveX == 0)
        {
            switch (GameManager.instance.location)
            {
                case GameManager.Location.first:
                    SoundBroker.PlayerSoundCall(Player_Sounds.step_First);
                    break;
                case GameManager.Location.basement:
                    break;
                case GameManager.Location.outside:
                    break;
                default:
                    break;
            }
        }
    }
}
