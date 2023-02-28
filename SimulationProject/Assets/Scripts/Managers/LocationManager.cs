using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    private static List<GameObject> activeLocations = new List<GameObject>();//The player's current income in-game


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

    public static List<GameObject> GetActiveLocations()
    {
        return activeLocations; 
    }
 
}
