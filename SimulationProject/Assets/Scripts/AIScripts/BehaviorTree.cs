
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from the Behavior Tree tutorial
public class BehaviorTree : Node
{
    //A default BehaviorTree Object
    public BehaviorTree()
    {

        name = "Tree";
    }
    //A Behavior Tree Object with a string established
    public BehaviorTree(string n)
    {

        name = n;
    }
    //Node Levels used 
    struct NodeLevel
    {

        public int level;
        public Node node;
    }
    //Overridden process method to run current child
    public override Status Process()
    {

        return children[currentChild].Process();
    }
    //Displays the layout of the behavior tree
    public void PrintTree()
    {

        string treePrintOut = "";
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
        Node currentNode = this;
        nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

        while (nodeStack.Count != 0)
        {

            NodeLevel nextNode = nodeStack.Pop();
            treePrintOut += new string('-', nextNode.level) + nextNode.node.name + "\n";

            for (int i = nextNode.node.children.Count - 1; i >= 0; --i)
            {

                nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.children[i] });
            }
        }
        Debug.Log(treePrintOut);
    }
}