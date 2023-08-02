using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f;
    public float damage = 5f;
    public float repulseForce;
    
    public GameObject attack;

    public LayerMask enemyLayer;

    public Vector2 repulseEnemy;

    public Rigidbody2D enemyrb;
    public bool wallBro;
    public void Attack()
    {
        Collider2D[] attackEnemy = Physics2D.OverlapCircleAll(/*/attack./*/transform.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in attackEnemy)
        {
            wallBro = true;
            if (enemy.GetComponent<Enemies>())
            {
                enemy.GetComponent<Enemies>().enemyHealth -= damage;
                //wallBro = true;
                Debug.Log("Ad");
                //wallBro = false;
            }
        }
    }
   

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Attack();
    }
}
