using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderPlayer : MonoBehaviour
{
    float damageOverTime = 0f;
    float damageOverTimeInterval = 1f;

    int playerHP = 100;

    GameObject gasWall;
    GameObject buttonOne;
    [SerializeField] private Animator animatorButtonOne;
    [SerializeField] private Animator animatorGasWall;

    /// <summary>
    /// replace movement code with soham movement else write your own
    /// </summary>
    /// 
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    [SerializeField] float m_speed = 4.0f;
    private Rigidbody2D m_body2d;
    [SerializeField] float m_jumpForce = 7.5f;

   // [SerializeField] public GameObject waterWater;

    private int m_facingDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        gasWall = GameObject.Find("GasWall");
        buttonOne = GameObject.Find("button 1 opens gate save player");

        m_body2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }

        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }

        if (Input.GetKeyDown("space"))
        {
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // my code starts here, above should be our player movement
        // if bool gas set true then do tick damage to player hp
        if (gasWall.GetComponent<TriggerGasWall>().inGas == true)
        {
            Debug.Log("do i work ?");
            damageOverTime += Time.deltaTime;

            if (damageOverTime > damageOverTimeInterval)
            {
                damageOverTime = 0;
                playerHP -= 5;
                Debug.Log("it urrttss bruuu");
                Debug.Log("health" + playerHP);
            }
        }
        if(buttonOne.GetComponent<TriggerButton>().inButtonOne == true)
        {
            Debug.Log("beep");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("boop");
                animatorButtonOne.SetBool("OpenDoor", true);
                animatorGasWall.SetBool("StopGas", true);
            }
        }

        // A confused should i have put all the OnTriggerEnter, Exits and stays here with 
        /// if other = gas or other equal button or is it the way i did better to have collidors seperate small scripts
        // cause if here thne how will i differentiate from each buttons collidor having 5 tags?

        /*
        else if (bool inGas == false)
        {
            Stop increment of time delta somehow or don't need to?
        checking now
        }
         */
        //increment stops itself the way I setup dw
    }



}
