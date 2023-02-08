using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : Building, ISpawnableObject
{
    [SerializeField]
    private List<float> moneyMultipliers;//A list of floats representing multiplier values


    
    //Overridden GenerateMoney() method generates a random multiplier and multiplies
    //it by the generateAmount
    protected override void GenerateMoney()
    {
        float randomMultiplier = moneyMultipliers[Random.Range(0, moneyMultipliers.Count)];
        MoneyManager.SetCurrentIncome(generateAmount * randomMultiplier);
    }

    //Overridden SetDisplayText()reflects unique behavior of Restaurant, which
    //can generate at or a multiple of the generateAmount
    protected override void SetDisplayText()
    {
        displayText.text = $"${generateAmount}+ per {resetTimer} seconds";
    }
}
