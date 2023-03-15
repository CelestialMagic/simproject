using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//Code by Brandon Lo
public class VisitorDespawner : MonoBehaviour
{
    //despawns visitors when they enter the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Visitor")
        {
            PhotonNetwork.Destroy(other.gameObject);
            Destroy(other.gameObject);

        }
    }
}
