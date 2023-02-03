using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    private float totalIncome;
    private float currentIncome; 


    // Update is called once per frame
    void Update()
    {
        displayText.text = "$" + GetCurrentIncome().ToString();
    }

    public float GetCurrentIncome()
    {
        return currentIncome;
    }

    public void SetCurrentIncome(float amount)
    {
        currentIncome += amount;

    }

    
}
