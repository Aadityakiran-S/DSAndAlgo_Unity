using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IsSameTreeProblem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/same-tree/description/

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

	public bool IsSameTree(TreeNode p, TreeNode q)
	{
		//Base case: When either of them is null, both have to be null at the same time
		if (p == null || q == null)
		{
			if (p == null && q == null)
			{
				return true;
			}
			else
				return false;
		}

		//If values are eqal => Go one step below in both directions
		if (p.val == q.val)
		{
			return (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
		}
		else //Otherwise it's not the same tree obviously
			return false;
	}

	#endregion

	#region Helper Methods	



	#endregion
}