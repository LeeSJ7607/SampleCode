using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public sealed class Builder
{
    [PostProcessBuild((int) PostProcessBuildOrder.None)]
    public static void OnPostProcessBuild(BuildTarget buildTarget_, string pathToBuiltProject_)
    {
        Debug.Log("Builder.OnPostProcessBuild Start");
        
        // 개발을 하는 도중에 개발자 실수로 인해 어드레서블 정리를 안 했을 경우를 대비하여 빌드 과정에 어드레서블 리프레쉬 메소드를 추가함.
        AddressableEditor.Refresh();
        Debug.Log("AddressableEditor.Refresh");
        
        Debug.Log("Builder.OnPostProcessBuild End");
    }
}