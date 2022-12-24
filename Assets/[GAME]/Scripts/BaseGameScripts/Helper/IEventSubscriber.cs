namespace Scripts
{
    public interface IEventSubscriber
    {
        void SubscribeEvent();
        void UnsubscribeEvent();
    }
}