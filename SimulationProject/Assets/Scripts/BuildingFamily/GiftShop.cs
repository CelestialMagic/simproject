using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftShop : Building, ISpawnableObject
{
    //GiftShop generates income on a random interval between minSec and maxSec
    [SerializeField]
    protected int minSec;
    [SerializeField]
    protected int maxSec;

    //Sets the first resetTimer to be random on start
    protected void Start()
    {
        resetTimer = Random.range(minSec, maxSec);
    }

    //Has to implement GenerateMoney
    protected override void GenerateMoney()
    {
        MoneyManager.SetCurrentIncome(generateAmount);
    }

    //resetTimer is randomized every time money is generated
    protected void Update()
    {
        if (generateTimer - Time.deltaTime <= 0)
        {
            GenerateMoney();
            generateTimer = resetTimer;
            resetTimer = Random.range(minSec, maxSec);

        }
        else
        {
            generateTimer -= Time.deltaTime;
        }

    }
}
