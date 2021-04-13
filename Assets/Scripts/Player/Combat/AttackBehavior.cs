///////////////////////////////////////////////////////////////////////////
//FileName: AttackBehavior.cs
//Author : Greggory Reed
//Description : Class for allowing state to change variables inside animator
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPunching", false);
    }
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.instance.canMove = true;
    }
}
