using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLinkedListImplementation : MonoBehaviour
{
    #region Referances

    [SerializeField] private CustomLinkedList _linkedList;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        System.Object obj = "Midhun";
        _linkedList = new CustomLinkedList(obj);
    }

    private void Start()
    {
        Debug.Log("Head value is: " + _linkedList.Retrieve());
    }

    #endregion
}
