using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    float timer;

    public enemymovement enemyPatrolPoints;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        enemyPatrolPoints = animator.GetComponent<enemymovement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (animator.GetBool("GetHit") == true && animator.GetBool("dieFront") == false && animator.GetBool("dieBack") == false)
        {
            timer += Time.deltaTime;
            animator.Play("Hit Reaction");
            if (timer > 2.10f)
            {
                animator.SetBool("GetHit", false);
                timer = 0;
            }

        }
        else if (animator.GetBool("dieFront") == true)
        {
            animator.Play("Death From Front Headshot");
        }
        else if (animator.GetBool("dieBack") == true)
        {
            animator.Play("Walking To Dying");
        }
        else
        {

            animator.Play("Check Shoe");
        }

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
