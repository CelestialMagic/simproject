using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<ObjectFactory> objects = new List<ObjectFactory>();

    [SerializeField]
    private int currentIndex;

    private bool isTouchingPen;

    // Update is called once per frame
    void Update()
    {
        int objListLength = objects.Count;

        //user selects choice
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (objects[currentIndex] is Animal && isTouchingPen)
            {
                ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;
                ((Animal)objects[currentIndex]).CreateObject();
            }

        }

        //user cycles left (down in objects list)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentIndex != 0 && currentIndex >= 0 && objListLength > 1)
            {
                currentIndex -= 1;
            }
        }

        //user cycles right (up in objects list)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (objListLength > (currentIndex + 1) && objListLength > 1)
            {
                currentIndex += 1;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTouchingPen = true;
            Debug.Log("Touching pen works.");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTouchingPen = false;
        }
    }
}