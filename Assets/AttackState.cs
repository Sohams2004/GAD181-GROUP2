using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    float timer;
    
    public Enemies facingPlayer;
    public enemymovement enemySearchPoints;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        
        enemySearchPoints = animator.GetComponent<enemymovement>();
        facingPlayer = animator.GetComponent<Enemies>();
        //playerAttack.GetComponent<PlayerAttack>();
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
        else if (facingPlayer.facingLeft == true && facingPlayer.tooClose == true)
        {
            enemySearchPoints.Patroling(enemySearchPoints.searchPoints[1].position);
            animator.Play("Run Backwards");
        }
        else if (facingPlayer.facingLeft == false && facingPlayer.tooClose == true)
        {
            enemySearchPoints.Patroling(enemySearchPoints.searchPoints[0].position);
            animator.Play("Run Backwards");
        }
        else if (facingPlayer.semiClose == true)
        {
            animator.Play("Firing Rifle");
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
