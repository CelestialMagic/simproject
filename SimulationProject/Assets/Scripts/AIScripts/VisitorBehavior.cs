using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Code by Brandon Lo
public class VisitorBehavior : MonoBehaviour
{
    private BehaviorTree tree;//Behavior Tree
    [SerializeField]
    private NavMeshAgent agent;//The NavMesh Agent

    [SerializeField]
    private List<GameObject> visitable = new List<GameObject>();//A list of places to visit

    [SerializeField]
    private GameObject ticketBooth;//The location to return to
    
    [SerializeField]
    private float locationDistance;//The location distance 

    [SerializeField]
    private float idleDuration;//The idle time
    private float idleCount = 0;

    [SerializeField]
    private Vector3 stopRotation;//The Vector3 to stop rotating the visitor

    //each visitor will spawn with a random interest between min and max
    [SerializeField]
    private int minInterest;
    [SerializeField]
    private int maxInterest;
    private int interest;

    //stores the index of the area to visit
    private int toVisit;

    private bool visitableInstantiated = false;

    //ActionStates for idling and executing an action
    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    // Start is called before the first frame update
    void Start()
    {
        //randomizing interest and starting visit location
        interest = Random.Range(minInterest, maxInterest);

        tree = new BehaviorTree();

        Sequence visitPark = new Sequence("Visit the Park");
        Leaf leavePark = new Leaf("Exit the Park", ExitPark);
        Leaf getTicket = new Leaf("Getting a Ticket", GetTicket);

        visitPark.AddChild(getTicket);
        for (int i = 0; i < interest; i++)
        {
            visitPark.AddChild(VisitAttractionSetup());
        }
        visitPark.AddChild(leavePark);
        tree.AddChild(visitPark);

        tree.PrintTree();
    }

    //Cleaning up Start() by separating VisitAttraction node setup into its own function
    public Selector VisitAttractionSetup()
    {
        Selector visitAttraction = new Selector("Visit an Attraction");
        Leaf findNewLocation = new Leaf("Find New Building", FindNewLocation);

        // VisitBuilding setup
        Sequence visitBuilding = new Sequence("Visit Building");
        Leaf goToBuilding = new Leaf("Go To Building", GoToBuilding);
        Leaf decreaseInterest = new Leaf("Decrease Interest", DecreaseInterest);
        Leaf idle = new Leaf("Idle in Place", Idle);
       
        visitBuilding.AddChild(goToBuilding);
        visitBuilding.AddChild(decreaseInterest);
        visitBuilding.AddChild(findNewLocation);
        visitBuilding.AddChild(idle);

        visitAttraction.AddChild(visitBuilding);

        return visitAttraction;
    }

    //Enters park and finds locations
    public Node.Status GetTicket()
    {
        SetVisitableLocations();
        toVisit = Random.Range(0, visitable.Count);
        return Idle();
    }
    //Finds a new location to travel to 
    public Node.Status FindNewLocation()
    {
        if (interest > 0)
        {
            int newToVisit = Random.Range(0, visitable.Count);
            //in the event that the same index is picked again
            while (newToVisit == toVisit)
            {
                newToVisit = Random.Range(0, visitable.Count);
            }
            toVisit = newToVisit;
        }
        return Node.Status.SUCCESS;
    }

    //WILL BE UTILIZED IN NEXT PLAYTEST
    //Checks if the visitor still has interest in visiting other locations
    public Node.Status HasInterest()
    {
        if (interest > 0)
        {
            return VisitAttractionSetup().Process();
        }
        return ExitPark();
    }

    //Stops the agent in its place
    public Node.Status Idle()
    {
        if (idleCount >= idleDuration)
        {
            agent.Resume();
            idleCount = 0;
            Debug.Log("finished idling");
            return Node.Status.SUCCESS;
        }
        else
        {
            idleCount+=Time.deltaTime;
            this.gameObject.transform.Rotate(stopRotation);
        }
        return Node.Status.RUNNING;

    }

    //Sends the agent to the building according to the index toVisit
    public Node.Status GoToBuilding()
    {
        return GoToLocation(visitable[toVisit].transform.position);
    }

    //increases or decreases interest based on input
    public Node.Status DecreaseInterest()
    {
        interest--;
        return Node.Status.SUCCESS;
    }

    //Exits the park
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
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < locationDistance)
        {
            //successful! Can reach location
            state = ActionState.IDLE;
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
    //Sets the visitable locations to the currently accessible spots
    //These spots include the expansion if it has been purchased. 
    private void RefreshVisitableLocations()
    {
        
        visitable = LocationManager.GetAccessibleLocations();

    }

    //this should only get used when accessible locations NEED to be updated
    //bc of purchases!!!
    private void SetVisitableLocations()
    {
        LocationManager.SetAccessibleLocations();
        RefreshVisitableLocations();
    }
}
