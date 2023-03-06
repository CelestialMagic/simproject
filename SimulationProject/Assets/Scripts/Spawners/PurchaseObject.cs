using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer
//Purchase Object provides methods and fields used by both the Spawner and
//LandExpansion classes. 
public abstract class PurchaseObject : MonoBehaviour
{
    protected bool isTouchingPen;//determines if player is touching pen

    protected bool placeIsHeld;//A boolean that checks if place button is held down

    protected PlayerMovement currentPlayer;//The current player character being controlled

    [SerializeField]
    protected SpawnDisplay spawnDisplay; //A display card to use

    protected abstract void SpawnObject();//A method to spawn the object

    //OnTriggerEnter() is used to detect player entry. 
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTouchingPen = true;
            currentPlayer = other.GetComponent<PlayerMovement>();
        }
    }
    //Checks if player exited radius
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTouchingPen = false;
        }
    }
}
