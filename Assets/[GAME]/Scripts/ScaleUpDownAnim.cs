using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts
{
    public class ScaleUpDownAnim : MonoBehaviour
    {
        private void OnEnable()
        {
            Scale();
        }

        private void Scale()
        {
            transform.DOPunchScale(Vector3.one, 1, 1)
                .OnComplete(() => { Scale(); });
        }
    }
}