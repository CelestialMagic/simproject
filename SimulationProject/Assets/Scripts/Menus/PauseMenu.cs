using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool GamePaused = false;
    [SerializeField]
    private GameObject PauseMenuUI;

    public void Awake()
    {
        //When the game is run, the pause menu will not show
        PauseMenuUI.SetActive(false);
    }

    public void Update()
    {
        //When the esc key is pressed, the pause menu will open
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume(); //if the game is already paused, pressing esc again will resume it
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false); //closes pause menu
        Time.timeScale = 1f; //unfreezes the game when pause menu is closed
        GamePaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true); //opens pause menu
        Time.timeScale = 0f; //freezes the game when pause menu is open
        GamePaused = true;
    }

    public void Restart()
    {
        //Time.timeScale = 1f; //unfreezes the game when restarted
        //GameStateManager.Restart();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f; //unfreezes the game
        SceneManager.LoadScene(0); //Loads menu scene (build index of 0)
    }

    public void Quit()
    {
        Application.Quit(); //quits game
    }
}