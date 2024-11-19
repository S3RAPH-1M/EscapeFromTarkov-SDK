using UnityEngine;
using System.IO;

public class AssetBundleLoader : MonoBehaviour
{
    private string bundleFolderPath;
    [SerializeField]
    private bool UseSmapDecal;

    void Start()
    {
        bundleFolderPath = Path.Combine(Application.dataPath + "/Tools/Unity Bundle Loader/Loaded Bundles");
        LoadAssetBundles();
    }
    void LoadAssetBundles()
    {
        if (!Directory.Exists(bundleFolderPath))
        {
            Debug.LogError("Bundle folder not found at path: " + bundleFolderPath);
            return;
        }

        string[] bundlePaths = Directory.GetFiles(bundleFolderPath, "*.bundle");
        foreach (string bundlePath in bundlePaths)
        {
            LoadAssetBundle(bundlePath);
        }
    }
    void LoadAssetBundle(string path)
    {
        path = path.Replace("\\", "/");
        AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
        if (assetBundle == null)
        {
            Debug.LogError("Failed to load asset bundle at path: " + path);
            return;
        }
        Object[] assets = assetBundle.LoadAllAssets();

        foreach (Object asset in assets)
        {
            if (asset is GameObject)
            {
                GameObject instantiatedObject = Instantiate((GameObject)asset);

                Renderer[] renderers = instantiatedObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
                    {
                        foreach (Material m in renderer.materials)
                        {
                            if(UseSmapDecal)
                            {
                                m.shader = Shader.Find("p0/Reflective/Bumped Specular SMap_Decal");
                            }
                            else
                            {
                                m.shader = Shader.Find("p0/Reflective/Bumped Specular SMap");
                            }
                        }
                    }
                }
            }
        }
        assetBundle.Unload(false);
    }
}
