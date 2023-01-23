using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Purchasable : ScriptableObject
{
    /// <summary>
    /// Base class for purchasables, used by UI to display options
    /// </summary>
    [SerializeField]
    public List<(ResourceType, int)> Cost { get; private set; }
    [SerializeField]
    public string Description { get; private set; }

    [SerializeField]
    public Sprite Icon { get; private set; }

    public bool CanPurchase(Inventory inventory)
    {
        ///Compares a player's resources with this cost, returning a bool if the player has enough resources
        foreach(var info in Cost)
        {
            (ResourceType resource, int amount) = info;
            if (!inventory.HasResource(resource, amount))
            {
                return false;
            }
        }
        return true;
    }
    
    public virtual bool Purchase(Inventory inventory)
    {
        ///Returns a bool depending on whether the transaction was possible
        ///Removes resources from the inventory passed in
        if (!CanPurchase(inventory))
        {
            Debug.Log("INSUFFICIENT PURCHASING FUNDS");
            return false;
        }
        foreach(var info in Cost)
        {
            (ResourceType resource, int amount) = info;
            inventory.RemoveResource(resource, amount);
        }
        return true;
    }
}
