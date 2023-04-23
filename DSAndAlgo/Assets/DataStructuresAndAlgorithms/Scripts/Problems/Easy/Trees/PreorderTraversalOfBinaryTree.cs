using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PreorderTraversalOfBinaryTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/binary-tree-preorder-traversal/description/

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

	public IList<int> PreorderTraversal_Iterative(TreeNode root)
	{
		IList<int> output = new List<int>();
		Stack<TreeNode> stack = new Stack<TreeNode>();
		if (root == null)
		{
			goto end;
		}
		stack.Push(root); var node = root;
		while (stack.Count > 0)
		{
			while (node != null)
			{
				output.Add(node.val);
				stack.Push(node);
				node = node.left;
			}
			node = stack.Pop();
			node = node.right;
		}

		end:
		return output;
	}

	public IList<int> PreorderTraversal_Recursive(TreeNode root)
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

		list.Add(curr.val);
		Recurse(curr.left, list);
		Recurse(curr.right, list);
	}

	#endregion
}