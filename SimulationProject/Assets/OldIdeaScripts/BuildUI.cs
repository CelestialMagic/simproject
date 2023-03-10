using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : ShopUI
{
    ///UNTESTED. (remove this line when tested)
    /// <summary>
    /// An implementation of the ShopUI, with BuildingObjects as purchasables
    /// </summary>

    [SerializeField]
    private PlayerMovement player;

    public override bool PurchaseCurrent(Inventory inventory)
    {
        bool result = base.PurchaseCurrent(inventory);
        if (!result) { return false; }
        SpawnCurrent();
        return result;
    }
    public void SpawnCurrent()
    {
        BuildingObject buildingObject = (BuildingObject)GetCurrent(); //Typecasting the current purchasable into as a building
        //TODO: Calculate a position to put it
        Vector3 spawnPosition = player.transform.position + player.transform.forward.normalized * 20;
        //TODO: implement some sort of collision checking BEFORE spawning
        buildingObject.Spawn(spawnPosition, player.transform.rotation);

    }

    public 
    void Update()
    {
        //THIS UPDATE WILL BE DELETED LATER!!! DELETE THIS WHEN MENU IS IMPLEMENTED
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnCurrent();//Checking to see if spawning works, JUST FOR TESTING PURPOSES.
                           //Should always be called through PurchaseCurrent(). Testingis an exception!
        }
        if(Input.GetKeyDown(KeyCode.C)) {
            Next();
        }
        if(Input.GetKeyDown(KeyCode.Z)) {
            Previous();
        }
    }
}
