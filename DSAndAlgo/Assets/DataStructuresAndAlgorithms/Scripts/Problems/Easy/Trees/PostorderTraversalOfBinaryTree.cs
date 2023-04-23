using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PostorderTraversalOfBinaryTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/binary-tree-postorder-traversal/description/

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

	public IList<int> PostorderTraversal_Iterative(TreeNode root)
	{
		List<int> output = new List<int>();
		Stack<TreeNode> stack = new Stack<TreeNode>();

		if (root == null)
		{
			goto end;
		}
		stack.Push(root);
		while (stack.Count > 0)
		{
			var node = stack.Pop();
			output.Add(node.val);

			if (node.left != null)
			{
				stack.Push(node.left);
			}

			if (node.right != null)
			{
				stack.Push(node.right);
			}
		}

		end:
		output.Reverse();
		return output;
	}

	public IList<int> PostorderTraversal_Recursive(TreeNode root)
	{
		IList<int> list = new List<int>();
		Recurse(root, list);
		return list;
	}

	private void Recurse(TreeNode curr, IList<int> list)
	{
		if (curr == null)
		{
			return;
		}

		Recurse(curr.left, list);
		Recurse(curr.right, list);
		list.Add(curr.val);
	}

	#endregion
}