using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class UIContainer : MonoBehaviour
{
    private readonly Dictionary<Type, UIView> _views = new Dictionary<Type, UIView>();

    public void GetView<T>(Action<T> onLoaded_) where T : UIView
    {
        var type = typeof(T);

        if (_views.ContainsKey(type))
        {
            onLoaded_(_views[type] as T);
        }
        else
        {
            LoadView(onLoaded_);
        }
    }

    private void LoadView<T>(Action<T> onLoaded_) where T : UIView
    {
        var name = typeof(T).ToString();
        
        ResourceManager.Instance.GetResource<GameObject>(name, (resource_) =>
        {
            var view = GetAndInstantiate<T>(resource_);
            if (view.ReferenceEquals(null) == false)
            {
                onLoaded_(view);
                _views.Add(typeof(T), view);
            }
            else
            { 
                Debug.LogError(name + " is Not Find Component");
            }
        });
    }

    private T GetAndInstantiate<T>(GameObject resource_) where T : UIView
    {
        var obj = Instantiate(resource_, BaseScene.Instance.transform);
        return obj.GetComponent<T>();
    }
}