using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/Custom/Player")]
public class Player : ScriptableObject
{
    [SerializeField]
    public PlayerMovement prefab;
    [SerializeField]
    public Color color;


    public PlayerMovement Spawn()
    {
        PlayerMovement instance = GameObject.Instantiate(prefab);
        instance.Initialize(color);
        return instance;
    }
}
