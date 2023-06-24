using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPreviewWindow : EditorWindow
{
    private ItemPreview itemPreview;
    private GameObject itemToRender;
    private static ItemPreviewWindow window;
    private bool showPreview;
    private ItemPreview itemPreviewInstance;
    private GameObject itemToRenderInstance;
    private Scene previewScene;
    private Texture2D generatedIcon;
    private int _itemWidth = 1;
    private int _itemHeight = 1;

    [MenuItem("Custom Windows/Item Preview")]
    static void Init()
    {
        window = (ItemPreviewWindow) GetWindow(typeof(ItemPreviewWindow));
        window.Show();
        window.titleContent = new GUIContent("Item Preview");
    }

    private void OnEnable()
    {
        window = (ItemPreviewWindow) GetWindow(typeof(ItemPreviewWindow));
        itemPreview = AssetDatabase
            .LoadAssetAtPath<GameObject>("Assets/Scripts/Custom/Item Preview/iconPreviewPrefab.prefab")
            .GetComponent<ItemPreview>();
    }

    void OnGUI()
    {
        var style = new GUIStyle(EditorStyles.boldLabel) {alignment = TextAnchor.MiddleCenter, fontSize = 14};
        GUILayout.BeginVertical(GUILayout.Width(position.width), GUILayout.Height(position.height));
        GUILayout.Space(5f);
        EditorGUI.BeginChangeCheck();
        itemToRender =
            (GameObject) EditorGUILayout.ObjectField("Item to preview", itemToRender, typeof(GameObject), true);
        if (EditorGUI.EndChangeCheck())
        {
            if (itemToRender == null)
            {
                ClosePreviewWindow();
                showPreview = false;
                return;
            }

            showPreview = true;
            SetupItemPreviewWindow();
        }

        GUILayout.Space(5f);
        GUILayout.Label("Model Preview", style);
        RenderPreviewWindow();
        GUILayout.Space(position.height / 2.5f);
        GUILayout.Label("Icon Generator", style);
        GUILayout.Space(5f);
        _itemHeight = EditorGUILayout.IntField("Item Height From Template", _itemHeight);
        _itemWidth = EditorGUILayout.IntField("Item Width From Template", _itemWidth);
        if (GUILayout.Button("Save current rotation to PreviewPivot"))
        {
            itemToRender.GetComponent<PreviewPivot>().Icon.rotation = itemToRenderInstance.transform.rotation;
            PrefabUtility.SavePrefabAsset(itemToRender);
        }
        if (GUILayout.Button("Render Icon"))
        {
            if (itemToRender == null) return;
            RenderIcon();
        }

        if (generatedIcon)
        {
            var rect = new Rect(0, 0, generatedIcon.width, generatedIcon.height)
            {
                center = new Vector2(position.width / 2f, position.height / 1.25f)
            };
            EditorGUI.DrawPreviewTexture(rect, generatedIcon, null, ScaleMode.StretchToFill);

        }

        GUILayout.EndVertical();
    }

    private void SetupItemPreviewWindow()
    {
        previewScene = EditorSceneManager.NewPreviewScene();
        itemPreviewInstance = Instantiate(itemPreview);
        SceneManager.MoveGameObjectToScene(itemPreviewInstance.gameObject, previewScene);
        itemPreviewInstance.previewCamera.scene = previewScene;
        itemToRenderInstance = Instantiate(itemToRender, itemPreviewInstance.previewPivot);
        PreviewPivot component = itemToRenderInstance.GetComponent<PreviewPivot>();
        if (component != null)
        {
            itemToRenderInstance.transform.localPosition = -component.pivotPosition;
            itemPreviewInstance.previewPivot.localRotation = component.Icon.rotation;
        }
        else
        {
            itemToRenderInstance.transform.localPosition = ItemPreview.GetBounds(itemToRenderInstance).center;
        }
        itemToRenderInstance.transform.localScale = component != null ? component.scale : Vector3.one;
    }

    private void ClosePreviewWindow()
    {
        DestroyImmediate(itemPreviewInstance);
        DestroyImmediate(itemToRenderInstance);
        EditorSceneManager.ClosePreviewScene(previewScene);
    }

    private void RenderPreviewWindow()
    {
        if (!showPreview) return;

        var windowRect = new Rect(0, 0, position.size.x, position.size.y / 2f)
        {
            center = new Vector2(position.width / 2f, position.height / 1.33f)
        };

        itemPreviewInstance.previewCamera.pixelRect = windowRect;
        itemPreviewInstance.previewCamera.Render();

        var e = Event.current;
        switch (e.type)
        {
            case EventType.MouseDrag when e.button == 0:
                itemPreviewInstance.Rotate(e.delta.x, -e.delta.y, 0f, 0f);
                window.Repaint();
                break;
            case EventType.ScrollWheel:
                itemPreviewInstance.Zoom(e.delta.y / 20f);
                window.Repaint();
                break;
        }
    }

    private void RenderIcon()
    {
        ClosePreviewWindow();
        SetupItemPreviewWindow();
        itemPreviewInstance.ChangeLights();
        generatedIcon = GenerateIcon();
        ClosePreviewWindow();
        SetupItemPreviewWindow();
    }

    private Texture2D GenerateIcon()
    {
        var itemSize = new Vector2(_itemWidth, _itemHeight) * (64f * 3);
        itemPreviewInstance.previewCamera.orthographic = true;
        itemPreviewInstance.previewCamera.aspect = itemSize.x / itemSize.y;
        itemToRenderInstance.transform.localScale = Vector3.one;

        var previewPivot = itemToRenderInstance.GetComponent<PreviewPivot>();
        if (previewPivot != null)
        {
            PoseByPivot(previewPivot);
        }
        else
        {
            var bounds = ItemPreview.GetBounds(itemToRenderInstance);
            PoseModelByBounds(bounds);
        }

        int x = (int) itemSize.x;
        int width = x * 2;
        int y = (int) itemSize.y;
        int height = y * 2;
        var temporary = RenderTexture.GetTemporary(width, height, 16, RenderTextureFormat.ARGB32,
            RenderTextureReadWrite.Default, 8);
        temporary.name = "IconCreator TextureDouble";
        itemPreviewInstance.previewCamera.gameObject.SetActive(true);
        itemPreviewInstance.previewCamera.targetTexture = temporary;
        itemPreviewInstance.previewCamera.clearFlags = CameraClearFlags.Color;
        itemPreviewInstance.previewCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
        itemPreviewInstance.previewCamera.useOcclusionCulling = false;
        RenderTexture temporary2 = RenderTexture.GetTemporary(x, y);
        ClearTexture(temporary2);
        itemPreviewInstance.previewCamera.Render();
        Graphics.Blit(temporary, temporary2);
        RenderTexture active = RenderTexture.active;
        RenderTexture.active = temporary2;
        Texture2D texture2D = new Texture2D(x, y, TextureFormat.ARGB32, false)
            {filterMode = FilterMode.Trilinear, name = "icon"};
        texture2D.ReadPixels(
            new Rect(0f, 0f, itemPreviewInstance.previewCamera.pixelWidth,
                itemPreviewInstance.previewCamera.pixelHeight), 0, 0, false);
        texture2D.Apply();
        RenderTexture.active = active;
        itemPreviewInstance.previewCamera.targetTexture = null;
        RenderTexture.ReleaseTemporary(temporary);
        RenderTexture.ReleaseTemporary(temporary2);
        return texture2D;
    }

    private void PoseByPivot(PreviewPivot previewPivot)
    {
        itemToRenderInstance.transform.rotation = previewPivot.Icon.rotation;
        CenterByBounds(previewPivot.Icon);
    }

    private void PoseModelByBounds(in Bounds bounds)
    {
        itemPreviewInstance.previewCamera.orthographicSize = bounds.extents.y;
    }

    private void CenterByBounds(PreviewPivot.IconSettings settings)
    {
        var bounds = ItemPreview.GetBounds(itemToRenderInstance);
        float num = bounds.extents.x / bounds.extents.y;
        var vector = itemToRenderInstance.transform.position;
        vector -= bounds.center;
        var vector2 = new Vector3(vector.x, vector.y + itemPreviewInstance.previewCamera.transform.position.y,
            vector.z);

        if (settings.hasOffset)
        {
            vector2 += settings.position;
        }

        itemToRenderInstance.transform.position = vector2;
        if (num > itemPreviewInstance.previewCamera.aspect)
        {
            itemPreviewInstance.previewCamera.orthographicSize =
                bounds.extents.x / itemPreviewInstance.previewCamera.aspect / settings.boundsScale;
            return;
        }

        itemPreviewInstance.previewCamera.orthographicSize = bounds.extents.y / settings.boundsScale;
    }

    private void ClearTexture(RenderTexture tex)
    {
        RenderTexture active = RenderTexture.active;
        Graphics.SetRenderTarget(tex);
        GL.Clear(true, true, new Color(0f, 0f, 0f, 0f));
        RenderTexture.active = active;
    }

    private void OnDisable()
    {
        ClosePreviewWindow();
        showPreview = false;
    }
}
