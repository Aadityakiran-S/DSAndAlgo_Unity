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
}
