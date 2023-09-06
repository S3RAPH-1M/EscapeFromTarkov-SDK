using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using Diz.Skinning;
using EFT.Visual;
using UnityEditorInternal;
using System.Reflection;

public class GameReadySkinnedObjectCreatorEditor : EditorWindow
{
    private int numItemsToCreate = 1;
    private GameObject[] mainGameObjects;
    private GameObject[] skinGameObjects;
    private GameObject[] lootGameObjects;
    private Preset[] skinPresets;

    [MenuItem("Custom/Game Ready Object Creator/Skinned Object Creator")]
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
            skinGameObjects = new GameObject[numItemsToCreate];
            lootGameObjects = new GameObject[numItemsToCreate];
            skinPresets = new Preset[numItemsToCreate];
        }

        for (int i = 0; i < numItemsToCreate; i++)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Item " + (i + 1));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            mainGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_MAIN", mainGameObjects[i], typeof(GameObject), true);
            skinGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_SKIN", skinGameObjects[i], typeof(GameObject), true);
            lootGameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject_LOOT", lootGameObjects[i], typeof(GameObject), true);

            EditorGUILayout.LabelField("Select a Skin Preset:");
            skinPresets[i] = EditorGUILayout.ObjectField("Skin Preset", skinPresets[i], typeof(Preset), false) as Preset;

            EditorGUILayout.EndVertical();
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
            if (mainGameObjects[i] == null || skinGameObjects[i] == null || lootGameObjects[i] == null)
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
            GameObject skinGameObject = skinGameObjects[i];
            GameObject lootGameObject = lootGameObjects[i];
            Preset skinPreset = skinPresets[i];

            // Your existing CreateGamereadyObject() logic here using the current item's objects and preset

            // Example: Unpack the mainGameObject prefab if it is a prefab
            if (PrefabUtility.GetPrefabInstanceStatus(mainGameObject) == PrefabInstanceStatus.Connected)
            {
                PrefabUtility.UnpackPrefabInstance(mainGameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            }

            // Add "Dress Item" and "Preview Pivot" scripts to the main_gameobject
            mainGameObject.AddComponent<DressItem>();
            mainGameObject.AddComponent<PreviewPivot>();

            // Add "Skin" script to skin_gameobject
            Skin skinComponent = skinGameObject.AddComponent<Skin>();

            // Apply the selected preset to the Skin component if a valid preset is selected
            if (skinPreset != null)
            {
                skinPreset.ApplyTo(skinComponent);
            }

            // Set the SkinnedMeshRenderer for the Skin component using reflection
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

            // Create two new gameobjects "Loot" and "Skin" and make them children of main_gameobject
            GameObject loot = new GameObject("Loot");
            GameObject skin = new GameObject("Skin");
            loot.transform.SetParent(mainGameObject.transform);
            skin.transform.SetParent(mainGameObject.transform);

            // Add "Skin Dress" to the newly created "Skin" gameobject
            SkinDress skinDressComponent = skin.AddComponent<SkinDress>();

            // Set the LOD levels to 1 and assign the skinGameObject to Element 0 of the _lods array using reflection
            FieldInfo lodsField = typeof(SkinDress).GetField("_lods", BindingFlags.NonPublic | BindingFlags.Instance);
            AbstractSkin[] lodsArray = new AbstractSkin[1];
            lodsArray[0] = skinGameObject.GetComponent<AbstractSkin>();
            lodsField.SetValue(skinDressComponent, lodsArray);

            // Set the Renderers to an array containing the skinGameObject's renderer using reflection
            FieldInfo renderersField = typeof(SkinDress).GetField("Renderers", BindingFlags.NonPublic | BindingFlags.Instance);
            Renderer[] renderersArray = new Renderer[1];
            renderersArray[0] = skinGameObject.GetComponent<Renderer>();
            renderersField.SetValue(skinDressComponent, renderersArray);

            // Move the skin_gameobject to be a child of our new "Skin" gameobject
            skinGameObject.transform.SetParent(skin.transform);

            // Move the loot_gameobject to be a child of our new "Loot" gameobject
            lootGameObject.transform.SetParent(loot.transform);

            // Add Mesh Collider with "Convex" option ticked to loot_gameobject
            MeshCollider meshCollider = lootGameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;

            // Assign the "Loot" and "Skin" gameobjects to LootPrefab and DressPrefab in DressItem script
            DressItem dressItemComponent = mainGameObject.GetComponent<DressItem>();
            dressItemComponent.LootPrefab = loot;
            dressItemComponent.DressPrefab = skin;

            // Reset the references to the gameobjects
            mainGameObjects[i] = null;
            skinGameObjects[i] = null;
            lootGameObjects[i] = null;
        }

        // Repaint the window to update the GUI
        Repaint();

        // Notify the user that the process is complete
        EditorUtility.DisplayDialog("GameReady Skinned Objects Created", "The GameReady Skinned objects have been created successfully!", "OK");
    }
}
