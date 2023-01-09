using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GenerateAllValidParanthesis : MonoBehaviour
{
    #region Question
    //https://leetcode.com/problems/generate-parentheses/
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

    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> output = new List<string>();

        //left adds to count, right decreases count and if both left and right reduce to zero, 
        //we have reached the possible valid parenthesis
        RecursivelyAddParanthesis(n, n, 0, "", output);

        return output;
    }

    #endregion

    #region Private Methods

    private void RecursivelyAddParanthesis(int left, int right, int count, string current, IList<string> output)
    {
        //Base case 
        if (left == 0 && right == 0)
        {
            output.Add(current);
            return;
        }

        //Count > 0 => Can add either left or right depending on how many we have left
        if (count > 0)
        {
            //Adding left
            if (left > 0)
                RecursivelyAddParanthesis(left - 1, right, count + 1, current + "(", output);

            //Or adding right
            if (right > 0)
                RecursivelyAddParanthesis(left, right - 1, count - 1, current + ")", output);
        }
        //Can only add left
        else if(count == 0)
        {
            RecursivelyAddParanthesis(left - 1, right, count + 1, current + "(", output);
        }
    }

    #endregion
}