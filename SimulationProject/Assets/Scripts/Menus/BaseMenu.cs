using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject menu;

    //Opens the menu
    public void Open()
    {
        menu.SetActive(true);
    }
    //Closes the menu
    public void Close()
    {
        menu.SetActive(false);
    }
}
