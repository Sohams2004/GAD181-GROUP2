using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpforce = 5;
    public bool jumpLimit;
    
    public Vector2 player1_Stand;
    public Vector2 player1_Crouch;

    public BoxCollider2D P1_boxCollider2D;
    public Rigidbody2D player_1_rb;


    GameObject gasWall;
    //Damage overtime variable for gaswall
    float damageOverTime = 0f;
    float damageOverTimeInterval = 1f;
    int playerHP = 10;

    void Start()
    {
        P1_boxCollider2D = GetComponent<BoxCollider2D>();
        player_1_rb = GetComponent<Rigidbody2D>();

        gasWall = GameObject.Find("GasWall");
    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal1");

        Vector2 playerMovement = new Vector2(movementSpeed * inputx, 0) * Time.deltaTime;
        transform.Translate(playerMovement);

        if (Input.GetKey(KeyCode.Space) && !jumpLimit)
        {
           player_1_rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
           jumpLimit = true;
            
            //rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }   
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            P1_boxCollider2D.size = player1_Crouch;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            P1_boxCollider2D.size = player1_Stand;
        }
        //mohit here bringing my code over here from placeholder player 2 as it is part of player 1 script
        // if gasWall's bool inGas true then damage player 1 damage per second and print for now, visual and sound later
        if (gasWall.GetComponent<TriggerGasWall>().inGas == true)
        {
            Debug.Log("do i work ?");
            damageOverTime += Time.deltaTime;

            if (damageOverTime > damageOverTimeInterval)
            {
                damageOverTime = 0;
                playerHP -= 1;
                Debug.Log("it urrttss bruuu");
                Debug.Log("health" + playerHP);
            }
        }

    }
    public void DamageMe2()
    {
        playerHP -= 1;
    }
}
