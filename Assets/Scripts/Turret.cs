using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float turretRayLength = 5f;
    public LayerMask playerMask;

    void Start()
    {
        
    }

    public void TurretRay()
    {
        RaycastHit2D targetPoint = (Physics2D.Raycast(transform.position, transform.right, turretRayLength, playerMask));

        if(targetPoint.collider != null && targetPoint.collider.tag == "Player")
        {
            Debug.Log("Turret deployed");
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
