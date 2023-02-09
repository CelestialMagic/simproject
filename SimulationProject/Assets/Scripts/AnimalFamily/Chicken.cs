using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer
public class Chicken : Animal, ISpawnableObject
{
    [SerializeField]
    private List<AudioClip> chickenNoises;//A list of chicken noises to play

    //Cluck() cycles through all audioclips and plays them
    private void Cluck()
    {
        foreach(AudioClip ac in chickenNoises)
        {
            PlaySound(ac, volume);
            
        }
    }

    //Chicken overrides MakeNoise() to call the Cluck() method
    protected override void MakeNoise(AudioClip noise, float volume)
    {
        if (audioTimer - Time.deltaTime <= 0)
        {
            Cluck();
            audioTimer = Random.Range(resetTimer - waitPeriod, resetTimer + waitPeriod);

        }
        else
        {
            audioTimer -= Time.deltaTime;
        }
    }
}
