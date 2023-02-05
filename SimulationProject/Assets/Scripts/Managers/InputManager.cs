using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool inRange = false;

    // Update is called once per frame
    private void Update()
    {
        //if X is pressed inside the build zone
        if (Input.GetKeyDown(KeyCode.X) && inRange)
        {
            Debug.Log("Open build menu");
        }

        //
    }

    private void OnTriggerEnter(Collider other) 
    //building checker for opening menus
    {
        switch (other.tag)
        {
            case "Building":
                inRange = true;
                Debug.Log("player reached building");
                break;
            case "AnimalPen":
                inRange = true;
                Debug.Log("player reached animal pen");
                break;
            case "WatchRoom":
                inRange = true;
                Debug.Log("player reached watch room");
                break;

            default:
                break;
        }

    }

    private void OnTriggerExit(Collider other) 
     //resets inRange value if player leaves
    {
        inRange = false;
        Debug.Log("player has exited");
    }

    public void Notify()
    {

    }
}
