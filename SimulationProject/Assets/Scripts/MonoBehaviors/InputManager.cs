using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Input input; //To be used with Input system.

    [SerializeField]
    private PlayerInput playerInput;//Player Input System to be used by certain player

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
