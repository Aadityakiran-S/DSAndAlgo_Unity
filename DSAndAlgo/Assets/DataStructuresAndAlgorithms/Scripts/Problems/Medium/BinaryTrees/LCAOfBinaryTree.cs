using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LCAOfBinaryTree : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/

    #endregion


    #region Regular Recursive Method

    private List<List<TreeNode>> res;
    public TreeNode LowestCommonAncestor_UsingArrayOfArray(TreeNode root, TreeNode p, TreeNode q)
    {
        res = new List<List<TreeNode>>(); TreeNode output = null;
        FindPath(root, p.val, q.val, new List<TreeNode>());

        //After finding path, since p and q are guarenteed to exist, 
        //there will be 2 entries in res
        for (int i = 0; i < Math.Min(res[0].Count, res[1].Count); i++)
        {
            //The place before the entries split is the LCA
            if (res[0][i].val != res[1][i].val)
            {
                output = res[0][i - 1];
                goto end;
            }
        }

        //If LCA is one of the nodes, then this is how we figure that out
        output = (res[0].Count < res[1].Count) ? res[0][res[0].Count - 1] :
            res[1][res[1].Count - 1];
        end:
        return output;
    }

    public TreeNode LowestCommonAncestor_UsingHashSet(TreeNode root, TreeNode p, TreeNode q)
    {
        res = new List<List<TreeNode>>(); TreeNode output = null;
        FindPath(root, p.val, q.val, new List<TreeNode>());

        //Seperating the paths of p and q
        List<TreeNode> pPath = res[0]; List<TreeNode> qPath = res[1];

        //Creating a HashSet to keep count of first common element
        HashSet<TreeNode> qSet = new HashSet<TreeNode>(qPath);

        //Iterating back from furthest ancestor to find lowest common one.
        for (int index = pPath.Count - 1; index >= 0; index--)
        {
            if (qSet.Contains(pPath[index]))
            {
                output = pPath[index];
                break;
            }
        }

        return output;
    }

    void FindPath(TreeNode curr, int p, int q, List<TreeNode> path)
    {
        path.Add(curr);
        if (curr == null)
        {
            path.RemoveAt(path.Count - 1);
            return;
        }
        //If we reach a target, we add the path to the master list
        //DO NOT stop the recursion since if LCA is this node itself, then we won't 
        //get the other one
        if (curr.val == p || curr.val == q)
        {
            res.Add(new List<TreeNode>(path));
        }

        FindPath(curr.left, p, q, path);
        //This makes sure that at each node, the path list will have the path up till
        //  that node itself. 
        if (path.Count > 0 && path[path.Count - 1] == curr.left)
        {
            path.RemoveAt(path.Count - 1);
        }
        FindPath(curr.right, p, q, path);
        //Same as above, what it does is remove the last element if it's the
        //  one just visited
        if (path.Count > 0 && path[path.Count - 1] == curr.right)
        {
            path.RemoveAt(path.Count - 1);
        }
    }

    #endregion

    #region Simple Reucrsive Method

    public TreeNode LowestCommonAncestor_SimpleRecursive(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return null;
        }
        //If LCA is the node itself, then every other node will return null and
        //  the not null returned node will be the LCA, which is this.
        if (root == p || root == q)
        {
            return root;
        }

        var leftLCA = LowestCommonAncestor_SimpleRecursive(root.left, p, q);
        var rightLCA = LowestCommonAncestor_SimpleRecursive(root.right, p, q);

        //If we get a value back from both left and right, then this is the LCA
        if (leftLCA != null && rightLCA != null) return root;

        //Returning back the value which is not null (which means we've hit one 
        //  required node)
        return (leftLCA != null) ? leftLCA : rightLCA;
    }

    #endregion
}