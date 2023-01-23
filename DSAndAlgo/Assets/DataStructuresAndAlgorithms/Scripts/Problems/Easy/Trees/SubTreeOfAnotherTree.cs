using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SubTreeOfAnotherTree : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/subtree-of-another-tree/

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


    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        //Base case: If subRoot is null => Totally true since every tree has a leaf which has null children only
        if (subRoot == null)
        {
            return true;
        }
        //Base case: If root is null then nothing except a null tree can be it's sub tree so we return false
        //otherwise exited in the first statement
        if (root == null)
        {
            return false;
        }

        //If initially itself they are the same tree, return ture 
        if (IsSameTree(root, subRoot))
        {
            return true;
        }
        //o/w return true if any of root's children are the same as subTree
        return (IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot));
    }

    #endregion

    #region Helper Methods	
    private bool IsSameTree(TreeNode p, TreeNode q)
    {
        //Base case: When either of them is null, both have to be null at the same time
        if (p == null || q == null)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else
                return false;
        }

        //If values are eqal => Go one step below in both directions
        if (p.val == q.val)
        {
            return (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }
        else //Otherwise it's not the same tree obviously
            return false;
    }
    #endregion
}