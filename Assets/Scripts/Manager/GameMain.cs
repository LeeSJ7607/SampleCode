using UnityEngine.AddressableAssets;

public sealed class GameMain : MonoSingleton<GameMain>
{
    public void ProcessLogin()
    {
        ModelManager.Instance.Initialize();
        
        // 씬은 추후 작업.
        Addressables.LoadSceneAsync("bt");
    }
    
    public void ReStart()
    {
        
    }
}