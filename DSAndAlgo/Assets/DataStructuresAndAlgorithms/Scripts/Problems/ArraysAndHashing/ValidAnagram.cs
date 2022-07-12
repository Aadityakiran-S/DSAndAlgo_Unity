using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ValidAnagram : MonoBehaviour
{
    #region Question

    //Given two strings s and t, return true if t is an anagram of s, and false otherwise.

    //An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
    //typically using all the original letters exactly once.



    //Example 1:

    //Input: s = "anagram", t = "nagaram"
    //Output: true
    //Example 2:

    //Input: s = "rat", t = "car"
    //Output: false



    //Constraints:

    //1 <= s.length, t.length <= 5 * 104
    //s and t consist of lowercase English letters.


    //Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?

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

        if (s == t)
            return true;
        else return false;
    }

    private bool CheckIfValidAnagram_2(string s, string t)
    {
        //Can't be an anagram if not of same length
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> sChars  = new Dictionary<char, int>();
        Dictionary<char, int> tChars  = new Dictionary<char, int>();

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
        foreach(char c in t)
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
            if (!tChars.Contains(item))
            {
                return false;
            }
        }

        return true;
    }

    #endregion
}