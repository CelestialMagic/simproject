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
    protected float resetTimer;//A float to reset the timer to a given time

    [SerializeField]
    protected float waitPeriod;//A float representing seconds to vary when
                               //sound is played

    [SerializeField]
    protected NavMeshAgent agent;//The navmesh agent of the animal

    [SerializeField]
    protected float waitingTime;

    [SerializeField]
    protected float resettingTime;

    [SerializeField] GameObject m_prefab;//Animal prefab
    [SerializeField] int m_cost;//Animal cost
    [SerializeField] string m_name;//Animal name
    [SerializeField] string m_description;//Animal description

    [SerializeField]
    protected float wanderRadius;

    [SerializeField]
    protected float wanderDistance;

    [SerializeField]
    protected float wanderVariance;

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

 

    protected void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    //Update() is used primarily to play animal sound effects
    //This may be overridden for various AI behaviors
    protected virtual void Update()
    {
        MakeNoise(defaultSound, volume);
        LocateNextSpot();
    }

    //MakeNoise() is used to play a sound after a given time
    protected virtual void MakeNoise(AudioClip noise, float volume)
    {
        //if statement checks if timer is less than or below 0 to start playing
        //audio
        if (audioTimer - Time.deltaTime <= 0)
        {
            PlaySound(noise, volume);
            audioTimer = Random.Range(resetTimer - waitPeriod, resetTimer + waitPeriod);
         
        }
        else //else statement decrements timer
        {
            audioTimer -= Time.deltaTime;
        }
    }

    //For now, allows AnimalObjects to wander inside pens, which contain NavMeshes
    Vector3 moveTarget = Vector3.zero;
    //In case the position is outside the navmesh bounds, this value will check for nearby valid destinations.
    [SerializeField]
    protected float findDestination = 1.0f;

    protected void LocateNextSpot()
    {
        NavMeshHit hit;
        if (waitingTime - Time.deltaTime <= 0)
        {

            moveTarget += new Vector3(Random.Range(-wanderRadius, wanderRadius) * wanderVariance,
                0, Random.Range(-wanderRadius, wanderRadius) * wanderVariance);

            moveTarget.Normalize();
            moveTarget *= wanderRadius;

            Vector3 targetLocal = moveTarget + new Vector3(0, 0, wanderDistance);
            Vector3 targetGlobal = this.gameObject.transform.InverseTransformVector(targetLocal);

            if (NavMesh.SamplePosition(targetGlobal, out hit, findDestination, NavMesh.AllAreas))
            {
                agent.SetDestination(targetGlobal);
            }
            else if (!NavMesh.SamplePosition(targetGlobal, out hit, findDestination, NavMesh.AllAreas))
            {
                Vector3 tLocal = moveTarget + new Vector3(0, 0, -wanderDistance);
                Vector3 tGlobal = this.gameObject.transform.InverseTransformVector(tLocal);

                agent.SetDestination(tGlobal);
            }

            waitingTime = resettingTime;
        }
        else
        {
            waitingTime -= Time.deltaTime;
        }
    }


}
