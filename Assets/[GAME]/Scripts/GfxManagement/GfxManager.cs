using Cysharp.Threading.Tasks;
using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.GameScripts.GfxManagement
{
    public class GfxManager : BaseComponent
    {
        private int _convertedDelayedDuration;
        private int _i;

        private MaterialPropertyBlock _propertyBlock;

        [SerializeField]
        private int countToEnableDisable;

        [SerializeField]
        private float delayedDuration;

        [FormerlySerializedAs("gfxToJump")]
        [SerializeField]
        private Transform gfx;

        [SerializeField]
        private GameObject[] rends;

        public Transform Gfx => gfx;

        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
            _convertedDelayedDuration = (int) (delayedDuration * 1000);
        }

        public void SetGfxPos(Vector3 targetPos)
        {
            gfx.localPosition = targetPos;
        }

        public void OnDamaged()
        {
            Jump();
            GfxEffect().GetAwaiter();
        }

        private void Jump()
        {
            //   gfxToJump.DOLocalJump(Vector3.zero, 2, 1, .35f);
        }

        private async UniTask GfxEffect()
        {
            _i = 0;
            while (_i < countToEnableDisable * 2)
            {
                for (var i = 0; i < rends.Length; i++)
                {
                    var currentRend = rends[i];
                    currentRend.gameObject.SetActive(!currentRend.gameObject.activeSelf);
                }

                _i++;
                await UniTask.Delay(_convertedDelayedDuration);
            }
        }
    }
}