using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float CurrHealth { get; set; }
    [SerializeField]
    public float MaxHealth { get; set; } = 100;
   
    public event EventHandler onDeath, onReceiveDamage, onReceiveHealth; 

    void Awake()
    {
        CurrHealth = MaxHealth;
    }

    private void Update()
    {
        if (CurrHealth <= 0){
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(10);
        }
    }
    public void Damage(int amount)
    {
        if (onReceiveDamage != null ) onReceiveDamage(this, EventArgs.Empty);
        CurrHealth -= amount;
        if (CurrHealth < 0)
        {
            CurrHealth= 0;
        }
    }

    public void Heal(int amount)
    {
        if (onReceiveDamage != null) onReceiveHealth(this, EventArgs.Empty);
        CurrHealth += amount;
        if (CurrHealth > MaxHealth)
        {
            CurrHealth = MaxHealth;
        }
    }
    private void Die()
    {
        if (onDeath != null)
        {
            onDeath(this, EventArgs.Empty); 
        }
    }
}
