using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Jessie Archer
public class GiftShop : Building, ISpawnableObject
{
    [SerializeField]
    private float generateBuffer;//A float representing a buffer time to generate money

    //Overridden Update() sets a random amount of time to generate money next
    protected override void Update()
    {
        if (generateTimer - Time.deltaTime <= 0)
        {
            GenerateMoney();
            generateTimer = Random.Range(resetTimer - generateBuffer, resetTimer + generateBuffer);

        }
        else
        {
            generateTimer -= Time.deltaTime;
        }

    }
    //Overridden GenerateMoney() method generates a random amount
    protected override void GenerateMoney()
    {
        MoneyManager.SetCurrentIncome(generateAmount);
    }

    //Overridden SetDisplayText()reflects unique behavior of Restaurant
    protected override void SetDisplayText()
    {
        displayText.text = $"${generateAmount} for every {resetTimer - generateBuffer} to {resetTimer + generateBuffer} seconds.";
    }
}
