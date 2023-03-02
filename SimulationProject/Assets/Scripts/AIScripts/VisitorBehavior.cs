using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Code by Brandon Lo

public class VisitorBehavior : MonoBehaviour
{
    private BehaviorTree tree;
    private NavMeshAgent agent;
    [SerializeField]
    private List<GameObject> visitable = new List<GameObject>();
    [SerializeField]
    private GameObject ticketBooth;

    [SerializeField]
    private float locationDistance;

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
        SetVisitableLocations();
        toVisit = Random.Range(0, visitable.Count);

        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviorTree();

        Sequence visitPark = new Sequence("Visit the Park");
        Leaf leavePark = new Leaf("Exit the Park", ExitPark);
        
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
        //Leaf enterBuilding = new Leaf("Enter Into Building", EnterIntoBuilding);
        visitBuilding.AddChild(goToBuilding);
        visitBuilding.AddChild(decreaseInterest);
        visitBuilding.AddChild(findNewLocation);

        //Sequence visitAnimal = new Sequence("Visit Animal");

        visitAttraction.AddChild(visitBuilding);

        return visitAttraction;
    }

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
            Debug.Log("new index:" + toVisit);
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

    //Sends the agent to the building according to the index toVisit
    public Node.Status GoToBuilding()
    {
        return GoToLocation(visitable[toVisit].transform.position);
    }

    //increases or decreases interest based on input
    public Node.Status DecreaseInterest()
    {
        interest--;
        Debug.Log(interest);
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
        SetVisitableLocations();
        if (treeStatus != Node.Status.SUCCESS)
        {
            treeStatus = tree.Process();
        }
        
    }

    private void RefreshVisitableLocations()
    {
        List<GameObject> locations = LocationManager.GetAccessibleLocations();
        if (locations != null)
        {
            foreach (GameObject l in locations)
            {
                if (visitable.IndexOf(l) < 0)
                    visitable.Add(l);
            }

        }

    }

    private void SetVisitableLocations()
    {
        LocationManager.SetAccessibleLocations(false);
        RefreshVisitableLocations();
    }
}
