using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animator2;
    [SerializeField] private Animator animator3;
    //[SerializeField] private Animator animator4;
    //[SerializeField] GameObject TUNNELDOOR;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool( "CloseDoor", true);
            animator2.SetBool("StartGas", true); 
            animator3.Play("justGo");
            //animator4.SetBool()
            //TUNNELDOOR.SetActive(false);
        }
    }
}
