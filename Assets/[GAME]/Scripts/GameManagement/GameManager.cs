using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.EnemySpawnManagement.AllSpawners;
using Scripts.GameScripts.PlayerManagement;
using Scripts.GameScripts.TimerManagement;
using Scripts.GameScripts.WeaponManagement;
using Scripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.GameManagement
{
    public class GameManager : SingletonMono<GameManager>
    {
        private BaseEnemySpawnerByTime _baseEnemySpawnerByTime;
        private EventQueue _eventQueue;
        private GameStateManager _gameStateManager;
        private GameTimer _gameTimer;

        private PlayerManager _playerManager;
        private WeaponManager _weaponManager;

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

        public EventQueue EventQueue
        {
            get
            {
                if (!_eventQueue)
                    _eventQueue = FindObjectOfType<EventQueue>();

                return _eventQueue;
            }
        }

        public WeaponManager WeaponManager
        {
            get
            {
                if (!_weaponManager)
                    _weaponManager = FindObjectOfType<WeaponManager>();
                return _weaponManager;
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

        // private async void Start()
        // {
        //     Debug.Log("Starting UniTaskDelayExample");
        //
        //     // Call the UniTask version of Delay
        //     await DelayAsync();
        //
        //     Debug.Log("UniTaskDelayExample completed");
        // }
        //
        // async UniTask DelayAsync()
        // {
        //     Debug.Log("COW : " + Time.time);
        //
        //     // Use UniTask.Delay to create the delay
        //     await UniTask.Delay(1000);
        //
        //     Debug.Log("WOW " + Time.time);
        // }
    }
}