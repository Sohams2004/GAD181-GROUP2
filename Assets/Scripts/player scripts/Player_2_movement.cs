using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 5;
    public bool jumpLimit = true;

    public Vector2 player2_Stand;
    public Vector2 player2_Crouch;

    public BoxCollider2D P2_boxCollider2D;
    public Rigidbody2D player_2_rb;

    void Start()
    {
        P2_boxCollider2D = GetComponent<BoxCollider2D>();
        player_2_rb = GetComponent<Rigidbody2D>();


        void FixedUpdate()
        {
            float inputx = Input.GetAxis("Horizontal");

            Vector2 playerMovement = new Vector2(movementSpeed * inputx, 0) * Time.deltaTime;
            transform.Translate(playerMovement);

            if (Input.GetKey(KeyCode.Space) && !jumpLimit)
            {
                player_2_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                jumpLimit = true;
            }
        }
    }

}


