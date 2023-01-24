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


    void Update()
    {
        //THIS UPDATE WILL BE DELETED LATER
        if (Input.GetKeyDown(KeyCode.X))
        {
            BuildingObject buildingObject = (BuildingObject) GetCurrent(); //Typecasting the current purchasable into as a building
            Vector3 spawnPosition = player.transform.position + player.transform.forward.normalized * 20;
            buildingObject.Spawn(spawnPosition, player.transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.Z)) {
            Next();
        }
        if(Input.GetKeyDown(KeyCode.C)) {
            Previous();
        }
    }
}
