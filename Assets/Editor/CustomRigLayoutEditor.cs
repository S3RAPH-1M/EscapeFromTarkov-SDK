using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EFT.UI.DragAndDrop;


public class CustomRigEditor : EditorWindow
{
    private GameObject customRigGameObject;
    private List<GridView> gridViews = new List<GridView>();
    private List<int> cellWidths = new List<int>();
    private List<int> cellHeights = new List<int>();

    [MenuItem("Groovey GUI Toolbox/Tools/Custom Rig Editor", priority = 5)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomRigEditor));
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField("This tool configures the layout of your custom rig, and optionally exports the grid layout to a JSON file.", EditorStyles.wordWrappedLabel);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField("Select your main Custom Rig GameObject before continuing.", EditorStyles.wordWrappedLabel);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        customRigGameObject = Selection.activeGameObject;

        if (customRigGameObject == null)
        {
            EditorGUILayout.HelpBox("Please select a Custom Rig GameObject in the Hierarchy.", MessageType.Info);
            return;
        }

        TemplatedGridsView templatedGridsView = customRigGameObject.GetComponent<TemplatedGridsView>();
        if (templatedGridsView == null)
        {
            EditorGUILayout.HelpBox("The selected Custom Rig GameObject does not have a TemplatedGridsView component.", MessageType.Error);
            return;
        }
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField("Renames all grid slots to GridView (n), fills out Templated Grids View script, checks the size of the layout and compares it to the Rect Transform, setting them to the same value.", EditorStyles.wordWrappedLabel);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
        if (GUILayout.Button("Configure Rig Layout"))
        {
            ConfigureRig();
        }
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUILayout.LabelField("Exports the grid layout to a JSON file, located in the Assets/CustomRigLayouts/Grids folder.", EditorStyles.wordWrappedLabel);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
        if (GUILayout.Button("Export Grid"))
        {
            ExportJSON();
        }
    }



    private void ConfigureRig()
    {
        if (customRigGameObject == null)
        {
            Debug.LogError("Custom Rig GameObject not set!");
            return;
        }

        gridViews.Clear();
        cellWidths.Clear();
        cellHeights.Clear();

        int childCount = customRigGameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = customRigGameObject.transform.GetChild(i);
            child.name = "GridView (" + (i + 1) + ")";
            GridView gridView = child.GetComponent<GridView>();

            gridViews.Add(gridView);


            RectTransform rectTransform = child.GetComponent<RectTransform>();
            if (rectTransform != null)
            {

                int cellsH = CalculateNearestValidSlotSize(Mathf.RoundToInt(rectTransform.sizeDelta.x));
                int cellsV = CalculateNearestValidSlotSize(Mathf.RoundToInt(rectTransform.sizeDelta.y));


                cellWidths.Add(cellsH);
                cellHeights.Add(cellsV);

                Debug.Log("Slot " + (i + 1) + " size: " + cellsH + "x" + cellsV);
            }
            else
            {
                Debug.LogError("RectTransform component not found on child " + child.name);
            }
        }

        TemplatedGridsView templatedGridsView = customRigGameObject.GetComponent<TemplatedGridsView>();
        if (templatedGridsView != null)
        {
            FieldInfo fieldInfo = typeof(TemplatedGridsView).GetField("_presetGridViews", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(templatedGridsView, gridViews.ToArray());
            }
            else
            {
                Debug.LogError("_presetGridViews field not found in TemplatedGridsView!");
                return;
            }
        }
        else
        {
            Debug.LogError("TemplatedGridsView component not found on Custom Rig GameObject!");
            return;
        }

        RectTransform mainRectTransform = customRigGameObject.GetComponent<RectTransform>();
        if (mainRectTransform != null)
        {
            mainRectTransform.sizeDelta = new Vector2(Mathf.Round(mainRectTransform.sizeDelta.x), Mathf.Round(mainRectTransform.sizeDelta.y));
            LayoutElement layoutElement = customRigGameObject.GetComponent<LayoutElement>();
            if (layoutElement != null)
            {
                layoutElement.minWidth = mainRectTransform.sizeDelta.x;
                layoutElement.minHeight = mainRectTransform.sizeDelta.y;
            }
        }
        else
        {
            Debug.LogError("RectTransform component not found on Custom Rig GameObject!");
            return;
        }


    }

    private int CalculateNearestValidSlotSize(int size)
    {
        if (size >= 60 && size <= 68) return 1; // x1 slot size
        if (size >= 124 && size <= 132) return 2; // x2 slot size
        if (size >= 188 && size <= 196) return 3; // x3 slot size
        if (size >= 248 && size <= 256) return 4; // x4 slot size
        if (size >= 312 && size <= 320) return 5; // x5 slot size
        if (size >= 372 && size <= 380) return 6; // x6 slot size
        if (size >= 436 && size <= 444) return 7; // x7 slot size
        if (size >= 496 && size <= 504) return 8; // x8 slot size

        return size;
    }



