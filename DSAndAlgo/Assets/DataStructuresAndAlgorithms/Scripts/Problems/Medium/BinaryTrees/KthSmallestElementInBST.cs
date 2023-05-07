using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KthSmallestElementInBST : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/kth-smallest-element-in-a-bst/description/

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

	#region Recursive Method	

	public int KthSmallest_Recursive(TreeNode root, int k)
	{
		List<int> order = new List<int>();

		Recurse(root, order);
		return order[k - 1];
	}

	//Basically do inorder traversal to get all elements in order. 
	//Then take (k + 1)th element from list
	private void Recurse(TreeNode curr, List<int> order)
	{
		if (curr == null)
		{
			return;
		}

		Recurse(curr.left, order);
		order.Add(curr.val);
		Recurse(curr.right, order);
	}

	#endregion

	#region Iterative Method

	public int KthSmallest_Iterative(TreeNode root, int k)
	{
		Stack<TreeNode> stack = new Stack<TreeNode>(); List<int> output = new List<int>();
		var curr = root.left; stack.Push(root);

		while (stack.Count > 0 || curr != null)
		{
			while (curr != null)
			{
				stack.Push(curr);
				curr = curr.left;
			}
			curr = stack.Pop(); output.Add(curr.val);
			curr = curr.right;
		}

		return output[k - 1];
	}

	#endregion
}