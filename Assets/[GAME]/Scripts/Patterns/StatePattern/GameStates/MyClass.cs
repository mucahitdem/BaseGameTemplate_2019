using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Patterns.StatePattern
{
    public class MyClass : MonoBehaviour
    {
        [Button]
        public void SetPlayingState()
        {
            GameStateManager.Instance().PrintAll();
        }
    }
}