using UnityEngine;

public class TurnWheelGame : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    float wheelRotation;
    [SerializeField] Animator movement;


    void Start()
    {
    }



    public void MoveScreenIn()
    {
        movement.Play("Wheel_Game_Drop_Down");
    }

    public void MoveScreenOut()
    {
        movement.Play("Wheel_Game_Leave_Window");
    }

   
}
