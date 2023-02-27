using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Animal, ISpawnableObject
{
    //The overridden Update() method removes the MakeNoise() method.
    //The inherited version will automatically play sound. 
    protected override void Update()
    {
        LocateNextSpot();
    }

    //lion roars if the player gets too close
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MakeNoise(defaultSound, volume);
        }
    }

    //lion stops roaring once player leaves trigger
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audioTimer = resetTimer;
        }
    }
}
