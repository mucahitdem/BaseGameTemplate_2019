using UnityEngine;

namespace Scripts.GameScripts.BulletManagement
{
    public class BulletGfxManager : MonoBehaviour
    {
        [SerializeField]
        private Transform bulletGfx;

        [SerializeField]
        private Renderer bulletVisual;

        public void SetBulletSize(float size, Color bulletColor)
        {
            bulletGfx.localScale = Vector3.one * size;
            bulletVisual.sharedMaterial.color = bulletColor;
        }
    }
}