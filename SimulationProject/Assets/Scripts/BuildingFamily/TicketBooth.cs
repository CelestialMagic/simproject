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
        
    }

    protected override void GenerateMoney()
    {
        if(generateTimer % moneyIncrement == 0)
        {
            moneyManager.SetCurrentIncome(generateAmount);
        }
    }


}
