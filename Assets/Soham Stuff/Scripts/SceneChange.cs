using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool Solo;
    public bool Coop;
    public Gamemanager gamemanager;

    public GameObject controlPanel;

    //[SerializeField] GameObject popUpGameOver;

    public void PlayCoop()
    {
        SceneManager.LoadScene("LevelCoop");
    }

    public void PlaySolo()
    {
        SceneManager.LoadScene("LevelSolo");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }

    public void ControlPanel()
    {
        controlPanel.SetActive(true);
    }

    public void BackButton()
    {
        controlPanel.SetActive(false);
    }
}
