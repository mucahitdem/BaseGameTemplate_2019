using System;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoadManagement;
using Scripts.GameScripts.Helpers;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.UpgradeManagement
{
    [Serializable]
    public class BaseUpgradableData : ISaveAndLoad
    {
        private int _currentLevel = 1;

        [SerializeField]
        private bool addOver;

        [ShowIf("useInitialValue")]
        [SerializeField]
        private float initialValue;

        [SerializeField]
        private AnimationCurve levelCurve;

        public Action<int> onLevelIncreased;
        public Action onUpgradeMaxed;

        [SerializeField]
        private string saveKey;

        [SerializeField]
        private bool useInitialValue;

        [ShowInInspector]
        [ReadOnly]
        public int CurrentLevel
        {
            get => _currentLevel;
            private set => _currentLevel = value;
        }

        [ShowInInspector]
        [ReadOnly]
        private int MaxLevel => levelCurve.keys.Length > 0 ? (int) levelCurve.keys[^1].time : 0;

        [ShowInInspector]
        [ReadOnly]
        public bool UpgradeMaxed => CurrentLevel >= MaxLevel;

        [ShowInInspector]
        [ReadOnly]
        public float ValueAtLevel => levelCurve.Evaluate(CurrentLevel);

        [ShowInInspector]
        [ReadOnly]
        public float CurrentValue { get; private set; }

        public void Save()
        {
            PlayerPrefs.SetInt(saveKey, CurrentLevel);
        }

        public void Load()
        {
            if (saveKey.IsNullOrWhitespace())
                saveKey = RandomStringGenerator.GenerateRandomString(Random.Range(5, 10));
            CurrentLevel = PlayerPrefs.GetInt(saveKey, 1);
            CurrentLevel = Mathf.Clamp(CurrentLevel, 1, 1000);
            CurrentValue = GetValue(CurrentLevel);
            //DebugHelper.LogRed(CurrentValue.ToString(CultureInfo.InvariantCulture));
        }

        public float GetNextLevelValues()
        {
            return GetValue(CurrentLevel + 1);
        }

        [ButtonGroup]
        public void Upgrade()
        {
            CurrentLevel++;
            CurrentValue = GetValue(CurrentLevel);
            onLevelIncreased?.Invoke(CurrentLevel);

            if (UpgradeMaxed) onUpgradeMaxed?.Invoke();
        }

        [ButtonGroup]
        public void Reset()
        {
            CurrentLevel = 1;
            CurrentValue = GetValue(CurrentLevel);
            onLevelIncreased?.Invoke(CurrentLevel);

            DebugHelper.LogRed(saveKey + " RESET DATA");
        }

        [ButtonGroup]
        public void Max()
        {
            Reset();
            for (var i = 0; i < MaxLevel; i++) Upgrade();
        }

        private float GetValue(int levelToCheck)
        {
            var value = levelCurve.Evaluate(levelToCheck);
            var sumOfValues = 0f;
            for (var i = 0; i < levelToCheck; i++)
                sumOfValues += levelCurve.Evaluate(i);
            if (!useInitialValue && !addOver)
                return value;
            if (useInitialValue && !addOver)
                return initialValue + value;
            if (!useInitialValue && addOver)
                return sumOfValues;
            if (useInitialValue && addOver)
                return initialValue + sumOfValues;

            return -1;
        }

        //[Button]
        private void MoveAllFramesForwardOnce()
        {
            var keysLength = levelCurve.keys.Length - 1;
            Keyframe prevKey = default;
            for (var i = keysLength; i >= 0; i--)
            {
                var currentKey = levelCurve.keys[i];
                if (i != 0)
                    prevKey = levelCurve.keys[i - 1];
                var value = i == 0 ? 0 : prevKey.value;
                levelCurve.AddKey(currentKey.time, value);
            }
        }
        //private float _sumOfValues;

        #region Add New Key Frame Or Update It

        [FoldoutGroup("Add Data")]
        [SerializeField]
        private bool addKeyFrame;

        [ShowIf("addKeyFrame")]
        [FoldoutGroup("Add Data")]
        [SerializeField]
        private int timeToAdd;

        [ShowIf("addKeyFrame")]
        [FoldoutGroup("Add Data")]
        [SerializeField]
        private float valueToAdd;

        [ShowIf("addKeyFrame")]
        [FoldoutGroup("Add Data")]
        [Button]
        private void AddValueAtTime()
        {
            if (KeyExistsAtTime(timeToAdd))
                levelCurve.RemoveKey(timeToAdd);

            levelCurve.AddKey(timeToAdd, valueToAdd);
        }

        private bool KeyExistsAtTime(float timeToCheck)
        {
            for (var i = 0; i < levelCurve.length; i++)
            {
                var keyframe = levelCurve[i];

                if (Mathf.Approximately(keyframe.time, timeToCheck)) return true;
            }

            return false;
        }

        #endregion
    }
}