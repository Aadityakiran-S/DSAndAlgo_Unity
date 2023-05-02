using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DeleteNodeInLinkedList : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/

	#endregion

	#region References



	#endregion

	#region UnityLifecycle

	//Use this to initialize
	private void Awake()
	{
	
	}	
	
	//Use this to run
	private void Start()
    {
        
    }

	#endregion

	#region Methods	

	public void DeleteNode_Optimized(ListNode node)
	{
		//Changing our node's value to the next value
		node.val = node.next.val; //Thereby removing the value from list

		//At this point, we have 2 next nodes

		//Removing the duplicate next node from the list 
		//by cutting it's connection
		node.next = node.next.next;
	}

	public void DeleteNode(ListNode node)
	{
		ListNode curr = node; ListNode prev = null;

		//Swapping values till we reach the last node. 
		while (curr.next != null)
		{
			curr.val = curr.next.val;
			prev = curr; curr = curr.next;
		}

		//Cutting off the connection to the last node
		prev.next = null;
	}

	#endregion

	#region Helper Methods	



	#endregion
}