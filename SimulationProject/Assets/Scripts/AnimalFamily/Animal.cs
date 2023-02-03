using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : ObjectFactory
{
    
    [SerializeField]
    protected AudioClip noise;//An AudioClip representing an animal noise

    [SerializeField]
    protected float volume;//The volume of the animal noise played

    [SerializeField]
    protected AudioSource audioSource;//The audio source for the animal

    [SerializeField]
    protected float audioTimer;//The countdown variable to play audio

    [SerializeField]
    protected float resetTimer;//A float to reset the timer to a given time

    [SerializeField]
    protected float waitPeriod;//A float representing seconds to vary when
                               //sound is played


    [SerializeField] GameObject m_prefab;//Animal prefab
    [SerializeField] int m_cost;//Animal cost

    public GameObject prefab//Get and Set established for Interface field prefab
    {
        get { return m_prefab; }
        set { prefab = m_prefab; }
    }

    
    public int cost//Get and Set established for Interface field cost
    {
        get { return m_cost; }
        set { cost = m_cost; }
    }

    //Plays an audioclip
    protected void PlaySound(AudioClip sound, float volume)
    {
        audioSource.PlayOneShot(sound, volume);
    }



    //Code for creating an AnimalObject
    public override void CreateObject()
    {
        Instantiate(gameObject);
    }

    //Update() is used primarily to play animal sound effects
    //This may be overridden for various AI behaviors
    protected virtual void Update()
    {
        MakeNoise(noise, volume);
    }

    //A method used to play a sound after a given time
    protected virtual void MakeNoise(AudioClip noise, float volume)
    {

        if (audioTimer - Time.deltaTime <= 0)
        {
            PlaySound(noise, volume);
            audioTimer = Random.Range(resetTimer - waitPeriod, resetTimer + waitPeriod);
         
        }
        else
        {
            audioTimer -= Time.deltaTime;
        }
    }

    
}
