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

    private int[] ReturnBFSArray(int[][] adjacencyList)
    {
        Queue<int> bfsQueue = new Queue<int>(); bfsQueue.Enqueue(adjacencyList[0][0]);
        bool[] seen = new bool[adjacencyList.GetLength(0)]; //Assuming by default all entries are false
        List<int> answers = new List<int>(); //No shift menthod to add to last index in array for C# so using list

        while(bfsQueue.Count > 0)
        {
            int value = bfsQueue.Dequeue();
            answers.Add(value);
            seen[value] = true;
            int[] neighbors = adjacencyList[value];

            for (int i = 0; i < neighbors.Length; i++)
            {
                int neighbor = neighbors[i];
                if(!seen[neighbor]) //If not visited, add to queue to process later
                {
                    bfsQueue.Enqueue(neighbor);
                }
            }
        }

        return answers.ToArray();
    }
    
    #endregion
}
