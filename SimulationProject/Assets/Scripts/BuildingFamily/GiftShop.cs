using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftShop : Building, ISpawnableObject
{
    [SerializeField]
    private float generateBuffer;


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
