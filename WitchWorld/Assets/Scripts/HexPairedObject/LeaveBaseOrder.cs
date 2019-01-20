using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBaseOrder : MonoBehaviour
{
    public GameObject witchUnit;
    public WitchSelectUI mainUI;

    public void IssueLeaveBaseOrder()
    {
        Witch witch = mainUI.witch;
        WitchBase thisWitchBase = GetComponentInParent<WitchSelectUI>().witchBase;
        GameObject goWUnit = Instantiate(witchUnit);
        //wUnit.transform.position = thisWitchBase.transform.position
        WitchUnit wUnit = goWUnit.GetComponent<WitchUnit>();
        wUnit.witch = witch;
        wUnit.SetupWitchColours();
        thisWitchBase.witches.Remove(witch);
        wUnit.currentHex = thisWitchBase.pairedToThisTile;
        UnitMovement.BeginMovement(wUnit);
        Destroy(GetComponentInParent<WitchBaseUI>().gameObject);
    }
}
