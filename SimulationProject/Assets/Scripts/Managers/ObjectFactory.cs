using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectFactory : MonoBehaviour
{
    //A creation method to be determined by Building and Animal classes
    public abstract void CreateObject();

}
