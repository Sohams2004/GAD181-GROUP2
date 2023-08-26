using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public string SoloScene, CoopScene;
    [SerializeField] GameObject popUpGameOver;

    public bool toggleCharacters;

    public GameObject player1, player2;
    public GameObject pauseScreen;
    public GameObject controlPanel;

    public Player_1_movement player1Movement;
    public Player_2_movement player2Movement;

    public camera_follow cameraFollow;

    public bool SinglePlayer;
    public bool Coop;
    public bool isPaused = false;
    //public bool dead;

    // public GameObject playerOne;
    // public GameObject playerTwo;

    void OnEnable()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "LevelSolo")
        {
            SinglePlayer = true;
            Coop = false;
        }
        if (scene.name == "LevelCoop")
        {
            Coop = true;
            SinglePlayer = false;
        }
    }

    public void Start()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (SinglePlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ToggleCharacters();
            }
        }

        if (player1Movement.GetComponent<Player_1_movement>().playerHP <= 0)
        {
            Invoke("GameOver", 1.1f);
        }

        if (player2Movement.GetComponent<Player_2_movement>().playerHP2 <= 0)
        {
            Debug.Log("player ded bro");
            Invoke("GameOver", 1.1f);
        }

        ScreenPause();
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
    /*/ public void RetrySingle()
     {

         Time.timeScale = 1;
         SceneManager.LoadScene("LevelSolo");
         Debug.Log(" singplye player i cri otherwise i work yes");


     }/*/
    public void RetryCoop()
    {


        Time.timeScale = 1;
        SceneManager.LoadScene("LevelCoop");
        Debug.Log(" ocoop i work yes i cri otherwise");

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        popUpGameOver.SetActive(true);

    }

    public void ScreenPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            isPaused = true;
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenControlPanel()
    {
        controlPanel.SetActive(true);
    }
    
    public void CloseControlPanel()
    {
        controlPanel.SetActive(false);
    }
    /*/
    public void GameOver()
    {
        Time.timeScale = 0;
        popUpGameOver.SetActive(true);
    }/*/

}
