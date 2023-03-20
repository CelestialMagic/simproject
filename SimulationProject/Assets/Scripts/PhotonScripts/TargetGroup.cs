using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;
//Code by Jessie Archer
public class TargetGroup : MonoBehaviour
{
    [SerializeField]
    Cinemachine.CinemachineTargetGroup targetGroup;//The target group used in the scene
    [SerializeField]
    private float weight;//The weight for each target
    [SerializeField]
    private float radius;//The radius for each target
  
    // Update is called once per frame
    void Update()
    {
        //foreach loop cycles through the list of players online
        //This loop is responsible for ensuring the camera follows players
        foreach(GameObject p in PlayerMovement.GetOnlinePlayers())
        {
            //Checks if the player is in the list.
            //Performs a null check as well. 
            if (targetGroup.FindMember(p.transform) < 0)
                targetGroup.AddMember(p.transform, weight, radius);
            else if (targetGroup.FindMember(null) != -1)
                targetGroup.RemoveMember(null);
        }
        
    }
}
