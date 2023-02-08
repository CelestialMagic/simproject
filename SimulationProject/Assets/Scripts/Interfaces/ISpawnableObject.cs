using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ISpawnableObject is used by both Animal and Building subclasses
public interface ISpawnableObject
{
    GameObject prefab { get; set; }//Get and Set for prefab GameObject
    int cost { get; set; }//Get and Set for cost int
    string name { get; set; }//Get and Set for string name
    string description { get; set; }//Get and Set for string description


}
