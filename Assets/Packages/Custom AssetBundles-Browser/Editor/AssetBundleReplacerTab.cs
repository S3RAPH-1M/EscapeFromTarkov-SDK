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
        [SerializeField] private DictionaryData data;
        private Dictionary<AssetTypeValue, long> _fieldsToChange;
        private long _key;
        private long _value;
        private bool _logging;
        private Rect _position;
        private Vector2 _scrollPosition;

        internal void OnEnable(Rect pos)
        {
            data = GetDataFromFile();
            _position = pos;
            _fieldsToChange = new Dictionary<AssetTypeValue, long>();
        }

        internal void OnGUI(Rect pos)
        {
            _position = new Rect(pos.position, pos.size);

            OnGUIEditor();
        }

        private void OnGUIEditor()
        {
            var titleStyle = new GUIStyle(EditorStyles.boldLabel) {alignment = TextAnchor.MiddleCenter, fontSize = 16};
            _logging = GUI.Toggle(new Rect(17, 5, 15, 15), _logging, new GUIContent("", "Enable logging"));
            GUILayout.BeginArea(_position, titleStyle);

            EditorGUILayout.BeginHorizontal();
            DrawGUIField("SDK PathID", ref _key, titleStyle);
            GUILayout.Label("Made by SamSWAT", new GUIStyle(titleStyle){margin = new RectOffset(0,0,15,0)});
            DrawGUIField("EFT PathID", ref _value, titleStyle);
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(5f);
            if (GUILayout.Button("ADD ENTRY"))
            {
                if (data.sdk.Contains(_key))
                {
                    Debug.LogError("This SDK PathID is already defined");
                    return;
                }

                data.Add(_key, _value);
            }

            if (GUILayout.Button("CLEAR EVERYTHING"))
            {
                data.Clear();
            }

            if (GUILayout.Button("SAVE DATA TO FILE"))
            {
                WriteDataToFile();
            }

            if (GUILayout.Button("GET DATA FROM FILE"))
            {
                data = GetDataFromFile();
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
            for (var i = 0; i < data.sdk.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var key = EditorGUILayout.LongField(data.sdk[i]);
                if (!EditorGUI.EndChangeCheck()) continue;

                if (data.sdk.Contains(key))
                {
                    Debug.LogError($"{key} is already defined in SDK PathIDs");
                    break;
                }

                data.sdk[i] = key;
            }

            GUILayout.EndVertical();
        }

        private void DrawValues()
        {
            GUILayout.BeginVertical();
            for (var i = 0; i < data.eft.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var value = EditorGUILayout.LongField(data.eft[i]);
                if (!EditorGUI.EndChangeCheck()) continue;
                data.eft[i] = value;
            }

            GUILayout.EndVertical();
        }

        private void DrawDeleteButtons()
        {
            GUILayout.BeginVertical(GUILayout.MaxWidth(20f));
            for (var i = 0; i < data.sdk.Count; i++)
            {
                if (!GUILayout.Button(new GUIContent("x", "Remove item"))) continue;
                data.RemoveAt(i);
            }

            GUILayout.EndVertical();
        }

        private void WriteDataToFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Assets/Packages/Custom AssetBundles-Browser/data.json";
            using (var streamWriter = new StreamWriter(path))
            {
                var json = JsonUtility.ToJson(data, true);
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
                    var json = streamReader.ReadToEnd();
                    var data = JsonUtility.FromJson<DictionaryData>(json);

                    if (!data.SuitableForDict)
                    {
                        throw new Exception("Json is faulty");
                    }

                    return data;
                }
            }
            catch
            {
                Debug.LogError($"Some error occured while reading data at path: {path}, temporary empty file will be created.");
                /*using (var streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write("{}");
                }*/

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
            var assetList = assetsFile.table.assetFileInfo;

            var replaced = TryReplaceFields(assetList, am, assetsFile, replacers);
            if (!replaced)
            {
                Debug.Log($"skipping {bundle.name} as no ids were found to replace");
                am.UnloadAll();
                return;
            }

            WriteChangesFromMemory(assetsFile, replacers, path, bundle);
            am.UnloadAll();
            CompressBundle(am, options, path);
        }

        private bool TryReplaceFields(AssetFileInfoEx[] assetList, AssetsManager am, AssetsFileInstance assetsFile,
            List<AssetsReplacer> replacers)
        {
            var counter = 0;
            foreach (var asset in assetList)
            {
                var typeInstance = am.GetTypeInstance(assetsFile, asset);
                var baseField = typeInstance.GetBaseField();

                RecursiveSearch(baseField);

                if (_fieldsToChange.Count == 0) continue;

                foreach (var kvp in _fieldsToChange)
                {
                    var fieldValue = kvp.Key;
                    var pathID = kvp.Value;

                    fieldValue.Set(pathID);
                }

                var newBytes = baseField.WriteToByteArray();
                var replacer = new AssetsReplacerFromMemory(0, asset.index, (int) asset.curFileType,
                    AssetHelper.GetScriptIndex(assetsFile.file, asset), newBytes);
                replacers.Add(replacer);
                counter++;
                _fieldsToChange.Clear();
            }

            return counter > 0;
        }
        
        private void RecursiveSearch(AssetTypeValueField field)
        {
            foreach (var child in field.children)
            {
                if (child.templateField.hasValue && !child.templateField.isArray) 
                    continue;
                if (child.templateField.isArray && child.templateField.children[1].valueType != EnumValueTypes.ValueType_None)
                    continue;

                var typeName = child.templateField.type;

                if (typeName.StartsWith("PPtr<") && typeName.EndsWith(">") && child.childrenCount == 2)
                {
                    var fieldValue = child.Get("m_PathID").GetValue();
                    var pathId = fieldValue.AsInt64();

                    if (pathId == 0) continue;

                    if (!data.Lookup.TryGetValue(pathId, out var eftPathID)) continue;

                    if (_fieldsToChange.ContainsKey(fieldValue)) continue;

                    _fieldsToChange.Add(fieldValue, eftPathID);
                    if (_logging)
                        Debug.Log($"Found matching pathID: {pathId} asset {typeName}{child.GetName()}");
                }
                else
                {
                    RecursiveSearch(child);
                }
            }
        }

        private static void WriteChangesFromMemory(AssetsFileInstance assetsFile, List<AssetsReplacer> replacers, 
            string path, BundleFileInstance bundle)
        {
            byte[] newAssetData;
            using (var memoryStream = new MemoryStream())
            using (var writer = new AssetsFileWriter(memoryStream))
            {
                assetsFile.file.Write(writer, 0, replacers);
                newAssetData = memoryStream.ToArray();
            }

            var bunRepl = new BundleReplacerFromMemory(assetsFile.name, null, true, newAssetData, -1);

            //var modPath = path + "_mod";
            using (var writer = new AssetsFileWriter(path))
            {
                bundle.file.Write(writer, new List<BundleReplacer> {bunRepl});
            }
            
            //File.Delete(path);
            //File.Move(modPath, path);
            
            // !!!if sharing violation exception will come back, uncomment things above!!!
        }

        private void CompressBundle(AssetsManager am, BuildAssetBundleOptions options, string path)
        {
            var bundle = am.LoadBundleFile(path);
            switch (options)
            {
                case BuildAssetBundleOptions.None:
                {
                    var modPath = path + "_c";
                    using (var writer = new AssetsFileWriter(modPath))
                    {
                        bundle.file.Pack(bundle.file.reader, writer, AssetBundleCompressionType.LZMA);
                    }
                    am.UnloadAll();
                    File.Delete(path);
                    File.Move(modPath, path);
                    break;
                }
                case BuildAssetBundleOptions.ChunkBasedCompression:
                {
                    var modPath = path + "_c";
                    using (var writer = new AssetsFileWriter(modPath))
                    {
                        bundle.file.Pack(bundle.file.reader, writer, AssetBundleCompressionType.LZ4);
                    }
                    am.UnloadAll();
                    File.Delete(path);
                    File.Move(modPath, path);
                    break;
                }
            }
            am.UnloadAll();
        }
    }

    [Serializable]
    internal class DictionaryData : ISerializationCallbackReceiver 
    {
        public DictionaryData()
        {
            sdk = new List<long>();
            eft = new List<long>();
            Lookup = new Dictionary<long, long>();
        }
        
        public List<long> sdk;
        public List<long> eft;
        public Dictionary<long, long> Lookup;
        
        public bool SuitableForDict => sdk.Count == eft.Count;
        
        public void Add(long key, long value)
        {
            sdk.Add(key);
            eft.Add(value);
            Lookup.Add(key, value);
        }

        public void Clear()
        {
            sdk.Clear();
            eft.Clear();
            Lookup.Clear();
        }

        public void RemoveAt(int i)
        {
            var keyToDelete = sdk[i];
            sdk.RemoveAt(i);
            eft.RemoveAt(i);
            Lookup.Remove(keyToDelete);
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            Lookup = new Dictionary<long, long>();
            for (int i = 0; i != Math.Min(sdk.Count, eft.Count); i++)
            {
                Lookup.Add(sdk[i], eft[i]);
            }
        }
    }
}