using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal, ISpawnableObject
{
    [SerializeField] private GameObject m_prefab;

    public GameObject prefab { get { return m_prefab; }
        set { prefab = m_prefab; } }

    [SerializeField] private int m_cost;
    public int cost
    {
        get { return m_cost; }
        set { cost = m_cost; }
    }


    public override void CreateObject()
    {
        Instantiate(gameObject);
    }

    private void Update()
    {
        if(audioTimer - Time.deltaTime <= 0)
        {
            PlaySound(noise, volume);
            audioTimer = resetTimer; 
        }
        else
        {
            audioTimer -= Time.deltaTime;
        }
    }
}
