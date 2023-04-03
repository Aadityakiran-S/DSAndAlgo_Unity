using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PascalsTriangle : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/pascals-triangle/

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
    public IList<IList<int>> Generate_Iterative(int numRows)
    {
        IList<IList<int>> output = new List<IList<int>>();
        output.Add(new List<int> { 1 });

        if (numRows == 1)
        {
            goto last;
        }

        List<int> prev = new List<int> { 1, 1 };
        output.Add(prev);

        if (numRows == 2)
        {
            goto last;
        }

        int currNum = 2;
        while (currNum < numRows)
        {
            List<int> curr = new List<int> { 1, 1 };
            for (int i = 0; i < prev.Count - 1; i++)
            {
                curr.Insert(i + 1, prev[i] + prev[i + 1]);
            }
            prev = curr; currNum++;
            output.Add(curr);
        }

        last:
        return output;
    }

    public IList<IList<int>> Generate_Recursive(int numRows)
    {
        IList<IList<int>> output = new List<IList<int>>
        {
            new List<int> { 1 }
        };

        if (numRows == 1)
        {
            goto last;
        }

        output.Add(new List<int> { 1, 1 });

        if (numRows == 2)
        {
            goto last;
        }

        Generate_Recursive_Internal(output, new List<int> { 1, 1 }, 2, numRows);

        last:
        return output;
    }

    #endregion

    #region Helper Methods	

    private void Generate_Recursive_Internal(IList<IList<int>> output, List<int> prev, int currNum, int num)
    {
        if (currNum == num)
        {
            return;
        }

        List<int> curr = new List<int>();
        curr.Insert(0, 1); curr.Add(1);

        for (int i = 0; i < prev.Count - 1; i++)
        {
            curr.Insert(i + 1, prev[i] + prev[i + 1]);
        }

        output.Add(curr);

        Generate_Recursive_Internal(output, curr, currNum + 1, num);
    }

    #endregion
}