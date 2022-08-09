using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TwoSum : MonoBehaviour
{
    #region Question
    //Given an array of integers nums and an integer target,
    //return indices of the two numbers such that they add up to target.

    //You may assume that each input would have exactly one solution, and you may not use the same element twice.

    //You can return the answer in any order.


    //Example 1:

    //Input: nums = [2, 7, 11, 15], target = 9
    //Output: [0,1]
    //Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    //Example 2:

    //Input: nums = [3, 2, 4], target = 6
    //Output: [1,2]
    //Example 3:

    //Input: nums = [3, 3], target = 6
    //Output: [0,1]


    //Constraints:

    //2 <= nums.length <= 104
    //-109 <= nums[i] <= 109
    //-109 <= target <= 109
    //Only one valid answer exists.


    //Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
    #endregion

    #region References

    [SerializeField] private int[] _nums;
    [SerializeField] private int _target;

    [SerializeField] private int[] _result;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        _result = ReturnIndicesOfTwoSum(_nums, _target);
    }

    #endregion

    #region Methods
    public int[] ReturnIndicesOfTwoSum(int[] nums, int target)  //S: n; T: n
    {
        //Error check
        if(nums.Length == 0 || nums.Length == 1)
        {
            throw new Exception("Input array is too short");
        }

        //Key: value of the compliment of given num, Value: index of num
        Dictionary<int, int> complimentDict = new Dictionary<int, int>();
        int[] result = new int[2];

        for (int i = 0; i < nums.Length; i++)
        {
            //For when we've encountered a number that compliments this already
            if (complimentDict.ContainsKey(nums[i]))
            {
                result[0] = complimentDict[nums[i]]; //Returns index of previously seen compliment
                result[1] = i; //Returns current index

                return result;
            }
            //For case in which elements in nums repeat
            else if (complimentDict.ContainsKey(target - nums[i])) //No need to store this also as per question 
            {
                Console.WriteLine("Array contains duplicate. Ignoring successor");
                continue;
            }
            else
            {
                complimentDict.Add(target - nums[i], i);
            }
        }

        if(result.Length == 0)
        {
            throw new Exception("No entries add up to a compliment");
        }

        return result;
    }

    public int[] ReturnIndicesOfTwoSum_BruteForce(int[] nums, int target)   //S: 1; T: n^2
    {
        //Error check
        if(nums.Length == 0 || nums.Length == 1)
        {
            Debug.LogWarning("Input is too short to find two sum");
            return null;
        }

        int[] result = new int[2];

        for (int i = 0; i < nums.Length - 1; i++) //from: 0 to second last element
        {
            for (int j = i + 1; j < nums.Length; j++) //from i+1 to last element
            {
                if(nums[i] + nums[j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                }
            }
        }

        return result;
    }

    #endregion
}