using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonMethods 
{
    public static void CheckIfIndexInBounds(int index, int Length)
    {
        if (!(index <= Length - 1 && index >= 0))
        {
            throw new System.ArgumentOutOfRangeException("index", "Index is either negative or out of the range of the list");
        }
    }
}
