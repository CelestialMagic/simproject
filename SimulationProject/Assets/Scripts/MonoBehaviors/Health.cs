using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float currHealth;
    [SerializeField]
    private float maxHealth = 100;

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
        //emit an event signifying death!
        //TODO CHANGE THIS LINE BELOW: Dont just destroy the gameobject(if the player health gets below zero, BOOM they will immediately die)
        Destroy(gameObject);
    }
}
