using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EvaluateBooleanTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/evaluate-boolean-binary-tree/description/

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

	public bool EvaluateTree(TreeNode root)
	{
		return Recurse(root);
	}

	private bool Recurse(TreeNode curr)
	{
		//Reached leaf? => Return the boolean value
		if (curr.val == 1 || curr.val == 0)
		{
			return curr.val == 1;
		}

		//Not reached leaf yet? Value can only be OR or AND
		return (curr.val == 2) ? (Recurse(curr.left) || Recurse(curr.right)) : (Recurse(curr.left) && Recurse(curr.right));
	}

	#endregion

	#region Helper Methods	



	#endregion
}