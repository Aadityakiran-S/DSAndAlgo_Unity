using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ValidAnagram : MonoBehaviour
{
    #region Question
    //https://leetcode.com/problems/valid-anagram/
    #endregion

    #region References

    [SerializeField] private string _firstString;
    [SerializeField] private string _secondString;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        //Debug.Log("Valid Anagram? " + CheckIfValidAnagram_1(_firstString, _secondString));
        Debug.Log("Valid Anagram? " + CheckIfValidAnagram_2(_firstString, _secondString));
    }

    #endregion

    #region HelperMethods
    private bool CheckIfValidAnagram_1(string s, string t)
    {
        char[] sChar = s.ToArray();
        char[] tChar = t.ToArray();
        Array.Sort(sChar);
        Array.Sort(tChar);

        s = new string(sChar);
        t = new string(tChar);

        return s == t;
    }

    private bool CheckIfValidAnagram_2(string s, string t)
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
                if(tChars[item.Key] != sChars[item.Key])
                {
                    return false;
                }
            }
        }

        return true;
    }

    #endregion
}