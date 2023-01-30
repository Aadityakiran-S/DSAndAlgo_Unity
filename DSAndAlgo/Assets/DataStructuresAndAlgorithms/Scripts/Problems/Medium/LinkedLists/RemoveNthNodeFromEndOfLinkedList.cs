using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RemoveNthNodeFromEndOfLinkedList : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/

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

	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		ListNode dummy = new ListNode(0, head);
		ListNode left = dummy, right = dummy;

		for (int i = 0; i <= n; i++)
		{ //Shift right by n places
			right = right.next;
		}

		//Shifting left to the node before removal and right to the end
		while (right != null)
		{
			left = left.next; right = right.next;
		}

		//Actually removing node that we want to which is just before temp at this point
		left.next = left.next.next;

		return dummy.next;
	}

	#endregion

	#region Helper Methods	



	#endregion
}