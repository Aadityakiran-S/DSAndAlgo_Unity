using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PascalsTriangleII : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/pascals-triangle-ii/

	#endregion

	#region References

	private List<int> _output;

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

	public IList<int> GetRow_Iterative(int rowIndex)
	{
		IList<int> prev = new List<int> { 1 };

		if (rowIndex == 0)
		{
			return prev;
		}

		prev.Add(1); int currRow = 1;
		while (currRow < rowIndex)
		{
			List<int> curr = new List<int> { 1 };
			for (int i = 0; i < prev.Count - 1; i++)
			{
				curr.Add(prev[i] + prev[i + 1]);
			}
			curr.Add(1);
			prev = curr; currRow++;
		}

		return prev;
	}

	public IList<int> GetRow_Recursive(int rowIndex)
	{
		_output = new List<int>();

		if (rowIndex == 0)
		{
			return new List<int> { 1 };
		}
		else if (rowIndex == 1)
		{
			return new List<int> { 1, 1 };
		}

		GetRow_Recursive_Internal(rowIndex, 1, new List<int> { 1, 1 });

		return _output;
	}

	#endregion

	#region Helper Methods	

	private void GetRow_Recursive_Internal(int rowNum, int currRowNum, List<int> prevList)
	{
		if (currRowNum == rowNum)
		{
			_output = prevList;
			return;
		}

		List<int> currList = new List<int> { 1 };
		for (int i = 0; i < prevList.Count - 1; i++)
		{
			currList.Add(prevList[i] + prevList[i + 1]);
		}
		currList.Add(1);

		GetRow_Recursive_Internal(rowNum, currRowNum + 1, currList);
	}

	#endregion
}