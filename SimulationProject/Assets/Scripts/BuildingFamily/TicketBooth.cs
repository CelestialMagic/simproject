using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketBooth : Building, ISpawnableObject
{
    [SerializeField] private int moneyIncrement;
    [SerializeField] private MoneyManager moneyManager;

    // Update is called once per frame
    void Update()
    {
        if (generateTimer - Time.deltaTime <= 0)
        {
            GenerateMoney();
            generateTimer = resetTimer;

        }
        else
        {
            generateTimer -= Time.deltaTime;
        }

    }

    protected override void GenerateMoney()
    {
        moneyManager.SetCurrentIncome(generateAmount);
    }


}
