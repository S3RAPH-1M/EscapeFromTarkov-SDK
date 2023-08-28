using UnityEditor;
using UnityEngine;

public class CustomGUIToolboxEditor : EditorWindow
{
    [MenuItem("Custom Windows/Groovey GUI Toolbox")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomGUIToolboxEditor), false, "GUI Toolbox");
    }

    private void OnGUI()
    {
        GUILayout.Label("Groovey's GUI Toolbox");
		
		GUILayout.Label("Automate the creation of (almost) every Tarkov Item");
        GUILayout.Space(10); // Add space between buttons
		GUILayout.Label("Loot items are usable items, cases, basically anything you can't wear or attach to a weapon");


        if (GUILayout.Button("Open Game Ready Loot Item Creator"))
        {
            GameReadyLootItemEditor.ShowWindow();
        }
		
		GUILayout.Space(10); // Add space between buttons
		GUILayout.Label("Skinned items are anything the character wears that requires weight painting. Chest rigs, backpacks, armor, etc.");

        if (GUILayout.Button("Open Game Ready Skinned Object Creator"))
        {
            GameReadySkinnedObjectCreatorEditor.ShowWindow();
        }
		
		GUILayout.Space(10); // Add space between buttons
		GUILayout.Label("Dress objects are items the character wears that DON'T require weight painting (helmets) or objects that go into mod slots (masks, NVG, etc).");

        if (GUILayout.Button("Open Game Ready Dress Object Creator"))
        {
            GameReadyDressObjectCreatorEditor.ShowWindow();
        }
		
		GUILayout.Space(10); // Add space between buttons
		GUILayout.Label("Heads and clothing both have the same setup, so this works for both.");

        if (GUILayout.Button("Open Game Ready Clothing and Head Creator"))
        {
            GameReadyClothingHeadCreatorEditor.ShowWindow();
        }
		
		GUILayout.Space(10); // Add space between buttons
		GUILayout.Label("First person arms creator for custom models.");

        if (GUILayout.Button("Open Game Ready Character Arms Creator"))
        {
            GameReadyCharacterArmsCreatorEditor.ShowWindow();
        }

        // Add more buttons for your other custom GUIs here
    }
}
