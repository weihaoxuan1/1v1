using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class CreateAssetbundle : Editor {

	//打包单个
    [MenuItem("Custom Editor/Create AssetBundles Main(Android)")]
    static void CreateAssetBundlesMain_Android()
    {
        string path = AssetbundlePathAndroid;
        //获取在project视图中选择的所有游戏对象
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        //遍历所有游戏对象
        foreach (Object obj in SelectedAsset)
        {
            Caching.CleanCache();

            //本地测试：建议最好将Assetbundle房子StreamingAssets文件夹下，
            //如果没有就创建一个，因为移动平台下只能读取这个路径
            //StreamingAssets是只读路径，不能写入
            //服务器下载:就不需要放这里了
            //string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
            string targetPath = path;

            /*
                默认情况下打的包只能在电脑上用，如果要在手机上用就要添加一个参数。
                Android上：
                BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies,BuildTarget.Android)
                IOS上:
                BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies,BuildTarget.iPhone)
                另外，电脑上和手机上打出来的Assetbundle不能混用，不同平台只能用自己的。
            */
            if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android))
            {
                Debug.Log(obj.name + "资源打包成功");
            }
            else {
                Debug.Log(obj.name + "资源打包失败");
            }
        }
        //刷新编辑器
        AssetDatabase.Refresh();
    }
    //打包单个
    //[MenuItem("Custom Editor/Create AssetBundles Main(IOS)")]
    //static void CreateAssetBundlesMain_IOS()
    //{
    //    string path = AssetbundlePathIOS;
    //    //获取在project视图中选择的所有游戏对象
    //    Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

    //    //遍历所有游戏对象
    //    foreach (Object obj in SelectedAsset)
    //    {
    //        Caching.CleanCache();

    //        //本地测试：建议最好将Assetbundle房子StreamingAssets文件夹下，
    //        //如果没有就创建一个，因为移动平台下只能读取这个路径
    //        //StreamingAssets是只读路径，不能写入
    //        //服务器下载:就不需要放这里了
    //        //string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
    //        string targetPath = path;

    //        /*
    //            默认情况下打的包只能在电脑上用，如果要在手机上用就要添加一个参数。
    //            Android上：
    //            BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies,BuildTarget.Android)
    //            IOS上:
    //            BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies,BuildTarget.iPhone)
    //            另外，电脑上和手机上打出来的Assetbundle不能混用，不同平台只能用自己的。
    //        */
    //        if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies, BuildTarget.iOS))
    //        {
    //            Debug.Log(obj.name + "资源打包成功");
    //        }
    //        else
    //        {
    //            Debug.Log(obj.name + "资源打包失败");
    //        }
    //    }
    //    //刷新编辑器
    //    AssetDatabase.Refresh();
    //}

    //打包多个
    [MenuItem("Custom Editor/Create AssetBundles All (Andorid)")]
    static void CreateAssetBundlesAll_Andorid()
    {
        Caching.CleanCache();

        string path = Application.dataPath + "/AssetBundleAndroid/sound.assetbundle";
        Object[] SelectAsset = Selection.GetFiltered(typeof(object), SelectionMode.DeepAssets);
        foreach (Object obj in SelectAsset)
        {
            Debug.Log("Create AssetBundles name :" + obj.name);
        }
        if (BuildPipeline.BuildAssetBundle(null, SelectAsset, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android))
        {
            AssetDatabase.Refresh();
        }
    }
    //打包多个
    //[MenuItem("Custom Editor/Create AssetBundles All (IOS)")]
    //static void CreateAssetBundlesAll_IOS()
    //{
    //    Caching.CleanCache();

    //    string path = Application.dataPath + "/AssetBundleIOS/sound.assetbundle";
    //    Object[] SelectAsset = Selection.GetFiltered(typeof(object), SelectionMode.DeepAssets);
    //    foreach (Object obj in SelectAsset)
    //    {
    //        Debug.Log("Create AssetBundles name :" + obj.name);
    //    }
    //    if (BuildPipeline.BuildAssetBundle(null, SelectAsset, path, BuildAssetBundleOptions.CollectDependencies, BuildTarget.iOS))
    //    {
    //        AssetDatabase.Refresh();
    //    }
    //}

    //打包场景
    [MenuItem("Custom Editor/Create Scene")]
    static void CreateSceneAll()
    { 
        //清空一下缓存
        Caching.CleanCache();

        string path = Application.dataPath + "/ZJHScene.unity3d";
        string[] levels = { "Assets/scene/ZJH.unity" };
        //打包场景
        BuildPipeline.BuildPlayer(levels, path, BuildTarget.WebPlayer, BuildOptions.BuildAdditionalStreamedScenes);
        AssetDatabase.Refresh();
    }


    public static string AssetbundlePath1
    {
        get { return "Assets" + Path.DirectorySeparatorChar; }
    }

    public static string AssetbundlePathAndroid
    {
        get
        {
            // 打开保存面板，获得用户选择的路径  
            string path = EditorUtility.SaveFilePanel("Save Resource", AssetbundlePath1 + "AssetBundleAndroid" + Path.DirectorySeparatorChar, "New Resource", "assetbundle");
            return path;
        }
    }
    public static string AssetbundlePathIOS
    {
        get
        {
            // 打开保存面板，获得用户选择的路径  
            string path = EditorUtility.SaveFilePanel("Save Resource", AssetbundlePath1 + "AssetBundleIOS" + Path.DirectorySeparatorChar, "New Resource", "assetbundle");
            return path;
        }
    }

}
