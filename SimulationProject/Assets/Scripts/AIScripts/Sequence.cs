using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from the Behavior Tree tutorial
public class Sequence : Node
{
    //Sequence Constructor
    public Sequence(string n)
    {

        name = n;
    }
    //Process() method for Sequence
    public override Status Process()
    {

        Status childStatus = children[currentChild].Process();
        if (childStatus == Status.RUNNING) return Status.RUNNING;
        if (childStatus == Status.FAILURE) return childStatus;

        currentChild++;
        //Resets index of children
        if (currentChild >= children.Count)
        {

            currentChild = 0;
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
}