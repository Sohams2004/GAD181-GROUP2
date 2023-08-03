using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//ass
public class Keypad_functionality : MonoBehaviour
{
    [SerializeField] string passcode;   //pick whatever the code will be
    [SerializeField] TextMeshProUGUI displayText;   //attach the text here
    [SerializeField] GameObject keyPad;     //attach the keypad here

    //this function prints the numbers
    //attach this function to the buttons in the inspector and pick the displayed text (string number)
    public void numberToPrintOut(string number)
    {
        displayText.text += number;
    }
    // this function is for the green button
    // check if the code is correct
    //if code is correct destroy gate ("gate1") and disable keypad
    public void checkWhetherCodeIsCorrect()
    {
        if (displayText.text == passcode)
        {
            Destroy(GameObject.FindWithTag("gate1"));
            Destroy(GameObject.FindWithTag("gate2"));
            keyPad.SetActive(false);
        }
    }
    // this is attached to the red button on the keypad.
    //clears all text
    public void BackSpace()
    {
        displayText.text = "";
    }

    public void closeKeypad()
    {
        keyPad.SetActive(false);
    }
}

