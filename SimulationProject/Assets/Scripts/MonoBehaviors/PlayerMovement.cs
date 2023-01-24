using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce;//Force applied to rigidbody for movement. 

    [SerializeField]
    private Rigidbody rb;//RigidBody

    [SerializeField]
    private MeshRenderer renderer; 

    private Vector3 m_ToApplyMove;//A Vector3 representing the player movement force

    private Input input; //To be used with Input system.

    private int woodCount;

    private int stoneCount;

    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {


        //Read movement value
        float sideInput = playerInput.Movement.Sides.ReadValue<float>();
        float forwardInput = playerInput.Movement.Forward.ReadValue<float>();
        
        //Move Player
        Vector3 currentPosition = transform.position;

        m_ToApplyMove = new Vector3(forwardInput * moveForce * Time.deltaTime, 0, sideInput * moveForce * Time.deltaTime);





    }

    private void FixedUpdate()
    {
        ////Applies force to rigidbody to allow player to jump
        ////Resets to zero after. 
        rb.AddForce(m_ToApplyMove);
        m_ToApplyMove = Vector3.zero;



    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case ("Wood"):
                break;
            case ("Stone"):
                break;
            default:
                break;
        }
    }

    public void Initialize(Color color)
    {
        renderer.material.color = color;
    }

}
