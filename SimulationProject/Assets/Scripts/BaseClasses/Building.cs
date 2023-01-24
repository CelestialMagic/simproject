using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private void Start()
    {
        Health healthScript = this.GetComponent<Health>();
        if (healthScript) healthScript.onDeath += Destroy_OnDeath;
        //subscribe to destroy self when death event is emitted
    }
    private void Destroy_OnDeath(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }
}
