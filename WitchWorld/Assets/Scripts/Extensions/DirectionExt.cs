using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionExt  {

    public static float ToDegrees(this Direction direction)
    {
        switch (direction)
        {
            case Direction.NorthWest:
                return 30;
            case Direction.West:
                return 90;
            case Direction.SouthWest:
                return 150;
            case Direction.SouthEast:
                return 210;
            case Direction.East:
                return 270;
            case Direction.NorthEast:
                return 330;
        }

        return 0;
    }

    public static Direction GetDirection(this Transform transform)
    {
        int d = Mathf.RoundToInt(transform.rotation.eulerAngles.z);

        if (d <= 0)
        {
            d += 360;
        }

        if (d > 0 && d <= 60) return Direction.NorthWest;
        if (d > 60 && d <= 120) return Direction.West;
        if (d > 120 && d <= 180) return Direction.SouthWest;
        if (d > 180 && d <= 240) return Direction.SouthEast;
        if (d > 240 && d <= 300) return Direction.East;
        if (d > 300 && d <= 360) return Direction.NorthEast;


        throw new System.Exception("degrees " + d);

    }

    public static Direction Opposite(this Direction direction)
    {
        switch (direction)
        {
            case Direction.NorthWest:
                return Direction.SouthEast;
            case Direction.West:
                return Direction.East;
            case Direction.SouthWest:
                return Direction.NorthEast;
            case Direction.SouthEast:
                return Direction.NorthWest;
            case Direction.East:
                return Direction.West;
            case Direction.NorthEast:
                return Direction.SouthWest;
        }

        return 0;
    }

    public static Vector3Int Next(this Direction direction)
    {
        switch (direction)
        {
            case Direction.NorthEast:
                return new Vector3Int(1, 0, -1);
            case Direction.East:
                return new Vector3Int(1, -1, 0);
            case Direction.SouthEast:
                return new Vector3Int(0, -1, 1);
            case Direction.SouthWest:
                return new Vector3Int(-1, 0, 1);
            case Direction.West:
                return new Vector3Int(-1, 1, 0);
            case Direction.NorthWest:
                return new Vector3Int(0, 1, -1);
        }
        return new Vector3Int(0, 0, 0);
    }

}
