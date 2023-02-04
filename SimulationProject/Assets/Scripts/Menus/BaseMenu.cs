using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject menu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        menu.SetActive(true);
    }

    void Close()
    {
        menu.SetActive(false);
    }
}
