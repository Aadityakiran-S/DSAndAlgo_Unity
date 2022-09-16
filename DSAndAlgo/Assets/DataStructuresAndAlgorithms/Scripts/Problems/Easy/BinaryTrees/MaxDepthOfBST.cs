using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MaxDepthOfBST : MonoBehaviour
{
    #region Question
    //Link: https://leetcode.com/problems/maximum-depth-of-binary-tree/
    //Given the root of a binary tree, return its maximum depth.
    //A binary tree's maximum depth is the number of nodes along the longest path
    //from the root node down to the farthest leaf node.

    //Example 1:
    //Input: root = [3,9,20,null,null,15,7]
    //	Output: 3

    //Example 2:
    //Input: root = [1,null,2]
    //	Output: 2

    //Constraints:
    //The number of nodes in the tree is in the range[0, 104].
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

    private int MaxDepthOptimal(TreeNode root, int countSoFar = 0)//T:n, S:n 
    {
        if (root == null)
            return countSoFar;

        countSoFar++;

        return Math.Max(MaxDepthOptimal(root.left, countSoFar), MaxDepthOptimal(root.right, countSoFar));
    }

    private int _depthSoFar;
    private int MaxDepth(TreeNode root)
    {
        //No root => depth is zero
        if (root == null)
            return 0;

        _depthSoFar = 1; int tempDepth = 1;
        MaxDepthRecursive(root, tempDepth);

        return _depthSoFar;
    }

    #endregion

    #region Auxilliary Methods

    void MaxDepthRecursive(TreeNode node, int tempDepth)
    {
        if (node.left != null)
        {
            MaxDepthRecursive(node.left, tempDepth + 1);
        }
        if (node.right != null)
        {
            MaxDepthRecursive(node.right, tempDepth + 1);
        }

        //Stopping condition when current node is child
        _depthSoFar = Math.Max(_depthSoFar, tempDepth);
        return;
    }

    #endregion
}
//Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
