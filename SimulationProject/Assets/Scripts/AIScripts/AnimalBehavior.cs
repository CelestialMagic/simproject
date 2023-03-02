using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{
    private BehaviorTree tree;//The Animal Behavior Tree
    private NavMeshAgent agent;//The Animal NavMesh Agent
    private Transform spawnPos;//The Animal Spawn Position

    [SerializeField]
    private List<GameObject> players = new List<GameObject>();

    [SerializeField]
    private List<Vector3> tempPenSpots = new List<Vector3>();

    [SerializeField]
    private float locationDistance;

    [SerializeField]
    private float waitingTime;

    [SerializeField]
    private float resetTimer;

 
    private Vector3 zxNeg;

    private Vector3 zNegXPos;

    private Vector3 zxPos;

    private Vector3 zPosXNeg;

    private List<Vector3> penCorners;

    //ActionStates for idling and executing an action
    public enum ActionState { IDLE, WANDER, FOLLOW };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        spawnPos = GetComponent<Transform>();

        SetTempSpots();
        penCorners = new List<Vector3>() { zxNeg, zNegXPos, zxPos, zPosXNeg};

        foreach(Vector3 corner in penCorners)
        {
            tempPenSpots.Add(spawnPos.position + corner);
        }


        tree = new BehaviorTree();

        Sequence walk = new Sequence("Walk Around Pen");
        

        Leaf isIdle = new Leaf("Is Idle", IsIdle);
        Leaf wanderAround = new Leaf("Wander Around", WanderAround);
        Leaf followPlayer = new Leaf("Follow Player", FollowPlayer);

      
        
        walk.AddChild(isIdle);
        walk.AddChild(wanderAround);
        walk.AddChild(followPlayer);
        tree.AddChild(walk);

        tree.PrintTree();
    }

    //Determines a random time for the animal to wait before wandering.
    public Node.Status IsIdle()
    {
        if (waitingTime - Time.deltaTime <= 0)
            return Node.Status.SUCCESS;
        else
        {
            waitingTime -= Time.deltaTime;
            return Node.Status.RUNNING;
        }
    }


    public Node.Status WanderAround()
    {
        int spotsPerPen = tempPenSpots.Count;
        int randomSpot = Random.Range(0, spotsPerPen);
        return GoToLocation(tempPenSpots[randomSpot]);
    }

    public Node.Status FollowPlayer()
    {
        int amountOfPlayers = players.Count;
        int randomPlayerIndex = Random.Range(0, amountOfPlayers);

        Debug.Log("FIND PLAYER NOW");

        GameObject playerInScene = GameObject.Find($"{players[randomPlayerIndex]}");

        if (playerInScene == true)
            return GoToLocation(players[randomPlayerIndex].transform.position);
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
            Debug.Log("WANDER NOW");
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
            //successful!
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

    //SetTempSpots() is used as a "const" method for the four corners of the pen
    //Vector3 can not be a const, so this is one place to set these Vector3s. 
    private void SetTempSpots()
    {
        zxNeg = new Vector3(-0.5f, 0, -0.5f);
        zNegXPos = new Vector3(0.5f, 0, -0.5f);
        zxPos = new Vector3(0.5f, 0, 0.5f);
        zPosXNeg = new Vector3(-0.5f, 0, 0.5f);
    }

}
