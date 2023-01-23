using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : ShopUI
{
    /// <summary>
    /// An implementation of the ShopUI, with BuildingObjects as purchasables
    /// </summary>

    [SerializeField]
    private PlayerMovement player;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            BuildingObject buildingObject = (BuildingObject) GetCurrent(); //Typecasting the current purchasable into as a building
            buildingObject.Spawn(player.transform.position, player.transform.rotation);
        }
    }
}
