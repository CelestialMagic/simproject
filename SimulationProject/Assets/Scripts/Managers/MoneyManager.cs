using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    private static float currentIncome; 


    // Update is called once per frame
    void Update()
    {
        displayText.text = "$" + GetCurrentIncome().ToString();
    }

    //Returns the Current Amount of Money
    public static float GetCurrentIncome()
    {
        return currentIncome;
    }

    public static void SetCurrentIncome(float amount)
    {
        currentIncome += amount;

    }

    public static void BuyItem(float amount)
    {
        currentIncome -= amount;

    }

    
}
