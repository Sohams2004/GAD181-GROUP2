using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    //float timer;

    public enemymovement enemyPatrolPoints;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // timer = 0;
        enemyPatrolPoints = animator.GetComponent<enemymovement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.Play("Check Shoe");
        //animator.SetBool("isPatrolling", true);
        //enemyPatrolPoints.patrolRotation();
        /*timer += Time.deltaTime;
        if( timer > 4 ) 
        {
            animator.SetBool("isPatrolling", true);
        }
          */
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        enemyPatrolPoints.patrolRotation();
    }

     
}
