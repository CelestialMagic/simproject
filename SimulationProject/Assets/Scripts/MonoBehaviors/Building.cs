using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    Health health;

    // Start is called before the first frame update
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
