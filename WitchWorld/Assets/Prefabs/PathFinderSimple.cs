using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinderSimple {

    Dictionary<Vector3Int, Node> Open { get; set; }
    Dictionary<Vector3Int, Node> Closed { get; set; }
    Dictionary<Vector3Int, bool> Spaces { get; set; }
    Vector3Int Target;

    float distance;

    int Range = 999;

    public PathFinderSimple(Dictionary<Vector3Int, bool> spaces)
    {
       
       
        Spaces = spaces;
        Open = new Dictionary<Vector3Int, Node>();
        Closed = new Dictionary<Vector3Int, Node>();
    }

    public IEnumerable<Vector3Int> GetPath(Vector3Int start, Vector3Int target)
    {
        distance = GetEffort(start, target);

        Target = target;

        if (!Spaces.ContainsKey(target))
        {
            Debug.Log("Invalide target");
            return new List<Vector3Int>();
        }
        if (GetEffort(start, target) == 0)
        {
            return new List<Vector3Int>();
        }


        Node startNode = new Node();
        startNode.G = 0;
        startNode.H = GetEffort(start, target);
        startNode.F = startNode.G + startNode.H;
        startNode.position = start;
        GetSteps(startNode, target);
        return Path(start, target);
    }
    List<Node> path;
    private IEnumerable<Vector3Int> Path(Vector3Int start, Vector3Int target)
    {
        path = new List<Node>();

        if (Closed.ContainsKey(target))
        {
            var current = Closed[target];
            while (GetEffort(start, current.position) != 0)
            {
                path.Add(Closed[current.position]);
                current = Closed[current.parent];
            }
            return path.Select(x => x.position).Reverse();
        }
        else
        {
            return new List<Vector3Int>();
        }
    }

    List<Vector3Int> n;
    public void GetSteps(Node parent, Vector3Int target)
    {
        Closed[parent.position] = parent;
        if (Open.ContainsKey(parent.position))
        {
            Open.Remove(parent.position);
        }


        n = GetNeighbours(parent.position).ToList();

        foreach (var v in n)
        {
            if (!Closed.ContainsKey(v))
            {
                Node node = new Node();
                node.parent = parent.position;
                node.position = v;
                node.H = GetEffort(v, target);
                node.G = parent.G + GetEffort(parent.position, v);
                node.F = node.H + node.G;
                node.Distance = GetEffort(v, target); 

                if (Open.ContainsKey(v))
                {
                    if (Open[v].F > node.F)
                    {
                        Open[v] = node;
                    }
                }
                else
                {
                    Open[v] = node;
                }

                if (v == target)
                {
                    Closed[v] = node;
                    return;
                }
            }
        }


        if (Open.Count > 0 && Open.Count < Range)
        {
            int min = Open.Min(x => x.Value.F);
            var nd = Open.Where(x => x.Value.F == min).First();
            GetSteps(nd.Value, target);
        }
        else
        {
            return;
        }
    }

    public static Vector3Int[] neighbors = {
        new Vector3Int(1, 0, -1), new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 1),
        new Vector3Int(-1, 0, 1),new Vector3Int(-1, 1, 0),  new Vector3Int(0, 1, -1)
    };

    public IEnumerable<Vector3Int> GetNeighbours(Vector3Int start)
    {
        n = new List<Vector3Int>();

        foreach(var nbs in neighbors)
        {
            TryAdd(n, nbs + start);
        }

    
        return n;
    }

    void TryAdd(List<Vector3Int> n, Vector3Int v2)
    {

        if (!Spaces.ContainsKey(v2)) return;

        if (v2 == Target || Spaces[v2])
        {
            n.Add(v2);
        }

    }
   

    public int GetEffort(Vector3Int a, Vector3Int b)
    {
        return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z));
    }

}
