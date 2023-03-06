using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from the Behavior Tree tutorial
public class Selector : Node
{
    //Selector Constructor
    public Selector(string n)
    {

        name = n;
    }
    //Overridden Process() method for Selector
    public override Status Process()
    {

        Status childStatus = children[currentChild].Process();
        //Checks if child is running
        if (childStatus == Status.RUNNING) return Status.RUNNING;
        //Checks if child is running 
        if (childStatus == Status.SUCCESS)
        {
            currentChild = 0;
            return Status.SUCCESS;
        }

        currentChild++;
        //Resets index of children 
        if (currentChild >= children.Count)
        {

            currentChild = 0;
            return Status.FAILURE;
        }

        return Status.RUNNING;
    }
}