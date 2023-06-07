using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BitwiseANDOfNumbersInRange : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/bitwise-and-of-numbers-range/description/	

    #endregion

    #region Methods		

    public int RangeBitwiseAnd_1(int left, int right)
    {
        int count = 0;
        //keep right shifting till numbers are equal
        while (left != right)
        {
            left >>= 1; right >>= 1; count++;
        }
        //then left shift the res from the equal value
        //to how many times right shift needed to occur for equality
        int res = left;
        for (int i = 0; i < count; i++)
        {
            res <<= 1;
        }
        return res;
    }

    public int RangeBitwiseAnd_2(int left, int right)
    {
        int count = 0;
        //keep right shifting till numbers are equal
        while (left != right)
        {
            left >>= 1; right >>= 1; count++;
        }
        //then left shift the res from the equal value
        //to how many times right shift needed to occur for equality
        return left << count;
    }

    #endregion
}