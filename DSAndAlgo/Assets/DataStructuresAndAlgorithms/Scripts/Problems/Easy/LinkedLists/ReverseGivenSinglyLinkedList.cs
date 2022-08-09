using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReverseGivenSinglyLinkedList : MonoBehaviour
{
	#region Question

	/// Just reverse a singly linked list.

	#endregion

	#region References

	private SinglyLinkedList _linkedList;
	
	#endregion
	
	#region UnityLifecycle
	
	//Use this to initialize
	private void Awake()
	{
		_linkedList = new SinglyLinkedList(3);
        _linkedList.Append(2);
        _linkedList.Append(1);
        _linkedList.Append(0);
    }	
	
	//Use this to run
	private void Start()
    {
		Debug.LogWarning("Printing BEFORE reversal");
		_linkedList.PrintAllElements();

		ReverseLinkedList_Recursively(_linkedList);
        ReverseLinkedList_Iteratively(_linkedList);

        Debug.LogWarning("Printing AFTER reversal");
		_linkedList.PrintAllElements();
    }
	
	#endregion
	
	#region Methods	
	
	private void ReverseLinkedList_Iteratively(SinglyLinkedList list)
    {
		if(list.head == null)
        {
			Debug.LogError("Can't reverse an empty list bud!");
        }

		SinglyLinkedListNode currentNode = list.head;
		SinglyLinkedListNode previousNode = null;

		while(currentNode != null)
        {
			if(currentNode.nextNode != null)
            {
				var nextNode = currentNode.nextNode;
				currentNode.nextNode = previousNode;
				previousNode = currentNode;
				currentNode = nextNode;
            }
            else //Reached tail
            {
				currentNode.nextNode = previousNode;
				list.head = currentNode;
				currentNode = null;
            }
        }
    }

	private void ReverseLinkedList_Recursively(SinglyLinkedList list)
    {
		if (list.head == null)
		{
			Debug.LogError("Can't reverse an empty list bud!");
		}

		RecursiveReverse(list.head, list);
    }

    #endregion

    #region Helper Functions

	void RecursiveReverse(SinglyLinkedListNode node, SinglyLinkedList list)
    {
		if(node.nextNode == null)
        {
			list.head = node;
			return;
        }

		RecursiveReverse(node.nextNode, list);
		SinglyLinkedListNode nextNode = node.nextNode;
		nextNode.nextNode = node;
		node.nextNode = null;
    }

    #endregion
}

[System.Serializable]
public class SinglyLinkedList
{
	public SinglyLinkedListNode head;

	public SinglyLinkedList(object headValue)
    {
		head = new SinglyLinkedListNode(headValue, null);
    }

	public void Append(object value)
    {
		//Next is always null since append adds a new tail
		SinglyLinkedListNode nodeToAdd = new SinglyLinkedListNode(value, null); 
		SinglyLinkedListNode node = head;

		while(node.nextNode != null) //Fetching latest node
        {
			node = node.nextNode;
        }

		node.nextNode = nodeToAdd;
    }

	public void PrintAllElements()
    {
		SinglyLinkedListNode node = head;

		while (node!= null) //Fetching latest node
		{
			Debug.Log(node.value);
			node = node.nextNode;
		}
	}
}

[System.Serializable]
public class SinglyLinkedListNode
{
	public object value;
	public SinglyLinkedListNode nextNode;

	public SinglyLinkedListNode(object value, SinglyLinkedListNode next)
    {
		this.value = value;
		this.nextNode = next;
    }
}