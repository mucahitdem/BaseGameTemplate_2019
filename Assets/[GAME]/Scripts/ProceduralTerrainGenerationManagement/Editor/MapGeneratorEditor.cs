using UnityEditor;
using UnityEngine;

namespace Scripts.GameScripts.ProceduralTerrainGenerationManagement.Editor
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var mapGen = (MapGenerator) target;

            if (DrawDefaultInspector())
                if (mapGen.AutoUpdate)
                    mapGen.GenerateMap();

            if (GUILayout.Button("Generate")) mapGen.GenerateMap();
        }
    }
}