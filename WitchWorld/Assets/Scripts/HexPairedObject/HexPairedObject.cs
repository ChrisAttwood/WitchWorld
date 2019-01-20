using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPairedObject : MonoBehaviour
{
    public HexTile pairedToThisTile;
    public PairType pairType;


    public virtual void RegisterClick()
    {
    }
}
