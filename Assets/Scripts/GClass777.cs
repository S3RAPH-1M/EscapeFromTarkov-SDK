using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = System.Random;

// Token: 0x020006CB RID: 1739
public static class GClass777
{
    // Token: 0x06002D91 RID: 11665 RVA: 0x000CBD2D File Offset: 0x000C9F2D
    public static bool ApproxEquals(this float value, float value2)
    {
        return Math.Abs(value - value2) < float.Epsilon;
    }

    // Token: 0x06002D92 RID: 11666 RVA: 0x000CBD3E File Offset: 0x000C9F3E
    public static bool ApproxEquals(this double value, double value2)
    {
        return Math.Abs(value - value2) < 1.4012984643248171E-45;
    }

    // Token: 0x06002D93 RID: 11667 RVA: 0x000CBD53 File Offset: 0x000C9F53
    public static bool LowAccuracyApprox(this float value, float value2)
    {
        return Math.Abs(value - value2) < 0.001f;
    }

    // Token: 0x06002D94 RID: 11668 RVA: 0x000CBD64 File Offset: 0x000C9F64
    public static bool IsZero(this float value)
    {
        return Math.Abs(value) < float.Epsilon;
    }

    // Token: 0x06002D95 RID: 11669 RVA: 0x000CBD73 File Offset: 0x000C9F73
    public static bool IsZero(this Vector2 vector)
    {
        return vector.x.IsZero() && vector.y.IsZero();
    }

    // Token: 0x06002D96 RID: 11670 RVA: 0x000CBD8F File Offset: 0x000C9F8F
    public static bool IsZero(this double value)
    {
        return Math.Abs(value) < 1.4012984643248171E-45;
    }

    // Token: 0x06002D97 RID: 11671 RVA: 0x000CBDA2 File Offset: 0x000C9FA2
    public static bool Positive(this double value)
    {
        return value >= 1.4012984643248171E-45;
    }

    // Token: 0x06002D98 RID: 11672 RVA: 0x000CBDB3 File Offset: 0x000C9FB3
    public static bool Positive(this float value)
    {
        return value >= float.Epsilon;
    }

    // Token: 0x06002D99 RID: 11673 RVA: 0x000CBDC0 File Offset: 0x000C9FC0
    public static bool Negative(this double value)
    {
        return value <= -1.4012984643248171E-45;
    }

    // Token: 0x06002D9A RID: 11674 RVA: 0x000CBDD1 File Offset: 0x000C9FD1
    public static bool Negative(this float value)
    {
        return value <= -1.401298E-45f;
    }

    // Token: 0x06002D9B RID: 11675 RVA: 0x000CBDDE File Offset: 0x000C9FDE
    public static bool ZeroOrNegative(this float value)
    {
        return value < float.Epsilon;
    }

    // Token: 0x06002D9C RID: 11676 RVA: 0x000CBDE8 File Offset: 0x000C9FE8
    public static bool ZeroOrPositive(this float value)
    {
        return value > -1.401298E-45f;
    }

    // Token: 0x06002D9D RID: 11677 RVA: 0x000C835F File Offset: 0x000C655F
    public static double Clamp01(this double value)
    {
        if (value < 0.0) return 0.0;
        if (value <= 1.0) return value;
        return 1.0;
    }

    // Token: 0x06002D9E RID: 11678 RVA: 0x000CBDF2 File Offset: 0x000C9FF2
    public static double Clamp(this double value, double limit1, double limit2)
    {
        if (limit1 < limit2)
        {
            value = Math.Max(value, limit1);
            value = Math.Min(value, limit2);
        }
        else
        {
            value = Math.Max(value, limit2);
            value = Math.Min(value, limit1);
        }

        return value;
    }

    // Token: 0x06002D9F RID: 11679 RVA: 0x000CBE27 File Offset: 0x000CA027
    public static Vector3 Multiply(this Vector3 multiplier1, Vector3 multiplier2)
    {
        return new Vector3(multiplier1.x * multiplier2.x, multiplier1.y * multiplier2.y, multiplier1.z * multiplier2.z);
    }

