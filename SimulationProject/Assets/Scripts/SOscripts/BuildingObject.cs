using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
[CreateAssetMenu(menuName = "Create/Custom/BuildingObject")]
public class BuildingObject : Purchasable
{
    ///UNTESTED. (remove this line when tested)

    [SerializeField]
    public Building Prefab;

    public Building Spawn(Vector3 position, Quaternion rotation) 
    {
        //Spawns in the object
        Building instance = GameObject.Instantiate(Prefab, position, rotation);
        return instance;//the return is currently unused
    }
}
