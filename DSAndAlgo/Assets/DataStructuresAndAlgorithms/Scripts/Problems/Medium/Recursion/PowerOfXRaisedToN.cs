using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PowerOfXRaisedToN : MonoBehaviour
{
	#region Question
	
	

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

    #region NeetCode Solution

    public double MyPow_NeetCodeSolution(double x, int n)
    {
        bool neg = false;
        if (n < 0)
        {
            n = n * -1;
            neg = true;
        }
        double result = Helper(x, n);
        return !neg ? result : 1 / result;
    }
    public double Helper(double x, int n)
    {
        if (x == 0)
        {
            return 0;
        }

        if (n == 0)
        {
            return 1;
        }

        double result = Helper(x, n / 2);
        result *= result;
        return n % 2 == 0 ? result : result * x;
    }

    #endregion

    #region My Solution

    public double MyPow(double x, int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else if (x == 1 || x == 0)
        {
            return x;
        }

        Dictionary<int, double> dict = new Dictionary<int, double>();

        // int tempN = Math.Abs(n); //This causes some 2s compliment overflow issue
        int tempN = n;
        if (n < 0)
        {
            tempN = -n;
        }

        int half = (int)Math.Ceiling((double)(tempN / 2)); //This returns the same as Math.Floor for some reason
        int otherHalf = (int)Math.Floor((double)(tempN / 2));

        //This is a workaround for the Math.Ceiliing not working issue
        if (n % 2 != 0)
        {
            half += 1;
        }

        Console.WriteLine("Half " + half);
        Console.WriteLine("OtherHalf " + otherHalf);

        double output = MyPow_Recursive_Internal(x, half, dict) * MyPow_Recursive_Internal(x, otherHalf, dict);

        return (n < 0) ? (1 / output) : output;
    }

    private double MyPow_Recursive_Internal(double x, int n, Dictionary<int, double> dict)
    {
        if (dict.ContainsKey(n))
        {
            return dict[n];
        }
        else if (n == 0)
        {
            return 1;
        }
        else if (n == 1)
        {
            return x;
        }

        int half = (int)Math.Ceiling((double)(n / 2));
        int otherHalf = (int)Math.Floor((double)(n / 2));

        if (n % 2 != 0)
        {
            half += 1;
        }

        double output = MyPow_Recursive_Internal(x, half, dict) * MyPow_Recursive_Internal(x, otherHalf, dict);
        dict.Add(n, output);

        return output;
    }

    #endregion

}