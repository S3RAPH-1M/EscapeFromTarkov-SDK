using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AssetBundleBrowser.AssetBundleDataSource
{
    internal class AssetDatabaseABDataSource : ABDataSource
    {
        public static List<ABDataSource> CreateDataSources()
        {
            var op = new AssetDatabaseABDataSource();
            var retList = new List<ABDataSource>();
            retList.Add(op);
            return retList;
        }

        public string Name => "Default";
        public string ProviderName => "Built-in";

        public string[] GetAssetPathsFromAssetBundle (string assetBundleName) {
            return AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName);
        }

        public string GetAssetBundleName(string assetPath) {
            AssetImporter importer = AssetImporter.GetAtPath(assetPath);
            if (importer == null) {
                return string.Empty;
            }
            string bundleName = importer.assetBundleName;
            if (importer.assetBundleVariant.Length > 0) {
                bundleName = bundleName + "." + importer.assetBundleVariant;
            }
            return bundleName;
        }

        public string GetImplicitAssetBundleName(string assetPath) {
            return AssetDatabase.GetImplicitAssetBundleName (assetPath);
        }

        public string[] GetAllAssetBundleNames() {
            return AssetDatabase.GetAllAssetBundleNames ();
        }

        public bool IsReadOnly() {
            return false;
        }

        public void SetAssetBundleNameAndVariant (string assetPath, string bundleName, string variantName) {
            AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant(bundleName, variantName);
        }

        public void RemoveUnusedAssetBundleNames() {
            AssetDatabase.RemoveUnusedAssetBundleNames ();
        }

        public bool CanSpecifyBuildTarget => true;
        public bool CanSpecifyBuildOutputDirectory => true;
        public bool CanSpecifyBuildOptions => true;

        public bool BuildAssetBundles (ABBuildInfo info) {
            if(info == null)
            {
                Debug.Log("Error in build");
                return false;
            }

            AssetBundleManifest buildManifest =
	            BuildPipeline.BuildAssetBundles(info.outputDirectory, info.options, info.buildTarget);
            if (buildManifest == null)
            {
                Debug.Log("Error in build");
                return false;
            }

            foreach(string assetBundleName in buildManifest.GetAllAssetBundles())
            {
	            info.onBuild?.Invoke(assetBundleName);
            }
            
            return true;
        }
    }
}
