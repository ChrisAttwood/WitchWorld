using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchSelectUI : MonoBehaviour
{
    public Text title;
    public Witch witch;
    public WitchBase witchBase;

    public void SetupMenu(Witch Witch, WitchBase thisWitchBase)
    {
        witch = Witch;
        witchBase = thisWitchBase;
        Debug.Log(thisWitchBase == null);
        title.text = "Give order to " + witch.fullName;
    }
}
