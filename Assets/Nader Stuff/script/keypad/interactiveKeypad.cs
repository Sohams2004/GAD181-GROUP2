using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the ingame botton with 2D box collider
public class interactiveKeypad : MonoBehaviour, I_interactable
{
    //this is the keypad
    [SerializeField] GameObject keypadUI;

    public Player_2_movement playerMovement;
    //public bool playerMove;

    
    //function that enables and disables the keypad
    public void interactWithObject()
    {
        //This only executes when E is pressed to interact with the object not when close on the keypad is pressed 
        if (keypadUI.activeSelf)
        {
            keypadUI.SetActive(false);
            //playerMove = false;
            playerMovement.enabled = true;
            Debug.Log("ahhh");
            return;
            
        }

        if (!keypadUI.activeSelf)
        {
            keypadUI.SetActive(true);
            //playerMove = true;
            playerMovement.enabled = false;
            Debug.Log("ohk");
            return;
        }
    }
}