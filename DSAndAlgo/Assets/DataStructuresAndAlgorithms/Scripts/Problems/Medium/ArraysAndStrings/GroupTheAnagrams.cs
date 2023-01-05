using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GroupTheAnagrams : MonoBehaviour
{
    #region Question
    //https://leetcode.com/problems/group-anagrams/	
    #endregion

    #region References

    [SerializeField] private string[] _input;

    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
    {

    }

    //Use this to run
    private void Start()
    {
        GroupAnagrams(_input);
    }

    #endregion

    #region Methods	

    public IList<IList<string>> GroupAnagrams1(string[] input)
    {
        bool[] seen = new bool[input.Length];
        IList<IList<string>> output = new List<IList<string>>();

        if (input.Length == 0)
        {
            return output;
        }
        else if (input.Length == 1)
        {
            output.Add(input);
            return output;
        }

        while (true)
        {
            int start = -1; //Setting as -1 to see if all seen is true
            IList<string> anagrams = new List<string>();

            //Checking for first unseen value
            for (int i = 0; i < seen.Length; i++)
            {
                //Breaking out of iteration in seen when first unseen value is found
                if (seen[i] == false)
                {
                    seen[i] = true;
                    start = i;
                    anagrams.Add(input[i]);
                    break;
                }
            }

            //If all values are seen
            if (start == -1)
            {
                break;
            }

            //Checking against each value in input for anagram match
            for (int i = 0; i < input.Length; i++)
            {
                //Only need to check unseen values
                if (seen[i] == false)
                {
                    //If both are anagrams of eachother
                    if (CheckIfValidAnagram(input[start], input[i]))
                    {
                        seen[i] = true;
                        anagrams.Add(input[i]);
                    }
                }
            }

            output.Add(anagrams);
        }

        return output;
    }

    public IList<IList<string>> GroupAnagrams(string[] input)
    {
        IList<IList<string>> output = new List<IList<string>>();
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        //Edge cases
        if (input.Length == 0)
        {
            return output;
        }
        else if (input.Length == 1)
        {
            output.Add(input);
            return output;
        }

        for (int i = 0; i < input.Length; i++)
        {
            string sortedEntry = string.Concat(input[i].OrderBy(c => c));

            //If seen anagram before, we're adding to it's group in dict
            if (dict.ContainsKey(sortedEntry))
            {
                dict[sortedEntry].Add(input[i]);
            }
            else
            {
                List<string> temp = new List<string> { input[i] };
                dict.Add(sortedEntry, temp);
            }
        }

        foreach (var item in dict)
        {
            output.Add(item.Value);
        }

        return output;
    }

    #endregion

    #region Helper Methods

    private bool CheckIfValidAnagram(string s, string t)
    {
        //Can't be an anagram if not of same length
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> sChars = new Dictionary<char, int>();
        Dictionary<char, int> tChars = new Dictionary<char, int>();

        //Populating hashTable for s
        foreach (char c in s)
        {
            //If already contians c then increment it's count
            if (sChars.ContainsKey(c))
            {
                sChars[c] += 1;
            }
            else//Add char and it's initial count as hashTable entry
                sChars.Add(c, 1);
        }

        //Same process for t
        foreach (char c in t)
        {
            if (tChars.ContainsKey(c))
            {
                tChars[c] += 1;
            }
            else
                tChars.Add(c, 1);
        }

        //If all entries with corresponding counts are same in both => Valid anagram
        foreach (var item in sChars)
        {
            //If doesn't contain any one key then they're just words of same length
            if (!tChars.ContainsKey(item.Key))
            {
                return false;
            }
            else
            {
                //If not of same count, then they're not exactly anagrams
                if (tChars[item.Key] != sChars[item.Key])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private string Return_SortedString(string s)
    {
        char[] cArr = s.ToCharArray();
        Array.Sort(cArr);
        string outputString = cArr.ToString();

        return outputString;

        //return String.Concat(s.OrderBy(c => c));
    }

    #endregion
}