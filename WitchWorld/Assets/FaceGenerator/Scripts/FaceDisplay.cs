using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FaceDisplay : MonoBehaviour
{
    FaceData faceData;
    public List <Image> layers;

    public void DisplayFace (FaceData Face)
    {
        faceData = Face;
        UpdateFace();
    }

    private void UpdateFace()
    {
        FaceLayerLibrary faceLayerLibrary = FaceGenerator.femaleFaces;
        if (faceData.gender == Gender.Male)
        {
            faceLayerLibrary = FaceGenerator.maleFaces;
        }
        LoadFaceLayers(faceLayerLibrary);
    }

    private void LoadFaceLayers(FaceLayerLibrary faceLibrary)
    {
        UpdateFaceLayerSprite("HairBackground", faceLibrary.hairBackground, faceData.hairImageNumber, faceData.hairColour);
        UpdateFaceLayerSprite("Face", faceLibrary.face, faceData.faceImageNumber, faceData.skinColour);
        UpdateFaceLayerSprite("Eyes", faceLibrary.eyes, faceData.eyesImageNumber, Color.white);
        UpdateFaceLayerSprite("Iris", faceLibrary.iris, faceData.eyesImageNumber, faceData.eyeColour);
        UpdateFaceLayerSprite("Nose", faceLibrary.nose, faceData.noseImageNumber, faceData.skinColour);
        UpdateFaceLayerSprite("Mouth", faceLibrary.mouth, faceData.mouthImageNumber, faceData.skinColour);
        UpdateFaceLayerSprite("Eyebrows", faceLibrary.eyebrows, faceData.eyebrowsImageNumber, faceData.hairColour);
        UpdateFaceLayerSprite("Hair", faceLibrary.hair, faceData.hairImageNumber, faceData.hairColour);
        UpdateFaceLayerSprite("Robe", faceLibrary.robe, faceData.robeImageNumber, faceData.clothingColour);
        UpdateFaceLayerSprite("Hat", faceLibrary.hat, faceData.hatImageNumber, faceData.clothingColour);
    }

    private void UpdateFaceLayerSprite(string layerName, List<Sprite> spriteList, int spriteIndex, Color colour)
    {
        Image image = ReturnMatchingLayerInUI(layerName);
        image.sprite = spriteList[spriteIndex];
        image.color = colour;
        image.enabled = false;
        image.enabled = true;
    }

    private Image ReturnMatchingLayerInUI(string layerName)
    {
        Image imageToReturn = (from Image image in layers
                               where image.name == layerName
                               select image).Single();
        return imageToReturn;
    }
}
