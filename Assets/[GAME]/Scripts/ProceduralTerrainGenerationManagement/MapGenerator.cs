using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.ProceduralTerrainGenerationManagement.TerrainMeshGenerationManagement;
using UnityEngine;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement
{
    public class MapGenerator : BaseComponent
    {
        [SerializeField]
        public bool autoUpdate;


        [SerializeField]
        private DrawMode drawMode;

        [SerializeField]
        private float lacunarity;

        [SerializeField]
        private MapDisplay mapDisplay;

        [SerializeField]
        private int mapHeight;

        [SerializeField]
        private int mapWidth;

        [SerializeField]
        private float noiseScale;

        [SerializeField]
        private int octaves;

        [SerializeField]
        private Vector2 offset;

        [SerializeField]
        [Range(0f, 1f)]
        private float persistance;

        [SerializeField]
        private TerrainType[] regions;

        [SerializeField]
        private int seed;

        public bool AutoUpdate => autoUpdate;

        public void GenerateMap()
        {
            var noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance,
                lacunarity, offset);

            var colorMap = new Color[mapHeight * mapWidth];

            for (var y = 0; y < mapHeight; y++)
            for (var x = 0; x < mapWidth; x++)
            {
                var currentHeight = noiseMap[x, y];

                for (var i = 0; i < regions.Length; i++)
                    if (currentHeight <= regions[i].height)
                    {
                        colorMap[y * mapWidth + x] = regions[i].color;

                        break;
                    }
            }

            if (drawMode == DrawMode.NoiseMap)
                mapDisplay.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
            else if (drawMode == DrawMode.ColorMap)
                mapDisplay.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
            else if (drawMode == DrawMode.Mesh)
                mapDisplay.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap),
                    TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }


        private void OnValidate()
        {
            if (mapHeight < 1)
                mapHeight = 1;

            if (mapWidth < 1)
                mapWidth = 1;


            if (lacunarity < 1)
                lacunarity = 1;

            if (octaves < 0)
                octaves = 0;
        }
    }
}