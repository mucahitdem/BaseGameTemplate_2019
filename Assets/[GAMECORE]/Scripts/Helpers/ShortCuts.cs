using GAME.Scripts.SoundManagement;
using Scripts.ServiceLocatorModule;

namespace Scripts.Helpers
{
    public static class ShortCuts
    {
        private static SoundManager s_soundManager;

        public static void PlayAudio(string audioId)
        {
            if (!s_soundManager)
                s_soundManager = ServiceLocator.Instance.GetService<SoundManager>();
            
            s_soundManager.PlayAudio(audioId);
        }
    }
}