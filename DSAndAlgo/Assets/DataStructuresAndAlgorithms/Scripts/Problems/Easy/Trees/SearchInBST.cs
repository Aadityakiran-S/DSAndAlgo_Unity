using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SearchInBST : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/search-in-a-binary-search-tree/description/

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

	private TreeNode _subTree;

	public TreeNode SearchBST(TreeNode root, int val)
	{
		_subTree = null;
		SearchBST_Recursive(root, val);

		return _subTree;
	}

	private void SearchBST_Recursive(TreeNode curr, int target)
	{
		if (curr == null)
		{
			return;
		}

		if (curr.val == target)
		{
			_subTree = curr;
			return;
		}

		if (target > curr.val)
		{
			SearchBST_Recursive(curr.right, target);
		}
		else
		{
			SearchBST_Recursive(curr.left, target);
		}
	}

	#endregion

}