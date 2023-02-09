using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

// Token: 0x020000D8 RID: 216
public static class UnityExtensions
{
    // Token: 0x06000512 RID: 1298 RVA: 0x0001A612 File Offset: 0x00018812
    public static GameObject InstantiatePrefab(this Transform parent, GameObject prefab)
    {
        var gameObject = Object.Instantiate(prefab, parent, false);
        gameObject.SetActive(true);
        return gameObject;
    }

    // Token: 0x06000513 RID: 1299 RVA: 0x0001A623 File Offset: 0x00018823
    public static T InstantiatePrefab<T>(this Transform parent, GameObject prefab) where T : MonoBehaviour
    {
        return parent.InstantiatePrefab(prefab).GetComponent<T>();
    }

    // Token: 0x06000514 RID: 1300 RVA: 0x0001A631 File Offset: 0x00018831
    public static T InstantiatePrefab<T>(this GameObject parent, GameObject prefab) where T : MonoBehaviour
    {
        return parent.transform.InstantiatePrefab<T>(prefab);
    }

    // Token: 0x06000515 RID: 1301 RVA: 0x0001A640 File Offset: 0x00018840
    private static void smethod_0(this Transform parent, bool onlyActive = false)
    {
        for (var i = parent.childCount - 1; i >= 0; i--)
        {
            var child = parent.GetChild(i);
            if (!onlyActive || child.gameObject.activeSelf)
            {
                if (Application.isPlaying)
                    Object.Destroy(child.gameObject);
                else
                    Object.DestroyImmediate(child.gameObject);
            }
        }
    }

    // Token: 0x06000516 RID: 1302 RVA: 0x0001A697 File Offset: 0x00018897
    public static void DestroyAllChildren(this GameObject parent, bool onlyActive = false)
    {
        parent.transform.smethod_0(onlyActive);
    }

    // Token: 0x06000517 RID: 1303 RVA: 0x000134BD File Offset: 0x000116BD
    public static void ParentFake(this Transform child, Transform parent)
    {
    }

    // Token: 0x06000518 RID: 1304 RVA: 0x000134BD File Offset: 0x000116BD
    public static void PreventMaterialChangeInEditor(this Renderer renderer)
    {
    }

    // Token: 0x06000519 RID: 1305 RVA: 0x0001A6A5 File Offset: 0x000188A5
    public static Material CopyToPreventMaterialChangeInEditor(this Material material)
    {
        return material;
    }

