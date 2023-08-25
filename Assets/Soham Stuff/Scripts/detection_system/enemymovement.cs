using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    [SerializeField] float patrolSpeed = 1f;
    [SerializeField] public Transform[] patrolPoints;  //assign the 2 patrol points here ie point A and point B.
    [SerializeField] public int patrolIndex;
    // public bool iAmRotating;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Patroling(patrolPoints[patrolIndex].position);
        //patrolToNextPoint();
        //patrolRotation();
        //Debug.Log("patrolIndex" +  patrolIndex);
        //Debug.Log("patrolPoints.Length" + patrolPoints.Length);

    }
    //function that moves the enemy to a certain point on the map
    public void Patroling(Vector3 positionToGo)
    {
        //transform.Translate(Time.deltaTime * patrolSpeed * transform.right);
        //transform.position = Vector2.Lerp(transform.position, positionToGo, Time.deltaTime * patrolSpeed);
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z),
        new Vector3(positionToGo.x, transform.position.y, transform.position.z), Time.deltaTime * patrolSpeed);

    }
    //function that moves the enemy to the point after the enemy have reached the first point
    public void patrolToNextPoint()
    {

        float distance = Vector3.Distance(transform.position, patrolPoints[patrolIndex].position);
        //Debug.Log("distance" + distance);
        //check if enemy distance to the point is less or equal too 1 add a patrol point.
        if (distance <= 1)
        {
            patrolIndex++;
            animator.SetTrigger("ReachedPoint");
        }
        if (patrolIndex > patrolPoints.Length - 1)
        {
            patrolIndex = 0;
            return;
        }
    }
    //function that rotates enemy 180 degrees when the enemy reaches the point
    public void patrolRotation()
    {
        if (patrolIndex == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 1f, 0f);
            return;
        }
        if (patrolIndex == 1)
        {
            transform.rotation = Quaternion.Euler(0f, -179f, 0f);
            return;
        }
    }
}
