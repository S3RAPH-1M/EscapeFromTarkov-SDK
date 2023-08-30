using UnityEngine;
using UnityEditor;
using EFT.Visual;

public class GameReadyDressObjectCreatorEditor : EditorWindow
{
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

            // Create the empty gameobject with the same name as the selected Dress Object
            GameObject emptyGameObject = new GameObject(selectedObject.name);
            emptyGameObject.transform.position = Vector3.zero;

            // Set the selected Dress Object as a child of the empty gameobject
            selectedObject.transform.SetParent(emptyGameObject.transform);

            // Add the "Dress" script to the empty gameobject
            Dress dressScript = emptyGameObject.AddComponent<Dress>();

            // Add the "Preview Pivot" script to the empty gameobject
            PreviewPivot previewPivotScript = emptyGameObject.AddComponent<PreviewPivot>();

            // Use reflection to set the 'Renderers' field in the 'Dress' script
            System.Type dressType = typeof(Dress);
            System.Reflection.FieldInfo renderersField = dressType.GetField("Renderers", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (renderersField != null)
            {
                renderersField.SetValue(dressScript, new Renderer[] { selectedObject.GetComponent<Renderer>() });
            }
        }

        // Notify the user that the process is complete
        EditorUtility.DisplayDialog("GameReady Dress Object(s) Created", "The GameReady dress object(s) have been created successfully!", "OK");
    }

    [MenuItem("Custom/Dress Object Creator/Create Game Ready Dress Object(s)", priority = 0)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameReadyDressObjectCreatorEditor));
    }
}
