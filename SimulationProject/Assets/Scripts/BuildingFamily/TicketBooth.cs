using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Code by Jessie Archer
public class TicketBooth : Building, ISpawnableObject
{
    //TicketBooth uses GenerateMoney() to generate a constant amount of money
    //at the same amount of time. 
    protected override void GenerateMoney()
    {
        MoneyManager.SetCurrentIncome(generateAmount);
    }

}
