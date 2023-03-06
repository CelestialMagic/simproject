using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from the Behavior Tree tutorial
public class Leaf : Node
{

    public delegate Status Tick();//A delegate representing a behavior tree Tick
    public Tick ProcessMethod;

    public Leaf() { }//Default constructor
    //Overloaded Constructor for Leaf 
    public Leaf(string n, Tick pm)
    {
        name = n;
        ProcessMethod = pm;
    }

    //Establishes Process method for Leaf 
    public override Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();
        return Status.FAILURE;
    }
}