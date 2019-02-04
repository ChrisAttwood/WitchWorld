using UnityEngine;
using System.Collections;



public struct Node
{
    public Vector3Int position { get; set; }
    public Vector3Int parent { get; set; }

    public int H { get; set; }
    public int G { get; set; }
    public int F { get; set; }

    public float Distance { get; set; }
}
