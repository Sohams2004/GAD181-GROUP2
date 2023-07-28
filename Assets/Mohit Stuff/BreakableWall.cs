using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    //public float wallHp = 5f;
    //public bool wallBro;
    GameObject playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GameObject.Find("Player 2 Combat");
    }

    // Update is called once per frame
    void Update()
    {
        KillWall();
    }
    // function checks wallBro bool from playerattack script then destroys wall
    public void KillWall()
    {
        if (playerAttack.GetComponent<PlayerAttack>().wallBro == true)
        {
            Destroy(gameObject);
            Debug.Log("bf");
            //wallBro = false;
        }
    }
    //refine this next time, break part of wall every hit

}
