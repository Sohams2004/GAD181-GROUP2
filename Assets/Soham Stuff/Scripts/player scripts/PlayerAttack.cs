using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f;
    public float damage = 5f;
    public float repulseForce;

    //For combo attack
    bool attack;
    int attackCounter;
    Animator animator;

    //public GameObject attack;

    public LayerMask enemyLayer;

    public Vector2 repulseEnemy;

    public Rigidbody2D enemyrb;
    public bool wallBro;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        Collider2D[] attackEnemy = Physics2D.OverlapCircleAll(/*/attack./*/transform.position, attackRange, enemyLayer);

        animator.SetTrigger("Attack");
        attack = true;
        foreach (Collider2D enemy in attackEnemy)
        {
            wallBro = true;
            if (enemy.GetComponent<Enemies>())
            {
                enemy.GetComponent<Enemies>().enemyHealth -= damage;
                //wallBro = true;
                Debug.Log("Ad");
                //wallBro = false;
                
            }
        }
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch & Crouch walk") || 
                animator.GetCurrentAnimatorStateInfo(0).IsName("CrouchAttack")) 
            {
                
                Attack();
                
            }

            else
            {

                if (!attack)
                {
                    Attack();
                    attackCounter++;
                    animator.SetInteger("AttackCounter", attackCounter);

                    if (attackCounter >= 2)
                    {
                        attackCounter = 0;
                    }
                }    
                
                attack = false;
            }
           
        }
        
    }
}
