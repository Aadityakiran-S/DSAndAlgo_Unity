using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLinkedListImplementation_2 : MonoBehaviour
{
    #region Referances

    [SerializeField] private CustomLinkedList2 _linkedList;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _linkedList = new CustomLinkedList2("Midhun");
        _linkedList.Append("Allen");
        _linkedList.Append("Aaditya");
        _linkedList.Append("Amal");
        _linkedList.Append("Abhijith");
        _linkedList.Append("Adarsh");
        _linkedList.Prepend("Bijoy");
        _linkedList.Insert(3, "Aravind");
    }

    private void Start()
    {
        Debug.Log("Head value is: " + _linkedList.Retrieve(0));
        Debug.Log("Tail value is: " + _linkedList.Retrieve(_linkedList.Length - 1));

        _linkedList.PrintAllValues();
        _linkedList.RemoveAt(3);
        _linkedList.PrintAllValues();

        //the code below is written to throw exception; Just to check if the execptions I wrote are working as intended
        //Debug.Log("A random value is: " + _linkedList.Retrieve(20));
        //_linkedList.Remove(2.4f);
    }

    #endregion
}
