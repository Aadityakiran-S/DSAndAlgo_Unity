using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InorderTraversalOfBinaryTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/binary-tree-inorder-traversal/description/

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

	public IList<int> InorderTraversal_Iterative(TreeNode root)
	{
		IList<int> list = new List<int>();
		Stack<TreeNode> stack = new Stack<TreeNode>();

		if (root == null)
		{
			goto end;
		}

		stack.Push(root); var left = root.left;
		while (stack.Count > 0 || left != null)
		{
			while (left != null)
			{
				stack.Push(left);
				left = left.left;
			}

			left = stack.Pop();
			list.Add(left.val);
			left = left.right;
		}

		end:
		return list;
	}

	public IList<int> InorderTraversal_Recursive(TreeNode root)
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
		list.Add(curr.val);
		Recurse(curr.right, list);
	}

	#endregion
}