using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Enemies : MonoBehaviour
{
    public float rayLength = 1f; //adjust ray length here
    public LayerMask PlayerMask; // assign "Player" layermask in here

    public GameObject enemy;
    //public GameObject player;
    public GameObject player2;
    public GameObject player1;

    Turret turret;

    public float enemyHealth = 2f;

    public bool DamagePlayer, coroutineOn;

    float damagePlayer = 0f;
    float damagePlayerTimeInterval = 1f;

    public Renderer renderer;

    Player2 player_2;

    public GameObject player;

    public SpriteRenderer spriteRenderer;

    // [SerializeField] private Animator animatorTurret;
    [SerializeField] GameObject shooting;

    public Player_2_Health player_2_Health;
    private void Start()
    {
        player2 = GameObject.Find("Player 2 Combat");
        player1 = GameObject.Find("Player 1 Stealth");
        turret = FindAnyObjectByType<Turret>();

        renderer = enemy.GetComponent<Renderer>();

        player_2 = FindObjectOfType<Player2>();

        coroutineOn = false;
    }
    void Update()
    {
      

        TargetPlayer();
        KillEnemy();

        damagePlayer += Time.deltaTime;
    }
    //function that creates a ray, if the gameobject with tag player is in the ray the player gameobject will be destryed  
    public void TargetPlayer()
    {


        RaycastHit2D hitInfo = (Physics2D.Raycast(transform.position, transform.forward, rayLength,
             PlayerMask));
        if (hitInfo)
        {
            if (hitInfo.collider.tag == "Player")
            {

                Debug.Log("player is found");


                if (damagePlayer > damagePlayerTimeInterval)
                {
                    damagePlayer = 0;
                    //animatorTurret.SetBool("Deploy", true);
                    //shooting.SetActive(true);
                    turret.TurretShooting();

                    Debug.Log("urt");
                    player1.GetComponent<Player_1_movement>().DamageMe2();


                }
            }

            if (hitInfo.collider.tag == "Player2")
            {

                Debug.Log("player2 is found");
                player_2_Health.decreaseHealth = true;

                if (!coroutineOn)
                {
                    coroutineOn = true;
                    player_2.toggleColor = true;
                    StartCoroutine(player_2.ChangePlayerColor());
                }

              

                if (damagePlayer > damagePlayerTimeInterval)
                {
                    damagePlayer = 0;
                    Debug.Log("urt2");
                    player2.GetComponent<Player_2_movement>().DamageMe();
                    //animatorTurret.SetBool("Deploy", true);
                    //shooting.SetActive(true);
                    turret.TurretShooting();
                }
            }

            else
            {
                //animatorTurret.SetBool("Deploy",false);
                turret.TurretNotShooting();
            }
        }

        else
        {
            Debug.LogWarningFormat("Stop color");
            player_2_Health.decreaseHealth = false;

            if (coroutineOn)
            {
                player_2.toggleColor = false;
                coroutineOn = false;
            }
            
        }
    }


    public void KillEnemy()
    {
        if (enemyHealth <= 0)
        {
            Destroy(enemy);
        }
    }

    public IEnumerator ChangeEnemyColor()
    {
        renderer.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        renderer.GetComponent<Renderer>().material.color = Color.white;
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
        Gizmos.DrawRay(new Vector3 (transform.position.x, transform.position.y+2.5f, transform.position.z), transform.forward * rayLength);

    }
}







