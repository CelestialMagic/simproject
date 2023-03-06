using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Code by Jessie Archer
public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;//Text used to display current money
    private static float currentIncome;//The player's current income in-game


    // Update() works to display the current amount of money to the screen
    public void Update()
    {
        displayText.text = "$" + GetCurrentIncome().ToString();
    }

    //Returns the Current Amount of Money
    public static float GetCurrentIncome()
    {
        return currentIncome;
    }
    //Sets the current amount of money through addition
    public static void SetCurrentIncome(float amount)
    {
        currentIncome += amount;

    }
    //Deducts player bought item costs from the currentIncome. 
    public static void BuyItem(float amount)
    {
        currentIncome -= amount;

    }

    //Resets the amount of money earned by the player
    public static void ResetMoney()
    {
        currentIncome = 0;
    }

    
}
