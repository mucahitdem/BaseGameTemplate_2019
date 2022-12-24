using UnityEngine;

namespace Scripts
{
    public abstract class EventSubscriber : MonoBehaviour, IEventSubscriber
    {
        public virtual void OnEnable()
        {
            SubscribeEvent();
        }

        public virtual void OnDisable()
        {
            UnsubscribeEvent();
        }

        public abstract void SubscribeEvent();
        public abstract void UnsubscribeEvent();
    }
}