using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal, ISpawnableObject
{
    [SerializeField]
    private List<AudioClip> chickenNoises;//A list of chicken noises to play

    // Update is called once per frame
    protected override void Update()
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


    private void Cluck()
    {
        foreach(AudioClip ac in chickenNoises)
        {
            PlaySound(ac, volume);
            
        }
    }
}
