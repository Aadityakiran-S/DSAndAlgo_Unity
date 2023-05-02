using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinDepthOfBT : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/minimum-depth-of-binary-tree/description/

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

	#region Recursive Solutions	

	public int MinDepth_RecursiveII(TreeNode root)
	{
		//Encountered beyond leaf? => return 0;
		if (root == null)
		{
			return 0;
		}

		int leftDepth = MinDepth_RecursiveII(root.left);
		int rightDepth = MinDepth_RecursiveII(root.right);

		//In case either left or right subtree isn't available,
		//take the other and add 1 for current level.
		//If both are 0 => leaf => depth = 1;
		if (leftDepth == 0 || rightDepth == 0)
		{
			return Math.Max(leftDepth, rightDepth) + 1;
		}

		return Math.Min(leftDepth, rightDepth) + 1;
	}

	private int _minDepth = int.MaxValue;
	public int MinDepth_RecursiveI(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}

		Recurse(root, 0);
		return _minDepth;
	}

	private void Recurse(TreeNode curr, int depth)
	{
		//Overflow check
		if (curr == null)
		{
			return;
		}

		//Reached leaf node => Take count
		if (curr.left == null && curr.right == null)
		{
			_minDepth = Math.Min(_minDepth, depth + 1);
			return; //Not necessary to give return here.
		}

		depth++;

		Recurse(curr.left, depth);
		Recurse(curr.right, depth);
	}

	#endregion

	#region Iterative Solutions	

	public int MinDepth_IterativeII(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}

		int depth = 1; Queue<TreeNode> bfsQ = new Queue<TreeNode>();
		bfsQ.Enqueue(root);

		while (bfsQ.Count > 0)
		{
			int size = bfsQ.Count;
			//Taking out current level size and adding all
			//nodes in the next level into the queue
			for (int i = 0; i < size; i++)
			{
				var curr = bfsQ.Dequeue();
				if (curr.left != null)
				{
					bfsQ.Enqueue(curr.left);
				}
				if (curr.right != null)
				{
					bfsQ.Enqueue(curr.right);
				}

				if (curr.left == null && curr.right == null)
				{
					return depth;
				}
			}
			depth++; //Passed one level => increment depth
		}

		return 0; //Just for syntactic purposes
	}

	public int MinDepth_IterativeI(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}

		int depth = 1; Queue<TreeNode> bfsQ = new Queue<TreeNode>();
		bfsQ.Enqueue(root); int count = bfsQ.Count;

		while (bfsQ.Count > 0)
		{
			var curr = bfsQ.Dequeue(); count--;
			if (curr.left != null)
			{
				bfsQ.Enqueue(curr.left);
			}
			if (curr.right != null)
			{
				bfsQ.Enqueue(curr.right);
			}

			//If at any level, we encounter a leaf,
			//We're returning the depth there itself
			if (curr.left == null && curr.right == null)
			{
				return depth;
			}

			//If we've exhausted count of current level, 
			//Increase depth => When we start exploring a level itself, 
			//Depth of that level will be accurate
			if (count == 0)
			{
				count = bfsQ.Count;
				depth++;
			}
		}

		return 0; //Just for syntactic purposes
	}

	#endregion
}