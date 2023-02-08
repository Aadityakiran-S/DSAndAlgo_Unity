using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LowestCommonAncestor_Problem : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

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

	public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
	{
		TreeNode curr = root; bool toTraverse = true;

		while (toTraverse)
		{
			if (curr.val > p.val && curr.val > q.val)
			{
				curr = curr.left;
			}
			else if (curr.val < p.val && curr.val < q.val)
			{
				curr = curr.right;
			}
			else
				toTraverse = false;
		}

		return curr;
	}

	#endregion

	#region Helper Methods	



	#endregion
}