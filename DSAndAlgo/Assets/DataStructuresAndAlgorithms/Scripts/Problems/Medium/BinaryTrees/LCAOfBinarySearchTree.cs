
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LCAOfBinarySearchTree : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

	#endregion
	
	#region BinarySearch Method

	public TreeNode LowestCommonAncestor_BinarySearchMethod(TreeNode root, TreeNode p, TreeNode q)
	{
		TreeNode curr = root; bool toTraverse = true;

		while (toTraverse)
		{
			if (curr.val > p.val && curr.val > q.val)
			{
				curr = curr.left;
			}
			else if (curr.val < p.val && curr.val < q.val)
			{
				curr = curr.right;
			}
			else
				toTraverse = false;
		}

		return curr;
	}

    #endregion

    #region Ancestor Accumulation Method

    public TreeNode LowestCommonAncestor_Accumulation(TreeNode root, TreeNode p, TreeNode q)
    {
        List<TreeNode> pList = AccumulateAncestors(root, p.val);
        List<TreeNode> qList = AccumulateAncestors(root, q.val);
        TreeNode output = null;

        for (int i = 0; i < Math.Min(qList.Count, pList.Count); i++)
        {
            if (qList[i].val != pList[i].val)
            {
                output = qList[i - 1];
                goto end;
            }
        }

        //In case of no mismatch within range, 
        //Setting output as the last element in the list with the least count
        output = (qList.Count > pList.Count) ? pList[pList.Count - 1] :
        qList[qList.Count - 1];

        end:
        return output;
    }

    List<TreeNode> AccumulateAncestors(TreeNode root, int val)
    {
        List<TreeNode> output = new List<TreeNode>(); TreeNode curr = root;
        while (curr.val != val)
        {
            output.Add(curr);
            if (curr.val > val)
            {
                curr = curr.left;
            }
            else if (curr.val < val)
            {
                curr = curr.right;
            }
        }
        //Adding equals value (last value) to output
        output.Add(curr);
        return output;
    }

    #endregion
}