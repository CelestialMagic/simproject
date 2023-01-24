using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private List<Player> playersToFollow;

    [SerializeField]
    private float followDistance;

    private List<Transform> transforms = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(Player p in playersToFollow)
        {
            transforms.Add(p.prefab.transform);
        }
    }


    private void FixedUpdate()
    {
        camera.transform.position = new Vector3(transforms[0].position.x, transforms[0].position.y, transforms[0].position.z);
        
    }
}
