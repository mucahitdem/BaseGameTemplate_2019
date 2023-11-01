using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.StatsManagement
{
    [Serializable]
    public class StatsPerLevel
    {
        [FoldoutGroup("Add Data")]
        [SerializeField]
        private bool addKeyFrame;

        public AnimationCurve statPerLevel;

        [ShowIf("addKeyFrame")]
        [FoldoutGroup("Add Data")]
        [SerializeField]
        private int time;

        [ShowIf("addKeyFrame")]
        [FoldoutGroup("Add Data")]
        [SerializeField]
        private float value;

        [ShowInInspector]
        private int Level { get; set; }

        [ShowInInspector]
        private float Stat { get; set; }

        [Button]
        private void ShowLevelValues(int desiredLevel)
        {
            Level = desiredLevel;
            Stat = statPerLevel.Evaluate(Level);
        }

        [ShowIf("addKeyFrame")]
        [FoldoutGroup("Add Data")]
        [Button]
        private void AddValueAtTime()
        {
            statPerLevel.RemoveKey(time);
            statPerLevel.AddKey(time, value);
        }

        public void UpdateValues()
        {
            Stat = statPerLevel.Evaluate(Level);
        }

        public float GetStatWithLevel(int level)
        {
            Level = level;
            Stat = statPerLevel.Evaluate(Level);

            return Stat;
        }

        public int GetStatWithLevelAsInt(int level)
        {
            Level = level;
            Stat = statPerLevel.Evaluate(Level);

            return (int) Stat;
        }
    }
}