﻿using UnityEngine;
using Plugins.XAsset;
using System;

public class AssetsInit : MonoBehaviour
{
    public string assetPath;

    // Start is called before the first frame update
    void Start()
    {
        /// 初始化
        Assets.Initialize(OnInitialized, (error) => { Debug.Log(error); }); 
    }

    private void OnInitialized()
    {
        var asset = Assets.Load(assetPath, typeof(UnityEngine.Object));
        asset.completed += delegate(Asset a) 
        {
            if (a.name.EndsWith(".prefab", StringComparison.CurrentCulture))
            {
                var go = Instantiate(a.asset);
                go.name = a.asset.name;
                /// 设置关注对象，当关注对象销毁时，回收资源
                a.Require(go); 
                Destroy(go, 3);
                /// 设置关注对象后，只需要释放一次，可以按自己的喜好调整，
                /// 例如 ABSystem 中，不需要 调用这个 Release，
                /// 这里如果之前没有调用 Require，下一帧这个资源就会被回收
                a.Release();   
            }
        };
    } 
}
