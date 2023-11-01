using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.ProceduralTerrainGenerationManagement.TerrainMeshGenerationManagement;
using UnityEngine;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement
{
    public class MapDisplay : BaseComponent
    {
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
        public Renderer textureRend;


        public void DrawTexture(Texture2D tex)
        {
            textureRend.sharedMaterial.mainTexture = tex;
            textureRend.transform.localScale = new Vector3(tex.width, 1, tex.height);
        }

        public void DrawMesh(MeshData meshData, Texture2D tex)
        {
            meshFilter.sharedMesh = meshData.CreateMesh();
            meshRenderer.sharedMaterial.mainTexture = tex;
        }
    }
}