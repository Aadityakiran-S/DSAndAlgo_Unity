using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RightSideViewOfBST : MonoBehaviour
{
	#region Question
	//Question Link: https://leetcode.com/problems/binary-tree-right-side-view/

	//Given the root of a binary tree, imagine yourself standing on the right side of it, 
	//return the values of the nodes you can see ordered from top to bottom.

	//Example 1:
	//Input: root = [1,2,3,null,5,null,4]
	//Output: [1,3,4]

	//Example 2:
	//Input: root = [1,null,3]
	//Output: [1,3]

	//Example 3:
	//Input: root = []
	//Output: []

	//Constraints:
	//The number of nodes in the tree is in the range[0, 100].
	//-100 <= Node.val <= 100
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

	private IList<int> RightSideView_SecondBFSApproach(TreeNode root)
	{
		IList<int> output = new List<int>();
		//Base case
		if (root == null)
		{
			return output;
		}

		Queue<TreeNode> bfsQ = new Queue<TreeNode>();
		bfsQ.Enqueue(root); int count = 0;

		//Basically doing level order traversal and taking only rightmost element
		while (bfsQ.Count > 0)
		{
			TreeNode curr = bfsQ.Dequeue(); count--;

			if (curr.left != null)
				bfsQ.Enqueue(curr.left);
			if (curr.right != null)
				bfsQ.Enqueue(curr.right);

			//Taking in rightmost element
			if (count <= 0)
			{
				output.Add(curr.val);
				count = bfsQ.Count;
			}
		}

		return output;
	}

	//DFS preOrder with right side first approach (NRL PreOrder)
	private IList<int> RightSideView_DFSApproach(TreeNode root)
    {
		IList<int> rightSideValues = new List<int>(); 

		if (root == null)
			return rightSideValues;

		RightSideView_Recursive_Internal(root, 0 /*levelCount*/, rightSideValues);

		return rightSideValues;
	}

	private IList<int> RightSideView_BFSApproach(TreeNode root)
	{
		IList<int> rightSideValues = new List<int>();

		//Error check for null root
		if (root == null)
			return rightSideValues;

		Queue<TreeNode> childQueue = new Queue<TreeNode>(); childQueue.Enqueue(root);
		int count = childQueue.Count;

		while(childQueue.Count > 0)
        {
			//Iterating through initial child to end of that level's children
            for (int i = 1; i <= count; i++)
            {
				TreeNode currentNode = childQueue.Dequeue();
				
				//If iterated to value of count for previous child level count => we've reached right
				if (i == count)
					rightSideValues.Add(currentNode.val);

				//Adding children to back of the queue
				if (currentNode.left != null)
					childQueue.Enqueue(currentNode.left);
				if (currentNode.right != null)
					childQueue.Enqueue(currentNode.right);
            }

			count = childQueue.Count; //Updating count to proceed to next level's children
        }

		return rightSideValues;
	}

    #endregion

    #region Auxilliary Functions

	void RightSideView_Recursive_Internal(TreeNode node, int levelCount, IList<int> rightSideValues)
    {
		//Base case
		if (node == null)
			return;

		levelCount++; //Successfully entered a level? => increment level count

		//If level count is greater than number of values in list => Exploring new level
		// => First right side value needs to be added
		if (levelCount > rightSideValues.Count)
			rightSideValues.Add(node.val);

		//PreOrder with Node-Right-Left traversal
		if (node.right != null)
        {
			RightSideView_Recursive_Internal(node.right, levelCount, rightSideValues);
		}
		if (node.left != null)
        {
			RightSideView_Recursive_Internal(node.left, levelCount, rightSideValues);
		}
	}


    #endregion
}