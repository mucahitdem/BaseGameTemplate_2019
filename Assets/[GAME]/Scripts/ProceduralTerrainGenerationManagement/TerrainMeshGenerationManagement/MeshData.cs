using UnityEngine;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement.TerrainMeshGenerationManagement
{
    public class MeshData
    {
        private int _triangleIndex;
        public int[] triangles;
        public Vector2[] uvs;
        public Vector3[] vertices;

        public MeshData(int meshWidth, int meshHeight)
        {
            vertices = new Vector3[meshWidth * meshHeight];
            uvs = new Vector2[meshWidth * meshHeight];
            triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
        }

        public void AddTriangle(int a, int b, int c)
        {
            triangles[_triangleIndex] = a;
            triangles[_triangleIndex + 1] = b;
            triangles[_triangleIndex + 2] = c;

            _triangleIndex += 3;
        }

        public Mesh CreateMesh()
        {
            var mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            mesh.RecalculateBounds();
            return mesh;
        }
    }
}