using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Turret : MonoBehaviour
{
    public float turretRayLength = 5f;

    public LayerMask playerMask;

    public GameObject shooting;
    public GameObject enemy;
    //public Animator turretDeployAnim;
    //public Animator turretShootAnim;

    void Start()
    {
        //enemy = GameObject.Find("Smoker enemy 1");
        //turretDeployAnim.SetBool("Deploy", false);
    }

    public void TurretRay()
    {
        RaycastHit2D targetPoint = (Physics2D.Raycast(transform.position, transform.right, turretRayLength, playerMask));

        if(targetPoint.collider != null && targetPoint.collider.tag == "Player")
        {
            //turretDeployAnim.SetBool("Deploy", true);
            shooting.SetActive(true);
            Debug.Log("Turret deployed");
        }

        else
        {
            shooting.SetActive(false);
        }
    }

    public void TurretShooting()
    { shooting.SetActive(true); }

    public void TurretNotShooting()
    { shooting.SetActive(false); }
   
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * turretRayLength);
    }*/

    void Update()
    {
        //I don't have time to experiment now, will just repeat the enemy code and polish next project 
        //

        //enemy.GetComponent<Enemies>().TargetPlayer();
        //TurretRay();
        //Debug.Log("bruh");
    }
}
