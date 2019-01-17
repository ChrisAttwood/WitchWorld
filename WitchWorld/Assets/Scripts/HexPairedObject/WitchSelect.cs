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
        wUI.GetComponent<WitchSelectUI>().SetupMenu(witch, GetComponentInParent<WitchBase>());
        wUI.transform.position = this.transform.position;
    }
}
