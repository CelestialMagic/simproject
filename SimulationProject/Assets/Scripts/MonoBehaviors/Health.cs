using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float currHealth;
    [SerializeField]
    private float maxHealth = 100;
    public event EventHandler onDeath; 

    void Awake()
    {
        currHealth = maxHealth;
    }

    private void Update()
    {
        if (currHealth <= 0){
            Die();
        }
    }
    private void Die()
    {
        if (onDeath != null)
        {
            onDeath(this, EventArgs.Empty); 
            //Emits an event that the health has dipped below 0!
        }
    }
}
