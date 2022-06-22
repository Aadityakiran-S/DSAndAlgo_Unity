using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueUsingStack_Implementation : MonoBehaviour
{
    #region References

    [SerializeField] private QueueUsingStack<int> _queue;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _queue = new QueueUsingStack<int>();
        for (int i = 1; i < 11; i++)
        {
            _queue.Enqueue(i);
        }
    }

    private void Start()
    {
        Debug.LogWarning("Peeking first come: " + _queue.Peek());
        _queue.PrintAllValues();
        
        int currentLength = _queue.Length;
        for (int i = 0; i < currentLength; i++)
        {
            Debug.Log(i + "th entry popped is: " + _queue.Dequeue());
        }

        Debug.LogWarning("Current queue Length is " + _queue.Length);
        _queue.PrintAllValues();
    }

    #endregion
}
