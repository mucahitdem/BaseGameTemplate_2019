using BayatGames.SaveGameFree;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.SaveAndLoad;
using UnityEngine;

namespace Scripts.GameScripts.Coin_System
{
    public class CoinManager : MonoBehaviour , IPoolObject , ISaveAndLoad
    {
        [field: SerializeField]
        public int ItemCount { get; set; }

        public float coinCount;


        public void Save()
        {
            SaveGame.Save("coinCount" , coinCount);
        }

        public void Load()
        {
            coinCount = SaveGame.Load("coinCount" , coinCount);
            Debug.LogError("COIN COUNT : " + coinCount);
        }
    }
}