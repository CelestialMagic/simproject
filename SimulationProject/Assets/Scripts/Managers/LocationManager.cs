using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer and Brandon Lo
public class LocationManager : MonoBehaviour
{
    private static bool expansionPurchased = false;//Bool that shows if expansion was purchased

    private static List<GameObject> activeLocations = new List<GameObject>();//Locations available in the scene
    private static List<GameObject> accessibleLocations = new List<GameObject>();//Locations that can be accessed (expansion)

    //Adds a location to the activeLocations list
    public static void AddLocation(GameObject location)
    {
        activeLocations.Add(location);
    }
    //Removes a location from the active and accessible list
    public static void RemoveLocation(GameObject location)
    {
        Debug.Log(location.name);
        Debug.Log(activeLocations.Remove(location));
        Debug.Log(accessibleLocations.Remove(location));

    }
    //Indicates that the expansion has been purchased
    public static void ToggleExpansionPurchased()
    {
        expansionPurchased = true;
    }
    //Sets the available locations for visitors to enter
    public static void SetAccessibleLocations()
    {
        //Before the expansion is purchased, only make the pens in the starting area accessible
        if (!expansionPurchased)
        {
            for (int i = 0; i < activeLocations.Count; i++)
            {
                if (activeLocations[i].tag != "ExpansionPen" && accessibleLocations.IndexOf(activeLocations[i]) < 0)
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
    //Returns the Accessible Locations
    public static List<GameObject> GetAccessibleLocations()
    {
        return accessibleLocations; 
    }
    //Resets both location lists upon restarting the game
    public static void ResetLists()
    {
        activeLocations = new List<GameObject>();
        accessibleLocations = new List<GameObject>();
        expansionPurchased = false; 
    }
 
}
