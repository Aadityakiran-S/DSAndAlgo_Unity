using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LongestSubStringWithoutRepeatingChars : MonoBehaviour
{
    #region Question
    //Given a string s, find the length of the longest substring without repeating characters.

    //Example 1:

    //Input: s = "abcabcbb"
    //Output: 3
    //Explanation: The answer is "abc", with the length of 3.

    //Example 2:

    //Input: s = "bbbbb"
    //Output: 1
    //Explanation: The answer is "b", with the length of 1.

    //Example 3:

    //Input: s = "pwwkew"
    //Output: 3
    //Explanation: The answer is "wke", with the length of 3.
    //Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

    //Constraints:

    //0 <= s.length <= 5 * 104
    //s consists of English letters, digits, symbols and spaces.

    #endregion

    #region References

    [SerializeField] private string _stringToCheck;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {
        Debug.Log("Max Length " + LengthOfLongestSubstring_Optimized(_stringToCheck));
    }

    #endregion

    #region Methods	

    public int LengthOfLongestSubstring(string s) //S: n; T: n (possibly n^2);
    {
        Dictionary<char, int> charDict = new Dictionary<char, int>();
        int currentCount = 0; int greatestCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            //If does not contain, then we can keep adding and incrementing count
            if (!charDict.ContainsKey(s[i]))
            {
                charDict.Add(s[i], i);
                currentCount++;
            }
            else //If contains then we need to start new substring
            {
                i = charDict[s[i]]; //Resetting i to the position after first occurance of repetition

                //Completely wipe local cache and go back to index after repeating element
                charDict = new Dictionary<char, int>();
                currentCount = 0;
            }

            greatestCount = Math.Max(currentCount, greatestCount);
        }

        return greatestCount; //No need to add 1 since we're incrementing this ourselves
    }

    public int LengthOfLongestSubstring_Optimized(string s)
    {
        //Empty string? Can't do anything about it
        if (s.Length == 0)
        {
            return 0;
        }

        Dictionary<char, int> charDict = new Dictionary<char, int>();
        int left = 0; int right = 1; int currentLength = 0; int maxLength = 0;
        charDict.Add(s[left], left);

        while (right < s.Length)
        {
            //If haven't seen before, simply add to dict
            if (!charDict.ContainsKey(s[right]))
            {
                charDict.Add(s[right], right);
            }
            //If have seen
            else
            {
                //Put left to just right of first occurance of this char if left hasn't passed it already
                if (left <= charDict[s[right]] + 1)
                    left = charDict[s[right]] + 1;

                charDict[s[right]] = right; //Change value of repeated key to current index of right
            }

            currentLength = right - left;
            maxLength = Math.Max(currentLength, maxLength);
            right++;
        }

        return maxLength + 1; //+1 because subtracting indices is always 1 less than actual length
    }

    #endregion
}