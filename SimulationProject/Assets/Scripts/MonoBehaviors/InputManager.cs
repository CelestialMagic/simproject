using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool inRange;
    [SerializeField]
    private GameObject player; 

    // Update is called once per frame
    private void Update()
    {
        //if X is pressed inside the build zone
        if (Input.GetKeyDown(KeyCode.X) && inRange)
        {
            Debug.Log("Open build menu");
        }
    }

    private void OnTriggerEnter(Collider other) //building checker
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
}
