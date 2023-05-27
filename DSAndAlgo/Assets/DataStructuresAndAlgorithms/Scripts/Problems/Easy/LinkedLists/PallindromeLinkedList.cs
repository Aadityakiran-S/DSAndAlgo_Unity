using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PallindromeLinkedList : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/palindrome-linked-list/description/

    #endregion

    #region Trivial solutionl: Adding all elements to a list

    public bool IsPalindrome_Trivial(ListNode head)
    {
        List<int> values = new List<int>(); ListNode curr = head;
        while (curr != null)
        {
            values.Add(curr.val);
            curr = curr.next;
        }

        for (int i = 0; i < values.Count; i++)
        {
            int j = (values.Count - 1) - i;
            if (j < i)
            {
                break;
            }
            if (values[i] != values[j])
            {
                return false;
            }
        }
        return true;
    }

    #endregion

    #region Recursive Solution (Advanced) 

    ListNode frontPointer;
    public bool IsPalindrome_Recursive(ListNode head)
    {
        frontPointer = head;
        return Recurse(head);
    }

    private bool Recurse(ListNode curr)
    {
        if (curr != null)
        {
            if (!Recurse(curr.next)) return false;
            if (curr.val != frontPointer.val) return false;
            frontPointer = frontPointer.next;
        }
        return true;
    }

    #endregion

    #region 3 Step Process

    //In place algorithm to determine pallindrome
    public bool IsPalindrome_3Step(ListNode head)
    {
        ListNode half = FindMidNode(head);
        ListNode first = head;

        var last = ReverseList(half.next);
        half.next = last; //Reattaching last to after half, after reversal

        bool output = CompareBothHalvesOfList(first, half.next);

        //Putting the list back the way it was
        last = ReverseList(half.next);
        half.next = last;

        return output;
    }

    //After reversal of half, start from the head and the middle and compare each values
    bool CompareBothHalvesOfList(ListNode first, ListNode second)
    {
        while (second != null)
        {
            // Console.WriteLine(first.val); Console.WriteLine(second.val);
            if (first.val != second.val)
            {
                return false;
            }
            first = first.next; second = second.next;
        }
        return true;
    }

    //Classic reversal of list iterative but need to return end so that we may 
    //attach it to mid to complete the reversal properly
    ListNode ReverseList(ListNode start)
    {
        ListNode curr = start; ListNode prev = null;
        while (curr != null)
        {
            var next = curr.next;
            curr.next = prev;

            //Condition to prevent prev from being null on exit condition
            if (curr == null)
            {
                break;
            }

            prev = curr; curr = next;
        }
        return prev;
    }

    //Slow and fast pointer method where fast reaches the end when slow reaches half
    ListNode FindMidNode(ListNode head)
    {
        ListNode slow = null; ListNode fast = head;
        while (fast != null)
        {
            if (fast.next != null)
            {
                fast = fast.next.next;
            }
            //Condition to stop loop when fast is at penultimate node
            else
            {
                fast = null;
            }

            //Condition to assing value to slow in the initial iteration
            if (slow == null)
            {
                slow = head;
            }
            else
            {
                slow = slow.next;
            }
        }

        return slow; //Return slow since it's at mid now
    }
    #endregion
}