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
        GameObject wUnit = Instantiate(witchUnit);
        //wUnit.transform.position = thisWitchBase.transform.position
        wUnit.GetComponent<WitchUnit>().witch = witch;
        wUnit.GetComponent<WitchUnit>().SetupWitchColours();
        Destroy(GetComponentInParent<WitchBaseUI>().gameObject);
    }
}
