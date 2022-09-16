using UnityEngine;

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ValidPallindrome : MonoBehaviour
{
    #region Question
    //A phrase is a palindrome if, after converting all uppercase letters into lowercase letters
    //and removing all non-alphanumeric characters, it reads the same forward and backward.
    //Alphanumeric characters include letters and numbers.

    //Given a string s, return true if it is a palindrome, or false otherwise.

    //Example 1:

    //Input: s = "A man, a plan, a canal: Panama"
    //Output: true
    //Explanation: "amanaplanacanalpanama" is a palindrome.
    //Example 2:

    //Input: s = "race a car"
    //Output: false
    //Explanation: "raceacar" is not a palindrome.
    //Example 3:

    //Input: s = " "
    //Output: true
    //Explanation: s is an empty string "" after removing non-alphanumeric characters.
    //Since an empty string reads the same forward and backward, it is a palindrome.

    //Constraints:

    //1 <= s.length <= 2 * 105
    //s consists only of printable ASCII characters.
    #endregion

    #region References

    [SerializeField] private string _stringToCheckIfPallindrome;

    //[Space(5)]
    //[SerializeField] private string _stringToValidateRegex;
    //[SerializeField] private string _regex;

    #endregion

    #region UnityLifecycle

    private void Start()
    {
        Debug.Log("Is given string a pallindrome? " + CheckIfPallindrome(_stringToCheckIfPallindrome));
        //Debug.Log("Validating regex " + ValidateRegex(_stringToValidateRegex, _regex));
    }

    #endregion

    #region Methods

    //DOLATER: Fix this is not working
    private bool ValidateRegex(string input, string regex)
    {
        Regex regXObj = new Regex(regex);
        return Regex.IsMatch(input, regex);
    }

    //DOLATER: Find out why this is slow for that mamoth input
    private bool CheckIfPallindrome_Optimized(string s)
    {
        //Empty strings and single chars are valid pallindromes
        if(s.Length == 0 || s.Length == 1)
        {
            return true;
        }

        int i = 0; int j = s.Length - 1;

        while(i < j)
        {
            while (!CheckIfAlphaNumChar(s[i]) || !CheckIfAlphaNumChar(s[j]))
            {
                Debug.Log("Printing i and j " + i + j);

                //After checking, if indices cross => pruned string is empty or single char which is a pallindrome
                if (i >= j)
                {
                    return true;
                }

                //Incrementing indices to skip non AlpNum char
                if (!CheckIfAlphaNumChar(s[i]))
                {
                    i++;
                }
                if (!CheckIfAlphaNumChar(s[j]))
                {
                    j--;
                }
            }

            if (s.ToLower()[i] != s.ToLower()[j])
            {
                return false;
            }

            i++; j--;
        }

        return true;
    }

    private bool CheckIfPallindrome(string inputString)
    {
        //Empty strings or individual letters are pallindromes anyway
        if (inputString.Length == 0 || inputString.Length == 1)
        {
            return true;
        }

        //Getting rid of all unnecessary charechters
        string lowerInput = inputString.ToLower();
        char[] inputArray = lowerInput.ToCharArray();
        inputArray = inputArray.Where(c => char.IsLetterOrDigit(c)).ToArray();

        //After removing everything if nothing is left, then you could say it is a pldrm
        if (inputArray.Length == 0)
        {
            return true;
        }

        int j = inputArray.Length - 1;
        for (int i = 0; i < inputArray.Length; i++)
        {
            if (i >= j)
            {
                return true;
            }
            else
            {
                if (inputArray[i] != inputArray[j])
                {
                    return false;
                }
            }

            j--;
        }

        return default;
    }

    //Regex is very slow. Linq is much faster
    private bool CheckIfPallindrome_Regex(string inputString)
    {
        //Empty strings or individual letters are pallindromes anyway
        if (inputString.Length == 0 || inputString.Length == 1)
        {
            return true;
        }

        //Regex pruning of things we don't want
        Regex rgx = new Regex("[^a-zA-Z0-9]");
        inputString = rgx.Replace(inputString, "").ToLower();

        //After removing everything if nothing is left, then you could say it is a pldrm
        if (inputString.Length == 0)
        {
            return true;
        }

        //Two pointer iteration 
        int j = inputString.Length - 1;
        for (int i = 0; i < inputString.Length; i++)
        {
            if (i >= j)
            {
                return true;
            }
            else
            {
                if (inputString[i] != inputString[j])
                {
                    return false;
                }
            }

            j--;
        }

        return default;
    }

    #endregion

    #region Helper Functions

    //Custom function to check if ASCII is alphNum or not
    bool CheckIfAlphaNumChar(char c)
    {
        //0-9 digits
        if (c >= 48 && c <= 57)
        {
            return true;
        }
        //Lower case alphabet
        else if (c >= 65 && c <= 90)
        {
            return true;
        }
        //Upper case alphabet
        if (c >= 97 && c <= 122)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator FrameSkipCoroutine()
    {
        yield return new WaitForEndOfFrame();
    }

    #endregion
}