using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeBuilding : Building, ISpawnableObject
{

    protected override void GenerateMoney()
    {
        generateAmount++;
        MoneyManager.SetCurrentIncome(generateAmount);
        SetDisplayText();
    }
}
