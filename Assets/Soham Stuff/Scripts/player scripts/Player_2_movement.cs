using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_movement : MonoBehaviour
{
    [SerializeField] private AudioSource takingDamageSoundEffect;

    public float movementSpeed = 10f;
    //public AnimationCurve movementCurve;
    float time = 0f; 

    public float jumpForce = 5;

    public bool isGrounded2;
    public float rayLength = 1f;
    public LayerMask floorMask;

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
       // triggerHealthTent.PlayerEnterTentEvent -= OnPlayerEnterTent;
       // triggerHealthTent.PlayerExitTentEvent -= OnPlayerExitTent;
    }

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonPress;


    //GameObject playerKeypadMovement;
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

        // if (playerKeypadMovement.GetComponent<interactiveKeypad>().playerMove == true)
        // {
        //    Debug.Log("iyea");
        // }/*/
        // else
        // {
        //Debug.Log("ahah");
        Movement();
        // }
        //raycast to replace isGrounded collidor, fixed jumping in quick succession issue
        RaycastHit2D hitinfo = (Physics2D.Raycast(transform.position, -transform.up, rayLength, floorMask));

        if (hitinfo)
        {
            if(hitinfo.collider.tag == "Floor")
            {
                Debug.Log("Floor found");

          
                    isGrounded2 = true;
                    animator.SetBool("IsGrounded2", true);
                    animator.SetBool("Jump", false);
          
            }

        }
        else
        {
            isGrounded2 = false;
            animator.SetBool("IsGrounded2", false);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * rayLength);
    }

    void Movement()
    {
        float inputx = Input.GetAxis("Horizontal");
        //animator state info fixes the issue of player moving even after doing these animations in which we don't want them to move
        //so if these states are true then stop moving on x axis
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CrouchAttack") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1")
           || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || animator.GetCurrentAnimatorStateInfo(0).IsName("Death")
           || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            player_2_rb.velocity = new Vector2(0, player_2_rb.velocity.y);
        }
        else 
        {
            /*/
            //inputx
            movementSpeed = movementCurve.Evaluate(time);
            time += Time.deltaTime;

            player_2_rb.AddForce(movementSpeed * Vector2.right);
            

            /*/
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
        //Mathf Absolute makes it so be it minus or plus it will give back the number as positive, makes things easier for blendtree float
        animator.SetFloat("xVelocity", Mathf.Abs(player_2_rb.velocity.x));

        //I may not need mathF now that turning animation requires - value i believe lets see
        //nah will keep this for later as desirable, can keep trun around outside blentree,
        //turn around needs friction player brake cause of speed then rotate complete.
        //Or when animation curve
        //animator.SetFloat("xVelocity", player_2_rb.velocity.x);

        animator.SetFloat("yVelocity", player_2_rb.velocity.y);
        /*/
            *aaa
         * 
        /*/
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded2)
        {
            print("bruh0");
            player_2_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded2 = false;

            animator.SetBool("IsGrounded2", false);
            animator.SetBool("Jump", true);

        }
    }

    /*/
   *  
   * 
    //easier isGrounded for now, allows for unlimited jump without flying
    //if player touchs ground it is grounded
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

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Floor")
        {
            Debug.Log("i am gonna cry");
            isGrounded2 = false;
            animator.SetBool("IsGrounded2", false);
            animator.SetBool("Jump", false);
        }
    }
     /*/

    //mohit here bringing my code over here from placeholder player 2 as it is part of player 2 script
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.S))
        {
            //isCrouch = true;
            P2_boxCollider2D.offset= new Vector2(P2_boxCollider2D.offset.x,-0.09f);
            P2_boxCollider2D.size = player2_Crouch;
            animator.SetBool("Crouch", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            //isCrouch = false;
            P2_boxCollider2D.offset = new Vector2(P2_boxCollider2D.offset.x, -0.01282739f);
            P2_boxCollider2D.size = player2_Stand;
            animator.SetBool("Crouch", false);
        }

          if (buttonOne.GetComponent<TriggerButton>().inButtonOne == true)
          {
              Debug.Log("beep");
              if (Input.GetKeyDown(KeyCode.E))
              {
                  Debug.Log("boop");
                  audioSource.PlayOneShot(buttonPress);
                  animatorButtonOne.SetBool("OpenDoor", true);
                  animatorGasWall.SetBool("StopGas", true);
              }
          }

        if (healTent2.GetComponent<TriggerHealthTent>().inHealTent2 == true)
        {
            HealBruh(out playerHP2);
            Debug.Log("healed2");
        }
        Jump();

    }

    void HealBruh(out int value)
    {
        value = 10;
    }
    public int DamageMe()
    {
        takingDamageSoundEffect.Play();
        playerHP2 -= 1;
        print("hp" + playerHP2);
        animator.SetTrigger("GotHit");

        if (playerHP2 <= 0)
        {
            animator.SetBool("Die", true);
        }
        return playerHP2;
    }
}



