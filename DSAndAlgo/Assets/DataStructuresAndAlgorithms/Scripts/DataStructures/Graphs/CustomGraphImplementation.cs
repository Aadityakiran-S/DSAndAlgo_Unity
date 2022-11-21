using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGraphImplementation : MonoBehaviour
{
    #region References

    private CustomGraph _myGraph;

    #endregion

    #region Unity Lifestyle

    private void Awake()
    {
        _myGraph = new CustomGraph("0");
        _myGraph.AddNode("1");
        _myGraph.AddNode("2");
        _myGraph.AddNode("3");
        _myGraph.AddNode("4");
        _myGraph.AddNode("5");
        _myGraph.AddNode("6");
        _myGraph.AddEdge("3", "1");
        _myGraph.AddEdge("3", "4");
        _myGraph.AddEdge("4", "2");
        _myGraph.AddEdge("4", "5");
        _myGraph.AddEdge("1", "2");
        _myGraph.AddEdge("1", "0");
        _myGraph.AddEdge("0", "2");
        _myGraph.AddEdge("6", "5");
    }

    private void Start()
    {

    }

    #endregion

    #region Public Functions

    #region BFS Functions

    private int[] ReturnBFSArray_FromAdjacencyList(int[][] adjacencyList)
    {
        List<int> answers = new List<int>(); //No shift menthod to add to last index in array for C# so using list
        bool[] seen = new bool[adjacencyList.GetLength(0)]; //Assuming by default all entries are false
        Queue<int> bfsQueue = new Queue<int>(); bfsQueue.Enqueue(0);

        while (bfsQueue.Count > 0)
        {
            int value = bfsQueue.Dequeue();
            answers.Add(value);
            seen[value] = true;
            int[] neighbors = adjacencyList[value];

            //Iterating through all the neighbors and only adding for processing the ones we've not seen
            for (int i = 0; i < neighbors.Length; i++)
            {
                int neighbor = neighbors[i];
                if (!seen[neighbor]) //If not visited, add to queue to process later
                {
                    bfsQueue.Enqueue(neighbor);
                }
            }
        }

        return answers.ToArray();
    }

    private int[] ReturnBFSArray_FromAdjacencyMatrix(int[][] adjacencyMatrix)
    {
        List<int> answers = new List<int>(); //No shift menthod to add to last index in array for C# so using list
        bool[] seen = new bool[adjacencyMatrix.GetLength(0)]; //Assuming by default all entries are false
        Queue<int> bfsQueue = new Queue<int>(); bfsQueue.Enqueue(0);

        while (bfsQueue.Count > 0)
        {
            int value = bfsQueue.Dequeue();
            answers.Add(value);
            seen[value] = true;

            for (int j = 0; j < seen.Length; j++)
            {
                //True if current node as a connection to a node we've not seen before
                if (adjacencyMatrix[value][j] == 1 && seen[j] != true) 
                {
                    bfsQueue.Enqueue(j);
                }
            }
        }

        return answers.ToArray();
    }

    #endregion

    #region DFS Functions

    private int[] ReturnDFSArray_FromAdjacencyList(int[][] adjacencyList)
    {
        List<int> answers = new List<int>();
        bool[] seen = new bool[adjacencyList.GetLength(0)];

        IterateDFSInAdjacencyList(adjacencyList, answers, seen, 0);

        return answers.ToArray();
    }

    void IterateDFSInAdjacencyList(int[][] adjacencyList, List<int> answers, bool[] seen, int value)
    {
        answers.Add(value);
        seen[value] = true;
        int[] neighbours = adjacencyList[value];

        for (int i = 0; i < neighbours.Length; i++)
        {
            if (seen[neighbours[i]] != true) //Perform DFS if not seen before
            {
                IterateDFSInAdjacencyList(adjacencyList, answers, seen, neighbours[i]);
            }
        }
    }

    private int[] ReturnDFSArray_FromAdjacencyMatrix(int[][] adjacencyList)
    {
        List<int> answers = new List<int>();
        bool[] seen = new bool[adjacencyList.GetLength(0)];

        IterateDFSInAdjacencyMatrix(adjacencyList, answers, seen, 0);

        return answers.ToArray();
    }

    void IterateDFSInAdjacencyMatrix(int[][] adjacencyMatrix, List<int> answers, bool[] seen, int value)
    {
        answers.Add(value);
        seen[value] = true;

        for (int j = 0; j < seen.Length; j++)
        {
            if(adjacencyMatrix[value][j] == 1 && seen[j] != true)
            {
                IterateDFSInAdjacencyMatrix(adjacencyMatrix, answers, seen, j);
            }
        }
    }

    #endregion

    #endregion
}
