using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeBuilding : Building, ISpawnableObject
{
    [SerializeField]
    private float money; 
    // Update is called once per frame
    private void Update()
    {
        GenerateMoney();

    }
    protected override void GenerateMoney()
    {
        MoneyManager.SetCurrentIncome(money);
    }
}
