using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IntersectionOf2Arrays : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/intersection-of-two-arrays/description/

    #endregion

    #region Methods		

    public int[] Intersection_1(int[] nums1, int[] nums2)
    {
        HashSet<int> set = new HashSet<int>(); List<int> output = new List<int>();
        foreach (int entry in nums1)
        {
            if (!set.Contains(entry))
            {
                set.Add(entry);
            }
        }

        foreach (int entry in nums2)
        {
            if (set.Contains(entry))
            {
                output.Add(entry);
                set.Remove(entry);
            }
        }

        return output.ToArray();
    }

    public int[] Intersection_2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1); Array.Sort(nums2); //T: O(nlogn) S: O(logn)
        int i = 0; int j = 0; HashSet<int> set = new HashSet<int>();
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else if (nums1[i] > nums2[j])
            {
                j++;
            }
            else
            { //If they are equal
                set.Add(nums1[i]);
                i++; j++;
            }
        }
        int[] output = new int[set.Count]; //S: O(n)
        int k = 0;
        foreach (int entry in set)
        {
            //Increment value after insertion k++ does that ++k does increment before
            output[k++] = entry;
        }
        return output;
    }

    public int[] Intersection_3(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1); HashSet<int> set = new HashSet<int>();
        foreach (int entry in nums2)
        {
            if (BinarySearch(nums1, entry))
            {
                set.Add(entry);
            }
        }
        int[] output = new int[set.Count];
        int k = 0;
        foreach (int entry in set)
        {
            output[k++] = entry;
        }
        return output;
    }

    private bool BinarySearch(int[] input, int target)
    {
        int l = 0; int r = input.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (input[m] == target)
            {
                return true;
            }

            if (input[m] < target)
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }
        return target == input[l];
    }

    #endregion
}