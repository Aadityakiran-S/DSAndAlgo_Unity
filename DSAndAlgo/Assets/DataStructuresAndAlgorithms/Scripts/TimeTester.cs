using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class TimeTester : MonoBehaviour
{
    #region Referances

    public UnityEvent OnCallFunctionToCheckForTime;

    #endregion

    #region Start and Update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            //Write function to check time

            OnCallFunctionToCheckForTime?.Invoke();

            //Between these two comments

            stopwatch.Stop();
            Debug.Log("Time taken: " + (stopwatch.Elapsed));
            stopwatch.Reset();
        }
    }

    #endregion
}
