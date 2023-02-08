using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

//MenuManager is a work-in-progress script to be developed in Playtest 2
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;//The MenuManager in scene
    [SerializeField]
    private GameObject[] menuTypes;//A list of available menu types
    [SerializeField]
    private GameObject playerToListen;//A player to follow

    public static Action MenuControl;//An action to be eventually used

    [SerializeField]
    private InputManager pInput; //InputManager for player

    //Singleton code
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



}
