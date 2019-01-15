using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {

    public Vector3Int Coordinates { get; set; }
    public float altitude;
    public float humidity;
    private HexPairedObject pairedObject;

    public void ColourSwitch (MapPresets mp)
    {
        if (altitude < mp.seaLevel)
        {
            ChangeToThisColour(mp.seaColour);
        } else
        {
            int coordX = (int)(humidity * mp.step);
            int coordY = (int)(altitude * mp.step);
            ChangeToThisColour(mp.mapColourSprite.texture.GetPixel(coordX, coordY));
        }
    }

    public void ChangeToThisColour (Color newColour)
    {
        GetComponent<SpriteRenderer>().color = newColour;
    }
    
    public void PairToObject(HexPairedObject newPairing)
    {
        pairedObject = newPairing;
        pairedObject.transform.position = this.transform.position;
        pairedObject.transform.SetParent(this.transform);
    }

    public void RegisterClick()
    {
        if (pairedObject != null) {
            pairedObject.RegisterClick();
        }

    }
}
