using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IsSymmetricTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/symmetric-tree/description/

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

	public bool IsSymmetric_Recursive(TreeNode root)
	{
		//Going Root-L-R on left subtree should be same as going Root-R-L on right subtree
		return root == null || Recurse(root.left, root.right);
	}

	private bool Recurse(TreeNode left, TreeNode right)
	{
		//If either of them are null, both have to be at the same time
		if (left == null || right == null)
		{
			return left == null && right == null;
		}

		//Guarenteed thqat both are not null
		if (left.val != right.val)
		{
			return false;
		}

		//Comparing extreme end subtrees and close subtrees
		return Recurse(left.left, right.right) && Recurse(left.right, right.left);
	}

	#endregion
}