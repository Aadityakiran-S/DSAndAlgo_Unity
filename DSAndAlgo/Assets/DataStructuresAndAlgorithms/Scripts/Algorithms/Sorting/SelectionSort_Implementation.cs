using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SelectionSort_Implementation : MonoBehaviour
{
	#region References

    [SerializeField] private int[] _arrayToSort;

	#endregion

	#region UnityLifecycle
	private void Awake()
	{
		//_arrayToSort = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 }; //I'm just adding this in the inspector
	}

	private void Start()
	{
		Debug.LogWarning("Is array initialy sorted? " + CommonMethods.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));

		SelectionSort(_arrayToSort);

		Debug.LogWarning("Is array finally sorted? " + CommonMethods.CheckIfArrayIsSorted(_arrayToSort, _arrayToSort.Length));
	}

	#endregion

	#region Methods

	private void SelectionSort(int[] arrayToSort)
	{
        if (CommonMethods.CheckIfArrayIsSorted(arrayToSort, arrayToSort.Length))
        {
			Debug.Log("Already sorted bro");
			return;
        }

		int currentLeast; int currentLeastIndex = 0;

        for (int i = 0; i < arrayToSort.Length; i++)
        {
			currentLeast = arrayToSort[i];

            for (int j = i; j < arrayToSort.Length; j++)
            {
				if(currentLeast > arrayToSort[j])
                {
					currentLeast = arrayToSort[j];
					currentLeastIndex = j;
                }
            }

			CommonMethods.SwapElementsInArray(arrayToSort, i, currentLeastIndex);
        }
	}

	#endregion

}