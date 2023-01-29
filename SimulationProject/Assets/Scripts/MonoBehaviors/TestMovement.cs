using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float rotation;

    private Vector3 m_ToApplyMove;//A Vector3 representing the player movement force



    // Start is called before the first frame update
    void Start()
    {

    }

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

   
}
