using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal, ISpawnableObject
{
    //The Update Method will eventually be changed in the Dog class to
    //account for NavMesh
    //Dog is a basic animal, so it follows the Animal class behavior
    protected override void Update()
    {
        base.Update();
    }

}
