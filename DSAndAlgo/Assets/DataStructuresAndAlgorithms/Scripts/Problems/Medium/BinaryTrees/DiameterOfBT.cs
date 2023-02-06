using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DiameterOfBT : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/diameter-of-binary-tree/description/

    #endregion

    #region References

    private int _maxDia;

    #endregion

    #region Methods
    public int DiameterOfBinaryTree(TreeNode root)
    {
        _maxDia = 0;
        ReturnHeight_Recursive(root);
        return _maxDia;
    }

    private int ReturnHeight_Recursive(TreeNode node)
    {
        //Base case: Entered node is null => -1
        if (node == null)
        {
            return -1;
        }

        //Taking heights from left and right and returning max among the two
        int l = ReturnHeight_Recursive(node.left); int r = ReturnHeight_Recursive(node.right);
        _maxDia = Math.Max(_maxDia, 2 + l + r); //Height from either side can be used to calc dia
        return 1 + Math.Max(l, r); //Function only returns height
    }
    #endregion
}