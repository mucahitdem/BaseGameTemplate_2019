using UnityEngine;

namespace Scripts.LookAtCameraManagement
{
    public class LookAtCamera : MonoBehaviour
    {
        private void OnEnable()
        {
            LookAtCameraManager.Instance.AddObj(transform);
        }
    }
}