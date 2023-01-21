using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Create/Custom/GeneratorType")]
public class GeneratorType : ScriptableObject
{
    [SerializeField]
    public ResourceType resource;
    [SerializeField]
    public float rateOfSpawn;
}
