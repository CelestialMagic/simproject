using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorBehavior : MonoBehaviour
{
    private BehaviorTree tree;
    private NavMeshAgent agent;
    [SerializeField]
    private List<GameObject> visitable = new List<GameObject>();
    [SerializeField]
    private GameObject ticketBooth;

    [SerializeField]
    private int locationDistance;

    //each visitor will spawn with a random interest between min and max
    [SerializeField]
    private int minInterest;
    [SerializeField]
    private int maxInterest;
    private int interest;

    //stores the index of the area to visit
    private int toVisit;

    //ActionStates for idling and executing an action
    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    // Start is called before the first frame update
    void Start()
    {
        //randomizing interest and starting visit location
        interest = Random.Range(minInterest, maxInterest);
        RefreshVisitableLocations();
        toVisit = Random.Range(0, visitable.Count);
        Debug.Log(toVisit);

        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviorTree();

        Sequence visitPark = new Sequence("Visit the Park");
        //Select attraction to visit: animal or building
        Selector visitAttraction = new Selector("Visit an Attraction");
        Leaf leavePark = new Leaf("Exit the Park", ExitPark);

        //Setting up behavior tree branch for visiting a building
        Sequence visitBuilding = new Sequence("Visit Building");
        Leaf goToBuilding = new Leaf("Go To Building", GoToBuilding);
        //Leaf enterBuilding = new Leaf("Enter Into Building", EnterIntoBuilding);
        visitBuilding.AddChild(goToBuilding);

        //Sequence visitAnimal = new Sequence("Visit Animal");

        visitAttraction.AddChild(visitBuilding);
        //visitAttraction.AddChild(visitAnimal);

        visitPark.AddChild(visitAttraction);
        visitPark.AddChild(leavePark);
        tree.AddChild(visitPark);
    }

    public Node.Status GoToBuilding()
    {
        Node.Status s = GoToLocation(visitable[toVisit].transform.position);
        if (s == Node.Status.SUCCESS)
        {
            interest--;
        }
        return s;
    }

    public Node.Status ExitPark()
    {
        return GoToLocation(ticketBooth.transform.position);
    }

    //Sends the agent to the specified location
    private Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
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
        RefreshVisitableLocations();
        if (treeStatus != Node.Status.SUCCESS)
        {
            treeStatus = tree.Process();
        }
        
    }

    private void RefreshVisitableLocations()
    {
        visitable = LocationManager.GetActiveLocations();
    }
}
