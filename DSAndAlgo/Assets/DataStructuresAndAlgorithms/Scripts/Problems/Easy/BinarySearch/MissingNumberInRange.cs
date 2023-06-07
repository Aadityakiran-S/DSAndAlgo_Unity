using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MissingNumberInRange : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/missing-number/

    #endregion

    #region Methods		

    public int MissingNumber_1(int[] nums)
    {
        //Creating an arra of space one more than input length
        int[] count = new int[nums.Length + 1];

        //Iterating over entire input and keeping count of the value in index
        for (int i = 0; i < nums.Length; i++)
        {
            count[nums[i]] = 1;
        }

        //Checking which slot in count is still having 0 value
        for (int i = 0; i < count.Length; i++)
        {
            //Wherever the value is 0, that index will be the missing number
            if (count[i] == 0)
            {
                return i;
            }
        }

        return 0; //For syntactical correctness
    }

    public int MissingNumber_2(int[] nums)
    {
        int res = 0; //Taking XOR between indices and values
        for (int i = 0; i < nums.Length; i++)
        {
            //Indices starting from zero will have all numbers in 0 to n
            res ^= (i + 1) ^ nums[i];
        }
        //XOR will cancel out all the same ones and 
        //leave the one which is not present in nums since everything is
        //there in the index iteration
        return res;
    }

    public int MissingNumber_3(int[] nums)
    {
        int res = 0; //Taking XOR between indices and values
        for (int i = 0; i < nums.Length; i++)
        {
            //Indices starting from zero will have all numbers in 0 to n
            res ^= (i + 1) ^ nums[i];
        }
        //XOR will cancel out all the same ones and 
        //leave the one which is not present in nums since everything is
        //there in the index iteration
        return res;
    }

    //Method of sum
    public int MissingNumber(int[] nums)
    {
        int sum = (nums.Length + 1) * (nums.Length) / 2;
        for (int i = 0; i < nums.Length; i++)
        {
            sum -= nums[i];
        }
        return sum;
    }

    #endregion
}