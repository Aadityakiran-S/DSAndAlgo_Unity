using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomArray2_Implementation : MonoBehaviour
{
    #region Referances

    [SerializeField] private CustomArray2 _customArray;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _customArray = new CustomArray2();
        _customArray.Push("Bijoy");
        _customArray.Push("Midhun");
        _customArray.Push("Allen");
        _customArray.Push("Aaditya");
        _customArray.Push("Amal");
        _customArray.Push("Abhijith");
        _customArray.Push("Adarsh");
    }

    private void Start()
    {
        Debug.Log("Length of before popped array: " + _customArray.Length);
        Debug.Log("Printing array before popping");

        int j = 0;
        while (j < _customArray.Length)
        {
            Debug.Log("Element " + j + " is " + _customArray.GetObject(j));
            j++;
        }

        System.Object objPop = _customArray.Pop();
        Debug.Log("Popped object is: " + objPop);
        System.Object objDel = _customArray.Delete(5);
        Debug.Log("Deleted object is: " + objDel);

        Debug.Log("Length of after popped array: " + _customArray.Length);
        Debug.Log("Printing array after popping");

        int i = 0;
        while(i < _customArray.Length)
        {
            Debug.Log("Element " + i + " is " + _customArray.GetObject(i));
            i++;
        }
    }

    #endregion
}
