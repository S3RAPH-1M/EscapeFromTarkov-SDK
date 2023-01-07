using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssetsTools.NET;
using AssetsTools.NET.Extra;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace AssetBundleBrowser.Custom
{
    [Serializable]
    public class AssetBundleReplacerTab
    {
        private Rect _position;

        internal void OnEnable(Rect pos)
        {
            _position = pos;
        }

        internal void OnGUI(Rect pos)
        {
            _position = new Rect(pos.position, pos.size);

            OnGUIEditor();
        }

        private void OnGUIEditor()
        {
            var titleStyle = new GUIStyle(EditorStyles.boldLabel) {alignment = TextAnchor.MiddleCenter, fontSize = 16};
            GUILayout.BeginArea(_position, titleStyle);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("SOME LABEL", titleStyle);
            EditorGUILayout.LabelField("SOME LABEL #2", titleStyle);
            EditorGUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        public void ReplacePathIDs(string bundleName, string outputDirectory, BuildAssetBundleOptions options)
        {
            var path = $"{Directory.GetCurrentDirectory()}/{outputDirectory}/{bundleName}";
            var replacers = new List<AssetsReplacer>();
            var am = new AssetsManager();

            var bundle = am.LoadBundleFile(path);
            var assetsFile = am.LoadAssetsFileFromBundle(bundle, 0, true);
            var assetList = assetsFile.table.GetAssetsOfType((int) AssetClassID.Material);

            foreach (var asset in assetList)
            {
                var baseField = am.GetTypeInstance(assetsFile, asset).GetBaseField();
                var field = baseField.Get("m_Shader").Get("m_PathID").GetValue();
                field.Set((long)1111111111);
                
                var newBytes = baseField.WriteToByteArray();
                var repl = new AssetsReplacerFromMemory(0, asset.index, (int) asset.curFileType, 0xffff, newBytes);
                replacers.Add(repl);
                Debug.Log($"Made changes in {baseField.GetName()}");
            }

            byte[] newAssetData;
            
            using (var stream = new MemoryStream())
            using (var writer = new AssetsFileWriter(stream))
            {
                assetsFile.file.Write(writer, 0, replacers);
                newAssetData = stream.ToArray();
            }

            var origPath = path;
            path += "_mod";
            using (var writer = new AssetsFileWriter(path))
            {
                var bunRepl = new BundleReplacerFromMemory(assetsFile.name, null, true, newAssetData, -1);
                bundle.file.Write(writer, new List<BundleReplacer> { bunRepl });
            }
            am.UnloadAll(true);
            File.Delete(origPath);
            File.Move(path, origPath);
        }
    }
}