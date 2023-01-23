using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// Inventory script, used to manage inventory of ResourceType(s).
    /// </summary>
    [SerializeField]
    private Dictionary<ResourceType, int> Resources { get;}


    public void AddResource(ResourceType resource, int quantity)
    {
        ///Adds resource to inventory
        Resources.Add(resource, quantity);
    }

    public void RemoveResource(ResourceType resource, int quantity)
    {
        ///Removes resource from inventory
        if (!HasResource(resource, quantity)) { return; }
        Resources[resource] -= quantity;
        Resources[resource] = Mathf.Max(0, Resources[resource]);
    }

    public bool HasResource(ResourceType resource, int quantity)
    {
        ///Returns bool whether the quantity of that resource is there
        return Resources.ContainsKey(resource) && (Resources[resource] >= quantity);
    }
}
