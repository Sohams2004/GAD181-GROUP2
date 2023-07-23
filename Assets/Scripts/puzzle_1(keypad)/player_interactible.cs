using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interactible : MonoBehaviour
{
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        I_interactable interactable=collision.gameObject.GetComponent<I_interactable>();
        if(interactable!=null) 
        {
            Debug.Log("interactablefound");
            if(Input.GetKeyDown(KeyCode.E))
            {

                interactable.interactWithObject();
                Debug.Log("E");
                
            }
        }
    }

}
