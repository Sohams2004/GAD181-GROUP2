using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealthTent : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip healingSoundEffect;
    
    public bool inHealTent;
    public bool inHealTent2;

    public delegate void PlayerTentCollisiont();
    public static event PlayerTentCollisiont PlayerEnterTentEvent1;
    public static event PlayerTentCollisiont PlayerEnterTentEvent2;
    public static event PlayerTentCollisiont PlayerExitTentEvent1;
    public static event PlayerTentCollisiont PlayerExitTentEvent2;

    private void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerEnterTentEvent1();
            Debug.Log("heal?");
            inHealTent = true;
            audioSource.PlayOneShot(healingSoundEffect);

        }
        else if (other.tag == "Player2")
        {
           
            audioSource.PlayOneShot(healingSoundEffect);
            PlayerEnterTentEvent2();
            Debug.Log("heal2?");
            //inHealTent2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            PlayerExitTentEvent1();
            Debug.Log("stopheal?");
            inHealTent = false;

        }
        else if (other.tag == "Player2")
        {
            PlayerExitTentEvent2();
            Debug.Log("stopheal2?");
            //inHealTent2 = false;
        }
    }

}
