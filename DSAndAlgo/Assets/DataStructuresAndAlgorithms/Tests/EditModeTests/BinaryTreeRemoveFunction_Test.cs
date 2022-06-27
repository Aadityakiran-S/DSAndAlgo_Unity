using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BinaryTreeRemoveFunction_Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void BinaryTreeRemoveFunction_TestSimplePasses()
    {
        ///What do we need to test? (We've already established all other functions work )
        /// We need to test the remove method...
        /// So what are the test cases?
        /// Basically, add all the stuff you usually do to the tree
        /// Then remove 170 (Leaf remove)
        /// Then remove 14 (single child node)
        /// Then remove 4 (2 child node remove)
        /// Then remove 9 (removing root itself)

        BinarySearchTree _tree = new BinarySearchTree();
        _tree.Insert(9);
        _tree.Insert(4);
        _tree.Insert(6);
        _tree.Insert(20);
        _tree.Insert(170);
        _tree.Insert(15);
        _tree.Insert(1);
        _tree.Insert(14);
        _tree.Insert(16);
        _tree.Insert(0);
        _tree.Insert(8);

        _tree.Remove(170);  //Leaf remove
        Assert.AreEqual(null, _tree.Lookup(20).nodeToReturn.right);

        _tree.Remove(6);   //Single child remove
        Assert.AreEqual(null, _tree.Lookup(8).nodeToReturn.right);
        Assert.AreEqual(8, _tree.Lookup(4).nodeToReturn.right.Value);

        //_tree.Remove(4);    //2 child remove
        //Assert.AreEqual(null, _tree.Lookup(20).nodeToReturn.right);

        //_tree.Remove(9);    //Removing root itself
        //Assert.AreEqual(null, _tree.Lookup(20).nodeToReturn.right);
    }
}
