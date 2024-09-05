using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.GameStateManagement.States;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameStateManagement;
using Scripts.ServiceLocatorModule;
using UnityEngine;

namespace GAME.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private GameStateManager _gameStateManager;
        protected void Awake()
        {
            _gameStateManager = ServiceLocator.Instance.GetService<GameStateManager>();
            _gameStateManager.SetState(new StartState());
        }
    }
}