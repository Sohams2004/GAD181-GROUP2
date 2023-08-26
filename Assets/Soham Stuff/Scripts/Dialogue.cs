using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogue;

    public GameObject dialogueBox;

    public IEnumerator dialogueSystem()
    {
        yield return new WaitForSeconds(1);
        dialogueBox.SetActive(true);
        dialogue.text = "Hello there!";
        yield return new WaitForSeconds(1);
        dialogue.text = "How are ya?";

        // Repeat the same method to add as many strings as u want
        // Dont forget to start coroutine whenever u feel is the right time
    }
}
