using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using Diz.Skinning;
using EFT.Visual;
using UnityEditorInternal;
using System.Reflection;
using System.Collections.Generic;

public class GameReadyClothingHeadCreatorEditor : EditorWindow
{
    private int numItemsToCreate = 1;
    private GameObject[] mainGameObjects;
    private List<GameObject[]> skinGameObjectsList;
    private int[] numSkinsPerItem;
    private Preset globalSkinPreset;
    private Vector2 scrollPosition;

    [MenuItem("Groovey GUI Toolbox/Tools/Clothing and Head Creator", priority = 3)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadyClothingHeadCreatorEditor));
    }

    private void OnEnable()
    {
        // Initialize variables when window is enabled or shown
        mainGameObjects = new GameObject[numItemsToCreate];
        skinGameObjectsList = new List<GameObject[]>(numItemsToCreate);
        numSkinsPerItem = new int[numItemsToCreate];

        for (int i = 0; i < numItemsToCreate; i++)
        {
            skinGameObjectsList.Add(new GameObject[0]);
        }
    }

    private void OnGUI()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        GUILayout.Label("Enter the number of items you want to create:");
        numItemsToCreate = EditorGUILayout.IntField("Number of Items", numItemsToCreate);

        // Adjust arrays/lists when numItemsToCreate changes
        if (mainGameObjects.Length != numItemsToCreate)
        {
            mainGameObjects = new GameObject[numItemsToCreate];
            skinGameObjectsList.Clear();
            numSkinsPerItem = new int[numItemsToCreate];

            for (int i = 0; i < numItemsToCreate; i++)
            {
                skinGameObjectsList.Add(new GameObject[0]);
            }
        }

        GUILayout.Label("Select a Global Skin Preset:");
        globalSkinPreset = EditorGUILayout.ObjectField("Global Skin Preset", globalSkinPreset, typeof(Preset), false) as Preset;

        for (int i = 0; i < numItemsToCreate; i++)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Item " + (i + 1));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            mainGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_MAIN", mainGameObjects[i], typeof(GameObject), true);

            if (GUILayout.Button("Select Skin GameObjects"))
            {
                SelectSkinGameObjects(i);
            }

            int numSkins = skinGameObjectsList[i].Length;
            GUILayout.Label("Number of Skins: " + numSkins);

            EditorGUILayout.EndVertical();
        }

        EditorGUI.BeginDisabledGroup(!AllGameObjectsSet());
        if (GUILayout.Button("Create Game Ready Clothes/Head"))
        {
            CreateGameReadyCharacterClothesHead();
        }
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.EndScrollView();
    }

    private bool AllGameObjectsSet()
    {
        for (int i = 0; i < numItemsToCreate; i++)
        {
            if (mainGameObjects[i] == null || skinGameObjectsList[i] == null || skinGameObjectsList[i].Length == 0)
            {
                return false;
            }
            for (int j = 0; j < skinGameObjectsList[i].Length; j++)
            {
                if (skinGameObjectsList[i][j] == null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void CreateGameReadyCharacterClothesHead()
    {
        for (int i = 0; i < numItemsToCreate; i++)
        {
            GameObject mainGameObject = mainGameObjects[i];
            GameObject[] skinGameObjects = skinGameObjectsList[i];

            if (mainGameObject == null)
            {
                Debug.LogError("Main GameObject is null for item " + (i + 1));
                continue;
            }

            if (PrefabUtility.GetPrefabInstanceStatus(mainGameObject) == PrefabInstanceStatus.Connected)
            {
                PrefabUtility.UnpackPrefabInstance(mainGameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            }

            LoddedSkin loddedSkinComponent = mainGameObject.AddComponent<LoddedSkin>();

            List<AbstractSkin> lodsList = new List<AbstractSkin>();

            for (int j = 0; j < skinGameObjects.Length; j++)
            {
                GameObject skinGameObject = skinGameObjects[j];

                if (skinGameObject == null)
                {
                    Debug.LogWarning("Skipping null skin GameObject for item " + (i + 1));
                    continue;
                }

                Skin skinComponent = skinGameObject.AddComponent<Skin>();

                if (globalSkinPreset != null)
                {
                    globalSkinPreset.ApplyTo(skinComponent);
                }
                else
                {
                    Debug.LogError("Global Skin Preset not set.");
                }

                SkinnedMeshRenderer skinnedMeshRenderer = skinGameObject.GetComponent<SkinnedMeshRenderer>();
                if (skinnedMeshRenderer != null)
                {
                    FieldInfo rendererField = typeof(Skin).GetField("_skinnedMeshRenderer", BindingFlags.NonPublic | BindingFlags.Instance);
                    rendererField.SetValue(skinComponent, skinnedMeshRenderer);
                }
                else
                {
                    Debug.LogError("SkinnedMeshRenderer not found on the Skin GameObject.");
                }

                lodsList.Add(skinGameObject.GetComponent<AbstractSkin>());

                skinGameObject.transform.SetParent(mainGameObject.transform);
            }

            FieldInfo lodsField = typeof(LoddedSkin).GetField("_lods", BindingFlags.NonPublic | BindingFlags.Instance);
            lodsField.SetValue(loddedSkinComponent, lodsList.ToArray());
        }

        // Clear or reset arrays/lists after creation
        for (int i = 0; i < numItemsToCreate; i++)
        {
            mainGameObjects[i] = null;
            skinGameObjectsList[i] = new GameObject[0];
        }

        Repaint();

        EditorUtility.DisplayDialog("GameReady Clothing/Head Created", "The GameReady Clothes/Head have been created successfully!", "OK");
    }

    private void SelectSkinGameObjects(int index)
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        if (selectedGameObjects == null || selectedGameObjects.Length == 0)
        {
            Debug.LogError("No GameObjects selected.");
            return;
        }

        List<GameObject> skinGameObjects = new List<GameObject>();
        foreach (GameObject gameObject in selectedGameObjects)
        {
            if (gameObject != mainGameObjects[index])
            {
                skinGameObjects.Add(gameObject);
            }
        }

        skinGameObjectsList[index] = skinGameObjects.ToArray();
        numSkinsPerItem[index] = skinGameObjects.Count;
    }
}
