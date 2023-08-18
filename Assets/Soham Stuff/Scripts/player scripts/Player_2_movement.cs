using System;
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

    //bool isCrouch;

    public BoxCollider2D P2_boxCollider2D;
    public Rigidbody2D player_2_rb;

    public int playerHP2 = 5;
    //gaswall the button and their animators 
    
    GameObject buttonOne;
    GameObject healTent2;
    Animator animator;
    [SerializeField] private Animator animatorButtonOne;
    [SerializeField] private Animator animatorGasWall;

    public ParticleSystem healingEffect;

    TriggerHealthTent triggerHealthTent;

    void OnDestroy()
    {
        triggerHealthTent.PlayerEnterTentEvent -= OnPlayerEnterTent;
        triggerHealthTent.PlayerExitTentEvent -= OnPlayerExitTent;
    }

    void Start()
    {
        P2_boxCollider2D = GetComponent<BoxCollider2D>();
        player_2_rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        //gets components from gasWall and button 1 scripts
       
        buttonOne = GameObject.Find("button 1 opens gate save player");
        healTent2 = GameObject.Find("HealingStation (1)");

        healingEffect.Stop();

        triggerHealthTent = healTent2.GetComponent<TriggerHealthTent>();

        triggerHealthTent.PlayerEnterTentEvent += OnPlayerEnterTent;
        triggerHealthTent.PlayerExitTentEvent += OnPlayerExitTent;

    }

    private void OnPlayerEnterTent()
    {
        healingEffect.Play();
    }

    private void OnPlayerExitTent()
    {
        healingEffect.Stop();
    }


    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CrouchAttack") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || animator.GetCurrentAnimatorStateInfo(0).IsName("Death")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            player_2_rb.velocity= new Vector2(0, player_2_rb.velocity.y);
        }
        else
        {

            player_2_rb.velocity = new Vector2(movementSpeed * inputx, player_2_rb.velocity.y);

            if (inputx > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (inputx < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

        }
        if (Input.GetKey(KeyCode.W) && isGrounded2)
        {
            player_2_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded2 = false;

            animator.SetBool("IsGrounded2", false);
            animator.SetBool("Jump", true);
            
        }
        
        
        //Mathf Absolute makes it so be it minus or plus it will give back the number as positive, makes things easier for blendtree float
        animator.SetFloat("xVelocity", Mathf.Abs(player_2_rb.velocity.x));

        //I may not need mathF now that turning animation requires - value i believe lets see
        //nah will keep this for later as desirable, can keep trun around outside blentree,
        //turn around needs friction player brake cause of speed then rotate complete.
        //Or when animation curve
        //animator.SetFloat("xVelocity", player_2_rb.velocity.x);

        animator.SetFloat("yVelocity", player_2_rb.velocity.y);
        /*/
         * aaa
         * 
        /*/

        
    }

    // easier isGrounded for now, allows for unlimited jump without flying
    // if player touchs ground it is grounded
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Floor")
        {
            Debug.Log("i am gonna cry");
            isGrounded2 = true;
            animator.SetBool("IsGrounded2", true);
            animator.SetBool("Jump", false);
        }
    }

    //mohit here bringing my code over here from placeholder player 2 as it is part of player 2 script
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //isCrouch = true;
            P2_boxCollider2D.offset= new Vector2(P2_boxCollider2D.offset.x,-0.09f);
            P2_boxCollider2D.size = player2_Crouch;
            animator.SetBool("Crouch", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //isCrouch = false;
            P2_boxCollider2D.offset = new Vector2(P2_boxCollider2D.offset.x, -0.005058818f);
            P2_boxCollider2D.size = player2_Stand;
            animator.SetBool("Crouch", false);
        }

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
    }

    void HealBruh(out int value)
    {
        value = 10;
    }
    public int DamageMe()
    {
        playerHP2 -= 1;
        print("hp" + playerHP2);

      
        if (playerHP2 <= 0)
        {
            animator.SetBool("Die", true);
        }
        return playerHP2;
    }
}



