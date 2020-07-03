using System.IO;
using UnityEngine;

public sealed class ScreenShotManager : Singleton<ScreenShotManager>
{
    private const string Path = @"/Users/mac/work/1_leesj/";
    
    public async void Save(string fileName_)
    {
        await YieldInstructionCache.WaitForEndOfFrame;

        var tex2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tex2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        tex2D.Apply();

        var path = string.Concat(Path, fileName_, ".png");
        File.WriteAllBytes(path, tex2D.EncodeToJPG());
    }
}