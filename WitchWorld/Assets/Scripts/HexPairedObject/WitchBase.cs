using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchBase : HexPairedObject
{
    public List<Witch> witches;
    public int numberOfWitches;
    public Canvas witchUI;

    void Awake()
    {
        pairType = PairType.WitchBase;
    }

    public void GenerateNewWitchBase()
    {
        witches = new List<Witch>();
        for (int i = 0; i < numberOfWitches; i++)
        {
            Witch w = new Witch();
            w.RandomiseWitch();
            witches.Add(w);
        }
    }

    public override void RegisterClick()
    {
        UnitMovement.IsUnitOnBase(pairedToThisTile);
        OpenWitchBaseUI();
    }

    public void OpenWitchBaseUI()
    {
        Canvas c = Instantiate(witchUI);
        c.GetComponent<WitchBaseUI>().SetupUI(this);
    }

}
