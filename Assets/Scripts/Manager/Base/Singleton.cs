using System;
using UnityEngine;

public class Singleton<T> where T : class
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance.ReferenceEquals(null))
            {
                _instance = Activator.CreateInstance<T>();
            }

            return _instance.ReferenceEquals(null) == false ? _instance : throw new Exception(typeof(T) + " instance Create Failure");
        }
    }
}

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance.ReferenceEquals(null))
            {
                var objs = FindObjectsOfType<T>();
                if (0 < objs.Length && objs[0].ReferenceEquals(null) == false)
                {
                    _instance = objs[0];
                }
                else
                {
                    var name = typeof(T).ToString();
                    var obj = GameObject.Find(name);

                    if (obj.ReferenceEquals(null))
                    {
                        obj = new GameObject(name);
                    }

                    _instance = obj.AddComponent<T>();
                }

                DontDestroyOnLoad(_instance);
            }
            
            return _instance.ReferenceEquals(null) == false ? _instance : throw new Exception(typeof(T) + " instance Create Failure");
        }
    }
}