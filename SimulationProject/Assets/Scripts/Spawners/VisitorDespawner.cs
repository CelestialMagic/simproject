using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Brandon Lo
public class VisitorDespawner : MonoBehaviour
{
    //despawns visitors when they enter the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Visitor")
        {
            Destroy(other.gameObject);
        }
    }
}
