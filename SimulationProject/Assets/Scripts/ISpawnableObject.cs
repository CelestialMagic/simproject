using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnableObject
{
    GameObject prefab { get;  }
    int cost { get; }



}
