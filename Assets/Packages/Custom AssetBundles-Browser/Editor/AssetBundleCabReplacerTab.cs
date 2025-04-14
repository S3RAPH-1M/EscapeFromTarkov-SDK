using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AssetsTools.NET;
using AssetsTools.NET.Extra;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace AssetBundleBrowser.Custom
{
    [Serializable]
    public class AssetBundleCabReplacerTab
    {
        [SerializeField] private CabDictionaryData data;
        private string _key;
        private string _value;
        private bool _logging;
        private Rect _position;
        private Vector2 _scrollPosition;

        internal void OnEnable(Rect pos)
        {
            data = GetDataFromFile();
            _position = pos;
        }

        internal void OnGUI(Rect pos)
        {
            _position = new Rect(pos.position, pos.size);

            OnGUIEditor();
        }

        private void OnGUIEditor()
        {
            var titleStyle = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.MiddleCenter, fontSize = 16 };
            _logging = GUI.Toggle(new Rect(17, 5, 15, 15), _logging, new GUIContent("", "Enable logging"));
            GUILayout.BeginArea(_position, titleStyle);

            EditorGUILayout.BeginHorizontal();
            DrawGUIField("SDK CabID", ref _key, titleStyle);
            DrawGUIField("EFT CabID", ref _value, titleStyle);
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(5f);
            if (GUILayout.Button("ADD ENTRY"))
            {
                if (data.sdk.Contains(_key))
                {
                    Debug.LogError("This SDK CabID is already defined");
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

            if (GUILayout.Button("SORT AND SAVE"))
            {
                data.SortAndSaveData();
            }

            //==\\ VISUAL DICTIONARY REPRESENTATION //==\\
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            GUILayout.Space(5f);
            GUILayout.BeginHorizontal();
            DrawKeys();
            DrawButtons();
            DrawValues();
            DrawDescriptions();
            GUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private void DrawGUIField(string label, ref string field, GUIStyle titleStyle)
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Label(label, titleStyle);
            GUILayout.Space(5f);
            field = EditorGUILayout.TextField(field);
            EditorGUILayout.EndVertical();
        }

        private void DrawKeys()
        {
            GUILayout.BeginVertical(GUILayout.Width(_position.width * 0.25f));
            for (var i = 0; i < data.sdk.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var key = EditorGUILayout.TextField(data.sdk[i]);
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
            GUILayout.BeginVertical(GUILayout.Width(_position.width * 0.25f));
            for (var i = 0; i < data.eft.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var value = EditorGUILayout.TextField(data.eft[i]);
                if (!EditorGUI.EndChangeCheck()) continue;
                data.eft[i] = value;
            }

            GUILayout.EndVertical();
        }

        private void DrawButtons()
        {
            GUILayout.BeginVertical(GUILayout.MaxWidth(25f));
            for (var i = 0; i < data.sdk.Count; i++)
            {
                if (!GUILayout.Button(new GUIContent("∧", "Move item up"))) continue;
                var newIndex = i - 1;
                if (newIndex < 0) return;
                data.Move(i, newIndex);
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical(GUILayout.MaxWidth(25f));
            for (var i = 0; i < data.sdk.Count; i++)
            {
                if (!GUILayout.Button(new GUIContent("x", "Remove item"))) continue;
                data.RemoveAt(i);
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical(GUILayout.MaxWidth(25f));
            for (var i = 0; i < data.sdk.Count; i++)
            {
                if (!GUILayout.Button(new GUIContent("∨", "Move item down"))) continue;
                var newIndex = i + 1;
                if (newIndex >= data.sdk.Count) return;
                data.Move(i, newIndex);
            }
            GUILayout.EndVertical();
        }

        private void DrawDescriptions()
        {
            GUILayout.BeginVertical();
            for (var i = 0; i < data.sdk.Count; i++)
            {
                GUILayout.Space(1f);
                EditorGUI.BeginChangeCheck();
                var value = EditorGUILayout.TextField(data.descriptionList[i]);
                if (!EditorGUI.EndChangeCheck()) continue;
                data.descriptionList[i] = value;
            }

            GUILayout.EndVertical();
        }

        private void WriteDataToFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Assets/Packages/Custom AssetBundles-Browser/cab_data.json";
            using var streamWriter = new StreamWriter(path);
            string json = JsonUtility.ToJson(data, true);
            streamWriter.Write(json);
        }

        private CabDictionaryData GetDataFromFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Assets/Packages/Custom AssetBundles-Browser/cab_data.json";
            try
            {
                using var streamReader = new StreamReader(path);
                string json = streamReader.ReadToEnd();
                var cabDictionaryData = JsonUtility.FromJson<CabDictionaryData>(json);

                if (cabDictionaryData == null || !cabDictionaryData.SuitableForDict)
                {
                    throw new Exception("Json is faulty");
                }

                return cabDictionaryData;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Some error occured while reading data at path: {path}, temporary empty file will be created. Exception: {ex}");
                /*using (var streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write("{}");
                }*/

                return new CabDictionaryData();
            }
        }

        public void ReplaceCabIDs(string path)
        {
            byte[] pattern = new byte[] { 0x43, 0x41, 0x42, 0x2D };
            var fileBytes = File.ReadAllBytes(path);
            ReplaceIds(pattern, fileBytes, data.Lookup);
            File.WriteAllBytes(path, fileBytes);
        }

        void ReplaceIds(byte[] pattern, byte[] bytes, Dictionary<string, string> mappings)
        {
            //Debug.Log($"There are {bytes.Length} Bytes!!!");
            //Debug.Log($"There are {mappings.Count} mappings");
            var buffer = new byte[32];

            for (var i = 0; i < bytes.Length; i++)
            {
                var match = true;
                for (var j = 0; j < pattern.Length; j++)
                {
                    var thisIndex = i + j;
                    if (thisIndex < bytes.Length)
                    {
                        if (bytes[thisIndex] != pattern[j])
                        {
                            match = false;
                        }
                    }
                }

                if (match)
                {
                    var offset = i + pattern.Length;
                    Array.Copy(bytes, offset, buffer, 0, buffer.Length);
                    var id = Encoding.UTF8.GetString(buffer);
                    if (mappings.TryGetValue(id, out var newId))
                    {
                        var newIdBytes = Encoding.UTF8.GetBytes(newId);
                        //Debug.Log($"Replaced {id} with {newId}");
                        Array.Copy(newIdBytes, 0, bytes, offset, 32);
                    }
                    else
                    {
                        //Debug.Log($"Failed to get mapping for id: {id}");
                    }
                }
            }
        }
    }

    [Serializable]
    internal class CabDictionaryData : ISerializationCallbackReceiver 
    {
        public CabDictionaryData()
        {
            sdk = new List<string>();
            eft = new List<string>();
            descriptionList = new List<string>();
            Lookup = new Dictionary<string, string>();
        }
        
        public List<string> sdk;
        public List<string> eft;
        public List<string> descriptionList;
        public Dictionary<string, string> Lookup;
        
        public bool SuitableForDict => sdk.Count == eft.Count;
        

        public void Add(string key, string value, string description = "")
        {
            sdk.Add(key);
            eft.Add(value);
            descriptionList.Add(description);
            Lookup.Add(key, value);
        }

        public void Clear()
        {
            sdk.Clear();
            eft.Clear();
            descriptionList.Clear();
            Lookup.Clear();
        }

        public void RemoveAt(int i)
        {
            var keyToDelete = sdk[i];
            sdk.RemoveAt(i);
            eft.RemoveAt(i);
            descriptionList.RemoveAt(i);
            Lookup.Remove(keyToDelete);
        }
        
        public void Move(int oldIndex, int newIndex)
        {
            var key = sdk[oldIndex];
            var value = eft[oldIndex];
            var desc = descriptionList[oldIndex];
            
            RemoveAt(oldIndex);

            //if (newIndex > oldIndex) newIndex--; 

            sdk.Insert(newIndex, key);
            eft.Insert(newIndex, value);
            descriptionList.Insert(newIndex, desc);
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            Lookup = new Dictionary<string, string>();
            for (int i = 0; i != Math.Min(sdk.Count, eft.Count); i++)
            {
                Lookup.Add(sdk[i], eft[i]);
            }
            FixMissingDescriptions();
        }

        private void FixMissingDescriptions()
        {
            if (sdk.Count == descriptionList.Count) return;
            
            foreach (var _ in sdk)
            {
                descriptionList.Add("");
            }
        }

        public void SortAndSaveData()
        {
            var sortedIndices = GetSortedIndices(descriptionList, true); // true for ascending (alphabetical order)

            SortListsByIndices(sortedIndices);
            WriteDataToFile();
        }

        private List<int> GetSortedIndices(List<string> list, bool ascending)
        {
            var sortedIndices = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                sortedIndices.Add(i);
            }

            sortedIndices.Sort((a, b) => ascending ? string.Compare(list[a], list[b]) : string.Compare(list[b], list[a]));
            return sortedIndices;
        }

        private void SortListsByIndices(List<int> sortedIndices)
        {
            var sortedSdk = new List<string>();
            var sortedEft = new List<string>();
            var sortedDescriptions = new List<string>();

            foreach (var index in sortedIndices)
            {
                sortedSdk.Add(sdk[index]);
                sortedEft.Add(eft[index]);
                sortedDescriptions.Add(descriptionList[index]);
            }

            sdk = sortedSdk;
            eft = sortedEft;
            descriptionList = sortedDescriptions;

            Lookup.Clear();
            for (int i = 0; i < sdk.Count; i++)
            {
                Lookup[sdk[i]] = eft[i];
            }
        }

        private void WriteDataToFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Assets/Packages/Custom AssetBundles-Browser/cab_data.json";
            using (var streamWriter = new StreamWriter(path))
            {
                var json = JsonUtility.ToJson(this, true);
                streamWriter.Write(json);
            }
        }

    }
}
