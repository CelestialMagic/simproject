using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TicketBooth : Building, ISpawnableObject
{
    [SerializeField]
    private int moneyIncrement;


    
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
        MoneyManager.SetCurrentIncome(generateAmount);
    }

 



}
