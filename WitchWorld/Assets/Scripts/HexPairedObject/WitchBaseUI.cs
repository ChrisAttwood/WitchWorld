using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchBaseUI : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject witchIcon;
    public WitchBase witchBase;

    public void SetupUI(WitchBase WitchBase)
    {
        witchBase = WitchBase;
        for (int i = 0; i < witchBase.witches.Count; i++)
        {
            GameObject goWitchIcon = Instantiate(witchIcon);
            goWitchIcon.transform.SetParent(mainPanel.transform);
            goWitchIcon.GetComponent<FaceDisplay>().DisplayFace(witchBase.witches[i].faceData);
            goWitchIcon.GetComponent<WitchSelect>().witch = witchBase.witches[i];
        }
    }

    public void CloseWindow()
    {
        GameObject.Destroy(this.gameObject);
    }
}