    // Token: 0x06000523 RID: 1315 RVA: 0x0001A8A4 File Offset: 0x00018AA4
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var t = gameObject.GetComponent<T>();
        if (t == null) t = gameObject.AddComponent<T>();
        return t;
    }

    // Token: 0x06000524 RID: 1316 RVA: 0x0001A8D0 File Offset: 0x00018AD0
    public static Component GetOrAddComponent(this GameObject gameObject, Type type)
    {
        var component = gameObject.GetComponent(type);
        if (component == null) component = gameObject.AddComponent(type);
        return component;
    }

    // Token: 0x06000525 RID: 1317 RVA: 0x0001A8F7 File Offset: 0x00018AF7
    public static T GetOrAddComponent<T>(this MonoBehaviour component) where T : Component
    {
        return component.gameObject.GetOrAddComponent<T>();
    }

    // Token: 0x06000526 RID: 1318 RVA: 0x0001A904 File Offset: 0x00018B04
    public static string GetFullPath(this Transform transform, bool withSceneName = false)
    {
        var transform2 = transform;
        var stringBuilder = new StringBuilder();
        do
        {
            stringBuilder.Insert(0, "/" + transform2.name);
            if (withSceneName && transform2.parent == null)
                stringBuilder.Insert(0, transform2.gameObject.scene.name + ":");
        } while ((transform2 = transform2.parent) != null);

        return stringBuilder.ToString();
    }

    // Token: 0x06000527 RID: 1319 RVA: 0x0001A988 File Offset: 0x00018B88
    public static Transform FindObjectByFullPath(string path)
    {
        var array = path.Split('/');
        if (array.Length == 0) return null;
        Transform transform = null;
        var text = array[0];
        if (text.EndsWith(":")) text = text.Remove(text.Length - 1);
        using (var enumerator = array.Skip(1).GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                var @class = new Class83();
                @class.part = enumerator.Current;
                if (transform == null)
                    for (var i = 0; i < SceneManager.sceneCount; i++)
                    {
                        var sceneAt = SceneManager.GetSceneAt(i);
                        if (sceneAt.isLoaded && (!(text != "") || !(sceneAt.name != text)))
                        {
                            IEnumerable<GameObject> source = sceneAt.GetRootGameObjects() ?? Array.Empty<GameObject>();
                            Func<GameObject, bool> predicate;
                            if ((predicate = @class.func_0) == null) predicate = @class.func_0 = @class.method_0;
                            var gameObject = source.FirstOrDefault(predicate);
                            if (gameObject != null)
                            {
                                transform = gameObject.transform;
                                break;
                            }
                        }
                    }
                else
                    transform = transform.transform.Find(@class.part);

                if (transform == null) break;
            }
        }

        return transform;
    }

    // Token: 0x06000528 RID: 1320 RVA: 0x0001AAE0 File Offset: 0x00018CE0
    public static List<T> GetComponentsInChildrenActiveIgnoreFirstLevel<T>(this Transform transform) where T : Component
    {
        var componentsInChildren = transform.GetComponentsInChildren<T>(true);
        var list = new List<T>();
        foreach (var t in componentsInChildren)
            if (smethod_5(t, transform))
                list.Add(t);
        return list;
    }

    // Token: 0x06000529 RID: 1321 RVA: 0x0001AB28 File Offset: 0x00018D28
    public static T GetComponentInChildrenActiveIgnoreFirstLevel<T>(this Transform transform) where T : Component
    {
        var componentInChildren = transform.GetComponentInChildren<T>(true);
        if (componentInChildren != null && smethod_5(componentInChildren, transform)) return componentInChildren;
        return default;
    }

    // Token: 0x0600052A RID: 1322 RVA: 0x0001AB64 File Offset: 0x00018D64
    private static bool smethod_5(Component component, Transform firstLevel)
    {
        var transform = component.transform;
        if (transform == firstLevel) return true;
        while (transform.gameObject.activeSelf)
            if (!((transform = transform.parent) != firstLevel))
                return true;
        return false;
    }

    // Token: 0x0600052B RID: 1323 RVA: 0x0001ABA4 File Offset: 0x00018DA4
    public static T AddComponentCopy<T>(this GameObject go, T source) where T : Component
    {
        var t = go.AddComponent<T>();
        foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                                                             BindingFlags.Public | BindingFlags.NonPublic))
            if (propertyInfo.CanWrite)
                try
                {
                    propertyInfo.SetValue(t, propertyInfo.GetValue(source, null), null);
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                }

        foreach (var fieldInfo in typeof(T).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                                                      BindingFlags.Public | BindingFlags.NonPublic))
            fieldInfo.SetValue(t, fieldInfo.GetValue(source));
        return t;
    }

    // Token: 0x0600052C RID: 1324 RVA: 0x0001AC5C File Offset: 0x00018E5C
    public static List<Transform> GetChildren(this Transform transform)
    {
        var list = new List<Transform>(transform.childCount);
        for (var i = 0; i < transform.childCount; i++) list.Add(transform.GetChild(i));
        return list;
    }

    // Token: 0x0600052D RID: 1325 RVA: 0x0001AC94 File Offset: 0x00018E94
    public static void SetActiveWithCheck(this GameObject go, bool active)
    {
        if (go.activeSelf != active) go.SetActive(active);
    }

    // Token: 0x020000DA RID: 218
    [CompilerGenerated]
    [Serializable]
    private sealed class Class82
    {
        // Token: 0x06000534 RID: 1332 RVA: 0x0001ADEA File Offset: 0x00018FEA
        internal bool method_0(MultiFlareLight flare)
        {
            return flare.Parent != null;
        }

        // Token: 0x04000631 RID: 1585
        public static readonly Class82 class82_0 = new Class82();

        // Token: 0x04000632 RID: 1586
        public static Func<MultiFlareLight, bool> func_0;
    }

    // Token: 0x020000DB RID: 219
    [CompilerGenerated]
    [StructLayout(LayoutKind.Auto)]
    private struct Struct2
    {
        // Token: 0x04000633 RID: 1587
        public List<Transform> objectsChildren;

        // Token: 0x04000634 RID: 1588
        public Action<Transform> onTick;
    }

    // Token: 0x020000DD RID: 221
    [CompilerGenerated]
    private sealed class Class83
    {
        // Token: 0x06000538 RID: 1336 RVA: 0x0001B002 File Offset: 0x00019202
        internal bool method_0(GameObject o)
        {
            return o.name == part;
        }

        // Token: 0x0400063F RID: 1599
        public string part;

        // Token: 0x04000640 RID: 1600
        public Func<GameObject, bool> func_0;
    }
}