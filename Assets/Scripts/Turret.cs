using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float turretRayLength = 5f;

    public LayerMask playerMask;

    public GameObject shooting;
    //public Animator turretDeployAnim;
    //public Animator turretShootAnim;

    void Start()
    {
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * turretRayLength);
    }

    void Update()
    {
        TurretRay();
    }
}
