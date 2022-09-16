using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ValidateBST : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/validate-binary-search-tree/

    //	Given the root of a binary tree, determine if it is a valid binary search tree(BST).
    //A valid BST is defined as follows:

    //The left subtree of a node contains only nodes with keys less than the node's key.
    //The right subtree of a node contains only nodes with keys greater than the node's key.
    //Both the left and right subtrees must also be binary search trees.


    //Example 1:
    //	Input: root = [2,1,3]
    //	Output: true

    //Example 2:
    //	Input: root = [5,1,4,null,null,3,6]
    //	Output: false
    //	Explanation: The root node's value is 5 but its right child's value is 4.

    //Constraints:
    //	The number of nodes in the tree is in the range[1, 104].
    //	-231 <= Node.val <= 231 - 1
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

    #region Optimal Approach

    private bool InValidBST_Optimal(TreeNode root)
    {
        return CheckIfBSTValid_Recursive(root, int.MaxValue, int.MinValue);
    }

    bool CheckIfBSTValid_Recursive(TreeNode node, int right, int left)
    {
        if (node.val <= left || node.val >= right)
        {
            return false;
        }

        if (node.left != null)
        {
            if (!CheckIfBSTValid_Recursive(node.left, node.val, left))
            {
                return false;
            }
        }

        if (node.right != null)
        {
            if(!CheckIfBSTValid_Recursive(node.right, right, node.val))
            {
                return false;
            }
        }

        return true;
    }

    #endregion

    #region Brute Force Approach

    private bool IsValidBST_SubOptimal(TreeNode root)//S:n, T:n
    {
        List<int> inOrderList = new List<int>();

        PopulateInOrderList(root, inOrderList);

        int previousValue = inOrderList[0];
        for (int i = 1; i < inOrderList.Count; i++)
        {
            if (previousValue >= inOrderList[i])
            {
                return false;
            }
            else
            {
                previousValue = inOrderList[i];
            }
        }

        return true;
    }

    void PopulateInOrderList(TreeNode node, List<int> valueList)
    {
        if (node.left != null)
        {
            PopulateInOrderList(node.left, valueList);
        }

        valueList.Add(node.val);

        if (node.right != null)
        {
            PopulateInOrderList(node.right, valueList);
        }
    }

    #endregion

    #endregion
}