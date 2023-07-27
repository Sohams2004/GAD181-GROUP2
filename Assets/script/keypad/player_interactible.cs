using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interactible : MonoBehaviour
{
    I_interactable interactable;
    bool playerEnterTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = collision.gameObject.GetComponent<I_interactable>();
        if (interactable != null)
        {
            playerEnterTrigger= true;
            Debug.Log("interactablefound");

        }
    }
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
    {
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

