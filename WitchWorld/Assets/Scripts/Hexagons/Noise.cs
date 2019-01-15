using UnityEngine;
using System.Collections;

public static class Noise {

	public static float Generate2DNoiseValue (int x, int y, float firstSeed, float secondSeed, float smoother){
		float pixel = (Mathf.PerlinNoise (firstSeed + x / smoother, secondSeed + y / smoother));
		return pixel;
	}

    public static float Generate2DNoiseValue(int x, int y, Vector2 seed, float smoother)
    {
        float pixel = (Mathf.PerlinNoise(seed.x + x / smoother, seed.y + y / smoother));
        return pixel;
    }

    public static float Generate2DNoiseValue(Vector2 coordinates, Vector2 seed, float smoother)
    {
        float pixel = (Mathf.PerlinNoise(seed.x + coordinates.x / smoother, seed.y + coordinates.y / smoother));
        return pixel;
    }

    public static float Generate2DNoiseValue(Vector2 coordinates, SeedGroup seedGroup)
    {
        float pixel = (Mathf.PerlinNoise(seedGroup.seed.x + coordinates.x / seedGroup.seedSmoothing, seedGroup.seed.y + coordinates.y / seedGroup.seedSmoothing));
        return pixel;
    }
}
