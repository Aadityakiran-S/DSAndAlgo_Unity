using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SwapPairsOfNodes : MonoBehaviour
{
	#region Question
	
	

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

	public ListNode SwapPairs_Iterative(ListNode head)
	{
		if (head == null)
		{
			return null;
		}
		else if (head.next == null)
		{
			return head;
		}

		ListNode curr = head; ListNode toReturn = curr.next;
		while (curr != null && curr.next != null)
		{
			ListNode next = curr.next;
			ListNode next2 = next.next;
			next.next = curr;

			if (next2 == null)
			{
				curr.next = null;
				break;
			}
			else
			{
				ListNode next3 = next2.next;

				if (next3 == null)
				{
					curr.next = next2;
					break;
				}
				else
				{
					curr.next = next3;
					curr = next2;
				}
			}
		}

		return toReturn;
	}

	public ListNode SwapPairs_Iterative_Values(ListNode head)
	{
		ListNode curr = head;

		while (curr != null && curr.next != null)
		{
			SwapValues(curr, curr.next);

			curr = curr.next.next;
		}

		return head;
	}

	public ListNode SwapPairs_Values_Recursive(ListNode head)
	{
		SwapPairs_Values_Recursive_Internal(head);
		return head;
	}	

	public ListNode SwapPairs_Recursive(ListNode head)
	{
		return SwapPairs_Recursive_Internal(head);
	}

	#endregion

	#region Helper Methods	

	private ListNode SwapPairs_Recursive_Internal(ListNode curr)
	{
		if (curr == null)
		{
			return null;
		}

		//The next of the current pair depends on which is the next2Next in the next pair
		ListNode next = curr.next; ListNode next2Next = null;
		
		//At the end we'll get next as null so we need to be careful
		if (next != null)
		{
			next2Next = next.next; next.next = curr;
		}

		curr.next = SwapPairs_Recursive_Internal(next2Next);

		//If next is null, return current otherwise return null. 
		//This is to prevent prevent last node from being dropped from odd notes
		return next ?? curr; 
	}

	private void SwapPairs_Values_Recursive_Internal(ListNode curr)
	{
		if (curr == null)
		{
			return;
		}

		ListNode next = curr.next;

		if (next == null)
		{
			return;
		}

		SwapValues(curr, next);
		SwapPairs_Values_Recursive_Internal(next.next);
	}

	private void SwapValues(ListNode one, ListNode two)
	{
		int ONE = one.val; int TWO = two.val;
		one.val = TWO; two.val = ONE;
	}

	#endregion
}