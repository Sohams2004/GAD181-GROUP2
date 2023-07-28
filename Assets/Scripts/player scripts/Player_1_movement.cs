using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 5;
    public bool jumpLimit;
    
    public Rigidbody2D player_1_rb;

    void Start()
    {
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
        }
    }
}
