using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public sealed class AssetData
{
    public AsyncOperationHandle Data { get; }

    public AssetData(AsyncOperationHandle data_) => Data = data_;
}

public sealed class AddressableContainer
{
    private readonly Dictionary<string, AssetData> _assets = new Dictionary<string, AssetData>();
    
    public void GetAsset<T>(string assetName_, Action<T> onLoaded_) where T : Object
    {
        if (_assets.ContainsKey(assetName_))
        {
            onLoaded_(_assets[assetName_].Data.Result as T);
        }
        else
        {
            LoadAsset(assetName_, onLoaded_);
        }
    }
    
    private async void LoadAsset<T>(string path_, Action<T> onLoaded_) where T : Object
    {
        var asset = Addressables.LoadAssetAsync<T>(path_);
        await Awaiters.Until(() => asset.IsDone);

        if (asset.Status == AsyncOperationStatus.Succeeded)
        {
            onLoaded_(asset.Result);
            _assets.Add(path_, new AssetData(asset));
        }
        else
        {
            Debug.LogError("Addressables LoadAssetAsync Failure!! ErrorMsg : " + asset.OperationException.Message);
        }
    }
}