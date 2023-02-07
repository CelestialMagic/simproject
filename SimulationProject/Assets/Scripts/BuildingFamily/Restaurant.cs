using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : Building, ISpawnableObject
{
    //restaurant generates a random amount of money between
    //x and y
    [SerializeField]
    protected float min;
    [SerializeField]
    protected float max;

    protected override void GenerateMoney()
    {
        //Random rand = new Random();
        //generateAmount = rand.Next(min, max + 1);
        MoneyManager.SetCurrentIncome(generateAmount);
    }
}
