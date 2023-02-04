using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<ObjectFactory> objects = new List<ObjectFactory>();

    [SerializeField]
    private int currentIndex;

    // Update is called once per frame
    void Update()
    {
        //user selects choice
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (objects[currentIndex] is Animal)
            {
                ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;
                ((Animal)objects[currentIndex]).CreateObject();
            }

        }

        //user cycles left (down in objects list)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentIndex -= 1;
        }

        //user cycles right (up in objects list)
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentIndex += 1;
        }
        
    }
}
