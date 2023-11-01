using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.UiManagement.HealthUiManagement
{
    public class HealthIconController : MonoBehaviour
    {
        private bool _isEnabled;

        [SerializeField]
        private GameObject heartInside;

        [SerializeField]
        private GameObject heartOutside;

        [ButtonGroup]
        private void GetIcons()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                var emptyIcon = child.name == "EmptyIcon";
                if (emptyIcon)
                    heartOutside = child.gameObject;
                else
                    heartInside = child.gameObject;
            }
        }

        public void ActivateHeart()
        {
            if (_isEnabled)
                return;
            _isEnabled = true;

            gameObject.SetActive(true);
            heartOutside.SetActive(true);
        }

        public void ControlIcon(bool isActive)
        {
            heartInside.SetActive(isActive);
        }
    }
}