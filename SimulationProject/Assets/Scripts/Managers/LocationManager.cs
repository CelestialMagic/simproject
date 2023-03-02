using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer and Brandon Lo
public class LocationManager : MonoBehaviour
{
    
    private static List<GameObject> activeLocations = new List<GameObject>();//The player's current income in-game
    private static List<GameObject> accessibleLocations = new List<GameObject>();

    //Returns the Current Amount of Money
    public static void AddLocation(GameObject location)
    {
        activeLocations.Add(location);
    }
    //Sets the current amount of money through addition
    public static void RemoveLocation(GameObject location)
    {
        activeLocations.Remove(location);

    }

    public static void SetAccessibleLocations(bool expansionPurchased)
    {
        //Before the expansion is purchased, only make the pens in the starting area accessible
        if (!expansionPurchased)
        {
            for (int i = 0; i < activeLocations.Count; i++)
            {
                if (activeLocations[i].tag != "ExpansionPen")
                {
                    accessibleLocations.Add(activeLocations[i]);
                }
            }
        }
        else
        {
            accessibleLocations = activeLocations;
        }
       
    }

    public static List<GameObject> GetAccessibleLocations()
    {
        return accessibleLocations; 
    }

    public static void ResetLists()
    {
        activeLocations = new List<GameObject>();
        accessibleLocations = new List<GameObject>();
    }
 
}
