using System;
using System.Collections.Generic;
using System.IO;
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
        [SerializeField] private DictionaryData idsLookup;
        private Dictionary<long, long> _idsLookupDict;
        private long _key;
        private long _value;
        private Rect _position;
        private Vector2 _scrollPosition;

        internal void OnEnable(Rect pos)
        {
            idsLookup = GetDataFromFile();
            _position = pos;
            _idsLookupDict = ToDictionary(idsLookup);
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
            DrawGUIField("SDK PathID", ref _key, titleStyle);
            DrawGUIField("EFT PathID", ref _value, titleStyle);
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(5f);
            if (GUILayout.Button("ADD ENTRY"))
            {
                if (idsLookup.sdk.Contains(_key))
                {
                    Debug.LogError("This SDK PathID is already defined");
                    return;
                }

                idsLookup.Add(_key, _value);
                _idsLookupDict.Add(_key,_value);
            }
            
            if (GUILayout.Button("CLEAR EVERYTHING"))
            {
                idsLookup.Clear();
                _idsLookupDict.Clear();
            }

            if (GUILayout.Button("SAVE DATA TO FILE"))
            {
                WriteDataToFile();
            }
            
            if (GUILayout.Button("GET DATA FROM FILE"))
            {
                GetDataFromFile();
            }
            
            //==\\ VISUAL DICTIONARY REPRESENTATION //==\\
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            GUILayout.Space(5f);
            GUILayout.BeginHorizontal();
            DrawKeys();
            DrawDeleteButtons();
            DrawValues();
            GUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();
            GUILayout.EndArea();
            
            _idsLookupDict = ToDictionary(idsLookup);
        }
        
        private Dictionary<long, long> ToDictionary(DictionaryData data)
        {
            var dictionary = new Dictionary<long, long>();
            for (int i = 0; i != Math.Min(data.sdk.Count, data.eft.Count); i++)
                dictionary.Add(data.sdk[i], data.eft[i]);
            return dictionary;
        }

        private void DrawGUIField(string label, ref long field, GUIStyle titleStyle)
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Label(label, titleStyle);
            GUILayout.Space(5f);
            field = EditorGUILayout.LongField(field);
            EditorGUILayout.EndVertical();
        }
        
        private void DrawKeys()
        {
            GUILayout.BeginVertical(GUILayout.Width(_position.width * 0.478f));
            for (var i = 0; i < idsLookup.sdk.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var key = EditorGUILayout.LongField(idsLookup.sdk[i]);
                if (!EditorGUI.EndChangeCheck()) continue;

                if (idsLookup.sdk.Contains(key))
                {
                    Debug.LogError($"{key} is already defined in SDK PathIDs");
                    break;
                }
                
                idsLookup.sdk[i] = key;
            }

            GUILayout.EndVertical();
        }
        
        private void DrawValues()
        {
            GUILayout.BeginVertical();
            for (var i = 0; i < idsLookup.eft.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var value = EditorGUILayout.LongField(idsLookup.eft[i]);
                if (!EditorGUI.EndChangeCheck()) continue;
                idsLookup.eft[i] = value;
            }

            GUILayout.EndVertical();
        }

        private void DrawDeleteButtons()
        {
            GUILayout.BeginVertical(GUILayout.MaxWidth(20f));
            for (var i = 0; i < idsLookup.sdk.Count; i++)
            {
                if (!GUILayout.Button(new GUIContent("x", "Remove item"))) continue;
                idsLookup.RemoveAt(i);
            }

            GUILayout.EndVertical();
        }
        
        private void WriteDataToFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Assets/Packages/Custom AssetBundles-Browser/data.json";
            using (var streamWriter = new StreamWriter(path))
            {
                var json = JsonUtility.ToJson(idsLookup, true);
                streamWriter.Write(json);
            }
        }

        private DictionaryData GetDataFromFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Assets/Packages/Custom AssetBundles-Browser/data.json";
            try
            {
                using (var streamReader = new StreamReader(path))
                {
                    var text = streamReader.ReadToEnd();
                    var json = JsonUtility.FromJson<DictionaryData>(text);

                    if (!json.SuitableForDict)
                    {
                        throw new Exception("Json is faulty");
                    }

                    return json;
                }
            }
            catch
            {
                Debug.LogError($"Some error occured while reading data at path: {path}, creating new empty file.");
                using (var streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write("{}");
                }
                return new DictionaryData();
            }
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
    
    [Serializable]
    internal class DictionaryData
    {
        public DictionaryData()
        {
            sdk = new List<long>();
            eft = new List<long>();
        }
        
        public List<long> sdk;
        public List<long> eft;
        
        public bool SuitableForDict => sdk.Count == eft.Count;
        
        public void Add(long key, long value)
        {
            sdk.Add(key);
            eft.Add(value);
        }

        public void Clear()
        {
            sdk.Clear();
            eft.Clear();
        }

        public void RemoveAt(int i)
        {
            sdk.RemoveAt(i);
            eft.RemoveAt(i);
        }
    }
}