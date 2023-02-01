using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : ObjectFactory
{
    [SerializeField]
    protected AudioClip noise;

    [SerializeField]
    protected float volume;

    [SerializeField]
    protected AudioSource audioSource;

    [SerializeField]
    protected float audioTimer;

    [SerializeField]
    protected float resetTimer;

    protected void PlaySound(AudioClip sound, float volume)
    {
        audioSource.PlayOneShot(sound, volume);
    }


}
