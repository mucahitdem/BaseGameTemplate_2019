using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.WeaponManagement
{
    public class WeaponRangeUi : BaseComponent
    {
        [SerializeField]
        private CreateCircle createCircle;

        public void UpdateRange(float newRange)
        {
            createCircle.radius = newRange;
        }
    }
}