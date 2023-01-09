using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReversePolishNotationProblem : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/evaluate-reverse-polish-notation/

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

    public int EvalRPN(string[] input)
    {
        Stack<int> output = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            //If the input is an operator, operate on the previous 2 values in stack
            if(input[i] == "+" || input[i] == "-" || input[i] == "*" || input[i] == "/")
            {
                int first = output.Pop(); int second = output.Pop();
                int operationOutput = Operate(second, first, input[i]);

                output.Push(operationOutput);
            }
            else //If input is a number
            {
                output.Push(Convert.ToInt32(input[i]));
            }
        }

        return output.Pop();
    }

    #endregion

    #region Helper Methods

    int Operate(int second, int first, string operation)
    {
        int output = 0;
        switch (operation)
        {
            case "+":
                output = second + first;
                break;
            case "-":
                output = second - first;
                break;
            case "*":
                output = second * first;
                break;
            case "/": //Round towards zero and cast output as int
                output = (int)Math.Floor((float)(second / first));
                break;
            default:
                break;
        }

        return output;
    }

    #endregion
}