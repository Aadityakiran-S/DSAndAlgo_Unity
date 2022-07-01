using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDoublyLinkedList_Implementation : MonoBehaviour
{
    #region Referances

    [SerializeField] private CustomDoublyLinkedList _linkedList;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _linkedList = new CustomDoublyLinkedList("Midhun");
        _linkedList.Append("Allen");
        _linkedList.Append("Aaditya");
        _linkedList.Append("Amal");
        _linkedList.Append("Abhijith");
        _linkedList.Append("Adarsh");
        _linkedList.Prepend("Bijoy");
        _linkedList.Insert(2, "Aravind");
    }

    private void Start()
    {
        Debug.Log("Length of list: " + _linkedList.Length);
        Debug.LogWarning("Head value is: " + _linkedList.Retrieve(0));
        Debug.LogWarning("Tail value is: " + _linkedList.Retrieve(_linkedList.Length - 1));

        Debug.LogWarning("Print before removing");
        _linkedList.PrintAllValues_Iterative();
        _linkedList.RemoveAt(2);
        Debug.LogWarning("Print after removing");
        _linkedList.PrintAllValues_BruteForce();

        Debug.LogWarning("##############");     //Just adding to give a visual break to the console

        //Reversing 3 times should be like reversing once
        _linkedList.Reverse_BruteForce();
        _linkedList.Reverse_Iterative();
        _linkedList.Reverse_Recursive();

        _linkedList.PrintAllValues_Recursive();
        _linkedList.PrintAllValues_ReverseRecursive();

        //the code below is written to throw exception; Just to check if the execptions I wrote are working as intended
        //Debug.Log("A random value is: " + _linkedList.Retrieve(20));
        //_linkedList.Remove(2.4f);
    }

    #endregion
}
