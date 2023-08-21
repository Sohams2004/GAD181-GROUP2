using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationState : StateMachineBehaviour
{
    float timer;
    public GameObject enemyRotate;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        enemyRotate = GameObject.Find("Enemy (2)");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            animator.SetBool("isPatrolling", true);

        timer += Time.deltaTime;
        if (timer > 4f)
        {
            enemyRotate.GetComponent<enemymovement>().patrolRotation();
            Debug.Log("I work on exit?");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
