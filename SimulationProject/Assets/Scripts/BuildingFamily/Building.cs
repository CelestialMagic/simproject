using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Building : ObjectFactory
{
    [SerializeField]
    protected float generateTimer;//A countdown timer to generate money
    [SerializeField]
    protected float resetTimer;//An amount to reset the timer each time
    [SerializeField]
    protected float generateAmount;//An amount of income to be generated

    [SerializeField]
    protected TextMeshProUGUI displayText;//A text displaying info on building

    [SerializeField] GameObject m_prefab;//The building prefab
    [SerializeField] int m_cost;//The cost for building type

    public GameObject prefab //Get and Set established for Interface field prefab
    {
        get { return m_prefab; }
        set { prefab = m_prefab; }
    }

    public int cost //Get and Set established for Interface field cost
    {
        get { return m_cost; }
        set { cost = m_cost; }
    }

    //A default Start() method able to be changed per building
    protected virtual void Start()
    {
        SetDisplayText();  
    }

    //A default method to create a building object
    public override void CreateObject()
    {
        Instantiate(gameObject);
    }

    //GenerateMoney() is defined by each individual building
    protected abstract void GenerateMoney();

    //SetDisplayText() displays information for each building
    protected virtual void SetDisplayText()
    {
        displayText.text = $"${generateAmount} per {resetTimer} seconds.";
    }

}
