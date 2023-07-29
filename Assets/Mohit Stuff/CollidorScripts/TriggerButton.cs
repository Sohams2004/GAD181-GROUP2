using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public bool inButtonOne;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player2")
        {

            Debug.Log("he in?");
            inButtonOne = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player2")
        {
            Debug.Log("he left");
            inButtonOne = false;
        }
    }
}
