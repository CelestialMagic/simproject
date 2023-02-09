using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer
public class Cat : Animal, ISpawnableObject
{
    [SerializeField]
    private List<AudioClip> catNoises;//A list of cat noises

    //Meow() plays a randomized cat noise
    private void Meow()
    {
        AudioClip meow = catNoises[Random.Range(0, catNoises.Count - 1)];
        PlaySound(meow, volume);

    }

    //Cat overrides the MakeNoise() in order to account for Meow(), which
    //selects a random audioclip to play 
    protected override void MakeNoise(AudioClip noise, float volume)
    {
        if (audioTimer - Time.deltaTime <= 0)
        {
            Meow();
            audioTimer = Random.Range(resetTimer - waitPeriod, resetTimer + waitPeriod);
        }
        else
        {
            audioTimer -= Time.deltaTime;
        }
    }
}
