using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KClosestPointsToOrigin : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/k-closest-points-to-origin/description/

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

	//public int[][] KClosest(int[][] points, int k)
	//{

	//	//Declaring output and PQ (minHeap)
	//	int[][] output = new int[k][]; PriorityQueue<int[], float> minHeap = new();

	//	//Iterating through input and sorting according to priority
	//	foreach (int[] point in points)
	//	{
	//		minHeap.Enqueue(point, DistanceFromOrigin(point));
	//	}

	//	//Popping k elements of min priority (closest to origin)
	//	for (int i = 0; i < k; i++)
	//	{
	//		output[i] = minHeap.Dequeue();
	//	}

	//	return output;
	//}

	////Simply calculating distance from origin
	//private float DistanceFromOrigin(int[] point)
	//{
	//	float xSqr = (float)Math.Pow(point[0], 2);
	//	float ySqr = (float)Math.Pow(point[1], 2);
	//	return (float)Math.Sqrt(ySqr + xSqr);
	//}

	#endregion
}