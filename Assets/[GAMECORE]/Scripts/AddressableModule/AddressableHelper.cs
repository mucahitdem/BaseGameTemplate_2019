using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Scripts.AddressableModule
{
    public static class AddressableHelper
    {
        private static readonly Dictionary<string,GameObject> s_objectsLoaded = new Dictionary<string, GameObject>();
        public static void InitByAddress(string address, Action<GameObject> onEnd)
        {
            if (s_objectsLoaded.TryGetValue(address, out GameObject go))
            {
                onEnd?.Invoke(go);
                return;
            }
            
            var opHandle = Addressables.LoadAssetAsync<GameObject>(address);
            opHandle.Completed += (operation) =>
            {
                if (opHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("ASSET LOADED WITH ID : " + address);
                    s_objectsLoaded.Add(address, opHandle.Result);
                    onEnd?.Invoke(opHandle.Result);
                }
                else
                {
                    Debug.LogError("COULDN'T LOAD ASSET WITH ID : " + address);
                }
            };
        }
        public static void InitByAssetReference<T>(AssetReference address, Action<T> onEnd)
        {
            var opHandle = address.LoadAssetAsync<T>();
            opHandle.Completed += (operation) =>
            {
                if (opHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("ASSET LOADED WITH ID : " + address);
                    onEnd?.Invoke(opHandle.Result);
                }
                else
                {
                    Debug.LogError("COULDN'T LOAD ASSET WITH ID : " + address);
                }
            };
        }
    }
}