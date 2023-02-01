using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;//Speed to move

    [SerializeField]
    private float rotationSpeed;//Speed to rotate
                          
    [SerializeField]
    private Rigidbody rb;//RigidBody

    [SerializeField]
    private MeshRenderer renderer;//Player meshrenderer

    private Vector3 m_ToApplyMove;//A Vector3 representing the player movement force

    private Input input; //To be used with Input system.

    [SerializeField]
    private PlayerInput playerInput;//Player Input System to be used by certain player

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

        //Reads movement value from input system
        float sideInput = playerInput.Movement.Sides.ReadValue<float>();
        float forwardInput = playerInput.Movement.Forward.ReadValue<float>();


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        m_ToApplyMove = new Vector3(forwardInput * moveSpeed * Time.deltaTime, 0, sideInput * moveSpeed * Time.deltaTime);
        transform.Translate(m_ToApplyMove, Space.World);

        //Determines when to rotate the player character
        if(m_ToApplyMove != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        

    }

    //To be used with potential scriptableobjects
    public void Initialize(Color color)
    {
        renderer.material.color = color;
    }

}
