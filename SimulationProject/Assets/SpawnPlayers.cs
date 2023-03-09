using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    [SerializeField] Vector3 spawnLocation;

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnLocation, Quaternion.identity);
    }
}
