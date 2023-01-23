using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField]
    private List<BuildingObject> buildings;

    [SerializeField]
    private PlayerMovement player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            buildings[0].Spawn(player);
        }
    }
}
