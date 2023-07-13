using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_movement : MonoBehaviour
{
    public float movementSpeed = 10f;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");

        Vector2 playerMovement = new Vector2(movementSpeed * inputx, 0) * Time.deltaTime;
        transform.Translate(playerMovement);
    }
}
