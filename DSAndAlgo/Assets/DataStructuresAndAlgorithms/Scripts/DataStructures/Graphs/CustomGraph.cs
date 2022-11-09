using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CustomGraph
{
    #region References and Constructor

    public List<GraphNode> nodes;
    public int NodeCount { get => nodes.Count; }

    private Hashtable _nodeEntriesHashTable;  //Added to check for duplicates

    public CustomGraph(object initialValue)
    {
        GraphNode firstNode = new GraphNode(initialValue);

        nodes = new List<GraphNode>
        {
            firstNode
        };

        _nodeEntriesHashTable = new Hashtable
        {
            { initialValue, initialValue }
        };
    }

    #endregion

    #region Public Methods

    public void AddNode(object value)
    {
        GraphNode newNode = new GraphNode(value);
        nodes.Add(newNode);

        _nodeEntriesHashTable.Add(value, value);
    }

    public void AddEdge(object node1Value, object node2Value)
    {
        //If both entries are not preasent, you can't make a connection between them
        if (!(_nodeEntriesHashTable.Contains(node1Value) && _nodeEntriesHashTable.Contains(node2Value)))
        {
            UnityEngine.Debug.LogError("Either of the nodes you've requested to be connected are non extant");
            return;
        }

        GraphNode node1 = nodes.FirstOrDefault(x => x.Value == node1Value);
        GraphNode node2 = nodes.FirstOrDefault(x => x.Value == node2Value);

        node1.AddConnection(node2);
        node2.AddConnection(node1);
    }

    #endregion
}

public class GraphNode
{
    private object _value;  //Mutable through function only
    public object Value { get => _value; private set => this._value = value; }

    private List<GraphNode> _connections;

    public GraphNode(object value)
    {
        this.Value = value;
        _connections = new List<GraphNode>();
    }

    #region Public Methods

    public void ChangeValue(object value)
    {
        this.Value = value;
    }

    public void AddConnection(GraphNode nodeToConnect)
    {
        _connections.Add(nodeToConnect);
    }

    #endregion

}
