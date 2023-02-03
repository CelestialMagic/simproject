using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal, ISpawnableObject
{

    [SerializeField]
    private int cluckTimes;//An average number to play cluck sound


    // Update is called once per frame
    protected override void Update()
    {
        
    }

    private void Cluck()
    {
        for(int i = 0; i < cluckTimes; i++)
        {
            PlaySound(defaultSound, cluckTimes);
        }
    }
}
