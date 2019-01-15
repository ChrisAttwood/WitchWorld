using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Witch
{
    public string fullName;
    public string firstName;
    public string surname;
    public FaceData faceData;

    public Witch()
    {
        NameGenerator.NameFactory();
        firstName = NameGenerator.GenerateFemaleFirstName();
        surname = NameGenerator.GenerateSurname();
        fullName = firstName + " " + surname;
        faceData = FaceGenerator.GenerateFace(Gender.Female);
    }
}
