using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.EnemySpawnManagement.AllSpawners;
using Scripts.GameScripts.TimerManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameManagement
{
    public class GameManager : SingletonMono<GameManager>
    {
        private BaseEnemySpawnerByTime _baseEnemySpawnerByTime;
        private EventQueue _eventQueue;
        private GameStateManager _gameStateManager;
        private GameTimer _gameTimer;

        private PlayerManager _playerManager;

        [SerializeField]
        private Camera cam;

        public Camera MainCam => cam;

        public PlayerManager Player
        {
            get
            {
                if (!_playerManager)
                    _playerManager = FindObjectOfType<PlayerManager>();

                return _playerManager;
            }
        }
        public GameTimer GameTimer
        {
            get
            {
                if (!_gameTimer)
                    _gameTimer = FindObjectOfType<GameTimer>();

                return _gameTimer;
            }
        }

        public BaseEnemySpawnerByTime BaseEnemySpawnerByTime
        {
            get
            {
                if (!_baseEnemySpawnerByTime)
                    _baseEnemySpawnerByTime = FindObjectOfType<BaseEnemySpawnerByTime>();

                return _baseEnemySpawnerByTime;
            }
        }

        public GameStateManager GameStateManager
        {
            get
            {
                if (!_gameStateManager)
                    _gameStateManager = FindObjectOfType<GameStateManager>();

                return _gameStateManager;
            }
        }


        protected override void OnAwake()
        {
        }
    }
}