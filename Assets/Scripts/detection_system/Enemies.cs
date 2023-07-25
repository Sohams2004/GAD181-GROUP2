using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemies : MonoBehaviour
{
    public float rayLength =1f;
    public LayerMask PlayerMask;

    void Update()
    {
        TargetPlayer();
       
    }
      //function that creates a ray, if the gameobject with tag player is in the ray the player gameobject will be destryed  
    void TargetPlayer()
    {
        RaycastHit2D targetPoint = (Physics2D.Raycast(transform.position, -transform.right, rayLength,PlayerMask));
        if (targetPoint.collider!=null&&targetPoint.collider.tag=="Player")
        {
            
            Debug.Log("player is found");
            //Destroy(GameObject.FindWithTag("Player") );
        }
        else
        {
            return;
        }
    }
        //visual line that mimics the raycast.
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay (transform.position, -transform.right * rayLength);
    }
}







