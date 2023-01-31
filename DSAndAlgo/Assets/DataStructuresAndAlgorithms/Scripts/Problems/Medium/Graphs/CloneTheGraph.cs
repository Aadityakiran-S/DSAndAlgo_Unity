using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CloneTheGraph : MonoBehaviour
{
	#region Question
	
	

	#endregion

	#region References
	
	
	
	#endregion
	
	#region UnityLifecycle
	
	//Use this to initialize
	private void Awake()
	{
	
	}	
	
	//Use this to run
	private void Start()
    {
        
    }

    #endregion

    #region Public Functions

    Dictionary<Node, Node> map = new Dictionary<Node, Node>();
    public Node CloneGraph_Optimized(Node node)
    {
        if (node == null) return null;
        if (!map.ContainsKey(node))
        {
            map.Add(node, new Node(node.val));
            foreach (var n in node.neighbors)
            {
                map[node].neighbors.Add(CloneGraph_Optimized(n));
            }
        }

        return map[node];
    }

    public Node CloneGraph(Node head)
    {
        //Edge case where head is null 
        if (head == null)
            return head;

        Node headClone = new Node(head.val);
        Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
        dict.Add(head, headClone);

        CloneRecursive(head, headClone, dict);

        return headClone;
    }

    #endregion

    #region Helper Methods

    private void CloneRecursive(Node node, Node clone, Dictionary<Node, Node> dict)
    {
        foreach (var ng in node.neighbors)
        {
            //Current neighbor not cloned yet
            if (!dict.ContainsKey(ng))
            {
                Console.WriteLine("ng value: " + ng.val);

                //Cloning and assigning as neighbor
                Node ngClone = new Node(ng.val);
                dict.Add(ng, ngClone);
                clone.neighbors.Add(ngClone);

                CloneRecursive(ng, ngClone, dict);
            }
            //Neighbor is already cloned
            else
            {
                //Simply assign, no need to recurse in
                clone.neighbors.Add(dict[ng]);
            }
        }
    }

    #endregion
}


// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
