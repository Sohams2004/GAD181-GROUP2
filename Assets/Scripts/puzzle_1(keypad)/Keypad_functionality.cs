using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad_functionality : MonoBehaviour
{
    [SerializeField]string passcode;
    [SerializeField]TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void numberToPrintOut(string number)
    {
        displayText.text += number;
    }
    public void checkWhetherCodeIsCorrect()
    {
        if(displayText.text==passcode) 
        {
            displayText.text = "correct";
        }
    }
}