private void ExportJSON()
{
    RigData rigData = new RigData();
    rigData.Grids = new List<GridData>();

    string GenerateObjectId()
    {
        string hexChars = "0123456789abcdef";
        char[] objectId = new char[24];
        for (int i = 0; i < 24; i++)
        {
            objectId[i] = hexChars[UnityEngine.Random.Range(0, hexChars.Length)];
        }
        return new string(objectId);
    }

    for (int i = 0; i < gridViews.Count; i++)
    {
        GridView gridView = gridViews[i];
        GridData gridData = new GridData();
        gridData._id = GenerateObjectId();
        gridData._name = gridView.gameObject.name;
        gridData._parent = customRigGameObject.name;
        gridData._props = new Props();
        gridData._props.cellsH = cellWidths[i].ToString();
        gridData._props.cellsV = cellHeights[i].ToString();
        gridData._props.filters = new List<FilterData>();
        gridData._props.filters.Add(new FilterData());
        gridData._props.filters[0].ExcludedFilter = new List<string>();
        gridData._props.filters[0].ExcludedFilter.Add("5448bf274bdc2dfc2f8b456a");
        gridData._props.filters[0].Filter = new List<string>();
        gridData._props.filters[0].Filter.Add("54009119af1c881c07000029");
        gridData._props.isSortingTable = false;
        gridData._props.maxCount = 0;
        gridData._props.maxWeight = 0;
        gridData._props.minCount = 0;
        gridData._proto = "55d329c24bdc2d892f8b4567";

        rigData.Grids.Add(gridData);
    }

    string jsonData = JsonUtility.ToJson(rigData, true);
    string directoryPath = Path.Combine(Application.dataPath, "CustomRigLayouts", "Grids");
    string fileName = customRigGameObject.name + "_layout.json";
    string filePath = Path.Combine(directoryPath, fileName);

    Directory.CreateDirectory(directoryPath);

    if (File.Exists(filePath))
    {
        bool overwriteConfirmed = EditorUtility.DisplayDialog("Overwrite File", "A layout file with the same name already exists. Do you want to overwrite it?", "Yes", "No");
        if (!overwriteConfirmed)
            return;
    }

    File.WriteAllText(filePath, jsonData);

    Debug.Log("JSON file exported to: " + filePath);

    EditorUtility.DisplayDialog("Success", "Grid layout exported successfully!", "OK");
}

}

[System.Serializable]
public class RigData
{
    public List<GridData> Grids;
}

[System.Serializable]
public class GridData
{
    public string _id;
    public string _name;
    public string _parent;
    public Props _props;
    public string _proto;
}

[System.Serializable]
public class Props
{
    public string cellsH;
    public string cellsV;
    public List<FilterData> filters;
    public bool isSortingTable;
    public int maxCount;
    public int maxWeight;
    public int minCount;
}

[System.Serializable]
public class FilterData
{
    public List<string> ExcludedFilter;
    public List<string> Filter;
}
