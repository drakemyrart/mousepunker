using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGrid : MonoBehaviour
{
    UIGrid instance;
    [SerializeField]
    GridSystem grid;
    [SerializeField]
    Canvas uiGridCanvas;
    [SerializeField]
    Image gridImage;

    RectTransform panel;
   
    
    Dictionary<NodeSystem, Image> imageGrid = new Dictionary<NodeSystem, Image>();
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        grid = FindObjectOfType<GridSystem>();
        panel = uiGridCanvas.GetComponentInChildren<RectTransform>();
        CreateImageGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    void CreateImageGrid()
    {
        foreach (var item in grid.VisGrid)
        {
            var obj = Instantiate(gridImage, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(item);
            obj.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 0);
            obj.enabled = false;
            imageGrid.Add(item, obj);
        }
        
    }

    public Vector3 GetPosition(NodeSystem node)
    {
        return new Vector3(node.worldPosition.x, node.worldPosition.z, 0);
    }

    public void SetVisability(Vector3 pos, int move)
    {
        ResetVisability();
        NodeSystem current;
        for (int i = 0; i < move*2; i++)
        {
            for (int j = 0; j < move * 2; j++)
            {
                int currX = i - move;
                int currZ = j - move;
                Vector3 currPos = new Vector3(pos.x + currX, pos.y, pos.z + currZ);
                current = grid.NodeFromWorldPoint(currPos);
                if (current.walkable)
                {
                    imageGrid[current].enabled = true;
                }
                
            }
        }
    }

    public void ResetVisability()
    {
        foreach (var item in imageGrid)
        {
            imageGrid[item.Key].enabled = false;
        }
    }
}
