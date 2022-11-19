using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public interface Patterns_ISingleton
    {
    }

    [DefaultExecutionOrder(int.MinValue + 10)]
    public abstract class Patterns_SingletonMono<T> : MonoBehaviour, Patterns_ISingleton where T: MonoBehaviour
    {
        public bool dontDestroyOnLoad;
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (!Application.isPlaying)
                {
                    _instance = FindObjectOfType<T>();
                }
                BuildNewInstanceIfNull();

                return _instance;
            }
            set => _instance = value;
        }

        private static void BuildNewInstanceIfNull()
        {
            if (_instance == null)
            {
                var newObject = new GameObject("" + typeof(T).Name);
                _instance = newObject.AddComponent<T>();
            }
        }

        public static bool IsNull
        {
            get
            {
                if (!Application.isPlaying)
                {
                    _instance = FindObjectOfType<T>();
                }
                return _instance == null;
            }
        }

        protected virtual void Awake()
        {
            if(_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            (Instance as Patterns_SingletonMono<T>).UseThisInsteadOfAwake();
            SetIfDontDestroyOnLoad();
        }

        private void SetIfDontDestroyOnLoad()
        {
            if (dontDestroyOnLoad)
            {
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }
        }

        protected abstract void UseThisInsteadOfAwake();
    }
}