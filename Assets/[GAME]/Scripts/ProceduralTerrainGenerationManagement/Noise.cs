using UnityEngine;
using Random = System.Random;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement
{
    public static class Noise
    {
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves,
            float persistance, float lacunarity, Vector2 offset)
        {
            var noiseMap = new float[mapWidth, mapHeight];

            var prng = new Random(seed);
            var octavesOffsets = new Vector2[octaves];
            for (var i = 0; i < octaves; i++)
            {
                var offSetX = prng.Next(-10000, 10000) + offset.x;
                var offSetY = prng.Next(-10000, 10000) + offset.y;

                octavesOffsets[i] = new Vector2(offSetX, offSetY);
            }


            if (scale <= 0)
                scale = .0001f;

            var minNoiseHeight = float.MaxValue;
            var maxNoiseHeight = float.MinValue;


            var halfWidth = mapWidth / 2f;
            var halfHeight = mapHeight / 2f;

            for (var y = 0; y < mapHeight; y++)
            for (var x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (var i = 0; i < octaves; i++)
                {
                    var sampleX = (x - halfWidth) / scale * frequency + octavesOffsets[i].x;
                    var sampleY = (y - halfHeight) / scale * frequency + octavesOffsets[i].y;

                    var perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                    maxNoiseHeight = noiseHeight;
                else if (noiseHeight < minNoiseHeight) minNoiseHeight = noiseHeight;

                noiseMap[x, y] = noiseHeight;
            }

            for (var y = 0; y < mapHeight; y++)
            for (var x = 0; x < mapWidth; x++)
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);

            return noiseMap;
        }
    }
}