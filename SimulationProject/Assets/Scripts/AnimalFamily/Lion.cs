using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Animal, ISpawnableObject
{


    //lion roars if the player gets too close
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MakeNoise(defaultSound, volume);
        }
    }
}
