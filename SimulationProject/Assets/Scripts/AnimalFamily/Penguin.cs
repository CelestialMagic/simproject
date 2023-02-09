using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : Animal, ISpawnableObject
{
    //Instantiated by Noel Paredes
    //Major Refinements/Additions by Jessie Archer
    [SerializeField]
    private List<AudioClip> penguinSFX;//A list of penguin AudioClips

    private int currentIndex;//An int representing the current index of penguinSFX

    //PenguinSounds() cycles through the available penguin audioclips
    private void PenguinSounds()
    {
        if(currentIndex >= penguinSFX.Count)
        {
            currentIndex = 0;
        }
            PlaySound(penguinSFX[currentIndex], volume);
            currentIndex++;
    }

    //Penguin overrides MakeNoise() to account for the unique audio cycling
    //behavior
    protected override void MakeNoise(AudioClip noise, float volume)
    {
        if (audioTimer - Time.deltaTime <= 0)
        {
            PenguinSounds();
            audioTimer = Random.Range(resetTimer - waitPeriod, resetTimer + waitPeriod);

        }
        else
        {
            audioTimer -= Time.deltaTime;
        }

    }

}
