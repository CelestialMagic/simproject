using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adapted from the Behavior Tree tutorial
public class Node
{
    //An enum representing AI Status
    public enum Status
    {

        SUCCESS,
        RUNNING,
        FAILURE
    };

    public Status status;//Status object
    public List<Node> children = new List<Node>();
    public int currentChild = 0;//The current child in the children list
    public string name;//The name of the node

    public Node() { }//default constructor
    //Overloaded Node constructor
    public Node(string n)
    {

        name = n;
    }
    //Original Process Method
    public virtual Status Process()
    {

        return children[currentChild].Process();
    }
    //Method for adding children to behavior tree
    public void AddChild(Node n)
    {

        children.Add(n);
    }
}