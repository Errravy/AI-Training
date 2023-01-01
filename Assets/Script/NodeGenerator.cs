using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    [SerializeField] Node node;
    [SerializeField] GameObject container;
    public static List<Node> nodes;
    void Start()
    {
        nodes = new List<Node>();
        Tilemap tilemap = GetComponentInChildren<Tilemap>();
        BoundsInt bounds = tilemap.cellBounds;
        for (int y = bounds.min.y; y < bounds.max.y; y++)
        {
            for (int x = bounds.min.x; x < bounds.max.x; x++)
            {
                var tilePos = new Vector3Int(x, y);
                if (tilemap.HasTile(tilePos))
                {
                    var node = Instantiate(this.node, container.transform);
                    var pos = tilemap.GetCellCenterWorld(tilePos);
                    node.transform.position = new Vector3(pos.x, pos.y);
                    nodes.Add(node);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
