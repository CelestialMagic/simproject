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

    protected void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }


}
