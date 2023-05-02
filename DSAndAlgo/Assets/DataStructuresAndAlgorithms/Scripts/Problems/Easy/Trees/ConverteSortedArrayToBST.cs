using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ConverteSortedArrayToBST : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/

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

	//public TreeNode SortedArrayToBST(int[] nums)
	//{
	//	if (nums == null || nums.Length == 0) return null;

	//	int m = nums.Length / 2;

	//	TreeNode root = new TreeNode(nums[m]);
	//	root.left = SortedArrayToBST(nums[0..m]);
	//	root.right = SortedArrayToBST(nums[(m + 1)..]);

	//	return root;
	//}

	public TreeNode SortedArrayToBST(int[] nums)
	{
		if (nums == null || nums.Length == 0)
		{
			return null;
		}

		return BuildTree(nums, 0, nums.Length - 1);
	}

	private TreeNode BuildTree(int[] nums, int i, int j)
	{
		if (j < i)
		{
			return null;
		}

		int mid = j + (i - j) / 2;
		TreeNode node = new TreeNode(nums[mid]);

		node.left = BuildTree(nums, i, mid - 1);
		node.right = BuildTree(nums, mid + 1, j);

		return node;
	}

	#endregion
}