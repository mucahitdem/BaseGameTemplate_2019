using UnityEngine;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement.TerrainMeshGenerationManagement
{
    public static class MeshGenerator
    {
        public static MeshData GenerateTerrainMesh(float[,] heightMap)
        {
            var width = heightMap.GetLength(0);
            var height = heightMap.GetLength(1);
            var topLeftX = (width - 1) / -2f;
            var topLeftZ = (height - 1) / 2f;


            var meshData = new MeshData(width, height);
            var vertIndex = 0;

            for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
            {
                meshData.vertices[vertIndex] = new Vector3(topLeftX + x, heightMap[x, y], topLeftZ - y);
                meshData.uvs[vertIndex] = new Vector2(x / (float) width, y / (float) height);

                if (x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle(vertIndex, vertIndex + width + 1, vertIndex + width);
                    meshData.AddTriangle(vertIndex + width + 1, vertIndex, vertIndex + 1);
                }

                vertIndex++;
            }

            return meshData;
        }
    }
}