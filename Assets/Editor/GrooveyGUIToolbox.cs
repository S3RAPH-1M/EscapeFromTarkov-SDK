using UnityEditor;
using UnityEngine;

public class CustomGUIToolboxEditor : EditorWindow
{
    [MenuItem("Groovey GUI Toolbox/Groovey's GUI Toolbox")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomGUIToolboxEditor), false, "GUI Toolbox");
    }

    private void OnGUI()
    {
        GUILayout.Label("Groovey's GUI Toolbox");
		
		GUILayout.Label("Automate the creation of (almost) every Tarkov Item");
        GUILayout.Space(10); 
		GUILayout.Label("Loot items are static items: Quest items, cases, hideout items, basically anything you can't wear or attach to a weapon, that ISN'T animated.");


        if (GUILayout.Button("Open Game Ready Loot Item Creator"))
        {
            GameReadyLootItemEditor.ShowWindow();
        }
		
		GUILayout.Space(10); 
		GUILayout.Label("Skinned items are anything the character wears that requires weight painting. Chest rigs, backpacks, armor, etc.");

        if (GUILayout.Button("Open Game Ready Skinned Object Creator"))
        {
            GameReadySkinnedObjectCreatorEditor.ShowWindow();
        }
		
		GUILayout.Space(10); 
		GUILayout.Label("Dress objects are items the character wears that DON'T require weight painting (helmets) or objects that go into mod slots (masks, NVG, etc).");

        if (GUILayout.Button("Open Game Ready Dress Object Creator"))
        {
            GameReadyDressObjectCreatorEditor.ShowWindow();
        }
		
		GUILayout.Space(10); 
		GUILayout.Label("Heads and clothing both have the same setup, so this works for both.");

        if (GUILayout.Button("Open Game Ready Clothing and Head Creator"))
        {
            GameReadyClothingHeadCreatorEditor.ShowWindow();
        }
		
		GUILayout.Space(10); 
		GUILayout.Label("First person arms creator for custom models.");

        if (GUILayout.Button("Open Game Ready Character Arms Creator"))
        {
            GameReadyCharacterArmsCreatorEditor.ShowWindow();
        }

		GUILayout.Space(10); 
		GUILayout.Label("This tool allows you to automatically configure your custom rig layout after you've made it, and optionally export the grid servercode.");

        if (GUILayout.Button("Open Custom Rig Layout Editor"))
        {
            CustomRigEditor.ShowWindow();
        }

		GUILayout.Space(10); 
		GUILayout.Label("This tool automatically creates and configures tagbanks for your custom voicelines. This REQUIRES each audioclip be named the same as its corresponding tagbank.");

        if (GUILayout.Button("Open Custom Voice Creator"))
        {
            VoiceTagBankCreator.ShowWindow();
        }

		GUILayout.Space(10); 
		GUILayout.Label("This tool automatically configures your transform links for animated items. It fills out all the bones in the proper order, and converts the rotational data to quaterions.");

        if (GUILayout.Button("Open Auto Transform Links"))
        {
            TransformLinksAutomation.ShowWindow();
        }

    }
}
