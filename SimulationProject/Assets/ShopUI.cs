using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    ///UNTESTED
    /// <summary>
    /// IMPORTANT: MIGHT CHANGE THE NAME OF THIS!
    /// </summary>
    /// 

    public List<Purchasable> items;
    [SerializeField]
    private int currentIndex = 0;
    public void Next()
    {
        //Changes current index to the next one
        currentIndex = (currentIndex + 1) % items.Count;
    }
    public void Previous()
    {
        //Changes current index to the previous one
        currentIndex = (currentIndex - 1 ) % items.Count;
    }
    public virtual bool PurchaseCurrent(Inventory inventory)
    {
        ///Attempts to purchase the current item. Returns bool representing success of purchase
        bool result = items[currentIndex].Purchase(inventory);
        return result;
    }
    
    public Purchasable GetCurrent()
    {
        ///Gets currently selected purchasable
        Debug.Log("RUnning");
        Debug.Log(currentIndex);
        Debug.Log(items);
        return items[currentIndex];
    }

    public Purchasable GetNext()
    {
        ///Gets purchasable to the right of current selected
        return items[(currentIndex + 1) % items.Count];
    }
    public Purchasable GetPrevious()
    {
        ///Gets purchasable to the left of current selected
        return items[(currentIndex - 1) % items.Count];
    }
}
