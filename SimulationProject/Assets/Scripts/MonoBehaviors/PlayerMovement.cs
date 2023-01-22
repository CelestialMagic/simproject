using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce;//Force applied to rigidbody for movement. 

    [SerializeField]
    private Rigidbody rb;//RigidBody

    private Vector3 m_ToApplyMove;//A Vector3 representing the player movement force

    private Input input; //To be used with Input system.

    private int woodCount;

    private int stoneCount; 


    // Update is called once per frame
    void Update()
    {
        //Determines direction of key press
        if (Input.GetKey(KeyCode.W))
        {
            m_ToApplyMove += new Vector3(0, 0, moveForce * Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_ToApplyMove += new Vector3(0, 0, -moveForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_ToApplyMove += new Vector3(moveForce * Time.deltaTime, 0, 0);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_ToApplyMove += new Vector3(-moveForce * Time.deltaTime, 0, 0);

        }





    }

    private void FixedUpdate()
    {
        //Applies force to rigidbody to allow player to jump
        //Resets to zero after. 
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


}
