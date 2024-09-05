using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Pool
{
    [Serializable]
    public class AddressablePoolData
    {
        [HorizontalGroup]
        public GameObject prefab;
        [HorizontalGroup]
        public int prefabAmount;

        public AddressablePoolData(GameObject id, int amount)
        {
            prefab = id;
            prefabAmount = amount;
        }
    }
}