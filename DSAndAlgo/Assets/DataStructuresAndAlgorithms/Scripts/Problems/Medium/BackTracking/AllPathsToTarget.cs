using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AllPathsToTarget : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/all-paths-from-source-to-target/

    #endregion

    #region Method 1

    IList<IList<int>> res = new List<IList<int>>();
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        Backtrack(graph, 0, new List<int> { 0 });
        return res;
    }

    private void Backtrack(int[][] graph, int curr, List<int> temp)
    {
        //Adding to output only if we've reached the END OF THE GRAPH
        if (curr == graph.Length - 1)
        {
            res.Add(new List<int>(temp));
            return;
        }

        for (int i = 0; i < graph[curr].Length; i++)
        {
            temp.Add(graph[curr][i]); //Adding to list
            Backtrack(graph, graph[curr][i], temp); //Recursing
            temp.RemoveAt(temp.Count - 1); //Backtracking
        }
    }

    #endregion
}