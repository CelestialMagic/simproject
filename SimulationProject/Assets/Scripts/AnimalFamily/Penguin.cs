using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : Animal, ISpawnableObject
{
    public override void CreateObject()
    {
        Instantiate(gameObject);
    }
}
