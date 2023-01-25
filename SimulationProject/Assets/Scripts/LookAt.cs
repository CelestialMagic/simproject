using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform lookAt;
    [SerializeField]
    public bool flip;
    void Start()
    {
        if (lookAt == null)
        {
            lookAt = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int multiplier = flip ? 1 : -1;
        this.transform.LookAt(this.transform.position + multiplier * lookAt.position );
    }
}
