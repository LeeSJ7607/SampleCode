using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public sealed class ResourceData<T> where T : Object
{
    public T Data { get; }

    public ResourceData(T data_) => Data = data_;
}

public sealed class ResourceManager : Singleton<ResourceManager>
{
    private readonly AddressableContainer _addressableContainer = new AddressableContainer();
    private readonly Dictionary<string, ResourceData<Object>> _resources = new Dictionary<string, ResourceData<Object>>();

    public void GetResource<T>(Action<T> onLoaded_) where T : Object
        => Load(typeof(T).ToString(), onLoaded_);
    
    public void GetResource<T>(string resourceName_, Action<T> onLoaded_) where T : Object 
        => Load(resourceName_, onLoaded_);

    private void Load<T>(string resourceName_, Action<T> onLoaded_) where T : Object
    {
        if (_resources.ContainsKey(resourceName_))
        {
            onLoaded_(_resources[resourceName_].Data as T);
        }
        else
        {
            LoadResource(resourceName_, onLoaded_);
        }
    }
    
    private void LoadResource<T>(string resourceName_, Action<T> onLoaded_) where T : Object
    {
        _addressableContainer.GetAsset<T>(resourceName_, (asset_) =>
        {
            onLoaded_(asset_);
            _resources.Add(resourceName_, new ResourceData<Object>(asset_));
        });
    }
}