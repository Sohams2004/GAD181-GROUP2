using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCrouch : MonoBehaviour
{
    public bool inHide;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("hidden?");
            inHide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hidden no longer");
            inHide = false;
        }
    }
}
