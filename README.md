# 3D Perlin Noise Generator with Time Dimension

This repository contains a C# implementation of a **3D Perlin Noise Generator** that efficiently utilizes only two Perlin noise calls to create a smooth, evolving noise pattern. By treating the third dimension as a **time dimension**, this approach offers fully deterministic, artifact-free noise that avoids the traditional repeating patterns and emergent artifacts often associated with standard 3D Perlin implementations.

## Features
- **Efficient Noise Calculation**: Only two Perlin noise calls are used, making the implementation computationally lightweight while retaining high-quality results.
- **Artifact-Free Output**: Unlike traditional methods that average multiple Perlin noise calls and can lead to noticeable artifacts, this approach provides a clean and consistent 3D effect.
- **Fully Deterministic**: The noise evolves predictably over time, ensuring that any given point in the 3D space will always produce the same value, making it ideal for procedural generation.
- **Time-Based Third Dimension**: The third dimension is treated as a "time" parameter, allowing the noise to evolve smoothly without visible seams or repetition, effectively simulating a 3D noise space.

## How It Works
The `3DNoise` method blends two 2D Perlin noise layers using a time-based variable. The evolution of the noise is driven by a sine function, and the offsets for the two noise layers are updated deterministically as the time variable progresses. This technique creates a dynamic and continuous 3D noise field without introducing noticeable artifacts.

### Comparison to Other Approaches
Many other methods for extending 2D Perlin noise to three dimensions involve arbitrary changes to the Perlin parameters, such as adjusting scale, translating coordinates, or other forms of manipulation. These approaches often lead to undesirable effects, including visible artifacts or repeated patterns. In contrast, this implementation evolves a 2D Perlin noise deterministically over time without modifying the underlying parameters or translating the noise field. This ensures that the generated noise remains consistent, high-quality, and free from typical artifacts.

### Method Signature
```csharp
public static float 3DNoise(float x, float y, float time, float scale, float viewport, int steps, float low, float high, float target)
```

### Parameters
- `x`, `y`: Coordinates for the noise calculation.
- `time`: The time variable, representing the third dimension of the noise space.
- `scale`: Controls the frequency of the noise, adjusting the level of detail.
- `viewport`: Defines the observable field size used for offset calculation.
- `steps`: The number of quantization steps to control the level of detail in the output.
- `low`, `high`: Minimum and maximum values for the output noise range.
- `target`: A value used to calculate proximity and adjust the output accordingly.

## Usage
- This noise function can be used in Unity projects or any C# application to generate evolving 3D noise values.
- By adjusting the `time` parameter, you can simulate the noise evolving over time, perfect for procedural terrain, textures, or other dynamic content.

## Why This Approach?
Most traditional 3D Perlin implementations require averaging multiple Perlin calls, often resulting in noticeable artifacts and undesirable emergent patterns. This method avoids those pitfalls by leveraging a deterministic time variable to create smooth transitions and maintain a consistent, high-quality output.

## License
This project is licensed under the MIT License, making it free for anyone to use, modify, and distribute.

## Example Usage
```csharp
float noiseValue = Perlin.3DNoise(x, y, time, scale, viewport, steps, low, high, target);
```
This example shows how to generate a noise value based on `x`, `y`, and `time` coordinates. Adjust the `scale`, `steps`, `low`, `high`, and `target` parameters to fine-tune the noise output for your specific needs.

Feel free to explore, modify, and integrate this implementation into your projects!

