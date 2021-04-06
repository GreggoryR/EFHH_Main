///////////////////////////////////////////////////////////////////////////
//FileName: BasicMovement.cs
//Author : Greggory Reed
//Description : Class for making the player move and animating walking
////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    //[SerializeField] VariableJoystick joystick; // later
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] Rigidbody2D rb;
    public Animator animator;


    private void Start()
    {
        //if (!SceneManager.GetActiveScene().buildIndex.Equals(1))
        //{
        //    GameManager.instance.canMove = true;
        //}
    }
    void Update()
    {
        GameManager.instance.playerMoveX = Input.GetAxisRaw("Horizontal");
        GameManager.instance.playerMoveY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(GameManager.instance.playerMoveX, GameManager.instance.playerMoveY, 0.0f);


        //Vector3 movement = new Vector3(joystick.Horizontal, joystick.Vertical);

        if (GameManager.instance.canMove == true)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);
            //chose to use rigidbody for movement as the physics system will handle how
            //to respond to object/wall collisions without appearing jumpy
            rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed); 

            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("isPunching", true);
                GameManager.instance.canMove = false;
            }
        }
        else
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Magnitude",0f);
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.instance.chapter++;
        }
        
    }
}
