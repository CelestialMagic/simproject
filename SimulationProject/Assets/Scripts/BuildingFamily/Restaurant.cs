using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Brandon Lo, Noel Paredes, and Jessie Archer
public class Restaurant : Building, ISpawnableObject
{
    //restaurant generates a random amount of money between
    // min and max
    [SerializeField]
    protected int min;//The minimum amount of money to generate
    [SerializeField]
    protected int max;//The maximum amount of money to generate

    //Overridden GenerateMoney() method generates a random amount of money
    protected override void GenerateMoney()
    {
        int rand = Random.Range(min, max);
        MoneyManager.SetCurrentIncome(rand);
    }

    //Overridden SetDisplayText()reflects unique behavior of Restaurant by
    //displaying the range of money at a constant time
    protected override void SetDisplayText()
    {
        displayText.text = $"${min} to ${max} per {resetTimer} seconds.";
    }
}
