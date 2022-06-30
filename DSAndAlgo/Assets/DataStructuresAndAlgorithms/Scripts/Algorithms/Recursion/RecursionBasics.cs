using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursionBasics : MonoBehaviour
{
    #region References

    [SerializeField] private string _stringToReverse;
    [SerializeField] private string _stringToCheckIfPallindrome;
    [SerializeField] private int _decimalToConvertToBinary;
    [SerializeField] private int _sumFromNumber;

    private int _counter;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _counter = 0;
    }

    private void Start()
    {
        //Debug.Log("Recursion: " + Inception());

        //Debug.Log("Reversed string of " + _stringToReverse + " \n is " + ReverseString(_stringToReverse));
        //Debug.Log(_stringToCheckIfPallindrome + " is Pallindrome? " + CheckIfPallindrom(_stringToCheckIfPallindrome));
        //Debug.Log("Binary of " + _decimalToConvertToBinary + " \n is " + DecimalToBinary(_decimalToConvertToBinary));
        Debug.Log("Sum from " + _sumFromNumber + " is " + SumOfNaturalNumbers(_sumFromNumber));
    }

    #endregion

    #region Methods

    ///How to write recursive?
    /// Base case at top.
    /// Min increment of work to be done as recursive condition.

    private string Inception()
    {
        if (_counter >= 4)  //Base condition
        {
            Debug.Log("I'm done now");
            return "done";
        }

        //else
        _counter++;
        return Inception(); //Recursive condition
    }

    #endregion

    #region Practice Questions 

    private string ReverseString(string stringToRev)
    {
        if (stringToRev == "")   //Base case
        {
            return "";
        }

        //Add first element to end
        return ReverseString(stringToRev.Substring(1)) + stringToRev[0];
    }

    private bool CheckIfPallindrom(string stringToCheck)
    {
        //Base case for odd or even number char string
        if (stringToCheck.Length == 0 || stringToCheck.Length == 1)
        {
            return true;
        }
        else
        {
            //If both end elements are equal, we need to check within again 
            //char.ToUpperInvariant(x) = > eqautes upper and lower case
            if (char.ToUpperInvariant(stringToCheck[0]) == char.ToUpperInvariant(stringToCheck[stringToCheck.Length - 1]))
            {
                return CheckIfPallindrom(stringToCheck.Substring(1, stringToCheck.Length - 2));
            }
            else //if both end elements aren't equal, then it's not a pallindrome
                return false;
        }
    }

    private string DecimalToBinary(int input)
    {
        //Base case is when the input is less than 2. ie: input/2 is zero
        if (input / 2 == 0)
        {
            return (input % 2).ToString();
        }

        //Move the rest to the next stack while appending the current remainder to the end
        return DecimalToBinary(input / 2) + (input % 2);
    }

    private int SumOfNaturalNumbers(int num)
    {
        //Base case
        if(num == 0)
        {
            return 0;
        }

        //Simply sum the number till it gets to zero
        return SumOfNaturalNumbers(num - 1) + num;
    }

    #endregion
}
