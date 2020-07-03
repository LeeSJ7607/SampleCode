using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class ModelManager : Singleton<ModelManager>
{
    private readonly Dictionary<Type, Model> _models = new Dictionary<Type, Model>();

    public void Initialize()
    {
        AddModel<CMUser>();
    }
    
    private void AddModel<T>() where T : Model, new()
    {
        _models.Add(typeof(T), new T());
    }

    public T GetModel<T>() where T : Model
    {
        var type = typeof(T);

        if (_models.ContainsKey(type))
        {
            return _models[type] as T;
        }
        else
        {
            Debug.LogError(type + " is Not Find Key");
            return default;
        }
    }
}