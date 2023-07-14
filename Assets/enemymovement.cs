using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    [SerializeField] float potrolSpeed = 1f;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] int patrolIndex;

    void Update()
    {
        Patroling(patrolPoints[patrolIndex].position);
        patrolToNextPoint();
        patrolRotation();
    }
        //function that moves the enemy to a certain point on the map
    void Patroling(Vector2 positionToGo)
    {
        transform.position = Vector2.Lerp(transform.position, positionToGo, Time.deltaTime * potrolSpeed);
    }
        //function that moves the enemy to the point after the enemy have reached the first point
    void patrolToNextPoint()
    {
       
        float distance = Vector2.Distance(transform.position, patrolPoints[patrolIndex].position);
        
            //check if enemy distance to the point is less or equal too 1 add a patrol point.
        if(distance <= 1)
        {
            patrolIndex++;
        }
        if (patrolIndex > patrolPoints.Length - 1)
        {
            patrolIndex = 0;
            return;
        }
    }
    void patrolRotation()
    {
        if (patrolIndex == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            return;
        }
        if (patrolIndex == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            return;
        }
    }
}
