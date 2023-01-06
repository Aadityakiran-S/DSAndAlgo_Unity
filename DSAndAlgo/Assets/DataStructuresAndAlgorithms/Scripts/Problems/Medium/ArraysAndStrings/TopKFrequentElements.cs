using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopKFrequentElements : MonoBehaviour
{
    #region Question
    //https://leetcode.com/problems/top-k-frequent-elements/
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

    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> countDict = new Dictionary<int, int>();

        //Declaring and initializing array containing freq of each element as index and 
        //elements themselves as values in index
        List<int>[] frequency = new List<int>[nums.Length + 1];
        for (int i = 0; i < frequency.Length; i++)
        {
            frequency[i] = new List<int>();
        }

        List<int> output = new List<int>();

        //Populating dictionary with count of occurance of each element in nums
        for (int i = 0; i < nums.Length; i++)
        {
            if (countDict.ContainsKey(nums[i]))
                countDict[nums[i]] += 1;
            else
                countDict.Add(nums[i], 1);
        }

        //Populating frequency array
        foreach (var item in countDict)
        {
            Console.WriteLine("Value: " + item.Value + " Key: " + item.Key);
            frequency[item.Value].Add(item.Key);
        }

        int index = frequency.Length - 1;
        LoopBeginning:
        while (k > 0)
        {
            //Finding first non empty slot in frequency array
            while (true)
            {
                if (frequency[index].Count != 0)
                    break;
                else
                    index--;
            }

            //Iterating through each list in a slot in frequency array
            for (int j = 0; j < frequency[index].Count; j++)
            {
                //Console.WriteLine(frequency[index][j]);
                Console.WriteLine(frequency[index].Count);
                output.Add(frequency[index][j]);
                k--;

                if (k == 0)
                    goto LoopBeginning;
            }

            index--;
        }

        return output.ToArray();
    }

    #endregion
}