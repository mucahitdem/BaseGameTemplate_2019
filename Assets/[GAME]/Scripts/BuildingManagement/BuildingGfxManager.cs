using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BuildingManagement
{
    public class BuildingGfxManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gfx;

        [Button]
        public void EnableGfx()
        {
            gfx.transform.localScale = Vector3.zero;
            gfx.SetActive(true);
            //gfx.transform.DOPunchScale(Vector3.one, .5f, 1, 0);
            gfx.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutElastic);
        }

        public void DestroyBuilding()
        {
            gfx.gameObject.SetActive(false);
        }
    }
}