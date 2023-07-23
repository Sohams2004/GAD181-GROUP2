using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpforce = 5;
    
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");

        Vector2 playerMovement = new Vector2(movementSpeed * inputx, 0) * Time.deltaTime;
        transform.Translate(playerMovement);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
}
