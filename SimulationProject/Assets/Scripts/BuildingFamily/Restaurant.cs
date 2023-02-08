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
        float rand = Random.Range(min, max);
        MoneyManager.SetCurrentIncome(rand);
    }

    protected override void SetDisplayText()
    {
        displayText.text = $"${min} up to ${max} per {resetTimer} seconds.";
    }
}
