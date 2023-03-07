using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

//Code by Noel Paredes
public class AnimalBehavior : MonoBehaviour
{
    private BehaviorTree tree;//The Animal Behavior Tree
    [SerializeField]
    private NavMeshAgent agent;//The Animal NavMesh Agent
    [SerializeField]
    private Transform spawnPos;//The Animal Spawn Position

    [SerializeField]
    private float locationDistance;//A float representing a range to travel

    [SerializeField]
    private float idlingTime;//A countdown timer used to countdown idle state

    [SerializeField]
    private float shortenIdling;//Subtracts the idlingTime by however much for ShortIdle

    [SerializeField]
    private float resetIdleTimer;//A timer used to reset the idle time.

    //A list of locations the animal can move to in pen
    private List<Vector3> moveLocations = new List<Vector3>();

    //A PlayerMovement representing a player to travel to
    private PlayerMovement currentPlayer;

    //A bool used to determine if the animal AI can move to a player
    private bool canFollowPlayer; 

    //ActionStates for idling and executing an action
    public enum ActionState { IDLE, WANDER, FOLLOW };

    //State is initialized to IDLE
    ActionState state = ActionState.IDLE;

    //Status is set to RUNNING
    Node.Status treeStatus = Node.Status.RUNNING;

    // Start is called before the first frame update
    void Start()
    {

        tree = new BehaviorTree();

        //A sequence representing the states of Animal Walk Behavior
        Sequence walk = new Sequence("Walk Around Pen");
        
       
        Leaf isIdle = new Leaf("Is Idle", IsIdle);
        Leaf shortIdle = new Leaf("Short Idle", ShortIdle);
        Leaf wanderAround = new Leaf("Wander Around", WanderAround);
        Leaf followPlayer = new Leaf("Follow Player", FollowPlayer);

      
        
        walk.AddChild(isIdle);
        walk.AddChild(wanderAround);
        walk.AddChild(shortIdle);
        walk.AddChild(followPlayer);
        walk.AddChild(shortIdle);
        walk.AddChild(wanderAround);
        tree.AddChild(walk);

        tree.PrintTree();
    }

    //Determines a random time for the animal to wait before wandering.
    public Node.Status IsIdle()
    {
        if (idlingTime - Time.deltaTime <= 0)
        {
            idlingTime = resetIdleTimer;
            return Node.Status.SUCCESS;
        }
        else
        {
            idlingTime -= Time.deltaTime;
            return Node.Status.RUNNING;
        }
    }

    //Behaves like IsIdle, but now shortens the time for idling
    public Node.Status ShortIdle()
    {
        float shortened = idlingTime - shortenIdling;

        if (shortened - Time.deltaTime <= 0)
        {
            idlingTime = resetIdleTimer;
            return Node.Status.SUCCESS;
        }
        else
        {
            idlingTime -= Time.deltaTime;
            return Node.Status.RUNNING;
        }
    }

    //Determines where the animal wanders to in the pen based on waypoints
    public Node.Status WanderAround()
    {
        int spotsPerPen = moveLocations.Count;
        int randomSpot = Random.Range(0, spotsPerPen);

        Debug.Log("WANDER NOW");
        return GoToLocation(moveLocations[randomSpot]);
    }

    //Allows the AI animal to follow the player. 
    public Node.Status FollowPlayer()
    {
        Debug.Log("FIND PLAYER NOW");
        
        if (canFollowPlayer)
            return GoToLocation(currentPlayer.transform.position);
        else
            return Node.Status.FAILURE;
    }

    //Sends the agent to the specified location
    private Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WANDER;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) >= locationDistance)
        {
            //haven't made it to destination, agent failed
            state = ActionState.IDLE;
            Debug.Log("FAILED...");
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < locationDistance)
        {
            //successful! Able to reach destination
            state = ActionState.IDLE;
            Debug.Log("SUCCESS!!!");
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    // Update is called once per frame
    private void Update()
    {
        treeStatus = tree.Process();
    }

    //SetMoveLocations() is a public setter method 
    public void SetMoveLocations(List<Vector3> locations)
    {
        moveLocations = locations; 
    }

    //SetCurrentPlayer() is a public setter method accessed by the Spawner
    //class. It sets the current player to the player that entered the pen
    //OnTriggerEnter().
    public void SetCurrentPlayer(PlayerMovement player)
    {
        currentPlayer = player; 
    }

    //SetCanFollowPlayer() is a public setter method used to determine if
    //the player is in range. This method is used by the Spawner class,
    //which determines if the player is in the range of the pen.
    public void SetCanFollowPlayer(bool follow)
    {
        canFollowPlayer = follow; 
    }
    
}
