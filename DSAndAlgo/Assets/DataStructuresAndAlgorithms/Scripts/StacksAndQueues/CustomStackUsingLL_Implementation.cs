using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStackUsingLL_Implementation : MonoBehaviour
{
    #region References

    [SerializeField] private CustomStackUsingLinkedList _stack;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _stack = new CustomStackUsingLinkedList("Bijoy");
        _stack.Push("Midhun");
        _stack.Push("Allen");
        _stack.Push("Aravind");
        _stack.Push("Aaditya");
        _stack.Push("Amal");
        _stack.Push("Abhijith");
        _stack.Push("Adarsh");
    }

    private void Start()
    {
        Debug.LogWarning("Stack length now is: " + _stack.Length);
        Debug.Log("Peeking at the last value: " + _stack.Peek());

        int currentStackLength = _stack.Length;

        for (int i = 0; i < currentStackLength; i++)
        {
            Debug.Log(i + "th entry popped is: " + _stack.Pop());
        }

        Debug.LogWarning("Stack length now is: " + _stack.Length);
        _stack.Pop();
    }

    #endregion

}
