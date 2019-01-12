using UnityEngine;
using System.Collections;

public static class ColourMaths {

	public static Color ReturnRandomSkinColour (float minValue, float maxValue, float mixVariation){
		Color colour = new Color ();
		colour.a = 1.0f;
		float baseValue = Random.Range (minValue, maxValue);
		colour.r = ReturnMixAmountForAlphaComponent (baseValue, 1f, mixVariation);
		colour.g = ReturnMixAmountForAlphaComponent (baseValue, 0.89f, mixVariation);
		colour.b = ReturnMixAmountForAlphaComponent (baseValue, 0.64f, mixVariation);
		return colour;
	}

	public static Color ReturnRandomHairColour (float minValue, float maxValue, float redness){
		Color colour = new Color ();
		colour.a = 1.0f;
		float baseValue = Random.Range (minValue, maxValue);
		colour.r = baseValue;
		colour.g = (baseValue * (0.9f - (0.5f * redness)));
		colour.b = (baseValue * (0.45f - (0.25f * redness)));
		return colour;
	}

	public static Color ReturnRandomEyeColour (){
		Color colour = new Color ();
		colour.a = 1.0f;
		colour.r = Random.Range (0.0f, 0.5f);
		colour.g = Random.Range (0.0f, 1.0f);
		colour.b = Random.Range (0.0f, colour.g);
		return colour;
	}

    public static Color ReturnRandomClothingColour()
    {
        Color colour = new Color();
        colour.a = 1.0f;
        colour.r = Random.Range(0.0f, 1f);
        colour.g = Random.Range(0.0f, 1f);
        colour.b = Random.Range(0.0f, 1f);
        return colour;
    }

	private static float ReturnMixAmountForAlphaComponent (float baseValue, float standardMix, float mixVariation){
		float minimumMixAmount = (baseValue * (standardMix - mixVariation));
		float maximumMixAmount = (baseValue * (standardMix + mixVariation));
		float mixAmount = Random.Range (minimumMixAmount, maximumMixAmount);
		if (mixAmount > 1.0f) {
			mixAmount = 1.0f;
		} else if (mixAmount < 0.0f) {
			mixAmount = 0.0f;
		}
		return mixAmount;
	}
}
