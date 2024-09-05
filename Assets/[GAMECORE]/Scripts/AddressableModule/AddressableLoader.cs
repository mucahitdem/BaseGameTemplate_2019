using System;
using System.Collections.Generic;
using GAME.Scripts.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Scripts.AddressableModule
{
    public class AddressableLoader
    {
        private readonly ActionQueueManager _actionQueueManager;
        private readonly Dictionary<string, GameObject> _idAndObject = new Dictionary<string,GameObject>();

        public AddressableLoader()
        {
            _actionQueueManager = new ActionQueueManager();
        }


        public T AssetWithId<T>(string id)
        {
            if (_idAndObject.TryGetValue(id, out GameObject objInData))
            {
                var obj = objInData.GetComponent<T>();
                return obj;
            }
            
            Debug.LogError("ASSET WITH ID " + id + " NOT LOADED");
            var op = Addressables.LoadAssetAsync<GameObject>(id);
            GameObject go = op.WaitForCompletion();
            _idAndObject.Add(id, go);

            return go.GetComponent<T>();
        }
        public void TryInitializeAsset(string id, Action<GameObject> onEnd)
        {
            if (_idAndObject.TryGetValue(id, out GameObject objInData))
            {
                Debug.LogError("IT IS ALREADY INITED : " + id);
                return;
            }
            
            //Debug.Log("INIT ASSET WITH ID : " + id);
            AddLoadQueue(id, onEnd);
        }
        public bool IsInitializeEnded()
        {
            return _actionQueueManager.AreTasksCompleted;
        }
        
        
        
        private void AddLoadQueue(string id, Action<GameObject> onEnd)
        {
            _actionQueueManager.AddAction(() =>
            {
                try
                {
                    var opHandle = Addressables.LoadAssetAsync<GameObject>(id);
                    opHandle.Completed += (operation) =>
                    {
                        if (opHandle.Status == AsyncOperationStatus.Succeeded)
                        {
                            //Debug.Log("ASSET LOADED WITH ID : " + id);
                            _idAndObject.Add(id, opHandle.Result);
                            onEnd?.Invoke(opHandle.Result);
                        }
                        else
                        {
                            Debug.LogError("COULDN'T LOAD ASSET WITH ID : " + id);
                        }

                        _actionQueueManager.OnActionEnd();
                    };
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
               
            });
        }
    }
}