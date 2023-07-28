using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemies : MonoBehaviour
{
    public float rayLength =1f; //adjust ray length here
    public LayerMask PlayerMask; // assign "Player" layermask in here

    public GameObject enemy;
    //public GameObject player;
    public GameObject player2;
    public GameObject player1;

    public float enemyHealth = 2f;

    public bool DamagePlayer;

    float damagePlayer = 0f;
    float damagePlayerTimeInterval = 1f;

    private void Start()
    {
        player2 = GameObject.Find("Player 2 Combat");
        player1 = GameObject.Find("Player 1 Stealth");
    }
    void Update()
    {
        TargetPlayer();
        KillEnemy();

        damagePlayer += Time.deltaTime;

       
    }
    //function that creates a ray, if the gameobject with tag player is in the ray the player gameobject will be destryed  
    void TargetPlayer()
    {


        RaycastHit2D hitInfo = (Physics2D.Raycast(transform.position, -transform.right, rayLength,
             PlayerMask));
        if (hitInfo)
        {
            if (hitInfo.collider.tag == "Player")
            {

                Debug.Log("player is found");
               

                if (damagePlayer > damagePlayerTimeInterval)
                {
                    damagePlayer = 0;
                    
                   
                    Debug.Log("urt");
                    player1.GetComponent<Player_1_movement>().DamageMe2();
                }
            }

            if (hitInfo.collider.tag == "Player2")
            {

                Debug.Log("player2 is found");
                
               
                if (damagePlayer > damagePlayerTimeInterval)
                {
                    damagePlayer = 0;
                    Debug.Log("urt2");
                    player2.GetComponent<Player_2_movement>().DamageMe();
                }
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
     
           
        
    //visual line that mimics the raycast.
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.right * rayLength);
    }
}







