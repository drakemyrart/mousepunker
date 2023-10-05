using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSystem : IHeapItem<NodeSystem>
{
    public bool walkable;
    public Vector3 worldPosition;

    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;

    public NodeSystem parent;

    public NodeSystem(bool walkbl, Vector3 worldPos, int gX, int gY)
    {
        walkable = walkbl;
        worldPosition = worldPos;
        gridX = gX;
        gridY = gY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int HeapIndex { get; set; }

    public int CompareTo(NodeSystem nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}
