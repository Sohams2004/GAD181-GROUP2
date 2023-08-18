using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealthTent : MonoBehaviour
{
    public bool inHealTent;
    public bool inHealTent2;

    public delegate void PlayerTentCollisiont();
    public PlayerTentCollisiont PlayerEnterTentEvent;
    public PlayerTentCollisiont PlayerExitTentEvent;

    private void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerEnterTentEvent();
            Debug.Log("heal?");
            inHealTent = true;


        }
        else if (other.tag == "Player2")
        {
            PlayerEnterTentEvent();

            Debug.Log("heal2?");
            inHealTent2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerExitTentEvent();
            Debug.Log("stopheal?");
            inHealTent = false;


        }
        else if (other.tag == "Player2")
        {
            PlayerExitTentEvent();
            Debug.Log("stopheal2?");
            inHealTent2 = false;
        }
    }

}
