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

    void Start()
    {
        P1_boxCollider2D = GetComponent<BoxCollider2D>();
        player_1_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");

        Vector2 playerMovement = new Vector2(movementSpeed * inputx, 0) * Time.deltaTime;
        transform.Translate(playerMovement);

        if (Input.GetKey(KeyCode.Space) && !jumpLimit)
        {
           player_1_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
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
    }
}
