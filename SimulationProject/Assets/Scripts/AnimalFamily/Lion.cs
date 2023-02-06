using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Animal, ISpawnableObject
{
    public AudioSource RoarAudio;
    public AudioClip LionRoar;

    //lion roars if the player gets too close
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RoarAudio.clip = LionRoar;
            RoarAudio.Play();
        }
    }
}
