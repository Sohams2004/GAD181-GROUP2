using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad_functionality : MonoBehaviour
{
    [SerializeField] string passcode;
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] GameObject keyPad;
    public void numberToPrintOut(string number)
    {
        displayText.text += number;
    }
    public void checkWhetherCodeIsCorrect()
    {
        if (displayText.text == passcode)
        {
            displayText.text = "Beeepbeppp booooop";
            Destroy(GameObject.FindWithTag("gate1"));
            keyPad.SetActive(false);
        }
        else
        {
            Debug.Log("bro");
            displayText.text = "Error";
        }
    }

   /* public IEnumerator ErrorText()
    {
        if (displayText.text != passcode)
        {
            displayText.text = "Error";
            yield return new WaitForSeconds(1);
            displayText.text = "";
        }

         
        {
            yield return null;
        }
    }*/

    public void StartCoroutineErrorText()
    {
         // StartCoroutine(ErrorText());
    }

    public void BackSpace()
    {
        displayText.text = "";
    }

    public void Update()
    {
    }
}

