using UnityEngine;

namespace GAME.Scripts
{
    /// <summary>
    /// Created so name must be same as name of class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T s_instance = null;
        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    var name = typeof(T).Name;
                    s_instance = Resources.Load<T>(name);

                    if (s_instance == null)
                    {
                        Debug.LogError("SingletonScriptableObject -> Instance -> Unable to load ScriptableObject of type " + typeof(T) + " from Resources folder.");
                    }
                }
                return s_instance;
            }
        }
    }
}