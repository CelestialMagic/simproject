using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusedCode : MonoBehaviour
{
    //Unused Animal Script Code

    //[SerializeField]
    //protected float waitingTime;

    //[SerializeField]
    //protected float resettingTime;
    // Start is called before the first frame update

    //Animal Behavior Start() Code
    //void Start()
    //{

    //    agent = GetComponent<NavMeshAgent>();
    //    spawnPos = GetComponent<Transform>();

    //    Vector3 zxNeg = new Vector3(-0.5f, 0, -0.5f);
    //    Vector3 zNegXPos = new Vector3(0.5f, 0, -0.5f);
    //    Vector3 zxPos = new Vector3(0.5f, 0, 0.5f);
    //    Vector3 zPosXNeg = new Vector3(-0.5f, 0, 0.5f);

    //    tempPenSpots.Add(spawnPos.position + zxNeg);
    //    tempPenSpots.Add(spawnPos.position + zNegXPos);
    //    tempPenSpots.Add(spawnPos.position + zxPos);
    //    tempPenSpots.Add(spawnPos.position + zPosXNeg);

    //    tree = new BehaviorTree();

    //    Sequence walk = new Sequence("Walk Around Pen");

    //    //Selector standIdle = new Selector("Stand Idle");
    //    Leaf isIdle = new Leaf("Is Idle", IsIdle);
    //    //Leaf mvmtTime = new Leaf("Movement Time", MovementTime);

    //    Leaf wanderAround = new Leaf("Wander Around", WanderAround);
    //    Leaf followPlayer = new Leaf("Follow Player", FollowPlayer);

    //    //standIdle.AddChild(isIdle);
    //    //standIdle.AddChild(mvmtTime);

    //    walk.AddChild(isIdle);
    //    walk.AddChild(wanderAround);
    //    walk.AddChild(followPlayer);
    //    tree.AddChild(walk);

    //    tree.PrintTree();
    //}
    //Unused Animal Behavior MovementTime()
    /*
   public Node.Status MovementTime()
   {
       int spotsPerPen = spawner.penSpots.Count;
       int randomSpot = Random.Range(0, spotsPerPen);

       if (waitingTime - Time.deltaTime <= 0)
           return GoToLocation(spawner.penSpots[randomSpot].transform.position);
       else
       {
           waitingTime -= Time.deltaTime;
           return Node.Status.RUNNING;
       }
   }
   */

    //LocateNextSpot() from Animal Code
    //Destination for AnimalObjects to use as NavMeshAgents
    /*
    Vector3 moveTarget = Vector3.zero;

    protected void LocateNextSpot()
    {
        if (waitingTime - Time.deltaTime <= 0)
        {
            int randIndex = Random.Range(0, 5);
            Transform randPosition = availableLocations[randIndex];

            moveTarget = randPosition.position;

            agent.SetDestination(moveTarget);

            waitingTime = resettingTime;
        }
        else
        {
            waitingTime -= Time.deltaTime;
        }
    }
    */
    //In VisitorBehavior
    //Sequence visitAnimal = new Sequence("Visit Animal");
    //Leaf enterBuilding = new Leaf("Enter Into Building", EnterIntoBuilding);
}
