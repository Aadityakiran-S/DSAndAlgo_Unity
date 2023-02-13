using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BalancedBT : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/balanced-binary-tree/description/

	#endregion

	#region References

	private int _maxHeightDiff = 0;

	#endregion


	#region Methods	

	public bool IsBalanced(TreeNode root)
	{
		_maxHeightDiff = 0;
		HeightOfEachNode_Recursive(root);

		//If maxDiff is greater than 1 then it's not balanced (That's the definition apparently)
		return (_maxHeightDiff > 1) ? false : true;
	}

	private int HeightOfEachNode_Recursive(TreeNode curr)
	{
		//Base case
		if (curr == null)
		{
			return -1;
		}

		//Store left and right heights for calc of height diff and height
		int l = HeightOfEachNode_Recursive(curr.left); int r = HeightOfEachNode_Recursive(curr.right);
		int height = Math.Max(l, r) + 1;

		//Calculate the max height diff between l and r
		_maxHeightDiff = Math.Max(_maxHeightDiff, Math.Abs(l - r));

		return height;
	}

	#endregion
}