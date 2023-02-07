using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TicketBooth : Building, ISpawnableObject
{
   
    protected override void GenerateMoney()
    {
        MoneyManager.SetCurrentIncome(generateAmount);
    }

 



}
