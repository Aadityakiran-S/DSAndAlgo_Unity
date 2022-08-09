using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AlmostPallindrome : MonoBehaviour
{
    #region Question
    //Given a string s, return true if the s can be palindrome after deleting at most one character from it.

    //Example 1:
    //Input: s = "aba"
    //Output: true

    //Example 2:
    //Input: s = "abca"
    //Output: true
    //Explanation: You could delete the character 'c'.

    //Example 3:
    //Input: s = "abc"
    //Output: false


    //Constraints:
    //1 <= s.length <= 105
    //s consists of lowercase English letters.
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
        Debug.Log("Is given string almost a palindrome? " + CheckIfAlmostPallindrome(_stringToCheck));
    }

    #endregion

    #region Methods

    private bool CheckIfAlmostPallindrome(string s)
    {
        //Any string less that 2 elements will be almost a pallindrome
        if (s.Length <= 2)
        {
            return true;
        }

        int left = 0; int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++; right--;
            }
            else
            {
                if (CheckIfPallindrome(s, left, right - 1) || CheckIfPallindrome(s, left + 1, right))
                    return true;
                else
                    return false;
            }
        }

        return true;
    }

    //Basic thing is when we encounter a pair which is not the same from either end,
    //we skip over it once and check if the rest is a pallindrome
    //if not then we come back to the place we "scooted" over first
    //then we see if scooting the other pointer will yield a pallindrome. 
    private bool CheckIfAlmostPallindrome_Optimized(string s)
    {
        int left = 0; int right = s.Length - 1;
        ScootState scootState = new ScootState();

        while (left < right)
        {
            if (s[left] == s[right]) //If same then continue to move both pointers inwards
            {
                left++; right--;
            }
            else //If not same, to check if already scooted
            {
                //Haven't scooted yet
                if (scootState.numberOfScoots == 0)
                {
                    //Storing indices to come back to if to scoot the other way
                    scootState.leftIndex = left; scootState.rightIndex = right; scootState.numberOfScoots = 1;

                    if (s[left] == s[right - 1]) //Right scoot?
                    {
                        scootState.scootDir = ScootDir.Right;
                        right--;
                    }
                    else if (s[left + 1] == s[right]) //Left scoot?
                    {
                        scootState.scootDir = ScootDir.Left;
                        left++;
                    }
                    else //Can't scoot to get it to move next?
                    {
                        return false;
                    }
                }
                else if (scootState.numberOfScoots == 1) //Once already scooted?
                {
                    //Resetting pointers
                    left = scootState.leftIndex; right = scootState.rightIndex; scootState.numberOfScoots = 2;

                    if (scootState.scootDir == ScootDir.Left) //Scooted to left last time, now we'll do right
                    {
                        if (s[left] == s[right - 1])
                        {
                            right--; scootState.scootDir = ScootDir.Both;
                        }
                        else return false; //Can't make it work when we scoot to right?
                    }
                    else if (scootState.scootDir == ScootDir.Right) //Scooted to right last time, now we'll do left
                    {
                        if (s[left + 1] == s[right])
                        {
                            left++; scootState.scootDir = ScootDir.Both;
                        }
                        else return false; //Can't make it work when we scoot to left? 
                    }
                }
                else //Number of scoots is 2
                {
                    return false;
                }
            }
        }

        return true;
    }

    #endregion

    #region Helper Functions

    private bool CheckIfPallindrome(string inputString, int i, int j)
    {
        //Empty strings or individual letters are pallindromes anyway
        if (inputString.Length == 0 || inputString.Length == 1)
        {
            return true;
        }

        while(i < j)
        {
            if (inputString[i] == inputString[j])
            {
                i++; j--;
            }
            else return false;
        }

        return true;
    }

    #endregion
}

//Scoot is when we shift one pointer over (either right or left pointer) as if to skip that letter to see if
//skipping that letter at most will yield a pallindrome
public struct ScootState
{
    public int leftIndex;
    public int rightIndex;

    public int numberOfScoots;
    public ScootDir scootDir;
}

public enum ScootDir
{
    Left, Right, Both
}