using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using Diz.Skinning;
using EFT.Visual;
using UnityEditorInternal;
using System.Reflection;
using System.Collections.Generic;

public class GameReadySkinnedObjectCreatorEditor : EditorWindow
{
    private int numItemsToCreate = 1;
    private GameObject[] mainGameObjects;
    private GameObject[][] skinGameObjects;
    private GameObject[][] lootGameObjects;
    private Preset[] skinPresets;

    private GameObject[] selectedLootObjects;
    private GameObject[] selectedSkinObjects;

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
            skinGameObjects = new GameObject[numItemsToCreate][];
            lootGameObjects = new GameObject[numItemsToCreate][];
            skinPresets = new Preset[numItemsToCreate];
        }

        for (int i = 0; i < numItemsToCreate; i++)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Item " + (i + 1));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            mainGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_MAIN", mainGameObjects[i], typeof(GameObject), true);
            skinPresets[i] = (Preset)EditorGUILayout.ObjectField("Skin Preset", skinPresets[i], typeof(Preset), false) as Preset;

            int numSkinObjects = EditorGUILayout.IntField("Number of Skin Objects", skinGameObjects[i] != null ? skinGameObjects[i].Length : 1);
            int numLootObjects = EditorGUILayout.IntField("Number of Loot Objects", lootGameObjects[i] != null ? lootGameObjects[i].Length : 1);

            if (skinGameObjects[i] == null || skinGameObjects[i].Length != numSkinObjects)
                skinGameObjects[i] = new GameObject[numSkinObjects];

            if (lootGameObjects[i] == null || lootGameObjects[i].Length != numLootObjects)
                lootGameObjects[i] = new GameObject[numLootObjects];

            for (int j = 0; j < numSkinObjects; j++)
            {
                skinGameObjects[i][j] = (GameObject)EditorGUILayout.ObjectField("Skin Object " + (j + 1), skinGameObjects[i][j], typeof(GameObject), true);
            }

            for (int j = 0; j < numLootObjects; j++)
            {
                lootGameObjects[i][j] = (GameObject)EditorGUILayout.ObjectField("Loot Object " + (j + 1), lootGameObjects[i][j], typeof(GameObject), true);
            }

            EditorGUILayout.EndVertical();
        }

        if (GUILayout.Button("Apply Selected Loot Gameobject(s)"))
        {
            selectedLootObjects = Selection.gameObjects;
            if (selectedLootObjects.Length > 0)
            {
                for (int i = 0; i < numItemsToCreate; i++)
                {
                    if (lootGameObjects[i] == null || lootGameObjects[i].Length != selectedLootObjects.Length)
                    {
                        lootGameObjects[i] = new GameObject[selectedLootObjects.Length];
                    }
                    for (int j = 0; j < selectedLootObjects.Length; j++)
                    {
                        lootGameObjects[i][j] = selectedLootObjects[j];
                    }
                }
            }
        }

        if (GUILayout.Button("Apply Selected Skin Gameobject(s)"))
        {
            selectedSkinObjects = Selection.gameObjects;
            if (selectedSkinObjects.Length > 0)
            {
                for (int i = 0; i < numItemsToCreate; i++)
                {
                    if (skinGameObjects[i] == null || skinGameObjects[i].Length != selectedSkinObjects.Length)
                    {
                        skinGameObjects[i] = new GameObject[selectedSkinObjects.Length];
                    }
                    for (int j = 0; j < selectedSkinObjects.Length; j++)
                    {
                        skinGameObjects[i][j] = selectedSkinObjects[j];
                    }
                }
            }
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
            if (mainGameObjects[i] == null || skinPresets[i] == null)
            {
                return false;
            }

            for (int j = 0; j < skinGameObjects[i].Length; j++)
            {
                if (skinGameObjects[i][j] == null)
                {
                    return false;
                }
            }

            for (int j = 0; j < lootGameObjects[i].Length; j++)
            {
                if (lootGameObjects[i][j] == null)
                {
                    return false;
                }
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




}
