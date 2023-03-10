using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//Code by Brandon Lo
//InputManager is a deprecated script. It has been scrapped in favor of using
//the Spawner class, which detects players entering the range of the pen
public class InputManager : MonoBehaviour
{
    private bool inRange = false;//Determines if the player is in-range

    // Update is called once per frame
    private void Update()
    {
        //if X is pressed inside the build zone
        if (Input.GetKeyDown(KeyCode.X) && inRange)
        {
            Debug.Log("Open build menu");
        }

    }

    //OnTriggerEnter is used to detect if player has entered the range of
    //buildings and pens
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

    //OnTriggerExit determines if the player has left the trigger radius
    private void OnTriggerExit(Collider other) 
     //resets inRange value if player leaves
    {
        inRange = false;
        Debug.Log("player has exited");
    }

    //Notify() is a method to be used in Playtest 2
    public void Notify()
    {

    }
}
