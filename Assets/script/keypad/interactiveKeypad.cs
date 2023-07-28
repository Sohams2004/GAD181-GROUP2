using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    //this script is for the ingame botton with 2D box collider
public class interactiveKeypad : MonoBehaviour, I_interactable
{
       //this is the keypad
    [SerializeField] GameObject keypadUI;

    //function that enables and disables the keypad
    public void interactWithObject()
    {
        if (keypadUI.activeSelf)
        {
          keypadUI.SetActive(false);
            return;
        }

        if (!keypadUI.activeSelf)
        {
            keypadUI.SetActive(true);
            return;
        }
    }
}