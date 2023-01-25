using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;//Force applied to rigidbody for movement.
    [SerializeField]
    private float rotationSpeed;
                          

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

        //OLD: float horizontalInput = Input.GetAxis("Horizontal");
        //OLD: float verticalInput = Input.GetAxis("Vertical");

        //OLD: Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        //Read movement value
        float sideInput = playerInput.Movement.Sides.ReadValue<float>();
        float forwardInput = playerInput.Movement.Forward.ReadValue<float>();
        m_ToApplyMove = new Vector3(forwardInput, 0, sideInput).normalized * moveSpeed;
        //Time.deltaTime is only supposed to be used if the movement is applied in update. 
        //If used when the movement is applied in fixedupdate, Time.deltaTime will actually cause inconsistency
        //made sure to normalize the movement(so the speed remains the same even when going diagonal)


        //Only rotate when there is input
        if (sideInput != 0 || forwardInput != 0) 
        {
            Quaternion toRotation = Quaternion.LookRotation(m_ToApplyMove, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }







    }

    private void FixedUpdate()
    {
        ////Applies force to rigidbody to allow player to jump
        ////Resets to zero after. 
 
        //OLD: rb.AddForce(m_ToApplyMove);
        rb.velocity = m_ToApplyMove * Time.fixedDeltaTime;
        //since the actual move step is called in fixed update, we use fixedDeltaTime
        //using velocity instead of addforce for smooth movement
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
