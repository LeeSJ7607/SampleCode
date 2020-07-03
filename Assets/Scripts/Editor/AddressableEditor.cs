using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using System.Collections.Generic;

public sealed class AddressableEditor
{ 
    public static void Refresh()
    {
        Common.ClearAllAddress();
        Common.TargetPathToAllPrefabAddressChecked();
        
        Convert.ReplaceAddressToFileName();
    }
    
    public sealed class Common
    {
        [MenuItem("Addressable/Common/Clear All Address")]
        public static void ClearAllAddress()
        {
            var settings= AddressableAssetSettingsDefaultObject.Settings;
            var defaultGroup = settings.DefaultGroup;
            var entries = defaultGroup.entries;
            var tempEntrys = new List<AddressableAssetEntry>(entries);

            foreach (var entry in tempEntrys)
            {
                settings.RemoveAssetEntry(entry.guid);
            }
        }
        
        [MenuItem("Addressable/Common/Target Path to All Prefab Address Checked")]
        public static void TargetPathToAllPrefabAddressChecked()
        {
            const string FilterFindAssets = "t: scene t:Prefab t:ScriptableObject";
            
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var defaultGroup = settings.DefaultGroup;
            var assetGuids = AssetDatabase.FindAssets(FilterFindAssets, new[] {"Assets/Bundle"});
            var newEntrys = new List<AddressableAssetEntry>();
            
            foreach (var guid in assetGuids)
            {
                var entry = settings.CreateOrMoveEntry(guid, defaultGroup, false, false);
                entry.address = AssetDatabase.GUIDToAssetPath(guid);
                
                newEntrys.Add(entry);
            }

            settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryMoved, newEntrys, true);
        }
    }
    
    public sealed class Convert
    {
        private static readonly string[] FilterAddressReplace =
        {
            "/", ".prefab", ".asset", ".unity"
        };
        
        [MenuItem("Addressable/Convert/Replace Address to FileName")]
        public static void ReplaceAddressToFileName()
        {
            var defaultGroup = AddressableAssetSettingsDefaultObject.Settings.DefaultGroup;
            var entries = defaultGroup.entries;
            
            foreach (var entry in entries)
            {
                var assetPath = entry.AssetPath;
                var startIdx = assetPath.LastIndexOf('/');
                var address = assetPath.Substring(startIdx);
                
                foreach (var filter in FilterAddressReplace)
                {
                    address = address.Replace(filter, string.Empty);
                }

                entry.address = address;
            }
        }
        
        [MenuItem("Addressable/Convert/Replace Address to AssetPath")]
        public static void ReplaceAddressToAssetPath()
        {
            var defaultGroup = AddressableAssetSettingsDefaultObject.Settings.DefaultGroup;
            var entries = defaultGroup.entries;

            foreach (var entry in entries)
            {
                entry.address = entry.AssetPath;
            }
        }
    }
}