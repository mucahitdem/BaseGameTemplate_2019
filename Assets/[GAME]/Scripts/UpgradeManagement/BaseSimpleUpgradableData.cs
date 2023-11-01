using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.UpgradeManagement
{
    [Serializable]
    public class BaseSimpleUpgradableData
    {
        public Action<int,float> onLevelIncreased;
        public Action onUpgradeMaxed;
        
        [SerializeField]
        private UpgradeData[] upgradeData;

        [SerializeField]
        private bool enableSave;
        
        [ShowIf("enableSave")]
        [SerializeField]
        private string saveKey;        
        
        [ShowInInspector]
        [ReadOnly]
        public int CurrentLevel
        {
            get => _currentLevel;
            private set => _currentLevel = value;
        }

        [ShowInInspector]
        [ReadOnly]
        private int MaxLevel => upgradeData.Length;

        [ShowInInspector]
        [ReadOnly]
        public bool UpgradeMaxed => CurrentLevel >= MaxLevel;
        
        
        private int _currentLevel;

        
        
        [ButtonGroup]
        public void Upgrade()
        {
            CurrentLevel++;
            onLevelIncreased?.Invoke(CurrentLevel, DataAtLevel(CurrentLevel));

            if (UpgradeMaxed) 
                onUpgradeMaxed?.Invoke();
        }
        
        [ButtonGroup]
        public void Reset()
        {
            CurrentLevel = 0;
            onLevelIncreased?.Invoke(CurrentLevel, DataAtLevel(CurrentLevel));

            if (UpgradeMaxed) 
                onUpgradeMaxed?.Invoke();
        }
        
        
        private float CostAtLevel(int level) => upgradeData[level - 1].Cost;
        private float DataAtLevel(int level) => upgradeData[level - 1].Data;

    }
}