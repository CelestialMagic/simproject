using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Jessie Archer
public abstract class ObjectFactory : MonoBehaviour
{
    //A creation method to be determined by Building and Animal classes
    public abstract void CreateObject();

    //Returns a spawned object to be added to list in Spawner code
    public virtual GameObject ReturnSpawnedObject()
    {
        GameObject spawnedObject = Instantiate(gameObject);
        return spawnedObject;
    }

}