    // Token: 0x06002DA0 RID: 11680 RVA: 0x000CBE55 File Offset: 0x000CA055
    public static Vector2 Multiply(this Vector2 multiplier1, Vector2 multiplier2)
    {
        return new Vector2(multiplier1.x * multiplier2.x, multiplier1.y * multiplier2.y);
    }

    // Token: 0x06002DA1 RID: 11681 RVA: 0x000CBE76 File Offset: 0x000CA076
    public static Vector3 Divide(this Vector3 divisible, Vector3 divisor)
    {
        return new Vector3(divisible.x / divisor.x, divisible.y / divisor.y, divisible.z / divisor.z);
    }

    // Token: 0x06002DA2 RID: 11682 RVA: 0x000CBEA4 File Offset: 0x000CA0A4
    public static Vector2 Divide(this Vector2 divisible, Vector2 divisor)
    {
        return new Vector2(divisible.x / divisor.x, divisible.y / divisor.y);
    }

    // Token: 0x06002DA3 RID: 11683 RVA: 0x000CBEC5 File Offset: 0x000CA0C5
    public static Rect Scale(this Rect rect, Vector2 scale)
    {
        return new Rect(rect.x * scale.x, rect.y * scale.y, rect.width * scale.x, rect.height * scale.y);
    }

    // Token: 0x06002DA4 RID: 11684 RVA: 0x000CBF04 File Offset: 0x000CA104
    public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
    {
        return new Vector3(Mathf.Clamp(vector.x, Mathf.Min(min.x, max.x), Mathf.Max(min.x, max.x)),
            Mathf.Clamp(vector.y, Mathf.Min(min.y, max.y), Mathf.Max(min.y, max.y)),
            Mathf.Clamp(vector.z, Mathf.Min(min.z, max.z), Mathf.Max(min.z, max.z)));
    }

    // Token: 0x06002DA5 RID: 11685 RVA: 0x000CBF9D File Offset: 0x000CA19D
    public static Vector3 DeltaAngle(this Vector3 from, Vector3 to)
    {
        return new Vector3(Mathf.DeltaAngle(from.x, to.x), Mathf.DeltaAngle(from.y, to.y),
            Mathf.DeltaAngle(from.z, to.z));
    }

    // Token: 0x06002DA6 RID: 11686 RVA: 0x000CBFD8 File Offset: 0x000CA1D8
    public static T GetRandomItem<T>(this List<T> list, T excludedItem)
    {
        if (list == null) return default;
        var count = list.Count;
        if (count == 0) return default;
        if (count == 1) return list[0];
        var num = 0;
        T result;
        for (;;)
        {
            var index = UnityEngine.Random.Range(0, count);
            result = list[index];
            num++;
            if (result.Equals(excludedItem))
                if (num != 100)
                    break;
        }

        return result;
    }

    // Token: 0x06002DA7 RID: 11687 RVA: 0x000CC050 File Offset: 0x000CA250
    public static T GetRandomItem<T>(this List<T> list)
    {
        if (list != null && list.Count != 0)
        {
            var index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }

        return default;
    }

    // Token: 0x06002DA8 RID: 11688 RVA: 0x000CC086 File Offset: 0x000CA286
    public static double ExactLength(this AudioClip clip)
    {
        return clip.samples / (double) clip.frequency;
    }

    // Token: 0x06002DA9 RID: 11689 RVA: 0x000CC098 File Offset: 0x000CA298
    private static Func<object, T> smethod_0<T>(MethodInfo methodInfo)
    {
        var parameterExpression = Expression.Parameter(typeof(object), "obj");
        var arg = Expression.Convert(parameterExpression, methodInfo.GetParameters().First().ParameterType);
        return Expression.Lambda<Func<object, T>>(Expression.Call(methodInfo, arg), parameterExpression).Compile();
    }

