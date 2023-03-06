using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TaskScheduler : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/task-scheduler/

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

	public int LeastInterval(char[] tasks, int n)
	{
		int maxFreq = 0, interval = 0, cnt = 0;
		int[] freq = new int[26];

		foreach (char t in tasks)
		{
			freq[t - 'A']++;

			// Find the most frequent task
			if (freq[t - 'A'] > maxFreq)
			{
				maxFreq = freq[t - 'A'];
				cnt = 1;
			}
			// Count the number of most frequent tasks
			else if (freq[t - 'A'] == maxFreq)
				cnt++;
		}
		// maxFreq - 1: blocks needed to allocate the first maxFreq-1 most-frequent task
		// n + 1: each block needs n+1 spaces due the the cooling interval.
		// cnt: Size of last block = number of most-frequent tasks
		interval = (maxFreq - 1) * (n + 1) + cnt;

		return interval < tasks.Length ? tasks.Length : interval;
	}

	#endregion

	#region Helper Methods	



	#endregion
}