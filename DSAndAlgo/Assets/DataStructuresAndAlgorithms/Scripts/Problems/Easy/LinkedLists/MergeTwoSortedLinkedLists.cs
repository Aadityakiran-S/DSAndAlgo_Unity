using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MergeTwoSortedLinkedLists : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/merge-two-sorted-lists/description/

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
    public ListNode MergeTwoLists(ListNode h1, ListNode h2)
    {
        //Edge cases: (1) Both are null => Return either
        //            (2) Only one is null => Return not null one
        if (h1 == null || h2 == null)
        {
            return (h1 == null) ? h2 : h1;
        }

        //Setting head and current. Doing first iteration
        ListNode h0 = new ListNode(); ListNode curr = h0;
        while (h1 != null && h2 != null)
        {
            //Assigning min to current's next and incrementing pointers
            curr.next = new ListNode(Math.Min(h1.val, h2.val));
            curr = curr.next;

            //C# requires us to return something from a conditional operator
            //That's why I've put this _temp variable
            ListNode _temp = (h1.val > h2.val) ? (h2 = h2.next) : (h1 = h1.next);
        }

        //Attaching next of curr to the rest of the not null LL.
        curr.next = (h1 == null) ? h2 : h1;

        //First value will be zero due to initialization so returning from there.
        return h0.next;
    }
        
    //This solution splices the original list itself to create the output list
    public ListNode MergeTwoLists_Optimized(ListNode h1, ListNode h2)
    {
        //Edge cases: (1) Both are null => Return either
        //            (2) Only one is null => Return not null one
        if (h1 == null || h2 == null)
        {
            return (h1 == null) ? h2 : h1;
        }

        ListNode head = new ListNode();
        ListNode tail = head;

        while (h1 != null && h2 != null)
        {

            if (h1.val < h2.val)
            {
                tail.next = h1;
                h1 = h1.next;
            }
            else
            {
                tail.next = h2;
                h2 = h2.next;
            }

            tail = tail.next;
        }

        tail.next = (h1 == null) ? h2 : h1;

        return head.next; //First entry is null to prevent entering into null list
    }

    #endregion
}