using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal, ISpawnableObject
{
    public GameObject prefab
    {
        get;

        [SerializeField]
        private set;
    }
    public int cost
    {
        get;

        [SerializeField]
        private set;
    }

  
}
