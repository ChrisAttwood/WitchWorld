using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FaceData
{
    public Gender gender;
    public int faceImageNumber;
    public int eyesImageNumber;
    public int hairImageNumber;
    public int mouthImageNumber;
    public int noseImageNumber;
    public int eyebrowsImageNumber;
    public int robeImageNumber;
    public int hatImageNumber;
    public Color skinColour;
    public Color hairColour;
    public Color eyeColour;
    public Color clothingColour;

    public FaceData()
    {
        gender = Gender.Male;
    }

    public FaceData(Gender PresetGender)
    {
        gender = PresetGender;
    }
}
