using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action TempGameOver;  

    private static GAMESTATE m_State; //The current game state

    private static GameStateManager _instance; //This class is a Singleton - We will also discuss this pattern later in this class.


    //An enum that represents the game states. 
    enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER


    }



    // Start is called before the first frame update
    void Start()
    {
        //Singleton Code
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

  
        m_State = GAMESTATE.MENU;

    }



    //StartGame() is used to start the game.
    public static void StartGame()
    {
        m_State = GAMESTATE.PLAYING;
       
    }



    //Menu() loads the menu screen
    public static void Menu()
    {
        m_State = GAMESTATE.MENU;

    }



}





