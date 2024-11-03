using UnityEngine;

public static class Perlin
{
    /// <summary>
    /// Generates a blended Perlin noise value that evolves over time to create a 3D Perlin effect.
    /// </summary>
    /// <param name="x">The x-coordinate for the noise calculation.</param>
    /// <param name="y">The y-coordinate for the noise calculation.</param>
    /// <param name="time">The time variable, representing the third dimension.</param>
    /// <param name="scale">The scale factor to control the frequency of the noise.</param>
    /// <param name="viewport">The size of the observable field used for offset calculation.</param>
    /// <param name="steps">The number of steps for quantizing the blended noise value.</param>
    /// <param name="low">The minimum value of the noise output range.</param>
    /// <param name="high">The maximum value of the noise output range.</param>
    /// <param name="target">The target value used for proximity calculations.</param>
    /// <returns>A clamped, stepped Perlin noise value in the range [0, 1].</returns>
    public static float Noise3D(float x, float y, float time, float scale, float viewport, int steps, float low, float high, float target)
    {
        // Determine cycles for peak and valley updates based on time progression
        int cycleCount = Mathf.FloorToInt((time + Mathf.PI / 2) / Mathf.PI); // Adjust cycle count to align with peaks and valleys

        // Static offsets that change deterministically based on the cycle count
        float startOffset = 1000f;
        float offset2 = startOffset + (cycleCount / 2) * viewport; // Offset1 changes at each peak (even cycles)
        float offset1 = (viewport + startOffset) + ((cycleCount + 1) / 2) * viewport; // Offset2 changes at each valley (odd cycles)

        // Calculate Perlin noise values with offsets
        float delta = high - low;
        float noise1 = Mathf.PerlinNoise((x + offset1) * scale, y * scale) * delta + low;
        float noise2 = Mathf.PerlinNoise(x * scale, (y + offset2) * scale) * delta + low;

        // Use a sine function to oscillate between the two Perlin noise values
        float period = Mathf.PI; // Period of the wave
        float t = Mathf.PingPong((time + period / 2) / period, 1.0f);

        // Blend the two Perlin noise values based on the oscillation value
        float blendedNoise = Mathf.Lerp(noise1, noise2, t);

        // Calculate proximity to the target value and adjust the blended noise accordingly
        float miss = Mathf.Abs(target - blendedNoise);
        float prox = (1 - miss) * 2f;
        float stepped = Mathf.Floor(prox * steps) / steps;

        // Clamp the final output to the range [0, 1]
        return Mathf.Clamp(stepped, 0.0f, 1.0f);
    }    
}
