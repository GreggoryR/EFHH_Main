using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] Rigidbody2D rb;
    

    public Animator animator;
    void Start()
    {
       
    }

    void Update()
    {
        GameManager.instance.playerMoveX = Input.GetAxisRaw("Horizontal");
        GameManager.instance.playerMoveY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(GameManager.instance.playerMoveX, GameManager.instance.playerMoveY, 0.0f);

        
        
       
        if (GameManager.instance.canMove == true)
        {
            //need to check if pressing or not to have slow ramp then quick stop?
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

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
