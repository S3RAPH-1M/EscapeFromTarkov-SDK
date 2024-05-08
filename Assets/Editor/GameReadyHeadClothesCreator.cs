using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using Diz.Skinning;
using EFT.Visual;
using UnityEditorInternal;
using System.Reflection;

public class GameReadyClothingHeadCreatorEditor : EditorWindow
{
    private int numItemsToCreate = 1;
    private GameObject[] mainGameObjects;
    private GameObject[] skinGameObjects;
    private Preset[] skinPresets;

    [MenuItem("Groovey GUI Toolbox/Tools/Clothing and Head Creator", priority = 3)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadyClothingHeadCreatorEditor));
    }

    private void OnGUI()
    {
        GUILayout.Label("Enter the number of items you want to create:");
        numItemsToCreate = EditorGUILayout.IntField("Number of Items", numItemsToCreate);

        if (mainGameObjects == null || mainGameObjects.Length != numItemsToCreate)
        {
            mainGameObjects = new GameObject[numItemsToCreate];
            skinGameObjects = new GameObject[numItemsToCreate];
            skinPresets = new Preset[numItemsToCreate];
        }

        for (int i = 0; i < numItemsToCreate; i++)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Item " + (i + 1));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            mainGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_MAIN", mainGameObjects[i], typeof(GameObject), true);
            skinGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_SKIN", skinGameObjects[i], typeof(GameObject), true);

            EditorGUILayout.LabelField("Select a Skin Preset:");
            skinPresets[i] = EditorGUILayout.ObjectField("Skin Preset", skinPresets[i], typeof(Preset), false) as Preset;

            EditorGUILayout.EndVertical();
        }

        EditorGUI.BeginDisabledGroup(!AllGameObjectsSet());
        if (GUILayout.Button("Create Game Ready Clothes/Head"))
        {
            CreateGameReadyCharacterArms();
        }
        EditorGUI.EndDisabledGroup();
    }

    private bool AllGameObjectsSet()
    {
        for (int i = 0; i < numItemsToCreate; i++)
        {
            if (mainGameObjects[i] == null || skinGameObjects[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    private void CreateGameReadyCharacterArms()
    {
        for (int i = 0; i < numItemsToCreate; i++)
        {
            GameObject mainGameObject = mainGameObjects[i];
            GameObject skinGameObject = skinGameObjects[i];
            Preset skinPreset = skinPresets[i];

            if (PrefabUtility.GetPrefabInstanceStatus(mainGameObject) == PrefabInstanceStatus.Connected)
            {
                PrefabUtility.UnpackPrefabInstance(mainGameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            }

            LoddedSkin loddedSkinComponent = mainGameObject.AddComponent<LoddedSkin>();

            Skin skinComponent = skinGameObject.AddComponent<Skin>();

            if (skinPreset != null)
            {
                skinPreset.ApplyTo(skinComponent);
            }
            else
            {
                Debug.LogError("Skin Preset not set.");
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

            FieldInfo lodsField = typeof(LoddedSkin).GetField("_lods", BindingFlags.NonPublic | BindingFlags.Instance);
            AbstractSkin[] lodsArray = new AbstractSkin[1];
            lodsArray[0] = skinGameObject.GetComponent<AbstractSkin>();
            lodsField.SetValue(loddedSkinComponent, lodsArray);

            skinGameObject.transform.SetParent(mainGameObject.transform);

            mainGameObjects[i] = null;
            skinGameObjects[i] = null;
        }

        Repaint();

        EditorUtility.DisplayDialog("GameReady Clothing/Head Created", "The GameReady Clothes/Head have been created successfully!", "OK");
    }
}
