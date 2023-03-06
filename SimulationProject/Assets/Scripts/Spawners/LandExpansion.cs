using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Jessie Archer and Brandon Lo
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
    //Spawn Display values are instantiated
    private void Start()
    {
        spawnDisplay.SetName(landName);
        spawnDisplay.SetCost(landCost);
        spawnDisplay.SetDescription(landDescription);
    }
    //Calls SpawnObject() to check if player is purchasing it. 
    private void Update()
    {
        SpawnObject();
    }
    //SpawnObject determines 
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
                        MoneyManager.BuyItem(landCost);//Deducts money spent
                        LocationManager.ToggleExpansionPurchased();//Sets expansion locations to open
                        LocationManager.SetAccessibleLocations();//Expands the locations available to visitors
                        Destroy(purchaseGate);//Destroys barrier preventing players from entering expansion
                    }
                    break;

                default:
                    break;
            }
        }
    }

}
