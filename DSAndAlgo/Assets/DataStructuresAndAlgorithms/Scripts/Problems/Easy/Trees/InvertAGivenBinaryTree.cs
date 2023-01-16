using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InvertAGivenBinaryTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/invert-binary-tree/

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

	public TreeNode InvertTree(TreeNode root)
	{
		RecursiveInvert(root);
		return root;
	}

	#endregion

	#region Helper Methods	

	private void RecursiveInvert(TreeNode current)
    {
		if(current == null)
        {
			return;
        }

		FlipNode(current);

		RecursiveInvert(current.left);
		RecursiveInvert(current.right);
    }

	private void FlipNode(TreeNode current)
    {
		TreeNode left = current.left;
		TreeNode right = current.right;

		current.left = right;
		current.right = left;
    }

	#endregion
}