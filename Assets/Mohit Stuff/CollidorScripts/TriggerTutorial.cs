using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] public GameObject dialogueBox2;
    [SerializeField] public GameObject dialogueBox3;
    //[SerializeField] public GameObject dialogueBox4;
    //[SerializeField] public GameObject dialogueBox5;
    public int id; 
    //public delegate void PlayerTentCollisiont();
    //public static event PlayerTentCollisiont PlayerEnterTutorialDialogueEvent1;
    //public static event PlayerTentCollisiont PlayerEnterTutorialDialogueEvent2;
    //public static event PlayerTentCollisiont PlayerExitTutorialDialogueEvent1;
    //public static event PlayerTentCollisiont PlayerExitTutorialDialogueEvent2;

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "Player")
        {
            //PlayerEnterTutorialDialogueEvent1();
            //Debug.Log("bro");
            dialogueBox.SetActive(true);
        }
        */
        if (other.tag == "Player2")
        {
            if (id == 0)
            {
                dialogueBox.SetActive(true);
            }
            else if(id == 1)
            {
                dialogueBox2.SetActive(true);
            }
            else if (id == 2)
            {
                dialogueBox3.SetActive(true);
            }
            /*else if (id == 3)
            {
                dialogueBox4.SetActive(true);
            }
            else if (id == 4)
            {
                dialogueBox5.SetActive(true);
            }
            */
            //PlayerEnterTutorialDialogueEvent2();

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        /*if (other.tag == "Player")
        {

            //PlayerExitTutorialDialogueEvent1();
            dialogueBox.SetActive(false);


        }
        */
        if (other.tag == "Player2")
        {
            if (id == 0)
            {
                dialogueBox.SetActive(false);
            }
            else if (id == 1)
            {
                dialogueBox2.SetActive(false);
            }
            else if (id == 2)
            {
                dialogueBox3.SetActive(false);
            }
           /* else if (id == 3)
            {
                dialogueBox4.SetActive(false);
            }
            else if (id == 4)
            {
                dialogueBox5.SetActive(false);
            }*/
            //PlayerExitTutorialDialogueEvent2();
            //dialogueBox.SetActive(false);

        }
    }
}
