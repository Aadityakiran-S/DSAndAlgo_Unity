using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SearchAMatrix : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/search-a-2d-matrix/description/

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

    //Do binary search in left column to narrow down the row and then binary search in there again
    public bool SearchMatrix(int[][] matrix, int target)
    {
        //Performing binary search on left column.
        int top = 0; int bottom = matrix.Length - 1;
        while (top < bottom)
        {
            int mid = (int)Math.Floor((double)(top + bottom) / 2);

            if (matrix[mid][0] == target)
                return true;

            //During shifting of top pointer, 
            //if a flip in target position occurs, then we've narrowed down our row
            if (matrix[mid][0] < target)
            {
                //Flip occuring
                if (matrix[mid + 1][0] > target)
                {
                    top = mid; bottom = mid;
                    break;
                }
                else
                {
                    top = mid + 1;
                }
            }
            else if (matrix[mid][0] > target)
            {
                bottom = mid - 1;
            }

            //At the end of this, if top and bottom coincide, then we've again narrowed down our row
            if (top == bottom)
            {
                break;
            }
        }

        //Now, doing binary search on narrowed row (at this point top and bottom are same)
        int left = 0; int right = matrix[0].Length - 1;

        while (left <= right)
        {
            int mid = (int)Math.Floor((double)(left + right) / 2);

            if (matrix[top][mid] == target)
            {
                return true;
            }

            if (matrix[top][mid] < target)
            {
                left = mid + 1;
            }
            else if (matrix[top][mid] > target)
            {
                right = mid - 1;
            }
        }

        return false;
    }

    #endregion

    #region Helper Methods	



    #endregion
}