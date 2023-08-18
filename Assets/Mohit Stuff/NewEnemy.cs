using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class NewEnemy : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;

    Animator animator;

    [SerializeField] float suspiciousDistance;
    [SerializeField] float chaseDistance;
    [SerializeField] float shootDistance;

    public GameObject player2;
    public GameObject player1;




    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player 2 Combat");
        player1 = GameObject.Find("Player 1 Stealth");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance1 = Vector2.Distance(transform.position, player1.transform.position);
        float distance2 = Vector2.Distance(transform.position, player2.transform.position);
        

      
        if (distance1 < suspiciousDistance || distance2 < suspiciousDistance)
        {
            //animator.SetBool("Bro", true);
            transform.LookAt(new Vector3(player2.transform.position.x, transform.position.y, player2.transform.position.z));

        }/*/
        *
        else if (distance1 < chaseDistance || distance2 < chaseDistance)
        {
         
        }
        else if (distance1 < shootDistance || distance2 < shootDistance)
        {

        }
        else
        {
         false 
        }
          if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rifle Turn (1)"))
        {
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        
        /*/

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, suspiciousDistance);

        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, chaseDistance);

        Gizmos.color = new Color(0, 0, 1, 0.25f);
        Gizmos.DrawSphere(transform.position, shootDistance);
    }


}
