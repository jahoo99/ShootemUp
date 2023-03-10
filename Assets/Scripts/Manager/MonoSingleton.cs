using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        _instance = this as T;
    }
}