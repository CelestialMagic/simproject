using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Code by Jessie Archer
public abstract class Animal : ObjectFactory
{
    
    [SerializeField]
    protected AudioClip defaultSound;//An AudioClip representing an animal noise

    [SerializeField]
    protected float volume;//The volume of the animal noise played

    [SerializeField]
    protected AudioSource audioSource;//The audio source for the animal

    [SerializeField]
    protected float audioTimer;//The countdown variable to play audio

    [SerializeField]
    protected float resetAudioTimer;//A float to reset the timer to a given time

    [SerializeField]
    protected float waitPeriod;//A float representing seconds to vary when
                               //sound is played

    [SerializeField]
    protected AnimalBehavior behavior; //The animal behavior attached to the animal


    [SerializeField] GameObject m_prefab;//Animal prefab
    [SerializeField] int m_cost;//Animal cost
    [SerializeField] string m_name;//Animal name
    [SerializeField] string m_prefabName;//Animal name
    [SerializeField] string m_description;//Animal description

    [SerializeField]
    private List<Transform> availableLocations = new List<Transform>();

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

    public string name//Get and Set established for Interface field prefab
    {
        get { return m_name; }
        set { name = m_name; }
    }

    public string prefabName//Get and Set established for Interface field prefab
    {
        get { return m_prefabName; }
        set { prefabName = m_prefabName; }
    }
    public string description//Get and Set established for Interface field prefab
    {
        get { return m_description; }
        set { description = m_description; }
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
    protected virtual void Update()
    {
        MakeNoise(defaultSound, volume);
    }

    //MakeNoise() is used to play a sound after a given time
    protected virtual void MakeNoise(AudioClip noise, float volume)
    {
        //if statement checks if timer is less than or below 0 to start playing
        //audio
        if (audioTimer - Time.deltaTime <= 0)
        {
            PlaySound(noise, volume);
            audioTimer = Random.Range(resetAudioTimer - waitPeriod, resetAudioTimer + waitPeriod);
         
        }
        else //else statement decrements timer
        {
            audioTimer -= Time.deltaTime;
        }
    }

    //Sets up a spawner for the animals and updates the availableLocations
    //for the animal to travel to. These locations are native to the pen
    //the animal is spawned in to avoid the animal seeking other spots. 
    public void SetAnimalLocation(Spawner location)
    {
        availableLocations = location.GetAllSpots();
        List<Vector3> tempPositions = new List<Vector3>();
        foreach(Transform t in availableLocations)
        {
            tempPositions.Add(t.transform.position);
        }
        behavior.SetMoveLocations(tempPositions);

        
    }
    //Returns the Animal Behavior attached to Animal
    public AnimalBehavior GetBehavior()
    {
        return behavior; 
    }



}
