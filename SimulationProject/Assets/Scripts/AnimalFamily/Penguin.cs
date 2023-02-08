using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : Animal, ISpawnableObject
{
    [SerializeField]
    private List<AudioClip> penguinSFX;

    private int currentIndex; 

    // Update is called once per frame
    protected override void Update()
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
}
