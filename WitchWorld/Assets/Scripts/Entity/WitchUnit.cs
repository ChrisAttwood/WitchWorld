using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WitchUnit : MonoBehaviour
{
    public Witch witch;
    public HexTile currentHex;

    public List<SpriteRenderer> layers;

    public void SetupWitchColours()
    {
        FaceData faceData = witch.faceData;
        UpdateLayerSprite("Robe", faceData.clothingColour);
        UpdateLayerSprite("Belt", Color.black);
        UpdateLayerSprite("BeltBuckle", Color.white);
        UpdateLayerSprite("Head", faceData.skinColour);
        UpdateLayerSprite("Hat", faceData.clothingColour);
        UpdateLayerSprite("Hair", faceData.hairColour);
    }

    // Commented out section is to load different sprites, see exact same method in FaceDisplay.
    // Had to change this to use a spriterenderer instead though, so it is slightly different.
    private void UpdateLayerSprite(string layerName, Color colour)
    {
        SpriteRenderer spriteRenderer = ReturnMatchingLayerInUI(layerName);
        //image.sprite = spriteList[spriteIndex];
        spriteRenderer.color = colour;
        //spriteRenderer.enabled = false;
        //spriteRenderer.enabled = true;
    }

    private SpriteRenderer ReturnMatchingLayerInUI(string layerName)
    {
        SpriteRenderer spriteToReturn = (from SpriteRenderer spRend in layers
                               where spRend.name == layerName
                               select spRend).Single();
        return spriteToReturn;
    }

    public void RegisterClick()
    {
        UnitMovement.BeginMovement(this);
    }
}
