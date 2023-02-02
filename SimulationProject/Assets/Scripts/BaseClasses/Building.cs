using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : ObjectFactory
{

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

}
