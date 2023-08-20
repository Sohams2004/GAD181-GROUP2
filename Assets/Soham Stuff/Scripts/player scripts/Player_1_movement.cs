using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpforce = 5;
    public bool isGrounded;

    public Vector2 player1_Stand;
    public Vector2 player1_Crouch;

    bool isCrouch;

    public BoxCollider2D P1_boxCollider2D;
    public Rigidbody2D player_1_rb;

    public int playerHP = 5;

    GameObject gasWall;
    //Damage overtime variable for gaswall
    float damageOverTime = 0f;
    float damageOverTimeInterval = 1f;
    

    GameObject healTent1;
    GameObject hideSpot;
    GameObject hideSpot1;

    [SerializeField] GameObject popUpRetry;

    [SerializeField] private Animator animatorEnemyWalkBy;
    //[SerializeField] GameObject playerOne;
    void Start()
    {
        P1_boxCollider2D = GetComponent<BoxCollider2D>();
        player_1_rb = GetComponent<Rigidbody2D>();

        //playerOne = GetComponent<GameObject>();

        gasWall = GameObject.Find("GasWall");

        healTent1 = GameObject.Find("HealingStation");

        hideSpot = GameObject.Find("HideSpot");
        hideSpot1 = GameObject.Find("HideSpot1");


    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal1");

        player_1_rb.velocity = new Vector2(movementSpeed * inputx, player_1_rb.velocity.y);


        if (Input.GetKey(KeyCode.UpArrow) && !isGrounded)
        {
            player_1_rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            isGrounded = true;

            //rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
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


    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Floor")
        {
            Debug.Log("i am gonna cry");
            isGrounded = false;
        }
    }

    public void Update()
    {
        //This for polish next project
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            isCrouch = true;
            //P1_boxCollider2D.size = player1_Crouch;
        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            isCrouch = false;
            //P1_boxCollider2D.size = player1_Stand;
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
            //gameObject.layer = 2;
        }
        // put layer thing in gas to check what i was doing wrong, 
        // layer changing works in gas wall trigger but not in the dedcated one i was trying to make so i'll leave holding crouch or shift for next project
        /*if (gasWall.GetComponent<TriggerGasWall>().inGas == false)
        {
            Debug.Log("i cri");
            gameObject.layer = 3;
        }*/
        // put layer thing in gas to check what i was doing wrong, 
        // layer changing works in gas wall trigger but not in the dedcated one i was trying to make so i'll leave holding crouch or shift for next project


        // so in the end making it && was better && means when both are false
        //layer was changing to player even when was was true cause of || 
        //also before it wasn't reading the line due to not assigning hideSpot2

        //this function just does not want to work
        if (hideSpot.GetComponent<TriggerCrouch>().inHide == true)
        {
            
            if (isCrouch)
            {
                gameObject.layer = 2;
                animatorEnemyWalkBy.SetBool("GoOn", true);
            }

        }
        else if (hideSpot1.GetComponent<TriggerCrouch>().inHide == true)
        {
            
            if (isCrouch)
            {
                gameObject.layer = 2;
            }
        }

        if (hideSpot.GetComponent<TriggerCrouch>().inHide == false && hideSpot1.GetComponent<TriggerCrouch>().inHide == false)
        {
            //Debug.Log("i cri");
            gameObject.layer = 3;
        }

        /*/
        else if (hideSpot2.GetComponent<TriggerCrouch>().inHide == false)
         {
             Debug.Log("i cri2");
             gameObject.layer = 3;
         }
        */



        if (healTent1.GetComponent<TriggerHealthTent>().inHealTent2 == true)
        {
            HealBruh2(out playerHP);
            Debug.Log("healed2");
        }

    }

    void HealBruh2(out int value)
    {
        value = 10;
    }

    public int DamageMe2()
    {
        playerHP -= 1;
        print("hp" + playerHP);
        return playerHP;
    }

    
}
