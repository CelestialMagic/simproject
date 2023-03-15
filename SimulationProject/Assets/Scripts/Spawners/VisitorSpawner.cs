using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//Code by Jessie Archer
public class VisitorSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> visitorPrefabs;//A list of prefab objects

    private int randomVisitor;//An int that stores a randomized value.
    
    [SerializeField]
    private float resetTimer;//A time saved to reset the countdownTimer

    [SerializeField]
    private float countdownTimer;//A timer that counts down

    [SerializeField]
    private float timeVariation;//A float to vary the countdownTimer by  

    [SerializeField]
    private string visitorPrefabName;

    // Update is called once per frame
    void Update()
    {
        CountdownSpawn();
    }

    //CountdownSpawn() counts down and spawns visitors
    private void CountdownSpawn()
    {
        if (countdownTimer - Time.deltaTime <= 0)
        {
            GenerateRandomVisitor();
            countdownTimer = Random.Range(resetTimer - timeVariation, resetTimer + timeVariation);
        }
        else
        {
            countdownTimer -= Time.deltaTime;
        }

    }

    //GenerateRandomVisitor() picks a visitor from the visitorPrefabs list and
    //spawns the visitor at the spawner. 
    private void GenerateRandomVisitor()
    {
        GameObject visitor = visitorPrefabs[Random.Range(0, visitorPrefabs.Count - 1)];
        visitor.transform.position = gameObject.transform.position; 
        PhotonNetwork.Instantiate(visitorPrefabName, gameObject.transform.position, Quaternion.identity, 0);
    }
}
