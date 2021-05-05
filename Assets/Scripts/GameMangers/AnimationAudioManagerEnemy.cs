///////////////////////////////////////////////////////////////////////////
//FileName: AnimationAudioManager.cs
//Author : Greggory Reed
//Description : Helps sync animations with correct audio sounds
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class AnimationAudioManagerEnemy : MonoBehaviour
{
    public enum CurrentMovement { Right, Left, Up, Down};
    [SerializeField] public EnemyNumber number;
    public void EnemyHorizontalStepTaken()
    {
        switch (GameManager.instance.location)
        {
            case GameManager.Location.first:
                SoundBroker.EnemySoundCall(Enemy_Sounds.step_Orderly, number);
                break;
            case GameManager.Location.basement:
                break;
            case GameManager.Location.outside:
                break;
            default:
                break;
        }
    }
    public void EnemyVerticalStepTaken()
    {
        if (GameManager.instance.playerMoveX == 0)
        {
            switch (GameManager.instance.location)
            {
                case GameManager.Location.first:
                    SoundBroker.EnemySoundCall(Enemy_Sounds.step_Orderly, number);
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
