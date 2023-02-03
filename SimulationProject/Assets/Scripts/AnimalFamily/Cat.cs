using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal, ISpawnableObject
{
    [SerializeField]
    private List<AudioClip> catNoises;//A list of cat noises

    protected override void Update()
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

    //Meow() plays a randomized cat noise
    private void Meow()
    {
        AudioClip meow = catNoises[Random.Range(0, catNoises.Count - 1)];
        PlaySound(meow, volume);

    }
}
