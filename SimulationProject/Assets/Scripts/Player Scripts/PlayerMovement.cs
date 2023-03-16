using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Cinemachine;

//Code by Jessie Archer
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;//Speed to move

    [SerializeField]
    private float rotationSpeed;//Speed to rotate
                          
    [SerializeField]
    private Rigidbody rb;//RigidBody

    [SerializeField]
    private MeshRenderer pRenderer;//Player meshrenderer

    private Vector3 m_ToApplyMove;//A Vector3 representing the player movement force

    [SerializeField]
    private InputAction sideMovement;//An side movement binding unique to player

    [SerializeField]
    private InputAction forwardMovement;//A forward movement binding unique to player

    [SerializeField]
    private InputAction menuCycle;//A set of pos/neg inputs that track each player's menu inputs

    [SerializeField]
    private InputAction menuPlace;//A single binding representing placing an object

    [SerializeField]
    private PhotonView view;//PhotonView component

    private static List<GameObject> onlinePlayers = new List<GameObject>();//List of current active players

    [SerializeField]
    private GameObject prefab;//The player prefab

    [SerializeField]
    private List <Color> colors;//A list of available colors to randomly select


    //Enables Player Moveset
    private void OnEnable()
    {
        sideMovement.Enable();
        forwardMovement.Enable();
        menuCycle.Enable();
        menuPlace.Enable();

    }
    //Disables Player Moveset 
    private void OnDisable()
    {
        sideMovement.Disable();
        forwardMovement.Disable();
        menuCycle.Disable();
        menuPlace.Disable();
    }
    //Retrieves the PhotonView component
   public PhotonView GetView()
    {
        return view; 
    }
    //Awake() adds the player to list of active players
    private void Awake()
    {
        onlinePlayers.Add(this.gameObject);
        foreach (GameObject p in onlinePlayers)
        {
            Debug.Log(p);
        }
       
    }
    //Start() selects a random color for the players and sends it to other players
    private void Start()
    {
        Color color = colors[(int)Random.Range(0, colors.Count - 1)];
        //RPC call
        if (view)
            this.view.RPC("RPC_SendColor", RpcTarget.All, new Vector3(color.r, color.g, color.b));

    }

    // Update is called once per frame
    void Update()
    {
        
        if (view.IsMine)
        {
            //Reads movement value from input system
            float sideInput = sideMovement.ReadValue<float>();
            float forwardInput = forwardMovement.ReadValue<float>();

            Vector3 movementDirection = new Vector3(forwardInput, 0, sideInput);

            m_ToApplyMove = new Vector3(forwardInput * moveSpeed * Time.deltaTime, 0, sideInput * moveSpeed * Time.deltaTime);
            transform.Translate(m_ToApplyMove, Space.World);

            //Determines when to rotate the player character
            if (m_ToApplyMove != Vector3.zero && movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            
         
        }
        

    }

    //To be used with potential scriptableobjects
    public void Initialize(Color color)
    {
        pRenderer.material.color = color;
    }
    //GetMenuPlace() is a public getter method used to determine if player
    //is pressing the menu cycle keys
    public float GetMenuValue()
    {
        return menuCycle.ReadValue<float>();
    }
    //GetMenuPlace() is a public getter method used to determine if player
    //is pressing down their place key
    public float GetMenuPlace()
    {
        return menuPlace.ReadValue<float>();
    }
    //Returns the active player objects
    public static List<GameObject> GetOnlinePlayers()
    {
        return onlinePlayers;
    }
    //RPC_SendColor() sets the player to a random color and updates the other
    //players' screens. 
    [PunRPC]
    private void RPC_SendColor(Vector3 color)
    {
        gameObject.GetComponentInChildren<Renderer>().material.color = new Color(color.x, color.y, color.z); 
    }

}
