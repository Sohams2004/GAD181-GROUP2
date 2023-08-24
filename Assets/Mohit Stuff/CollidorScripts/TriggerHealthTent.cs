using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealthTent : MonoBehaviour
{
    [SerializeField] private AudioSource healingSoundEffect;
    public bool inHealTent;
    public bool inHealTent2;    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("heal?");
            inHealTent = true;

            
        }
       else if (other.tag == "Player2")
        {
            healingSoundEffect.Play();
            Debug.Log("heal2?");
            inHealTent2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("stopheal?");
            inHealTent = false;


        }
        else if (other.tag == "Player2")
        {
            Debug.Log("stopheal2?");
            inHealTent2 = false;
        }
    }

}
