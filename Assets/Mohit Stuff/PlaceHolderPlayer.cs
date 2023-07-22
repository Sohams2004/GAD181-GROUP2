using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderPlayer : MonoBehaviour
{
    [SerializeField] float m_speed = 4.0f;
    private Rigidbody2D m_body2d;
    [SerializeField] float m_jumpForce = 7.5f;

    private int m_facingDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
