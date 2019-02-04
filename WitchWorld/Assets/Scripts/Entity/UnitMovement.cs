using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnitMovement 
{
    public static WitchUnit currentActiveUnit;
    private static List<HexTile> highlightedTiles;

    public static void BeginMovement(WitchUnit wUnit)
    {
        currentActiveUnit = wUnit;
        HexEngine hEngine = HexEngine.instance;
        MapPresets mPresets = hEngine.mapPresets;
        List<Vector3Int> neighbours = HexEngine.instance.GetNeighbors(currentActiveUnit.currentHex.Coordinates);
        ShowNeighbours(neighbours, hEngine);
    }

    private static void ShowNeighbours(List <Vector3Int> nCoordinates, HexEngine hEngine)
    {
        highlightedTiles = new List<HexTile>();
        for (int i = 0; i < nCoordinates.Count; i++)
        {
            HexTile hexTile = hEngine.Hexes[nCoordinates[i]];
            if (hexTile.pairedUnit == null && hexTile.altitude > HexEngine.instance.mapPresets.seaLevel)
            {
                hexTile.HighlightMoveable();
                highlightedTiles.Add(hexTile);
            }
        }
    }

    private static void ClearNeighbours()
    {
        foreach (HexTile h in highlightedTiles)
        {
            h.inMovementRange = false;
            h.ColourSwitch(HexEngine.instance.mapPresets);
        }
    }

    public static void MoveUnit(HexTile moveToThisHex)
    {
        //  currentActiveUnit.Target = moveToThisHex.transform.position;

        if (HexEngine.instance.Spaces.ContainsKey(moveToThisHex.transform.ToGridVector3Int()))
        {
            PathFinderSimple pf = new PathFinderSimple(HexEngine.instance.Spaces);
            var path = pf.GetPath(currentActiveUnit.transform.ToGridVector3Int(), moveToThisHex.transform.ToGridVector3Int()).ToList();

            currentActiveUnit.SetPath(path);
        }
       




        currentActiveUnit.currentHex.pairedUnit = null;
        currentActiveUnit.currentHex = moveToThisHex;
        moveToThisHex.pairedUnit = currentActiveUnit;
        if (moveToThisHex.pairedObject != null)
        {
            if (moveToThisHex.pairedObject.pairType == PairType.WitchBase)
            {
                PlaceUnitInBase(moveToThisHex.pairedObject.GetComponent<WitchBase>());
            }
        }
        ClearNeighbours();
        if (currentActiveUnit != null)
        {
            currentActiveUnit = null;
        }
    }

    public static void IsUnitOnBase(HexTile thisHex)
    {
        if (currentActiveUnit != null)
        {
            if (currentActiveUnit.currentHex == thisHex)
            {
                PlaceUnitInBase(thisHex.GetComponentInChildren<WitchBase>());
            }
        }
    }

    private static void PlaceUnitInBase(WitchBase witchBase)
    {
        witchBase.witches.Add(currentActiveUnit.witch);
        ClearNeighbours();
        GameObject.Destroy(currentActiveUnit.gameObject);
    }
}
