using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacticeKeypad : MonoBehaviour,I_interactable
{
    [SerializeField]GameObject keypadUI;

    public void interactWithObject()
    {
        if (keypadUI.activeSelf)
        {
            keypadUI.SetActive(false);
            return;
        }
       
        if(!keypadUI.activeSelf)
        {
            keypadUI.SetActive(true);
            return;
        }
    }
}
