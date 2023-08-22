using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    int idleCounter = 0;

    public enemymovement enemyPatrolPoints;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        enemyPatrolPoints = animator.GetComponent<enemymovement>() ;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer += Time.deltaTime;
        //Debug.Log("aaf");
        //enemyPatrolPoints.  

        //(enemyPatrolPoints.GetComponent<enemymovement>().patrolIndex == 0 || 
        //enemyPatrolPoints.GetComponent<enemymovement>().patrolIndex == 1)

        if (timer > 3.06f)
        {
            Debug.Log("bruh");
            animator.SetBool("isPatrolling", false);
            idleCounter++;
            animator.SetInteger("idleCounter", idleCounter);
            if (idleCounter > 2)
            {
                idleCounter = 0;
            }
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
