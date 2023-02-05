using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Player> players;

    [SerializeField]
    private Transform spawner;

    
    

    // Start is called before the first frame update
    void Start()
    {
        foreach(Player p in players)
        {
            p.Spawn();
            p.prefab.transform.position = spawner.position;
            
        }
        
        
    }

}
