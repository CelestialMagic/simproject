using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{
    private BehaviorTree tree;
    private NavMeshAgent agent;
    
    [SerializeField]
    private List<GameObject> penSpots = new List<GameObject>();
    [SerializeField]
    private List<GameObject> players = new List<GameObject>();

    [SerializeField]
    private float locationDistance;

    [SerializeField]
    private float waitingTime;

    [SerializeField]
    private float resetTimer;

    //ActionStates for idling and executing an action
    public enum ActionState { IDLE, WANDER, FOLLOW };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviorTree();

        Sequence walk = new Sequence("Walk Around Pen");
        
        //Selector standIdle = new Selector("Stand Idle");
        Leaf isIdle = new Leaf("Is Idle", IsIdle);
        //Leaf mvmtTime = new Leaf("Movement Time", MovementTime);

        Leaf wanderAround = new Leaf("Wander Around", WanderAround);
        Leaf followPlayer = new Leaf("Follow Player", FollowPlayer);

        //standIdle.AddChild(isIdle);
        //standIdle.AddChild(mvmtTime);
        
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

    public Node.Status MovementTime()
    {
        int spotsPerPen = penSpots.Count;
        int randomSpot = Random.Range(0, spotsPerPen);

        if (waitingTime - Time.deltaTime <= 0)
            return GoToLocation(penSpots[randomSpot].transform.position);
        else
        {
            waitingTime -= Time.deltaTime;
            return Node.Status.RUNNING;
        }
    }

    public Node.Status WanderAround()
    {
        int spotsPerPen = penSpots.Count;
        int randomSpot = Random.Range(0, spotsPerPen);
        return GoToLocation(penSpots[randomSpot].transform.position);
    }

    public Node.Status FollowPlayer()
    {
        int amountOfPlayers = players.Count;
        int randomPlayer = Random.Range(0, amountOfPlayers);

        return GoToLocation(players[randomPlayer].transform.position);
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
            Debug.Log("FAILED");
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
        if (treeStatus != Node.Status.FAILURE)
        {
            treeStatus = tree.Process();
        }
        else
        {
            Debug.Log("Animal failed to reach player.");
            treeStatus = tree.Process();
        }
    }


}
