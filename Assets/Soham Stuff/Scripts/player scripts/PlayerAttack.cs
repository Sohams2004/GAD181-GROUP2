using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f;
    public int damage = 1;
    public float repulseForce;

    //For combo attack
    bool attack;
    int attackCounter;
    Animator animator;

    public GameObject attackPoint;

    public LayerMask enemyLayer;

    //public Vector2 repulseEnemy;

    //public Rigidbody2D enemyrb;
    public bool wallBro;
    //public Player_2_movement playerFacingDirection;
    public bool enemyFacingPlayer;
    //


    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attackSoundEffect;

    //public bool enemyFacingEnemy;

    Enemies enemy;
    //public enemymovement enemyPatrolPoints;
    private void Start()
    {
        animator = GetComponent<Animator>();
        //bool playerFacingDirection = GetComponent<Player_2_movement>(); 
    }

    public void Attack()
    {
        Collider2D[] attackEnemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayer);


        attack = true;
        foreach (Collider2D enemy in attackEnemy)
        {
            wallBro = true;
            if (enemy.GetComponent<Enemies>())
            {
                float angle = Vector3.Dot(transform.right, enemy.transform.right);
                //Debug.Log(angle + "angle");
                if (angle < 0)
                {
                    damage = 1;
                    enemyFacingPlayer = true;
                    //Debug.Log("I am facing");
                    /*if(enemy.GetComponent<Enemies>().enemyHealth <= 0)
                    {
                        animator.SetBool("diefront", true);
                    }*/

                }
                if (angle > 0)
                {
                    damage = 6;
                    enemyFacingPlayer = false;
                    //animator.SetBool("dieback", true);
                    //Debug.Log("I am not facing");
                }

                enemy.GetComponent<Enemies>().DamageMe(damage);
                StartCoroutine(enemy.GetComponent<Enemies>().ChangeEnemyColor());
                //wallBro = true;
                Debug.Log("Ad");
                //wallBro = false;
                /*Debug to check Nullreference after object destroyed if you spam attack 
                 * 
                if (enemy.GetComponent<Enemies>().enemyHealth <= 0)
                {

                }
                else
                {
                    StartCoroutine(enemy.GetComponent<Enemies>().ChangeEnemyColor());
                    print("enemyHealth" + enemy.GetComponent<Enemies>().enemyHealth);
                }*/

            }
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(attackPoint.transform.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {   //if crouching then crouch attack



            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch & Crouch walk") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("CrouchAttack"))
            {
                animator.SetTrigger("Attack");
                Attack();
                audioSource.PlayOneShot(attackSoundEffect);

            }
            //if not then normal attack
            else
            {

                if (!attack)
                {
                    Attack();
                    animator.SetTrigger("Attack");
                    attackCounter++;
                    animator.SetInteger("AttackCounter", attackCounter);
                    audioSource.PlayOneShot(attackSoundEffect);

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
