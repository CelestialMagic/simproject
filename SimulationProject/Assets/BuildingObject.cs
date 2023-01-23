using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create/Custom/Building")]
public class BuildingObject : ScriptableObject
{

    [SerializeField]
    private Building prefab;

    public Building Spawn(PlayerMovement player)
    {
        Building instance = GameObject.Instantiate(prefab, player.transform.position, Quaternion.identity);
        return instance;
    }
}
