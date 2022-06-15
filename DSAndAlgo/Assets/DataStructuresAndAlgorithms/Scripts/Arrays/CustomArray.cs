using System;
using System.Collections;
using System.Collections.Generic;

public class CustomArray<T>
{
    T[] arr = null;

    public CustomArray()
    {
        arr = new T[1];
        // myInitialize(ref arr, arr.Length + 1);
    }       

    public void Add(T item)
    {
        arr[arr.Length - 1] = item;
        InitializeCustomArray(ref arr, arr.Length + 1);
    }

    #region Private Functions

    private void InitializeCustomArray(ref T[] arr, int newLength)
    {
        if (arr == null)
        {
            arr = new T[newLength];
        }
        else
        {
            T[] tempArr = new T[newLength];
            //Array.Copy(arr, tempArr, arr.Length);
            for (int i = 0; i < newLength; i++)
                if (i < arr.Length)
                {
                    tempArr[i] = arr[i];
                }
                else
                {
                    tempArr[i] = default(T);
                }
            arr = new T[newLength];
            //Array.Copy(tempArr, arr, arr.Length);
            for (int i = 0; i < newLength; i++)
            {
                arr[i] = tempArr[i];
            }
        }
    }

    #endregion
}
