using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : Building, ISpawnableObject
{
    [SerializeField]
    private List<float> moneyMultipliers;


    
    //Overridden GenerateMoney() method generates a random amount
    protected override void GenerateMoney()
    {
        float randomMultiplier = moneyMultipliers[Random.Range(0, moneyMultipliers.Count)];
        MoneyManager.SetCurrentIncome(generateAmount * randomMultiplier);
    }

    //Overridden SetDisplayText()reflects unique behavior of Restaurant
    protected override void SetDisplayText()
    {
        displayText.text = $"${generateAmount} x multiplier";
    }
}
