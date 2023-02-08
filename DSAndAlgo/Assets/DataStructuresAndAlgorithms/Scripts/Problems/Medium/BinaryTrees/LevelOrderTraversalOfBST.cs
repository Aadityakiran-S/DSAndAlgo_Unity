using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelOrderTraversalOfBST : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/binary-tree-level-order-traversal/

    //Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

    //Example 1:
    //Input: root = [3,9,20,null,null,15,7]
    //Output: [[3],[9,20],[15,7]]

    //Example 2:
    //Input: root = [1]
    //Output: [[1]]

    //Example 3:
    //Input: root = []
    //Output: []

    //	Constraints:
    //The number of nodes in the tree is in the range[0, 2000].
    //-1000 <= Node.val <= 1000
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

    private IList<IList<int>> LevelOrder_Optimized(TreeNode root)
    {
        IList<IList<int>> output = new List<IList<int>>();

        //Edge case
        if (root == null)
        {
            return output;
        }

        //Initializing variables
        Queue<TreeNode> bfsQ = new Queue<TreeNode>(); bfsQ.Enqueue(root);
        List<int> currList = new List<int>(); int count = 0;

        //Performing BFS
        while (bfsQ.Count > 0)
        {
            TreeNode curr = bfsQ.Dequeue(); count--;
            currList.Add(curr.val);

            if (curr.left != null)
                bfsQ.Enqueue(curr.left);
            if (curr.right != null)
                bfsQ.Enqueue(curr.right);

            //Keeping track of level set bu using count variable
            if (count <= 0)
            {
                output.Add(new List<int>(currList)); currList.Clear(); count = bfsQ.Count;
            }
        }

        return output;
    }

    //This is basically BFS iterative.
    private IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> valueList = new List<IList<int>>();

        //Nothing in the root => Return empty list<list>
        if (root == null)
            return valueList;

        Queue<TreeNode> childQ = new Queue<TreeNode>(); childQ.Enqueue(root);

        //Iterate when at least one child is there for current level => Current level is not end of BST
        while (childQ.Count > 0)
        {
            List<int> tempValList = new List<int>();
            Queue<TreeNode> tempQ = new Queue<TreeNode>();

            //Essentially recreating the childQ
            int childCount = childQ.Count;
            for (int i = 0; i < childCount; i++)
            {
                tempQ.Enqueue(childQ.Dequeue());
            }

            //Populating childQ with children of current level
            //And adding values to tempList
            for (int i = 0; i < childCount; i++)
            {
                TreeNode currentNode = tempQ.Dequeue();
                tempValList.Add(currentNode.val);

                //Queing children of currentNode
                if (currentNode.left != null)
                {
                    childQ.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    childQ.Enqueue(currentNode.right);
                }
            }

            valueList.Add(tempValList);
        }

        return valueList;
    }

    #endregion
}