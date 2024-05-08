using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using Diz.Skinning;
using EFT.Visual;
using UnityEditorInternal;
using System.Reflection;

public class GameReadyCharacterArmsCreatorEditor : EditorWindow
{
    private int numItemsToCreate = 1;
    private GameObject[] mainGameObjects;
    private GameObject[] skinGameObjects;
    private Preset[] skinPresets;

    [MenuItem("Groovey GUI Toolbox/Tools/First Person Character Arms Creator", priority = 4)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadyCharacterArmsCreatorEditor));
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
        if (GUILayout.Button("Create Game Ready Character Arms"))
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

            HotObject hotObjectComponent = skinGameObject.AddComponent<HotObject>();
            skinGameObject.AddComponent<RainCondensator>();

            hotObjectComponent.Temperature = new Vector3(0.7f, 1f, 4f);

            skinGameObject.transform.SetParent(mainGameObject.transform);

            mainGameObjects[i] = null;
            skinGameObjects[i] = null;
        }

        Repaint();

        EditorUtility.DisplayDialog("GameReady Character Arms Created", "The GameReady Character Arms have been created successfully!", "OK");
    }
}
