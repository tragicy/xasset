using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public enum AssetPathType
{
    FOLDER = 0,
    FOLDER_FILE,
    FILE
}

[Serializable]
public class AssetPath
{
    public string path;
    public string name;
    public AssetPathType type;
}
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateABPathData", order = 1)]
public class ABPathData: ScriptableObject
{
    public List<AssetPath> assetPaths = new List<AssetPath>();
}