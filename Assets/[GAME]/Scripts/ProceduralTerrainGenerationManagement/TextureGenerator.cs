using UnityEngine;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement
{
    public static class TextureGenerator
    {
        public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
        {
            var tex = new Texture2D(width, height);
            tex.filterMode = FilterMode.Point;
            tex.wrapMode = TextureWrapMode.Clamp;
            tex.SetPixels(colorMap);
            tex.Apply();
            return tex;
        }

        public static Texture2D TextureFromHeightMap(float[,] heightMap)
        {
            var width = heightMap.GetLength(0);
            var height = heightMap.GetLength(1);

            var tex = new Texture2D(width, height);

            var colorMap = new Color[width * height];

            for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);

            return TextureFromColorMap(colorMap, width, height);
        }
    }
}