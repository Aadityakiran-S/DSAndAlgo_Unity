using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PowerOf2 : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/power-of-two/

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

    #region Top down approach (Math)

    public bool IsPowerOfTwo_TopDown(int input)
    {
        if (input <= 0)
        {
            return false;
            //Can only be possible of x is complex.
        }
        if (input == 1)
        {
            return true;
        }

        while (input != 1)
        {
            //Checkin at each step if n becomes odd
            //If so, then it's surely not a power of 2
            if (input % 2 != 0)
            {
                return false;
            }
            input = input / 2; //Dividing by 2 each time
        }

        return true; //If a no point, it became odd, it will become 1 => true
    }

    #endregion

    #region Bit manipulation 1
    public bool IsPowerOfTwo_BitManipulation1(int input)
    {
        if (input <= 0)
        {
            return false;
            //Can only be possible of x is complex.
        }
        if (input == 1)
        {
            return true;
        }

        int count = 0;
        while (input != 0)
        {
            //If at any point count has exceeded 1, we can return
            if (count > 1)
            {
                return false;
            }

            if ((input & 1) == 1)
            {
                count++;
            }
            input = input >> 1; //Right shift by one
        }

        //All powers of 2 will have one once in their binary rep
        return (count == 1);
    }
    #endregion

    #region Bit Manipulation 2
    public bool IsPowerOfTwo_BitManipulation2(int n)
    {
        if (n <= 0)
        {
            return false;
            //Can only be possible of x is complex.
        }
        return (n & (n - 1)) == 0; //Bitwise and of a power of 2 and it's predecessor is
                                   //always 0
    }
    #endregion

    #region Math: Logarithm solution
    public bool IsPowerOfTwo_Logarithm(int input)
    {
        if (input <= 0)
        {
            return false;
            //Can only be possible of x is complex.
        }
        if (input == 1)
        {
            return true;
        }

        //Basically if you take the log if a power of 2, it should be an int
        //So floor and ceiling should be the same.
        decimal output = (decimal)Math.Log(input, 2);
        return (Math.Floor(output) == Math.Ceiling(output));

        //Should cast to decimal to prevent overflow and rounding error issues with float and double
    }
    #endregion
}