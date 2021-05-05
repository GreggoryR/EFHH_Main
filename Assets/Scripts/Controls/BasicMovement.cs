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
    bool horizontalBoth = false;
    bool verticalBoth = false;
    [SerializeField] GameObject fist;
    [SerializeField] public bool specialGlove;
    bool canPunch = true;


    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 8)
        {
            specialGlove = true;
            fist.tag = "PlayerAttackGlove";
        }
    }
    void Update()
    {
        if(!horizontalBoth && Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") == 0) 
        {
            horizontalBoth = true;
            if(GameManager.instance.playerMoveX < 0)
            {
                GameManager.instance.playerMoveX = 1;
            }
            else
            {
                GameManager.instance.playerMoveX = -1;
            }
        }
        else if(horizontalBoth && Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") == 0)
        {
            if (GameManager.instance.playerMoveX < 0)
            {
                GameManager.instance.playerMoveX = -1;
            }
            else
            {
                GameManager.instance.playerMoveX = 1;
            }
        }
        else
        {
            GameManager.instance.playerMoveX = Input.GetAxisRaw("Horizontal");
            horizontalBoth = false;
        }

        if (!verticalBoth && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") == 0)
        {
            verticalBoth = true;
            if (GameManager.instance.playerMoveY < 0)
            {
                GameManager.instance.playerMoveY = 1;
            }
            else
            {
                GameManager.instance.playerMoveY = -1;
            }
        }
        else if (verticalBoth && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") == 0)
        {
            if (GameManager.instance.playerMoveY < 0)
            {
                GameManager.instance.playerMoveY = -1;
            }
            else
            {
                GameManager.instance.playerMoveY = 1;
            }
        }
        else
        {
            GameManager.instance.playerMoveY = Input.GetAxisRaw("Vertical");
            verticalBoth = false;
        }


        Vector3 movement = new Vector3(GameManager.instance.playerMoveX, GameManager.instance.playerMoveY, 0.0f);

        if(!animator.GetBool("FaceRight") && !animator.GetBool("FaceLeft") && !animator.GetBool("FaceUp") && !animator.GetBool("FaceDown"))
        {
            animator.SetBool("FaceDown", true);
        }
        
        //Vector3 movement = new Vector3(joystick.Horizontal, joystick.Vertical); //later

        if (GameManager.instance.canMove == true && !GameManager.instance.isPunching)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);
            //chose to use rigidbody for movement as the physics system will handle how
            //to respond to object/wall collisions without appearing jumpy
            rb.velocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed); 
            if(movement.x > 0)
            {
                animator.SetBool("NoInput", false);
                animator.SetBool("FaceRight", true);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
            }
            else if (movement.x < 0)
            {
                animator.SetBool("NoInput", false);
                animator.SetBool("FaceLeft", true);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", false);
            }
            else if (movement.y < 0 && movement.x == 0)
            {
                animator.SetBool("NoInput", false);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", false);
                animator.SetBool("FaceDown", true);
            }
            else if(movement.y > 0 && movement.x == 0)
            {
                animator.SetBool("NoInput", false);
                animator.SetBool("FaceLeft", false);
                animator.SetBool("FaceRight", false);
                animator.SetBool("FaceUp", true);
                animator.SetBool("FaceDown", false);
            }

            if(movement.x == 0 && movement.y == 0)
            {
                animator.SetBool("NoInput", true);
            }

            if (Input.GetKeyDown("space") && canPunch)
            {
                Debug.Log("punching");
                animator.SetBool("IsPunching", true);
                //GameManager.instance.canMove = false;
            }
        }
        else
        {
            if (!GameManager.instance.cutScenePlaying && Input.GetKeyDown("space"))
            {
                animator.SetBool("IsPunching", true);
                GameManager.instance.canMove = false;
            }
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Magnitude",0f);
            rb.velocity = Vector2.zero;
        }

    }
}
