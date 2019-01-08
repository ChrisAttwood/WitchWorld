using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexExt {

	public static Vector2 ToWorldVector2(this Vector3Int v3i)
    {
        return HexEngine.instance.GetWorldPosition(v3i);
    }

    public static Vector3Int ToGridVector3Int(this Transform transform)
    {
        return HexEngine.instance.GetGridCoordinates(transform.position);
    }
   
    public static HexTile GetHex(this Vector3Int pos)
    {
        return HexEngine.instance.Hexes[pos];
    }

    public static HexTile GetHex(this Transform transform)
    {
        return HexEngine.instance.Hexes[ToGridVector3Int(transform)];
    }
}
