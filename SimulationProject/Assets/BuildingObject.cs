using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
[CreateAssetMenu(menuName = "Create/Custom/Building")]
public class BuildingObject : Purchasable
{

    [SerializeField]
    public Building Prefab { get; }

    public Building Spawn(Vector3 position, Quaternion rotation) 
    {
        //Spawns in the object
        Building instance = GameObject.Instantiate(Prefab, position, rotation);
        return instance;//the return is currently unused
    }
}
