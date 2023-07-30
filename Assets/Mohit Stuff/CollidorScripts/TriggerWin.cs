using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    [SerializeField] GameObject popUpGGWP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="ball" && other.tag == "Player" || other.tag == "Player2")
        {
            popUpGGWP.SetActive(true);
        }
    }
}
