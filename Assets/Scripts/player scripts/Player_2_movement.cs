using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 5;
    public bool isGrounded2;

    public Vector2 player2_Stand;
    public Vector2 player2_Crouch;

    public BoxCollider2D P2_boxCollider2D;
    public Rigidbody2D player_2_rb;

    int playerHP = 10;
    //gaswall the button and their animators 
    
    GameObject buttonOne;
    GameObject healTent2;

    [SerializeField] private Animator animatorButtonOne;
    [SerializeField] private Animator animatorGasWall;

    void Start()
    {
        P2_boxCollider2D = GetComponent<BoxCollider2D>();
        player_2_rb = GetComponent<Rigidbody2D>();

        //gets components from gasWall and button 1 scripts
       
        buttonOne = GameObject.Find("button 1 opens gate save player");
        healTent2 = GameObject.Find("HealingStation (1)");
      
    }
    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");

        player_2_rb.velocity = new Vector2(movementSpeed * inputx, player_2_rb.velocity.y);


        if (Input.GetKey(KeyCode.Space) && !isGrounded2)
        {
            player_2_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded2 = true;

        }

        if (inputx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (inputx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // easier isGrounded for now, allows for unlimited jump without flying
    // if player touchs ground it is grounded
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Floor")
        {
            Debug.Log("i am gonna cry");
            isGrounded2 = false;
        }
    }

    //mohit here bringing my code over here from placeholder player 2 as it is part of player 2 script
    void Update()
    {

        if (buttonOne.GetComponent<TriggerButton>().inButtonOne == true)
        {
            Debug.Log("beep");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("boop");
                animatorButtonOne.SetBool("OpenDoor", true);
                animatorGasWall.SetBool("StopGas", true);
            }
        }

        if (healTent2.GetComponent<TriggerHealthTent>().inHealTent2 == true)
        {
            HealBruh(out playerHP);
            Debug.Log("healed2");
        }
        
    }

    void HealBruh(out int value)
    {
        value = 10;
    }
    public void DamageMe()
    {
        playerHP -= 1;
        print("hp" + playerHP);
    }

}



