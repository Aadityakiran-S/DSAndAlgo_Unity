using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IntersectionOf2ArraysII : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/intersection-of-two-arrays-ii/description/

    #endregion

    #region Method1	

    public int[] Intersect_1(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> set1 = new Dictionary<int, int>(); Dictionary<int, int> set2 = new Dictionary<int, int>();
        PopulateDict(set1, nums1); PopulateDict(set2, nums2); List<int> output = new List<int>();
        foreach (var entry in set1)
        {
            if (set2.ContainsKey(entry.Key))
            {
                int m = Math.Min(set2[entry.Key], set1[entry.Key]);
                while (m > 0)
                {
                    output.Add(entry.Key);
                    m--;
                }
            }
        }
        return output.ToArray();
    }

    private void PopulateDict(Dictionary<int, int> set, int[] input)
    {
        foreach (int entry in input)
        {
            if (!set.ContainsKey(entry))
            {
                set.Add(entry, 1);
            }
            else
            {
                set[entry]++;
            }
        }
    }

    #endregion

    #region Method2

    public int[] Intersect_2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1); Array.Sort(nums2);
        int i = 0; int j = 0; List<int> output = new List<int>();
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                output.Add(nums1[i]);
                i++; j++;
            }
            else if (nums1[i] > nums2[j])
            {
                j++;
            }
            else if (nums1[i] < nums2[j])
            {
                i++;
            }
        }

        return output.ToArray();
    }

    #endregion
}