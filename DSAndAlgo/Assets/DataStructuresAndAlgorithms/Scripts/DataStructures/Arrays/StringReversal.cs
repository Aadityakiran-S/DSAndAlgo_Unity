using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StringReversal : MonoBehaviour
{
    #region References

    [SerializeField] private string _stringToReverse;
    [SerializeField] private string _reversedString;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        _reversedString = ReverseAndReturnString(_stringToReverse);    
    }

    #endregion

    #region Methods

    private string ReverseAndReturnString(string stringToReverse)
    {
        //Performing error check
        if(stringToReverse == string.Empty || stringToReverse.Length == 2)
        {
            Debug.Log("Given string is empty or just one element");
            return string.Empty;
        }

        //Just put from the back to the front simple
        char[] reversedCharArray = new char[stringToReverse.Length];
        for (int i = 0; i < stringToReverse.Length; i++)
        {
            reversedCharArray[i] = stringToReverse[(stringToReverse.Length - 1) - i];
        }

        return new string(reversedCharArray);
    }

    #endregion
}
