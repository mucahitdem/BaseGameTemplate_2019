using UnityEngine;

namespace Scripts.GameScripts.LookAtCameraManagement
{
    public class LookAtCamera : MonoBehaviour
    {
        private void OnEnable()
        {
            LookAtCameraManager.Instance.AddObj(transform);
        }

        private void OnDisable()
        {
            LookAtCameraManager.Instance.RemoveObj(transform);
        }
    }
}