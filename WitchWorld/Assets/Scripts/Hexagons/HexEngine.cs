using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexEngine : MonoBehaviour {

    public static HexEngine instance;

    public HexTile HexPrefab;
    public Color Colour = Color.white;
    public Dictionary<Vector3Int, HexTile> Hexes;

    public SeedGroup altitudeSeed1;
    public SeedGroup altitudeSeed2;
    public SeedGroup humiditySeed1;
    public SeedGroup humiditySeed2;

    public MapPresets mapPresets;
    public WitchBase witchBase;


    [Range(0, 100)]
    public int Size = 10;

    float hexWidth { get; set; }
    float hexHeight { get; set; }

   
   
    public static Vector3Int[] neighbors = {
        new Vector3Int(1, 0, -1), new Vector3Int(1, -1, 0), new Vector3Int(0, -1, 1),
        new Vector3Int(-1, 0, 1),new Vector3Int(-1, 1, 0),  new Vector3Int(0, 1, -1)
    };



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Hexes = new Dictionary<Vector3Int, HexTile>();
        Renderer hex = HexPrefab.GetComponent<Renderer>();
        hexWidth = hex.bounds.size.x;
        hexHeight = hex.bounds.size.y;
        Build();
    }

    void Build()
    {

        for (int x = -Size; x <= Size; x++)
        {
            for (int y = -Size; y <= Size; y++)
            {
                Vector2Int point = new Vector2Int(x, y);
                if (InMap(point, Size))
                {

                    HexTile hex = Instantiate(HexPrefab);
                    hex.GetComponent<SpriteRenderer>().color = Colour;
                    Vector3Int v3i = ConvertToVector3(point);
                    hex.transform.position = GetWorldPosition(v3i);
                    hex.Coordinates = v3i;
                    Hexes[v3i] = hex;

                    // Added bits around altitude and humidity
                    Vector2 v2 = new Vector2(x, y);
                    float altitude = Noise.Generate2DNoiseValue(v2, altitudeSeed1) +
                        Noise.Generate2DNoiseValue(v2, altitudeSeed2);
                    float humidity = Noise.Generate2DNoiseValue(v2, humiditySeed1) +
                        Noise.Generate2DNoiseValue(v2, humiditySeed2);
                    hex.altitude = altitude;
                    hex.humidity = humidity;
                    hex.ColourSwitch(mapPresets);
                }
            }
        }
        GenerateWitchBase(new Vector3Int(0,0,0));
    }


    public List<Vector3Int> GetNeighbors(Vector3Int v3i, int radius)
    {
        List<Vector3Int> targets = new List<Vector3Int>();
        targets.Add(v3i);

        while (radius > 1)
        {
            List<Vector3Int> ts = new List<Vector3Int>();
            foreach (var n in targets)
            {
                ts.AddRange(GetNeighbors(n));
            }

            foreach (var n in ts)
            {
                if (!targets.Contains(n))
                {
                    targets.Add(n);
                }
            }
            radius--;
        }

        return targets;
    }



    

   

    public List<Vector3Int> GetNeighbors(Vector3Int coords)
    {
        List<Vector3Int> results = new List<Vector3Int>();

        for (int i = 0; i < 6; i++)
        {
            if (Hexes.ContainsKey(neighbors[i] + coords))
            {
                results.Add(neighbors[i] + coords);
            }

        }
        return results;
    }

 


    public List<Vector3Int> GetRange(Vector3Int coords, int range)
    {
        
        List<Vector3Int> results = new List<Vector3Int>();
        for (int x = -range; x <= range; x++)
        {
            for (int y = -range; y <= range; y++)
            {
                Vector2Int point = new Vector2Int(x, y);
                var v = ConvertToVector3(point);

                if (InMap(point, range))
                {
                    if (Hexes.ContainsKey(v + coords))
                    {
                        results.Add(v + coords);
                    }
                }
            }
        }

        return results;
    }

   

    public static bool InMap(Vector2Int point , int Size)
    {
        var c = ConvertToVector3(point);
        return ((Mathf.Max((Mathf.Abs(c.x) + Mathf.Abs(c.y) + Mathf.Abs(c.z)))) <= Size * 2);
    }


    public Vector2 GetWorldPosition(Vector3Int gridPos)
    {
        float x = ((gridPos.x) * hexWidth) + (gridPos.z * hexWidth/2f);
        float y = -gridPos.z * hexHeight * 0.75f;
        return new Vector2(x, y);
    }

    public static Vector2 GetWorldPosition(Vector3Int gridPos,float width,float height)
    {
        float x = ((gridPos.x) * width) + (gridPos.z * width / 2f);
        float y = -gridPos.z * height * 0.75f;
        return new Vector2(x, y);
    }

    public Vector3Int GetGridCoordinates(Vector2 point)
    {
        float size = hexHeight / 2f;
        var q = (Mathf.Sqrt(3f) / 3f * point.x - 1f / 3f * -point.y) / size;
        var r = (2f / 3f * -point.y) / size;
        return Round(ConvertToVector3(new Vector2(q, r)));
    }

    public Vector2 RoundToGrid(Vector2 point)
    {
        float size = hexHeight / 2f;
        var q = (Mathf.Sqrt(3f) / 3f * point.x - 1f / 3f * -point.y) / size;
        var r = (2f / 3f * -point.y) / size;
        return GetWorldPosition(Round(ConvertToVector3(new Vector2(q,r))));
    }


    public static Vector3Int ConvertToVector3(Vector2Int hex)
    {
        int x = hex.x;
        int z = hex.y;
        int y = -x - z;
        return new Vector3Int(x, y, z);
    }

    public static Vector3 ConvertToVector3(Vector2 hex)
    {
        float x = hex.x;
        float z = hex.y;
        float y = -x - z;
        return new Vector3(x, y, z);
    }


    public static Vector3Int Round(Vector3 cube)
    {
        int x = Mathf.RoundToInt(cube.x);
        int y = Mathf.RoundToInt(cube.y);
        int z = Mathf.RoundToInt(cube.z);
        var xDiff = Mathf.Abs(x - cube.x);
        var yDiff = Mathf.Abs(y - cube.y);
        var zDiff = Mathf.Abs(z - cube.z);

        if (xDiff > yDiff && xDiff > zDiff)
        {
            x = -y - z;
        }
        else if (yDiff > zDiff)
        {
            y = -x - z;
        }
        else
        {
            z = -x - y;
        }

        return new Vector3Int(x, y, z);
    }

    private void GenerateWitchBase(Vector3Int hexCoordinates)
    {
        HexTile ht = Hexes[hexCoordinates];
        WitchBase wb = Instantiate(witchBase);
        wb.pairedToThisTile = ht;
        wb.GenerateNewWitchBase();
        ht.PairToObject(wb);
    }

}

