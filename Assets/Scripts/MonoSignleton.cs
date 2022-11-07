using UnityEngine;

namespace GeneralScripts
{
    public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
    {
        private static volatile T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>();
                return _instance;
            }
        }
    }
}
