using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.CameraManagement
{
    public class MakeMeshTransparent : BaseComponent
    {
        private Color[] _colors;

        private MaterialPropertyBlock _propertyBlock;

        [SerializeField]
        private Renderer rend;

        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
            rend = GetComponent<Renderer>();
            var matCount = rend.sharedMaterials.Length;
            _colors = new Color[matCount];
            for (var i = 0; i < matCount; i++) _colors[i] = rend.sharedMaterials[i].GetColor("_Color");
        }

        public void ControlTransparent(float desiredOpacity)
        {
            //DebugHelper.LogRed("MAKE TRANSPARENCY : " + TransformOfObj.name + " --- " + desiredOpacity);
            for (var i = 0; i < rend.sharedMaterials.Length; i++)
            {
                rend.GetPropertyBlock(_propertyBlock, i);

                _colors[i].a = desiredOpacity;
                _propertyBlock.SetColor("_Color", _colors[i]);

                rend.SetPropertyBlock(_propertyBlock, i);
            }
        }
    }
}