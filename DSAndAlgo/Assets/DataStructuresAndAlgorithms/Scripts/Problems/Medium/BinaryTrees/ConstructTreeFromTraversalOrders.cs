using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ConstructTreeFromTraversalOrders : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

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

	#region Methods	

	public TreeNode BuildTree(int[] preorder, int[] inorder)
	{
		return BuildTreeHelper(0, 0, inorder.Length - 1, preorder, inorder);
	}

	#endregion

	#region Helper Methods	

	private TreeNode BuildTreeHelper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
	{
		//Condition where we get a null tree
		if (preorder.Length == 0 || inorder.Length == 0)
			return null;

		//Condition where partitioned input array is out of bounds
		// => The current node is null => Parent that it came from has no child 
		//      in this direction (either left or right)
		if (preStart > preorder.Length - 1 || inStart > inEnd)
			return null;

		//Creating root node and assigning the children
		var rootNode = new TreeNode(preorder[preStart]);

		//Using this variable to partion array according to the logic required
		// to process further elements
		var mid = Array.IndexOf(inorder, preorder[preStart]);

		rootNode.left = BuildTreeHelper(preStart + 1, inStart, mid - 1, preorder, inorder);
		rootNode.right = BuildTreeHelper(preStart + mid - inStart + 1, mid + 1, inEnd, preorder, inorder);

		//Returning root at the end to allow for recursion to propagate up 
		return rootNode;
	}

	#endregion
}