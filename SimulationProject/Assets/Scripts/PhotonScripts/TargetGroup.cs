using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

public class TargetGroup : MonoBehaviour
{
    [SerializeField]
    Cinemachine.CinemachineTargetGroup targetGroup;
    [SerializeField]
    private float weight;
    [SerializeField]
    private float radius;
  
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject p in PlayerMovement.GetOnlinePlayers())
        {
            if(targetGroup.FindMember(p.transform) < 0)
            targetGroup.AddMember(p.transform, weight, radius);
        }
        
    }
}
