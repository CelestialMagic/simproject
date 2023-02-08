using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : Building, ISpawnableObject
{
    //restaurant generates a random amount of money between
    // min and max
    [SerializeField]
    protected int min;
    [SerializeField]
    protected int max;

    //Overridden GenerateMoney() method generates a random amount
    protected override void GenerateMoney()
    {
        int rand = Random.Range(min, max);
        MoneyManager.SetCurrentIncome(rand);
    }

    //Overridden SetDisplayText()reflects unique behavior of Restaurant
    protected override void SetDisplayText()
    {
        displayText.text = $"${min} to ${max} per {resetTimer} seconds.";
    }
}
