using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<FaceData> faces;
    public int generateThisNumber;
    public FaceDisplay fd;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTestFace();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateTestFace();
        }
    }

    private void GenerateTestFace()
    {
        faces = new List<FaceData>();
        for (int i = 0; i < generateThisNumber; i++)
        {
            FaceData f = FaceGenerator.GenerateFace(Gender.Female);
            faces.Add(f);
        }
        fd.DisplayFace(faces[0]);
    }
}
