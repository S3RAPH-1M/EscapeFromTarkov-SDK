using UnityEngine;
using UnityEditor;
using EFT.Visual;

public class GameReadyDressObjectCreatorEditor : EditorWindow
{
    [MenuItem("Custom Windows/Groovey/Tools/Create Game Ready Dress Object(s)")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadyDressObjectCreatorEditor));
    }

    private void OnGUI()
    {
        GUILayout.Label("Create Game Ready Dress Object(s):");

        EditorGUI.BeginDisabledGroup(Selection.gameObjects.Length == 0);
        if (GUILayout.Button("Create Game Ready Dress Object(s)"))
        {
            CreateGameReadyDressObjects();
        }
        EditorGUI.EndDisabledGroup();
    }

    private void CreateGameReadyDressObjects()
    {
        foreach (GameObject selectedObject in Selection.gameObjects)
        {
            if (selectedObject == null)
                continue;

            GameObject emptyGameObject = new GameObject(selectedObject.name);
            emptyGameObject.transform.position = Vector3.zero;

            selectedObject.transform.SetParent(emptyGameObject.transform);

            // Add Dress script
            Dress dressScript = emptyGameObject.AddComponent<Dress>();

            // Add PreviewPivot script
            PreviewPivot previewPivotScript = emptyGameObject.AddComponent<PreviewPivot>();

            // Add BoxCollider
            BoxCollider boxCollider = selectedObject.AddComponent<BoxCollider>();
            boxCollider.enabled = false;

            // Set the Renderers field in Dress script
            System.Type dressType = typeof(Dress);
            System.Reflection.FieldInfo renderersField = dressType.GetField("Renderers", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (renderersField != null)
            {
                renderersField.SetValue(dressScript, new Renderer[] { selectedObject.GetComponent<Renderer>() });
            }
        }

        EditorUtility.DisplayDialog("GameReady Dress Object(s) Created", "The GameReady dress object(s) have been created successfully!", "OK");
    }
}
