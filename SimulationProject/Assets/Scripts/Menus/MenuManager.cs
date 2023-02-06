using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    private GameObject[] menuTypes;
    [SerializeField]
    private GameObject playerToListen;

    public static Action MenuControl;

    [SerializeField]
    private InputManager pInput; 

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


    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);

    }
}
