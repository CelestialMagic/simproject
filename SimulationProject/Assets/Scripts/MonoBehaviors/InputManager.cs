using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool inRange;
    // Update is called once per frame
    void Update()
    {
        //if X is pressed inside the build zone
        if (Input.GetKeyDown(KeyCode.X))
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
    }
}
