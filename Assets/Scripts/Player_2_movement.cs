using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpforce = 5;
    public bool jumplimit = true;

    public Vector2 player2_Stand;
    public Vector2 player2_Crouch;

    public BoxCollider2D P2_boxCollider2D;

    public Rigidbody2D rb;

    void Start()
    {
        P2_boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");

        Vector2 playerMovement = new Vector2(movementSpeed * inputx, 0) * Time.deltaTime;
        transform.Translate(playerMovement);

        if (Input.GetKeyDown(KeyCode.Space) && !jumplimit)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
}
