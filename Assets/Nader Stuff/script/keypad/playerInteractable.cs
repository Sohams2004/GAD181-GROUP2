using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractable : MonoBehaviour
{
    I_interactable interactable;
    bool playerEnterTrigger; //bool that tells if player is in 2D box collider or not

    //if player enters 2D box collider, set playerEnterTrigger=true
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        interactable = collision.gameObject.GetComponent<I_interactable>();
        if (interactable != null)
        {
            playerEnterTrigger= true;
            Debug.Log("interactablefound");

        }
    }
    //if player exits 2D box collider, set playerEnterTrigger=false
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = collision.gameObject.GetComponent<I_interactable>();
        if (interactable != null)
        {
            playerEnterTrigger = false;
            Debug.Log("interactablefound");

        }
    }
    private void Update()
    {   // if playerEnterTrigger allow the player to enable the keypad by pressing E
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerEnterTrigger)
            {
                interactable.interactWithObject();
                Debug.Log("E");
            }
        }
    }
}

