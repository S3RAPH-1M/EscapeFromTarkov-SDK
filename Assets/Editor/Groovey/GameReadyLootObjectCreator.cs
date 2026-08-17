using UnityEngine;
using UnityEditor;
using EFT.Visual;

public class GameReadyLootItemEditor : EditorWindow
{
    [MenuItem("Custom Windows/Groovey/Tools/Create GameReady Loot Object(s)")]
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
            GameObject mainGameObject = new GameObject(selectedObject.name);
            
            mainGameObject.transform.position = Vector3.zero;

            selectedObject.transform.SetParent(mainGameObject.transform);

            MeshCollider meshCollider = selectedObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;

            PreviewPivot previewPivot = mainGameObject.AddComponent<PreviewPivot>();
        }

        EditorUtility.DisplayDialog("GameReady Loot Objects Created", "The GameReady loot objects have been created successfully for the selected GameObjects!", "OK");

        Repaint();
    }
}
