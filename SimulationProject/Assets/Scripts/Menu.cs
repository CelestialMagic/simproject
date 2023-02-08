using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Menu Code to be used in next playtest (not currently implemented)
public class Menu : MonoBehaviour
{
    //Subscribes to closed menu
    private void Awake()
    {
        MenuManager.MenuControl += Close;
    }
    //Opens menu
    private void Open()
    {
        gameObject.SetActive(true);
    }
    //closes menu
    private void Close()
    {
        gameObject.SetActive(false);

    }


}
