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
            witches.Add(new Witch());
        }
    }

    public override void RegisterClick()
    {
        Debug.Log("Registered a click with inherited member");
        OpenWitchBaseUI();
    }

    public void OpenWitchBaseUI()
    {
        Canvas c = Instantiate(witchUI);
        c.GetComponent<WitchBaseUI>().SetupUI(this);
    }
}
