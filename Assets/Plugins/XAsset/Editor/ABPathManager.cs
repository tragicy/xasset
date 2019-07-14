using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

class ABPathManager: EditorWindow
{
    private List<AssetPath> assetPaths;

    [MenuItem("Window/AssetBundlePathManager")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ABPathManager));
    }
    private void OnEnable()
    {
        assetPaths = GetAssetPathData().assetPaths; 
    }
    private static T GetAsset<T>(string path) where T : ScriptableObject
    {
        var asset = AssetDatabase.LoadAssetAtPath<T>(path);
            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(asset, path);
                AssetDatabase.SaveAssets();
            }

            return asset;
        }

        public ABPathData GetAssetPathData()
        {
            return GetAsset<ABPathData>("Assets/AssetPathData.asset");
        }


    void OnGUI()
    {
        if(GUILayout.Button("Test"))
        {
            Debug.Log("Hello Unity Editor");
            AssetPath assetPath = new AssetPath();
            assetPaths.Add(assetPath);
            Debug.Log(assetPaths.Count);
        }
        // The actual window code goes here
    }
}