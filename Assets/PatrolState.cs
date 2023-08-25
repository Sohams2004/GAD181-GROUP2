using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    //int idleCounter = 0;

    public enemymovement enemyPatrolPoints;
    public Enemies enemyAnimations;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        enemyPatrolPoints = animator.GetComponent<enemymovement>();
        enemyAnimations = animator.GetComponent<Enemies>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



        //When enemy takes a hit, show hit animation else continue patrol
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
            enemyPatrolPoints.Patroling(enemyPatrolPoints.patrolPoints[enemyPatrolPoints.patrolIndex].position);
            enemyPatrolPoints.patrolToNextPoint();
            //enemyPatrolPoints.patrolRotation();
            animator.Play("Walk With Rifle");
        }




        //Debug.Log("aaf");
        //enemyPatrolPoints.patrolIndex == 0 || enemyPatrolPoints.patrolIndex == 1

        //(enemyPatrolPoints.GetComponent<enemymovement>().patrolIndex == 0 || 
        //enemyPatrolPoints.GetComponent<enemymovement>().patrolIndex == 1)



        //animator.SetBool("isPatrolling", false);
        /*if (animator.GetBool("GetHit") == true && animator.GetBool("dieFront") == false && animator.GetBool("dieBack") == false)
        {
            timer += Time.deltaTime;
            animator.Play("Hit Reaction");
            if (timer > 2.10f)
            {
                animator.SetBool("GetHit", false);
                timer = 0;
            }

           
            
        }
        if (animator.GetBool("dieFront") == true)
        {
            animator.Play("Death From Front Headshot");
        }
        else if (animator.GetBool("dieBack") == true)
        {
            animator.Play("Walking To Dying");
        }
        else
        {
            enemyPatrolPoints.Patroling(enemyPatrolPoints.patrolPoints[enemyPatrolPoints.patrolIndex].position);
            enemyPatrolPoints.patrolToNextPoint();
            //enemyPatrolPoints.patrolRotation();
            animator.Play("Walk With Rifle");
        }
        
         * 
         * if (timer > 3.06f)//enemyPatrolPoints.patrolIndex == 0 || enemyPatrolPoints.patrolIndex == 1)
        {
            Debug.Log("bruh");
            animator.SetBool("isPatrolling", false);
            idleCounter++;
            animator.SetInteger("idleCounter", idleCounter);
            if (idleCounter > 2)
            {
                idleCounter = 0;
            }
        }*/

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