    // Token: 0x06002DAA RID: 11690 RVA: 0x000CC0EC File Offset: 0x000CA2EC
    private static Action<object, T> smethod_1<T>(MethodInfo methodInfo)
    {
        var parameterExpression = Expression.Parameter(typeof(object), "obj");
        var parameterExpression2 = Expression.Parameter(typeof(T), "value");
        var arg = Expression.Convert(parameterExpression, methodInfo.GetParameters().First().ParameterType);
        var arg2 = Expression.Convert(parameterExpression2, methodInfo.GetParameters().Last().ParameterType);
        return Expression
            .Lambda<Action<object, T>>(Expression.Call(methodInfo, arg, arg2), parameterExpression,
                parameterExpression2).Compile();
    }

    // Token: 0x06002DAB RID: 11691 RVA: 0x000CC174 File Offset: 0x000CA374
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection, int n)
    {
        if (collection == null) throw new ArgumentNullException("collection");
        if (n < 0) throw new ArgumentOutOfRangeException("n", "n must be 0 or greater");
        var linkedList = new LinkedList<T>();
        foreach (var value in collection)
        {
            linkedList.AddLast(value);
            if (linkedList.Count > n) linkedList.RemoveFirst();
        }

        return linkedList;
    }

    // Token: 0x06002DAF RID: 11695 RVA: 0x000CC2DC File Offset: 0x000CA4DC
    public static List<Transform> GetChildsName(Transform transform, string name, bool onlyActive = true)
    {
        var list = new List<Transform>();
        foreach (var obj in transform)
        {
            var transform2 = (Transform) obj;
            if (transform2.name.Contains(name))
            {
                if (onlyActive)
                {
                    if (transform2.gameObject.activeSelf) list.Add(transform2);
                }
                else
                {
                    list.Add(transform2);
                }
            }
        }

        return list;
    }

    // Token: 0x06002DB0 RID: 11696 RVA: 0x000CC360 File Offset: 0x000CA560
    public static Transform GetChildName(Transform transform, string name, string nocontains = "")
    {
        foreach (var obj in transform)
        {
            var transform2 = (Transform) obj;
            if (transform2.name.Contains(name) && transform2.gameObject.activeSelf)
            {
                if (nocontains.Length <= 0) return transform2;
                if (!transform2.name.Contains(nocontains)) return transform2;
            }
        }

        return null;
    }

    // Token: 0x06002DB1 RID: 11697 RVA: 0x000CC3EC File Offset: 0x000CA5EC
    public static bool IsCloseDebug(Vector3 v, float x, float z)
    {
        var num = 0.1f;
        return v.x > x - num && v.x < x + num && v.z > z - num && v.z < z + num;
    }

    // Token: 0x06002DB2 RID: 11698 RVA: 0x000CC430 File Offset: 0x000CA630
    public static bool IsCloseDebug(Vector3 v, float x, float y, float z)
    {
        var num = 0.1f;
        return v.x > x - num && v.x < x + num && v.z > z - num && v.z < z + num && v.y > y - num && v.y < y + num;
    }

    // Token: 0x06002DB6 RID: 11702 RVA: 0x000CC588 File Offset: 0x000CA788
    public static float RandomNormal(float min, float max)
    {
        var num = 3.5;
        double num2;
        while ((num2 = BoxMuller(min + (max - min) / 2.0, (max - min) / 2.0 / num)) > max || num2 < min)
        {
        }

        return (float) num2;
    }

    // Token: 0x06002DB7 RID: 11703 RVA: 0x000CC5D6 File Offset: 0x000CA7D6
    public static double BoxMuller(double mean, double standard_deviation)
    {
        return mean + BoxMuller() * standard_deviation;
    }

    // Token: 0x06002DB8 RID: 11704 RVA: 0x000CC5E4 File Offset: 0x000CA7E4
    public static double BoxMuller()
    {
        if (bool_1)
        {
            bool_1 = false;
            return double_0;
        }

        double num;
        double num2;
        double num3;
        do
        {
            num = 2.0 * random_0.NextDouble() - 1.0;
            num2 = 2.0 * random_0.NextDouble() - 1.0;
            num3 = num * num + num2 * num2;
        } while (num3 >= 1.0 || num3 == 0.0);

        num3 = Math.Sqrt(-2.0 * Math.Log(num3) / num3);
        double_0 = num2 * num3;
        bool_1 = true;
        return num * num3;
    }

    // Token: 0x06002DB9 RID: 11705 RVA: 0x000CC690 File Offset: 0x000CA890
    public static bool RemoveFromQueue<T>(T item, Queue<T> q)
    {
        var result = false;
        var queue = new Queue<T>();
        while (q.Count > 0)
        {
            var item2 = q.Dequeue();
            if (item2.Equals(item))
                result = true;
            else
                queue.Enqueue(item2);
        }

        while (queue.Count > 0) q.Enqueue(queue.Dequeue());
        return result;
    }

    // Token: 0x06002DBA RID: 11706 RVA: 0x000CC6F0 File Offset: 0x000CA8F0
    public static Mesh MakeFullScreenMesh(Camera cam)
    {
        var mesh = new Mesh
        {
            name = "Utils MakeFullScreenMesh"
        };
        cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3[] vertices =
        {
            cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)),
            cam.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)),
            cam.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)),
            cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f))
        };
        mesh.vertices = vertices;
        Vector2[] uv =
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(0f, 1f),
            new Vector2(1f, 1f)
        };
        mesh.uv = uv;
        int[] triangles =
        {
            2,
            1,
            0,
            2,
            3,
            1
        };
        mesh.triangles = triangles;
        return mesh;
    }

    // Token: 0x06002DBB RID: 11707 RVA: 0x000CC83B File Offset: 0x000CAA3B
    public static void ProcessException(Exception exception)
    {
        Debug.LogException(exception);
    }

    // Token: 0x06002DBC RID: 11708 RVA: 0x000CC844 File Offset: 0x000CAA44
    public static string LoadTextResource(string name)
    {
        var textAsset = Resources.Load<TextAsset>(name);
        if (textAsset == null) return null;
        var text = textAsset.text;
        Resources.UnloadAsset(textAsset);
        return text;
    }

    // Token: 0x06002DBD RID: 11709 RVA: 0x000CC874 File Offset: 0x000CAA74
    public static bool IsOnNavMesh(Vector3 v, float dist = 0.04f)
    {
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(v, out navMeshHit, dist, -1);
        return navMeshHit.hit;
    }

    // Token: 0x06002DC0 RID: 11712 RVA: 0x000CC8BA File Offset: 0x000CAABA
    public static void SetCanvasRestriction(this CanvasScaler scaler, float scaleFactor)
    {
        if (scaler == null) return;
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        scaler.referencePixelsPerUnit = 100f;
        scaler.scaleFactor = scaleFactor;
    }

    // Token: 0x06002DC2 RID: 11714 RVA: 0x000CC8F7 File Offset: 0x000CAAF7
    public static void UnloadAssetFromBundle(AssetBundle bundle)
    {
        bundle.Unload(true);
    }

    // Token: 0x06002DC3 RID: 11715 RVA: 0x000CC900 File Offset: 0x000CAB00
    public static void ClearTransform(this Transform t)
    {
        foreach (var obj in t) Object.Destroy(((Transform) obj).gameObject);
    }

    // Token: 0x06002DC4 RID: 11716 RVA: 0x000CC958 File Offset: 0x000CAB58
    public static void ClearTransformImmediate(this Transform t)
    {
        var list = new List<Transform>();
        foreach (var obj in t)
        {
            var item = (Transform) obj;
            list.Add(item);
        }

        var array = list.ToArray();
        for (var i = 0; i < array.Length; i++) Object.DestroyImmediate(array[i].gameObject);
    }

    // Token: 0x06002DC5 RID: 11717 RVA: 0x000CC9E0 File Offset: 0x000CABE0
    public static float AngOfNormazedVectors(Vector3 a, Vector3 b)
    {
        return Mathf.Acos(a.x * b.x + a.y * b.y + a.z * b.z) * 57.29578f;
    }

    // Token: 0x06002DC6 RID: 11718 RVA: 0x000CCA16 File Offset: 0x000CAC16
    public static float AngOfNormazedVectorsCoef(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    // Token: 0x06002DC7 RID: 11719 RVA: 0x000CCA41 File Offset: 0x000CAC41
    public static bool IsAngLessNormalized(Vector3 a, Vector3 b, float cos)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z > cos;
    }

    // Token: 0x06002DC8 RID: 11720 RVA: 0x000CCA70 File Offset: 0x000CAC70
    public static Vector3 NormalizeFast(Vector3 v)
    {
        var num = (float) Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        return new Vector3(v.x / num, v.y / num, v.z / num);
    }

    // Token: 0x06002DC9 RID: 11721 RVA: 0x000CCACC File Offset: 0x000CACCC
    public static Vector3 NormalizeFastSelf(Vector3 v)
    {
        var num = (float) Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        v.x /= num;
        v.y /= num;
        v.z /= num;
        return v;
    }

    // Token: 0x06002DCA RID: 11722 RVA: 0x000CCB38 File Offset: 0x000CAD38
    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    // Token: 0x06002DCB RID: 11723 RVA: 0x000CCB40 File Offset: 0x000CAD40
    public static Vector3 Rotate90(Vector3 n, SideTurn side)
    {
        if (side == SideTurn.left) return new Vector3(-n.z, n.y, n.x);
        return new Vector3(n.z, n.y, -n.x);
    }

    // Token: 0x06002DCC RID: 11724 RVA: 0x000CCB78 File Offset: 0x000CAD78
    public static Vector3 RotateVectorOnAngToZ(Vector3 d, float angDegree)
    {
        var vector = NormalizeFastSelf(d);
        var f = 0.0174532924f * angDegree;
        var num = Mathf.Cos(f);
        var y = Mathf.Sin(f);
        return new Vector3(vector.x * num, y, vector.z * num);
    }

    // Token: 0x06002DCD RID: 11725 RVA: 0x000CCBB8 File Offset: 0x000CADB8
    public static Vector3 RotateOnAngUp(Vector3 b, float angDegree)
    {
        var f = angDegree * 0.0174532924f;
        var num = Mathf.Sin(f);
        var num2 = Mathf.Cos(f);
        var x = b.x * num2 - b.z * num;
        var z = b.z * num2 + b.x * num;
        return new Vector3(x, 0f, z);
    }

    // Token: 0x06002DCE RID: 11726 RVA: 0x000CCC08 File Offset: 0x000CAE08
    public static Vector2 RotateOnAng(Vector2 b, float a)
    {
        var f = a * 0.0174532924f;
        var num = Mathf.Sin(f);
        var num2 = Mathf.Cos(f);
        var x = b.x * num2 - b.y * num;
        var y = b.y * num2 + b.x * num;
        return new Vector2(x, y);
    }

    // Token: 0x06002DD4 RID: 11732 RVA: 0x000CCD00 File Offset: 0x000CAF00
    public static float Length(this Quaternion quaternion)
    {
        return Mathf.Sqrt(quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z +
                          quaternion.w * quaternion.w);
    }

    // Token: 0x06002DD5 RID: 11733 RVA: 0x000CCD40 File Offset: 0x000CAF40
    public static void Normalize(this Quaternion quaternion)
    {
        var num = quaternion.Length();
        if (Mathf.Approximately(num, 1f)) return;
        if (Mathf.Approximately(num, 0f))
        {
            quaternion.Set(0f, 0f, 0f, 1f);
            return;
        }

        quaternion.Set(quaternion.x / num, quaternion.y / num, quaternion.z / num, quaternion.w / num);
    }

    // Token: 0x0400270D RID: 9997
    private static readonly Random random_0 = new Random();

    // Token: 0x0400270E RID: 9998
    private static bool bool_1 = true;

    // Token: 0x0400270F RID: 9999
    private static double double_0;

    // Token: 0x020006CC RID: 1740
    public enum SideTurn
    {
        // Token: 0x04002712 RID: 10002
        left,

        // Token: 0x04002713 RID: 10003
        right
    }
}