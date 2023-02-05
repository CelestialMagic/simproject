using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool inRange;

    // Update is called once per frame
    void Update()
    {
        //if X is pressed inside the build zone
        if (Input.GetKeyDown(KeyCode.X) && inRange)
        {
            Debug.Log("Open build menu");
        }
    }

    void OnCollisionEnter(Collision collision) //building checker
    {
        if (collision.collider.tag == "Building")
        {
            inRange = true;
            Debug.Log("player reached building");
        }
        else if (collision.collider.tag == "AnimalPen")
        {
            inRange = true;
            Debug.Log("player reached animal pen");
        }
        else if (collision.collider.tag == "WatchRoom")
        {
            inRange = true;
            Debug.Log("player reached watch room");
        }
    }
}
