using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnableObject
{
    GameObject prefab { get; set; }
    int cost { get; set; }

}