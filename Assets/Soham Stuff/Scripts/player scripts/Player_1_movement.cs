using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_movement : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip hideSoundEffect;
    [SerializeField] AudioClip takingDamageSoundEffect;

    public float movementSpeed = 10f;
    public float jumpForce = 5;
    public bool isGrounded1;

    public float rayLength = 1f;
    public LayerMask floorMask;

    public Vector2 player1_Stand;
    public Vector2 player1_Crouch;

    //bool isCrouch;

    public BoxCollider2D P1_boxCollider2D;
    public Rigidbody2D player_1_rb;

    [SerializeField] Renderer rendererBody1;
    [SerializeField] Renderer rendererBody2;
    public bool toggleColor;

    [SerializeField] private Animator animator;

    public int playerHP = 4;

    GameObject gasWall;
    //Damage overtime variable for gaswall
    //float damageOverTime = 0f;
    //float damageOverTimeInterval = 1f;


    GameObject healTent1;


    //GameObject hideSpot;
    //GameObject hideSpot1;
    private TriggerCrouch hideSpot;
    private TriggerCrouch hideSpot1;


    //[SerializeField] private Animator animatorEnemyWalkBy;
    //[SerializeField] GameObject playerOne;
    public ParticleSystem healingEffect;

    private void Awake()
    {
        //subscribing to Delgate events placed in TriggerHealthTent
        TriggerHealthTent.PlayerEnterTentEvent1 += OnPlayerEnterTent;
        TriggerHealthTent.PlayerExitTentEvent1 += OnPlayerExitTent;
    }
    void OnDestroy()
    {   //unSubbing to same events on destroy 
        TriggerHealthTent.PlayerEnterTentEvent1 -= OnPlayerEnterTent;
        TriggerHealthTent.PlayerExitTentEvent1 -= OnPlayerExitTent;
    }

    private void OnPlayerEnterTent()
    {
        healingEffect.Play();
        HealBruh2(out playerHP);
        Debug.Log("healed1");

    }

    private void OnPlayerExitTent()
    {
        healingEffect.Stop();
    }

    void Start()
    {
        P1_boxCollider2D = GetComponent<BoxCollider2D>();
        player_1_rb = GetComponent<Rigidbody2D>();

        //playerOne = GetComponent<GameObject>();

        gasWall = GameObject.Find("GasWall");

        healTent1 = GameObject.Find("HealingStation");

        //hideSpot = GameObject.Find("HideSpot");
        //hideSpot1 = GameObject.Find("HideSpot1");

        hideSpot = FindAnyObjectByType<TriggerCrouch>();
        hideSpot1 = FindAnyObjectByType<TriggerCrouch>();

        healingEffect.Stop();

        // playHideAudio= false;
    }
    private void FixedUpdate()
    {

        Movement();
        // }
        //raycast to replace isGrounded collidor, fixed jumping in quick succession issue
        RaycastHit2D hitinfo = (Physics2D.Raycast(transform.position, -transform.up, rayLength, floorMask));

        if (hitinfo)
        {
            if (hitinfo.collider.tag == "Floor")
            {
                Debug.Log("Floor found");


                isGrounded1 = true;
                animator.SetBool("IsGrounded1", true);
                animator.SetBool("Jump", false);

            }

        }
        else
        {
            isGrounded1 = false;
            animator.SetBool("IsGrounded1", false);

        }
    }
    private void Update()
    {
        //This for polish next project
        if (Input.GetKeyDown(KeyCode.RightShift))
        {

            //isCrouch = true;

            //P1_boxCollider2D.offset = new Vector2(P1_boxCollider2D.offset.x, -0.09f);
            //P1_boxCollider2D.size = player1_Crouch;
            animator.SetBool("Crouch", true);

        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            //isCrouch = false;
            //P1_boxCollider2D.offset = new Vector2(P1_boxCollider2D.offset.x, -0.01282739f);
            //P1_boxCollider2D.size = player1_Stand;
            animator.SetBool("Crouch", false);

        }


        // if gasWall's bool inGas true then damage player 1 damage per second and print for now, visual and sound later
        /*if (gasWall.GetComponent<TriggerGasWall>().inGas == true)
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
            //gameObject.layer = 2;
        }

        if (hideSpot.GetComponent<TriggerCrouch>().inHide == true)
        {

            if (isCrouch)
            {
                gameObject.layer = 2;
                //animatorEnemyWalkBy.SetBool("GoOn", true);
                //hideSoundEffect.Play();
                audioSource.PlayOneShot(hideSoundEffect);
            }

        }
        else if (hideSpot1.GetComponent<TriggerCrouch>().inHide == true)
        {

            if (isCrouch)
            {
                gameObject.layer = 2;
                audioSource.PlayOneShot(hideSoundEffect);
            }
        }

        if (hideSpot.GetComponent<TriggerCrouch>().inHide == false && hideSpot1.GetComponent<TriggerCrouch>().inHide == false)
        {
            //Debug.Log("i cri");
            gameObject.layer = 3;
        }*/




        // if (healTent1.GetComponent<TriggerHealthTent>().inHealTent2 == true)
        // {
        //HealBruh2(out playerHP);
        //Debug.Log("healed2");
        // }
        Jump();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * rayLength);
    }


    void Movement()
    {
        float inputx = Input.GetAxis("Horizontal1");
        //animator state info fixes the issue of player moving even after doing these animations in which we don't want them to move
        //so if these states are true then stop moving on x axis
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        // {
        //    player_1_rb.velocity = new Vector2(0, player_1_rb.velocity.y);
        //}
        //else
        //{

        player_1_rb.velocity = new Vector2(movementSpeed * inputx, player_1_rb.velocity.y);

        if (inputx > 0)
        {
            //GetComponent<SpriteRenderer>().flipX = false;
        }
        if (inputx < 0)
        {
            //GetComponent<SpriteRenderer>().flipX = true;
        }

        //transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        //transform.rotation = Quaternion.Euler(0f, 270f, 0f);

        //}
        //Mathf Absolute makes it so be it minus or plus it will give back the number as positive, makes things easier for blendtree float
        animator.SetFloat("xVelocity", /*Mathf.Abs(*/
        player_1_rb.velocity.x);

        animator.SetFloat("yVelocity", player_1_rb.velocity.y);
        /*/
            *aaa
         * 
        /*/
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded1)
        {
            print("bruh0");
            player_1_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded1 = false;

            animator.SetBool("IsGrounded1", false);
            animator.SetBool("Jump", true);

        }
    }
    public IEnumerator ChangePlayerColor()
    {
        if (!toggleColor)
        {
            rendererBody1.GetComponent<Renderer>().material.color = Color.white;
            rendererBody2.GetComponent<Renderer>().material.color = Color.white;
            yield break;
        }
        else
        {
            rendererBody1.GetComponent<Renderer>().material.color = Color.red;
            rendererBody2.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            rendererBody1.GetComponent<Renderer>().material.color = Color.white;
            rendererBody2.GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(ChangePlayerColor());
        }

    }
    
    void HealBruh2(out int value)
    {
        value = 10;
    }

    public int DamageMe2()
    {
        audioSource.PlayOneShot(takingDamageSoundEffect);
        playerHP -= 1;
        print("hp" + playerHP);
        return playerHP;
    }


}
