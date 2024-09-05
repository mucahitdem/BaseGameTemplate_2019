using System.Collections.Generic;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Scripts.Pool
{
    public class PoolingPattern
    {
        private readonly Stack<GameObject> _objPool = new Stack<GameObject>();
        //private readonly string prefab;
        private readonly int prefabAmount;
        //private bool isInitialized;
        private GameObject prefab;
        private readonly PoolManager poolManager;

        public PoolingPattern(GameObject prefabId, int prefabAmount, PoolManager poolManager)
        {
            //this.prefab = prefab;
            prefab = prefabId;
            this.prefabAmount = prefabAmount;
            this.poolManager = poolManager;
            //isInitialized = false;
            FillPool();
        }
        
        
        
        
        public GameObject PullObjFromPool(Transform parent, Vector3 localPos, Vector3 localAngles = default)
        {
            var obj = GetItem();

            obj.transform.SetParent(parent);
            obj.transform.SetLocalPositionAndRotation(localPos, Quaternion.Euler(localAngles));
            obj.gameObject.SetActive(true);

            return obj;
        }
        public GameObject PullObjFromPool(Vector3 pos, Vector3 rot = default)
        {
            var obj = GetItem();

            obj.transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));
            obj.gameObject.SetActive(true);

            return obj;
        }
        public T PullObjFromPool<T>(Vector3 pos, Vector3 rot = default) where T : MonoBehaviour
        {
            var obj = GetItem();
            
            var type = obj.GetComponent<T>();
            if (type)
            {
                type.transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));
                obj.gameObject.SetActive(true);

                return type as T;
            }

            return null;
        }
        public T PullObjFromPool<T>(Transform parent, Vector3 localPos, Vector3 localAngles = default) where T : MonoBehaviour
        {
            var obj = GetItem();

            var type = obj.GetComponent<T>();
            if (type)
            {
                type.transform.SetParent(parent);
                type.transform.SetLocalPositionAndRotation(localPos, Quaternion.Euler(localAngles));
                obj.gameObject.SetActive(true);

                return type as T;
            }

            return null;
        }
        
        
        
        
        public void AddObjToPool(GameObject objToPool)
        {
            if(_objPool.Contains(objToPool))
                return;
            objToPool.transform.SetParent(null);
            objToPool.gameObject.SetActive(false);
            _objPool.Push(objToPool);
        }



        
        private GameObject GetItem()
        {
            // if (!isInitialized)
            //     Init();
            
            if (_objPool.Count > 0)
                return _objPool.Pop();
            
            return poolManager.InstantiateObj(prefab);
        }
        private void Init()
        {
            // AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(prefab);
            // handle.WaitForCompletion(); // Wait for the loading to complete synchronously
            //
            // if (handle.Status == AsyncOperationStatus.Succeeded)
            // {
            //     prefab = handle.Result;
            //     FillPool();
            //     isInitialized = true;
            // }
            // else
            // {
            //     Debug.LogError("Failed to load asset with key: " + prefab);
            // }
        }
        private void FillPool()
        {
            for (var i = 0; i < prefabAmount; i++)
            {
                var obj = poolManager.InstantiateObj(prefab);
                AddObjToPool(obj);
            }
        }
    }
}