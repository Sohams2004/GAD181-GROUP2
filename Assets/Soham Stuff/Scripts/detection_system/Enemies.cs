using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Enemies : MonoBehaviour
{
    // since i am working on the main pc at home for the first time now with git fork and unity, 
    // before i do any drastic changes, i am goign to push and check if everything is ok
    public float rayLength = 1f; //adjust ray length here
    public LayerMask PlayerMask; // assign "Player" layermask in here

    //[SerializeField] float patrolSpeed = 2f;
    [SerializeField] public Transform searchPoint;

    public GameObject enemy;
    //public GameObject player;
    public GameObject player2;
    public GameObject player1;

    //Turret turret;

    public int enemyHealth = 4;

    public bool DamagePlayer, coroutineOn;

    float damagePlayer = 0f;
    float damagePlayerTimeInterval = 1f;

    float susTimer = 0f;
    float susTimeInterval = 1f;

    //public Renderer renderer;
    //[SerializeField] public GameObject body1;
    //[SerializeField] public GameObject body2;
    [SerializeField] public Renderer rendererBody1;
    [SerializeField] public Renderer rendererBody2;

    Player2 player2Visual;
    Player_1_movement player1Visual;

    public GameObject player;

    //public SpriteRenderer spriteRenderer;

    // [SerializeField] private Animator animatorTurret;
    [SerializeField] GameObject shooting;

    public Player_2_Health player_2_Health;
    public Player_1_Health player_1_Health;


    [SerializeField] float suspiciousDistance;
    [SerializeField] float chaseDistance;
    [SerializeField] float shootDistance;

    public Animator animator;
    public PlayerAttack playerAttack;

    public Rigidbody2D enemyRb;

    public bool facingLeft;
    public bool tooClose;
    public bool semiClose;
    public bool notClose;
    private void Start()
    {
        player2 = GameObject.Find("Player 2 Combat");
        player1 = GameObject.Find("Player 1 Stealth");
        //turret = FindAnyObjectByType<Turret>();

        //rendererBody1 = body1.GetComponent<Renderer>();
        //rendererBody2 = body2.GetComponent<Renderer>();

        player2Visual = player2.GetComponent<Player2>();
        player1Visual = player1.GetComponent<Player_1_movement>();
        //.GetComponent<enemymovement>();
        coroutineOn = false;
        animator = GetComponent<Animator>();
        playerAttack = player2.GetComponent<PlayerAttack>();
        enemyRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        //animator.Play("Check Shoe");

        TargetPlayer();
        //DamageMe();

        damagePlayer += Time.deltaTime;
        susTimer += Time.deltaTime;

    }
    //function that creates a ray, if the gameobject with tag player is in the ray the player gameobject will be destryed  
    public void TargetPlayer()
    {
        float angle = Vector3.Dot(transform.right, searchPoint.transform.right);
        if (angle < 0)
        {
            facingLeft = true;
            //Debug.Log("I am facingLeft");
        }
        if (angle > 0)
        {
            facingLeft = false;
            //Debug.Log("I am  not facingLeft");
        }

        float distance1 = Vector2.Distance(transform.position, player1.transform.position);
        float distance2 = Vector2.Distance(transform.position, player2.transform.position);
       

        // Vector2 direction = player2.transform.position - transform.position;



        if (distance1 < shootDistance || distance2 < shootDistance)
        {
            tooClose = true;
        }
        else if (distance1 < chaseDistance || distance2 < chaseDistance)
        {
            semiClose = true;
        }
        else if (distance1 < suspiciousDistance || distance2 < suspiciousDistance)
        {
            notClose = true;
        }
        else 
        {
            tooClose = false;
            semiClose = false;
            notClose = false;
        }

        
        /*/
        *
        
        
        else
        {
         false 
        }
        
        /*/
        RaycastHit2D hitInfo = (Physics2D.Raycast(transform.position, transform.right, rayLength,
             PlayerMask));
        if (hitInfo)
        {
            if (hitInfo.collider.tag == "Player" && distance1 < chaseDistance)
            {

                Debug.Log("player is found");
                player_1_Health.decreaseHealth = true;
                if (!coroutineOn)
                {
                    coroutineOn = true;
                    player1Visual.toggleColor = true;
                    StartCoroutine(player1Visual.ChangePlayerColor());
                }

                if (damagePlayer > damagePlayerTimeInterval)
                {
                    damagePlayer = 0;
                    //animatorTurret.SetBool("Deploy", true);
                    //shooting.SetActive(true);
                    //turret.TurretShooting();

                    Debug.Log("urt");
                    player1.GetComponent<Player_1_movement>().DamageMe2();
                    animator.SetBool("Attack", true);
                    
                }
            }
            else if (hitInfo.collider.tag == "Player" && distance1 < suspiciousDistance)
            {
                animator.SetBool("canSeePlayer", true);
            }
            else if (hitInfo.collider.tag == "Player2" && distance2 < chaseDistance)
            {

                Debug.Log("player2 is found");
                

                if (!coroutineOn)
                {
                    player_2_Health.decreaseHealth = true;
                    coroutineOn = true;
                    player2Visual.toggleColor = true;
                    StartCoroutine(player2Visual.ChangePlayerColor());
                }



                if (damagePlayer > damagePlayerTimeInterval)
                {
                    damagePlayer = 0;
                    Debug.Log("urt2");
                    player2.GetComponent<Player_2_movement>().DamageMe();
                    animator.SetBool("Attack", true);
                    //animatorTurret.SetBool("Deploy", true);
                    //shooting.SetActive(true);
                    //turret.TurretShooting();
                }

                //player_2_Health.decreaseHealth = true;

            }

            else if(hitInfo.collider.tag == "Player2" && distance2 < suspiciousDistance)
            {

                animator.SetBool("canSeePlayer", true);
                
                //animatorTurret.SetBool("Deploy",false);
                //turret.TurretNotShooting();
            }
           
        }

        else
        {
            Debug.LogWarningFormat("Stop color");
            

            //Debug.LogWarningFormat("Stop color");
            //player_2_Health.decreaseHealth = false;

            if (coroutineOn)
            {
                player2Visual.toggleColor = false;
                coroutineOn = false;
                player_2_Health.decreaseHealth = false;
                
            }

            if (coroutineOn)
            {
                player1Visual.toggleColor = false;
                coroutineOn = false;
                player_1_Health.decreaseHealth = false;
            }

            if (susTimer > susTimeInterval)
            {
                susTimer = 0;
                animator.SetBool("canSeePlayer", false);
            }

        }
    }


    public int DamageMe(int damage)
    {
        enemyHealth -= damage;
        animator.SetBool("GetHit", true);
        //StartCoroutine(ChangeEnemyColor());
        if (enemyHealth <= 0)
        {
            //enemy.SetActive(false);
            //Had to add these bools and set them false here as they were never becoming false if player kills enemy while in enemy raycast
            player_2_Health.decreaseHealth = false;
            player_1_Health.decreaseHealth = false;
            player2Visual.toggleColor = false;
            coroutineOn = false;
            if (playerAttack.enemyFacingPlayer == true)
            {
                animator.SetBool("dieFront", true);
            }
            else
            {
                animator.SetBool("dieBack", true);
            }
            //Destroy(enemy);
            Destroy(GetComponent<Enemies>());
            Destroy(GetComponent<Collider2D>());
        }
        return enemyHealth;
    }

    public IEnumerator ChangeEnemyColor()
    {
        rendererBody1.GetComponent<Renderer>().material.color = Color.red;
        rendererBody2.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rendererBody1.GetComponent<Renderer>().material.color = Color.white;
        rendererBody2.GetComponent<Renderer>().material.color = Color.white;

        /*Debug to fix Null Reference after gameobject destroyed
         * if (enemy.GetComponent<Enemies>().enemyHealth <= 0)
        {
            
        }
        else
        {
            rendererBody1.GetComponent<Renderer>().material.color = Color.white;
            rendererBody2.GetComponent<Renderer>().material.color = Color.white;
            print("enemyHealth" + enemy.GetComponent<Enemies>().enemyHealth);
        }*/
    }

    /*private IEnumerator ChangePlayerColor()
    {
        Debug.Log("Red color");
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(5f);
        spriteRenderer.color = Color.white;
    }*/



    //visual line that mimics the raycast.
    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(transform.position, transform.forward, rayLength, PlayerMask);
        Gizmos.DrawRay(transform.position, transform.right * rayLength);
        //Gizmos.DrawRay(new Vector3 (transform.position.x, transform.position.y+2.5f, transform.position.z), transform.forward * rayLength);
        Gizmos.color = new Color(1, 1, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, suspiciousDistance);

        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, chaseDistance);

        Gizmos.color = new Color(0, 0, 1, 0.25f);
        Gizmos.DrawSphere(transform.position, shootDistance);

    }
}







