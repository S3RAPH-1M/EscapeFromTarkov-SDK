using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using Diz.Skinning;
using EFT.Visual;
using UnityEditorInternal;
using System.Reflection;
using System.Collections.Generic;
using System;

public class GameReadySkinnedObjectCreatorEditor : EditorWindow
{
    private int numItemsToCreate = 1;
    private GameObject[] mainGameObjects;
    private List<GameObject[]> skinGameObjects;
    private List<GameObject[]> lootGameObjects;
    private Preset[] skinPresets;

    private int selectedSkinCount;
    private int selectedLootCount;

    [MenuItem("Groovey GUI Toolbox/Tools/Skinned Object Creator", priority = 1)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadySkinnedObjectCreatorEditor));
    }

    private void OnGUI()
    {
        GUILayout.Label("Enter the number of items you want to create:");
        numItemsToCreate = EditorGUILayout.IntField("Number of Items", numItemsToCreate);

        if (mainGameObjects == null || mainGameObjects.Length != numItemsToCreate)
        {
            mainGameObjects = new GameObject[numItemsToCreate];
            skinGameObjects = new List<GameObject[]>();
            lootGameObjects = new List<GameObject[]>();
            skinPresets = new Preset[numItemsToCreate];

            for (int i = 0; i < numItemsToCreate; i++)
            {
                skinGameObjects.Add(new GameObject[0]);
                lootGameObjects.Add(new GameObject[0]);
            }
        }

        for (int i = 0; i < numItemsToCreate; i++)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Item " + (i + 1));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            mainGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_MAIN", mainGameObjects[i], typeof(GameObject), true);
            skinPresets[i] = (Preset)EditorGUILayout.ObjectField("Skin Preset", skinPresets[i], typeof(Preset), false) as Preset;

            EditorGUILayout.EndVertical();
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Apply Selected Loot Gameobject(s)"))
        {
            SelectLootGameObjects();
        }

        if (selectedLootCount > 0)
        {
            EditorGUILayout.LabelField("Selected Loot Objects: " + selectedLootCount);
        }

        if (GUILayout.Button("Apply Selected Skin Gameobject(s)"))
        {
            SelectSkinGameObjects();
        }

        if (selectedSkinCount > 0)
        {
            EditorGUILayout.LabelField("Selected Skin Objects: " + selectedSkinCount);
        }

        EditorGUI.BeginDisabledGroup(!AllGameObjectsSet());
        if (GUILayout.Button("Create Gameready Skinned Object(s)"))
        {
            CreateGamereadyObjects();
        }
        EditorGUI.EndDisabledGroup();
    }

    private bool AllGameObjectsSet()
    {
        for (int i = 0; i < numItemsToCreate; i++)
        {
            if (mainGameObjects[i] == null || skinPresets[i] == null || skinGameObjects[i].Length == 0 || lootGameObjects[i].Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    private void CreateGamereadyObjects()
    {
        for (int i = 0; i < numItemsToCreate; i++)
        {
            GameObject mainGameObject = mainGameObjects[i];
            GameObject[] skinObjects = skinGameObjects[i];
            GameObject[] lootObjects = lootGameObjects[i];
            Preset skinPreset = skinPresets[i];

            if (PrefabUtility.GetPrefabInstanceStatus(mainGameObject) == PrefabInstanceStatus.Connected)
            {
                PrefabUtility.UnpackPrefabInstance(mainGameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            }

            mainGameObject.AddComponent<DressItem>();
            mainGameObject.AddComponent<PreviewPivot>();

            if (skinPreset != null)
            {
                foreach (GameObject skinObject in skinObjects)
                {
                    Skin skinComponent = skinObject.AddComponent<Skin>();
                    skinPreset.ApplyTo(skinComponent);

                    SkinnedMeshRenderer skinnedMeshRenderer = skinObject.GetComponent<SkinnedMeshRenderer>();
                    if (skinnedMeshRenderer != null)
                    {
                        FieldInfo rendererField = typeof(Skin).GetField("_skinnedMeshRenderer", BindingFlags.NonPublic | BindingFlags.Instance);
                        rendererField.SetValue(skinComponent, skinnedMeshRenderer);
                    }
                    else
                    {
                        Debug.LogError("SkinnedMeshRenderer not found on the Skin GameObject.");
                    }
                }
            }

            GameObject loot = new GameObject("Loot");
            GameObject skin = new GameObject("Skin");
            loot.transform.SetParent(mainGameObject.transform);
            skin.transform.SetParent(mainGameObject.transform);

            SkinDress skinDressComponent = skin.AddComponent<SkinDress>();

            FieldInfo lodsField = typeof(SkinDress).GetField("_lods", BindingFlags.NonPublic | BindingFlags.Instance);
            AbstractSkin[] lodsArray = new AbstractSkin[skinObjects.Length];
            for (int j = 0; j < skinObjects.Length; j++)
            {
                lodsArray[j] = skinObjects[j].GetComponent<AbstractSkin>();
            }
            lodsField.SetValue(skinDressComponent, lodsArray);

            FieldInfo renderersField = typeof(SkinDress).GetField("Renderers", BindingFlags.NonPublic | BindingFlags.Instance);
            Renderer[] renderersArray = new Renderer[skinObjects.Length];
            for (int j = 0; j < skinObjects.Length; j++)
            {
                renderersArray[j] = skinObjects[j].GetComponent<Renderer>();
            }
            renderersField.SetValue(skinDressComponent, renderersArray);

            foreach (GameObject skinObject in skinObjects)
            {
                skinObject.transform.SetParent(skin.transform);
            }

            foreach (GameObject lootObject in lootObjects)
            {
                lootObject.transform.SetParent(loot.transform);

                MeshCollider meshCollider = lootObject.AddComponent<MeshCollider>();
                meshCollider.convex = true;
            }

            DressItem dressItemComponent = mainGameObject.GetComponent<DressItem>();
            dressItemComponent.LootPrefab = loot;
            dressItemComponent.DressPrefab = skin;

            mainGameObjects[i] = null;
            skinGameObjects[i] = null;
            lootGameObjects[i] = null;
        }

        Repaint();

        EditorUtility.DisplayDialog("GameReady Skinned Objects Created", "The GameReady Skinned objects have been created successfully!", "OK");
    }

    private void SelectSkinGameObjects()
    {
        List<GameObject> selectedObjects = new List<GameObject>(Selection.gameObjects);
        if (selectedObjects.Count > 0)
        {
            // Update the skinGameObjects list for all items being created
            for (int i = 0; i < numItemsToCreate; i++)
            {
                skinGameObjects[i] = selectedObjects.ToArray();
            }

            selectedSkinCount = selectedObjects.Count;
        }
    }

    private void SelectLootGameObjects()
    {
        List<GameObject> selectedObjects = new List<GameObject>(Selection.gameObjects);
        if (selectedObjects.Count > 0)
        {
            // Update the lootGameObjects list for all items being created
            for (int i = 0; i < numItemsToCreate; i++)
            {
                lootGameObjects[i] = selectedObjects.ToArray();
            }

            selectedLootCount = selectedObjects.Count;
        }
    }
}
