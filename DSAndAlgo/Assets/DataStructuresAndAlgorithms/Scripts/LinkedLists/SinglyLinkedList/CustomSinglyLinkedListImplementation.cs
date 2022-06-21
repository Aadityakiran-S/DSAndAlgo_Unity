using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSinglyLinkedListImplementation : MonoBehaviour
{
    #region Referances

    [SerializeField] private CustomSinglyLinkedList _linkedList;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        System.Object obj = "Midhun";
        _linkedList = new CustomSinglyLinkedList(obj);
    }

    private void Start()
    {
        Debug.Log("Head value is: " + _linkedList.Retrieve());
    }

    #endregion
}
