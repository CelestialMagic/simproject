using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeBuilding : Building, ISpawnableObject
{
    //Decorative Building overrides GenerateMoney() in order to gradually
    //increase the generateAmount value by 1. 
    protected override void GenerateMoney()
    {
        generateAmount++;
        MoneyManager.SetCurrentIncome(generateAmount);
        SetDisplayText();
    }
}
