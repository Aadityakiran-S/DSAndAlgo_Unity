using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TotalNumberOfBinaryTreePaths : MonoBehaviour
{
	#region Question

	//https://leetcode.com/problems/binary-tree-paths/description/

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

	public IList<string> BinaryTreePaths(TreeNode root)
	{
		IList<string> res = new List<string>();
		if (root == null)
		{
			goto end;
		}
		if (root.left == null && root.right == null)
		{
			res.Add(root.val.ToString());
			goto end;
		}

		string path = "";
		Recurse(root, path, res);

		end:
		return res;
	}

	void Recurse(TreeNode curr, string path, IList<string> res)
	{
		if (curr == null)
		{
			return;
		}

		path = $"{path}{curr.val}->";

		if (curr.left == null && curr.right == null)
		{
			path = path.Substring(0, path.Length - 2); //Removing the -> at the end from the last step
			res.Add(path);
			return;
		}

		Recurse(curr.left, path, res);
		Recurse(curr.right, path, res);
	}

	#endregion

	#region Helper Methods	



	#endregion
}