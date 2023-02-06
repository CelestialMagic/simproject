using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        MenuManager.MenuControl += Close;
    }

    private void Open()
    {
        gameObject.SetActive(true);
    }

    private void Close()
    {
        gameObject.SetActive(false);

    }


}
