using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CountCompleteTreeNodes : MonoBehaviour
{
    #region Question
    //Question Link: https://leetcode.com/problems/count-complete-tree-nodes/

    //Given the root of a complete binary tree, return the number of the nodes in the tree.
    //According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, 
    //and all nodes in the last level are as far left as possible.It can have between 1 and 2h nodes inclusive at the last level h.

    //Design an algorithm that runs in less than O(n) time complexity.

    //Example 1:
    //Input: root = [1, 2, 3, 4, 5, 6]
    //Output: 6

    //Example 2:
    //Input: root = []
    //Output: 0

    //Example 3:
    //Input: root = [1]
    //Output: 1

    //Constraints:
    //The number of nodes in the tree is in the range [0, 5 * 104].
    //0 <= Node.val <= 5 * 104
    //The tree is guaranteed to be complete.
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

    //TODO: Fix this. It's not working correctly
    private int CountNodes(TreeNode root)
    {
        if (root == null)
            return 0;

        int height = FindHeight(root); //Finding height of tree (log(n) time)

        int left = 0; int right = (int)Math.Pow(2, height - 1) - 1; //Performing Binary search on lowest level

        while (left < right)
        {
            int middle = (int)Math.Ceiling((double)(left + right) / 2);

            if (CheckIfNodeExists(middle, height, root))
            {
                left = middle;
            }
            else
            {
                right = middle - 1;
            }
        }

        return ((int)Math.Pow(2, height - 1) - 1) /*nodes before last level*/ + (left + 1) /*left is an index so it's one behind the count*/;
    }

    bool CheckIfNodeExists(int indexOfNodeToFind, int height, TreeNode node)
    {
        int left = 0; int right = (int)Math.Pow(2, height - 1) - 1; int count = 0;

        while(count < height)
        {
            int midOfNode = (int)Math.Ceiling((double)(left + right) / 2);

            if(indexOfNodeToFind >= midOfNode)
            {
                node = node.right;
                left = midOfNode;
            }
            else
            {
                node = node.left;
                right = midOfNode - 1;
            }

            count++;
        }

        return node != null;
    }

    int FindHeight(TreeNode root)
    {
        int height = 0;
        TreeNode currentNode = root;

        while (currentNode != null)
        {
            currentNode = currentNode.left;
            height++;
        }

        return height;
    }

    #endregion
}