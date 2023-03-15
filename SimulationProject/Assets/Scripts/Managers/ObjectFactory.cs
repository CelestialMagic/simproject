using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//Code by Jessie Archer
public abstract class ObjectFactory : MonoBehaviour
{
    //A creation method to be determined by Building and Animal classes
    public abstract void CreateObject();

    //Returns a spawned object to be added to list in Spawner code
    public virtual GameObject ReturnSpawnedObject(string prefabName, Vector3 spawnLocation)
    {
        GameObject spawnedObject = PhotonNetwork.Instantiate(prefabName, spawnLocation, gameObject.transform.rotation, 0);
        return spawnedObject;
    }

}
