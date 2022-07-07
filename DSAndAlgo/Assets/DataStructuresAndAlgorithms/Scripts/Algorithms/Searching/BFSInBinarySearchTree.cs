using System.Collections;
using System.Collections.Generic;

public class BFSInBinarySearchTree
{
    private static int[] Return_BFSValuesInTree_Iterative(BSTNode node)
    {
        List<int> listToReturn = new List<int>(); Queue<BSTNode> tempQueue = new Queue<BSTNode>();
        tempQueue.Enqueue(node);

        while (tempQueue.Count > 0)
        {
            BSTNode currentNode = tempQueue.Dequeue();
            listToReturn.Add(currentNode.Value);

            if (currentNode.left != null)
            {
                tempQueue.Enqueue(currentNode.left);
            }
            if (currentNode.right != null)
            {
                tempQueue.Enqueue(currentNode.right);
            }
        }

        return listToReturn.ToArray();
    }

    private static int[] Return_BFSValuesInTree_Recursive(Queue<BSTNode> queue, List<int> list)
    {
        //Base case: When there are no more elements in the queue
        if (queue.Count == 0)
        {
            return list.ToArray();
        }

        BSTNode currentNode = queue.Dequeue();
        list.Add(currentNode.Value);

        if (currentNode.left != null)
        {
            queue.Enqueue(currentNode.left);
        }
        if (currentNode.right != null)
        {
            queue.Enqueue(currentNode.right);
        }

        return Return_BFSValuesInTree_Recursive(queue, list);
    }
}
