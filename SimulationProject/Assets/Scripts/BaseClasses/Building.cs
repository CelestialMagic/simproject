using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : ObjectFactory
{
    
    

    public override void CreateObject()
    {
        Instantiate(gameObject);
    }

}
