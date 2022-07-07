using System.Collections;
using System.Collections.Generic;

public class DFSInBinarySearchTree 
{
    #region Public Methods

    public static int[] Populate_DFSValues_InOrder(BSTNode root)
    {
        List<int> list = new List<int>();
        return Traverse_InOrder(root, list);
    }

    public static int[] Populate_DFSValues_PreOrder(BSTNode root)
    {
        List<int> list = new List<int>();
        return Traverse_PreOrder(root, list);
    }

    public static int[] Populate_DFSValues_PostOrder(BSTNode root)
    {
        List<int> list = new List<int>();
        return Traverse_PostOrder(root, list);
    }

    #endregion

    #region Private Functions

    //Returns all elements in the tree in order
    private static int[] Traverse_InOrder(BSTNode node, List<int> list)
    {
        if (node.left != null)
        {
            Traverse_InOrder(node.left, list);
        }

        list.Add(node.Value);

        if (node.right != null)
        {
            Traverse_InOrder(node.right, list);
        }

        return list.ToArray();
    }

    //Returns elements as they are if added again to the tree, would form the same structure
    private static int[] Traverse_PreOrder(BSTNode node, List<int> list)
    {
        list.Add(node.Value);

        if (node.left != null)
        {
            Traverse_InOrder(node.left, list);
        }
        if (node.right != null)
        {
            Traverse_InOrder(node.right, list);
        }

        return list.ToArray();
    }

    private static int[] Traverse_PostOrder(BSTNode node, List<int> list)
    {
        if (node.left != null)
        {
            Traverse_InOrder(node.left, list);
        }
        if (node.right != null)
        {
            Traverse_InOrder(node.right, list);
        }

        list.Add(node.Value);

        return list.ToArray();
    }

    #endregion
}

///Tree that we made
///         9
///    4        20
///  1   6    15   170
///  

//InOrder => [1, 4, 6, 9, 15, 20, 170]  prints in the order that traversal is happening: from bottom to top
//PreOrder => [9, 4, 1, 6, 20, 15, 170] prints in the order that will enable us to recreate the tree
//PostOrder => [1, 6, 4, 15, 170, 20, 9] left first, children before parent, then right half; same thing.