using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQueueImplementation : MonoBehaviour
{
    #region References

    [SerializeField] private CustomQueue _queue;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _queue = new CustomQueue("Bijoy");
        _queue.Enqueue("Midhun");
        _queue.Enqueue("Allen");
        _queue.Enqueue("Aravind");
        _queue.Enqueue("Aaditya");
        _queue.Enqueue("Amal");
        _queue.Enqueue("Abhijith");
        _queue.Enqueue("Adarsh");
    }

    private void Start()
    {
        Debug.LogWarning("Stack length now is: " + _queue.Length);
        Debug.Log("Peeking at the last value: " + _queue.Peek());

        int currentQueueLength = _queue.Length;

        for (int i = 0; i < currentQueueLength; i++)
        {
            Debug.Log(i + "th entry popped is: " + _queue.Dequeue());
        }

        Debug.LogWarning("Stack length now is: " + _queue.Length);
        _queue.Dequeue();
    }

    #endregion
}
