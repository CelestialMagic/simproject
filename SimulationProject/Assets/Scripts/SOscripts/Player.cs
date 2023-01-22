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

}
