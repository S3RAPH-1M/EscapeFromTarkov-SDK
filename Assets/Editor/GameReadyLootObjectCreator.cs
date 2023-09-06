using UnityEngine;
using UnityEditor;
using EFT.Visual;

public class GameReadyLootItemEditor : EditorWindow
{
    [MenuItem("Custom/Game Ready Object Creator/Create GameReady Loot Object(s)")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadyLootItemEditor));
    }

    private void OnGUI()
    {
        GUILayout.Label("Click the button to turn selected GameObjects into GameReady loot objects:");

        EditorGUI.BeginDisabledGroup(Selection.gameObjects.Length == 0);
        if (GUILayout.Button("Create GameReady Loot Object(s)"))
        {
            CreateGameReadyLootObjects();
        }
        EditorGUI.EndDisabledGroup();
    }

    private void CreateGameReadyLootObjects()
    {
        foreach (GameObject selectedObject in Selection.gameObjects)
        {
            // Create the main gameobject with the same name as the selected GameObject
            GameObject mainGameObject = new GameObject(selectedObject.name);
            
            // Set the position to the origin (0, 0, 0)
            mainGameObject.transform.position = Vector3.zero;

            // Set the selected GameObject as a child of the main gameobject
            selectedObject.transform.SetParent(mainGameObject.transform);

            // Add a Mesh Collider with "Convex" option ticked to the selected GameObject
            MeshCollider meshCollider = selectedObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;

            // Add the Preview Pivot to the main gameobject
            PreviewPivot previewPivot = mainGameObject.AddComponent<PreviewPivot>();
        }

        // Notify the user that the process is complete
        EditorUtility.DisplayDialog("GameReady Loot Objects Created", "The GameReady loot objects have been created successfully for the selected GameObjects!", "OK");

        // Repaint the window to update the GUI
        Repaint();
    }
}
