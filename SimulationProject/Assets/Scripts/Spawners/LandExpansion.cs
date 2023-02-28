using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandExpansion : PurchaseObject 
{
    [SerializeField]
    private int landCost;//A float representing the cost of the expansion

    [SerializeField]
    private string landName;//A name for the expansion

    [SerializeField]
    private string landDescription;//A description for the expansion

    [SerializeField]
    private GameObject purchaseGate;//The gameobject barrier

    private void Start()
    {
        spawnDisplay.SetName(landName);
        spawnDisplay.SetCost(landCost);
        spawnDisplay.SetDescription(landDescription);
    }
    private void Update()
    {
        SpawnObject();
    }

    protected override void SpawnObject()
    {
        //Null check for player
        if (currentPlayer != null)
        {
            float place = currentPlayer.GetMenuPlace();
            //Switch statement executes based on input
            switch (place)
            {
                //No key press
                case 0:
                    if (placeIsHeld)
                        placeIsHeld = false;
                    break;

                //Player presses button to place object
                case 1:
                    if (!placeIsHeld && isTouchingPen && landCost <= MoneyManager.GetCurrentIncome())
                    {
                        MoneyManager.BuyItem(landCost);
                        LocationManager.SetAccessibleLocations(true);
                        Destroy(purchaseGate);
                    }
                    break;

                default:
                    break;
            }
        }
    }

}
