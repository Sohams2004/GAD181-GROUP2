using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
        //transform.rotation = Quaternion.Euler(3.3f,15,0);
    }
}
