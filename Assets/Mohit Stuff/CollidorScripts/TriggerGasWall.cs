using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGasWall : MonoBehaviour
{
    public bool inGas; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("Whats that smell?");
            inGas = true; 
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Smell nothin bruv");
            inGas = false;
        }
    }
}
