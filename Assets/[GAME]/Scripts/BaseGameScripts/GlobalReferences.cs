using Scripts.BaseGameScripts.Pool;
using Scripts.Managers;
using Scripts.State;
using Scripts.UI;
using Sirenix.OdinInspector;

namespace Scripts
{
    public class GlobalReferences : SingletonMono<GlobalReferences>
    {
        [Title("Managers")]
        public UiManager uiManager;
        public GameManager gameManager;
        public GameStateManager gameStateManager;
        public PoolManager poolManager;
        
        protected override void UseThisInsteadOfAwake()
        {
            
        }
    }
}