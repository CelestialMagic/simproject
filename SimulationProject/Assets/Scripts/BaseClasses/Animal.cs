using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField]
    protected GameObject prefab;
    [SerializeField]
    protected int cost;

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
