using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSelect : MonoBehaviour
{
    public Witch witch;
    public GameObject witchSelectUI;

    public void SelectMe()
    {
        Debug.Log("Selected " + witch.fullName);
        GameObject wUI = Instantiate(witchSelectUI);
        Canvas c = GetComponentInParent<Canvas>();
        wUI.transform.SetParent(c.transform);
        Debug.Log(GetComponentInParent<WitchBaseUI>().witchBase == null);
        wUI.GetComponent<WitchSelectUI>().SetupMenu(witch, GetComponentInParent<WitchBaseUI>().witchBase);
        wUI.transform.position = this.transform.position;
    }
}
