using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FaceGenerator
{
    public static FaceLayerLibrary maleFaces;
    public static FaceLayerLibrary femaleFaces;

    public static FaceData GenerateFace()
    {
        Gender gender = ReturnRandomGender();
        FaceData fd = new FaceData(gender);
        CreateCharacterImage(fd);
        return fd;
    }

    public static FaceData GenerateFace(Gender presetGender)
    {
        Gender gender = presetGender;
        FaceData fd = new FaceData(gender);
        CreateCharacterImage(fd);
        return fd;
    }

    private static Gender ReturnRandomGender()
    {
        Gender thisCharacterGender = Gender.Male;
        int randomRoll = Random.Range(-100, 100);
        if (randomRoll > 0)
        {
            thisCharacterGender = Gender.Female;
        }
        return thisCharacterGender;
    }

    private static void CreateCharacterImage(FaceData faceData)
    {
        FaceLayerLibrary faceLibrary = null;
        if (faceData.gender == Gender.Female)
        {
            faceLibrary = femaleFaces;
        }
        else
        {
            faceLibrary = maleFaces;
        }
        faceData.faceImageNumber = Random.Range(0, faceLibrary.face.Count);
        faceData.eyesImageNumber = Random.Range(0, faceLibrary.eyes.Count);
        faceData.hairImageNumber = Random.Range(0, faceLibrary.hair.Count);
        faceData.mouthImageNumber = Random.Range(0, faceLibrary.mouth.Count);
        faceData.noseImageNumber = Random.Range(0, faceLibrary.nose.Count);
        faceData.eyebrowsImageNumber = Random.Range(0, faceLibrary.eyebrows.Count);
        faceData.robeImageNumber = Random.Range(0, faceLibrary.robe.Count);
        faceData.hatImageNumber = Random.Range(0, faceLibrary.hat.Count);
        faceData.skinColour = ColourMaths.ReturnRandomSkinColour(0.1f, 1f, 0.05f);
        faceData.hairColour = ColourMaths.ReturnRandomHairColour(0.0f, 1f, Random.Range(0.0f, 1.0f));
        faceData.eyeColour = ColourMaths.ReturnRandomEyeColour();
        faceData.clothingColour = ColourMaths.ReturnRandomClothingColour();
    }
}
