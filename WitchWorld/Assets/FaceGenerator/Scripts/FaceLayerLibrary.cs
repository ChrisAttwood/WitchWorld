using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FaceLayerLibrary : MonoBehaviour {

	public Gender gender;

	public Sprite background;
	public List <Sprite> hairBackground;
	public List <Sprite> face;
	public List <Sprite> eyes;
	public List <Sprite> iris;
	public List <Sprite> nose;
	public List <Sprite> mouth;
	public List <Sprite> hair;
	public List <Sprite> eyebrows;
    public List <Sprite> hat;
    public List <Sprite> robe;

    private void Awake()
    {
        if (gender == Gender.Male){
            FaceGenerator.maleFaces = this;
        } else
        {
            FaceGenerator.femaleFaces = this;
        }
    }
}
