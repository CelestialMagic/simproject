using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : ObjectFactory
{
    [SerializeField] protected float generateTimer;
    [SerializeField] protected float resetTimer;
    [SerializeField] protected float generateAmount; 

    [SerializeField] GameObject m_prefab;
    [SerializeField] int m_cost;
    public GameObject prefab
    {
        get { return m_prefab; }
        set { prefab = m_prefab; }
    }

    public int cost
    {
        get { return m_cost; }
        set { cost = m_cost; }
    }




    public override void CreateObject()
    {
        Instantiate(gameObject);
    }

    protected abstract void GenerateMoney();

}
