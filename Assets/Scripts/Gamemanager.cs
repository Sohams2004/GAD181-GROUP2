using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public bool toggleCharacters;

    public GameObject player1, player2;

    public Player_1_movement player1Movement;
    public Player_2_movement player2Movement;

    public camera_follow cameraFollow;


    void Start()
    {
        
    }

    void ToggleCharacters()
    {

        if (!toggleCharacters)
        {
            player1Movement.enabled = false;
            player2Movement.enabled = true;

            toggleCharacters = true;

            cameraFollow.player = player2;

            Debug.LogWarning(1);
        }

        else
        {
            player1Movement.enabled = true;
            player2Movement.enabled = false;

            toggleCharacters = false;

            cameraFollow.player = player1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleCharacters();
        }
    }
}
