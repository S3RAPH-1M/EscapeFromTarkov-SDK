using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x020006D6 RID: 1750
public static class GClass778
{
	// Token: 0x06002DFC RID: 11772 RVA: 0x000CD12C File Offset: 0x000CB32C
	static GClass778()
	{
		GClass778.random_0 = new System.Random((int)DateTime.Now.Ticks);
	}

	// Token: 0x06002DFD RID: 11773 RVA: 0x000CD182 File Offset: 0x000CB382
	private static long smethod_0(long value, long min, long max)
	{
		if (value < min)
		{
			return min;
		}
		if (value <= max)
		{
			return value;
		}
		return max;
	}

	// Token: 0x06002DFE RID: 11774 RVA: 0x000CD191 File Offset: 0x000CB391
	public static string ToTimeString(this int seconds)
	{
		return GClass778.smethod_1((float)seconds);
	}

	// Token: 0x06002DFF RID: 11775 RVA: 0x000CD19A File Offset: 0x000CB39A
	public static string ToTimeString(this float seconds)
	{
		return GClass778.smethod_1(seconds);
	}

	// Token: 0x06002E00 RID: 11776 RVA: 0x000CD1A4 File Offset: 0x000CB3A4
	private static string smethod_1(float seconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds((double)seconds);
		return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, timeSpan.Minutes, timeSpan.Seconds);
	}

	// Token: 0x06002E01 RID: 11777 RVA: 0x000CD1E8 File Offset: 0x000CB3E8
	public static int RandomInclude(int a, int b)
	{
		b++;
		if (a > b)
		{
			return GClass778.random_0.Next(b, a);
		}
		return GClass778.random_0.Next(a, b);
	}

	// Token: 0x06002E02 RID: 11778 RVA: 0x000CD20E File Offset: 0x000CB40E
	public static int RandomSing()
	{
		if (GClass778.Random(0f, 100f) < 50f)
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06002E03 RID: 11779 RVA: 0x000CD22C File Offset: 0x000CB42C
	public static float Random(float a, float b)
	{
		float num = (float)GClass778.random_0.NextDouble();
		return a + (b - a) * num;
	}

	// Token: 0x06002E04 RID: 11780 RVA: 0x000CD24C File Offset: 0x000CB44C
	public static bool IsTrue100(float v)
	{
		return GClass778.Random(0f, 100f) < v;
	}

	// Token: 0x06002E05 RID: 11781 RVA: 0x000CD260 File Offset: 0x000CB460
	public static bool RandomBool(float chanceInPercent = 50f)
	{
		return GClass778.IsTrue100(chanceInPercent);
	}

	// Token: 0x06002E06 RID: 11782 RVA: 0x000CD268 File Offset: 0x000CB468
	public static T ParseEnum<T>(this string value)
	{
		return (T)((object)Enum.Parse(typeof(T), value, true));
	}

	// Token: 0x06002E07 RID: 11783 RVA: 0x000CD280 File Offset: 0x000CB480
	public static List<T> Shuffle<T>(this List<T> l)
	{
		return l.OrderBy(new Func<T, float>(GClass778.Class358<T>.class358_0.method_0)).ToList<T>();
	}

	// Token: 0x06002E09 RID: 11785 RVA: 0x000CD2D8 File Offset: 0x000CB4D8
	public static float SqrDistance(this Vector3 a, Vector3 b)
	{
		Vector3 vector = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
		return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
	}

	// Token: 0x06002E0A RID: 11786 RVA: 0x000CD33C File Offset: 0x000CB53C
	public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Quaternion Angle)
	{
		return Angle * (Point - Pivot) + Pivot;
	}

	// Token: 0x06002E0B RID: 11787 RVA: 0x000CD351 File Offset: 0x000CB551
	public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Vector3 Euler)
	{
		return Point.RotateAroundPivot(Pivot, Quaternion.Euler(Euler));
	}

	// Token: 0x06002E0C RID: 11788 RVA: 0x000CD360 File Offset: 0x000CB560
	public static void RotateAroundPivot(this Transform Me, Vector3 Pivot, Quaternion Angle)
	{
		Me.position = Me.position.RotateAroundPivot(Pivot, Angle);
	}

	// Token: 0x06002E0D RID: 11789 RVA: 0x000CD375 File Offset: 0x000CB575
	public static void RotateAroundPivot(this Transform Me, Vector3 Pivot, Vector3 Euler)
	{
		Me.position = Me.position.RotateAroundPivot(Pivot, Quaternion.Euler(Euler));
	}

	// Token: 0x06002E0E RID: 11790 RVA: 0x000CD390 File Offset: 0x000CB590
	public static float NextFloat(this System.Random random, int min, int max)
	{
		float num = (float)(random.NextDouble() * 2.0 - 1.0);
		double num2 = Math.Pow(2.0, (double)random.Next(min, max));
		return (float)((double)num * num2);
	}

	// Token: 0x06002E0F RID: 11791 RVA: 0x000CD3D2 File Offset: 0x000CB5D2
	public static void SetUnlockStatus(this CanvasGroup group, bool value, bool setRaycast = true)
	{
		group.alpha = (value ? 1f : 0.3f);
		group.interactable = value;
		if (setRaycast)
		{
			group.blocksRaycasts = value;
		}
	}

	// Token: 0x06002E10 RID: 11792 RVA: 0x000CD3FA File Offset: 0x000CB5FA
	public static string SubstringIfNecessary(this string @string, int count)
	{
		if (string.IsNullOrEmpty(@string))
		{
			return string.Empty;
		}
		if (@string.Length <= count)
		{
			return @string;
		}
		return @string.Substring(0, count - 2) + "...";
	}

	// Token: 0x06002E11 RID: 11793 RVA: 0x000CD429 File Offset: 0x000CB629
	public static string Prefix(this float value)
	{
		if (!value.Positive())
		{
			return string.Empty;
		}
		return "+";
	}

	// Token: 0x06002E12 RID: 11794 RVA: 0x000CD43E File Offset: 0x000CB63E
	public static string LevelFormat(this int level)
	{
		if (level <= 10)
		{
			return "0" + level;
		}
		return level.ToString();
	}

	// Token: 0x06002E13 RID: 11795 RVA: 0x000CD45D File Offset: 0x000CB65D
	public static string WithPrefix(this float value, string ending = "")
	{
		return value.Prefix() + value.ToString(CultureInfo.InvariantCulture) + ending;
	}

	// Token: 0x06002E14 RID: 11796 RVA: 0x000CD478 File Offset: 0x000CB678
	public static string ColoredWithPrefix(this float value, bool positive, string ending = "")
	{
		string text = value.WithPrefix(ending);
		if (!value.IsZero())
		{
			Color32 c = positive ? GClass778.color32_0 : GClass778.color32_1;
			text = string.Concat(new string[]
			{
				"<color=#",
				ColorUtility.ToHtmlStringRGBA(c),
				">",
				text,
				"</color>"
			});
		}
		return text;
	}

	// Token: 0x06002E15 RID: 11797 RVA: 0x000CD4DC File Offset: 0x000CB6DC
	public static string SubstringIfNecessary(this int @int)
	{
		if (@int <= 99)
		{
			return @int.ToString();
		}
		return "> 99";
	}

	// Token: 0x06002E16 RID: 11798 RVA: 0x000CD4F0 File Offset: 0x000CB6F0
	public static string RemoveAllNewLines(this string @string)
	{
		return @string.Replace('\n', '\0');
	}

	// Token: 0x06002E17 RID: 11799 RVA: 0x000CD4FB File Offset: 0x000CB6FB
	public static void ForceAddValue<T, W>(this Dictionary<T, W> d, T k, W v)
	{
		if (d.ContainsKey(k))
		{
			d[k] = v;
			return;
		}
		d.Add(k, v);
	}

	// Token: 0x06002E18 RID: 11800 RVA: 0x000CD517 File Offset: 0x000CB717
	public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
	{
		return source.OrderBy(new Func<T, int>(GClass778.Class359<T>.class359_0.method_0));
	}

	// Token: 0x06002E19 RID: 11801 RVA: 0x000CD540 File Offset: 0x000CB740
	public static IEnumerable<T> Shift<T>(this IEnumerable<T> source, int offset)
	{
		GClass778.Class360<T> @class = new GClass778.Class360<T>();
		@class.offset = offset;
		@class.index = 0;
		@class.length = source.Count<T>();
		@class.offset %= @class.length;
		return source.OrderBy(new Func<T, int>(@class.method_0));
	}

	// Token: 0x06002E1B RID: 11803 RVA: 0x000CD5AC File Offset: 0x000CB7AC
	public static List<T> ApplyFilter<T>(this List<T> list, Func<T, bool> predicate)
	{
		if (list == null)
		{
			return null;
		}
		int i = 0;
		while (i < list.Count)
		{
			T arg = list[i];
			if (predicate(arg))
			{
				i++;
			}
			else
			{
				list.RemoveAt(i);
			}
		}
		return list;
	}

	// Token: 0x06002E1C RID: 11804 RVA: 0x000CD5EC File Offset: 0x000CB7EC
	public static List<T> ApplyFilter<T>(this List<T> list, int maxCount, Func<T, bool> predicate)
	{
		if (list == null)
		{
			return null;
		}
		int num = 0;
		int i = 0;
		while (i < list.Count)
		{
			T arg = list[i];
			bool flag = false;
			if (num < maxCount)
			{
				flag = predicate(arg);
			}
			if (flag)
			{
				num++;
				i++;
			}
			else
			{
				list.RemoveAt(i);
			}
		}
		return list;
	}

	// Token: 0x06002E1D RID: 11805 RVA: 0x000CD638 File Offset: 0x000CB838
	[CanBeNull]
	public static T RandomElement<T>(this IReadOnlyList<T> list)
	{
		if (list.Count == 0)
		{
			return default(T);
		}
		int index = GClass778.random_0.Next(0, list.Count);
		return list[index];
	}

	// Token: 0x06002E1E RID: 11806 RVA: 0x000CD670 File Offset: 0x000CB870
	public static IList<T> RandomElement<T>(this IReadOnlyList<T> list, int count)
	{
		List<T> list2 = new List<T>();
		if (list.Count == 0)
		{
			return list2;
		}
		if (list.Count > count)
		{
			list2 = list.ToList<T>();
			int num = list2.Count - count;
			for (int i = 0; i < num; i++)
			{
				T item = list2.RandomElement<T>();
				list2.Remove(item);
			}
			return list2;
		}
		if (list.Count == count)
		{
			return list.ToList<T>();
		}
		Debug.LogError("not implemented yet");
		return list.ToList<T>();
	}

	// Token: 0x06002E1F RID: 11807 RVA: 0x000CD6E4 File Offset: 0x000CB8E4
	public static IList<T> RandomElement<T>(this IReadOnlyList<T> list, Func<T, bool> condition, int count)
	{
		List<T> list2 = new List<T>();
		if (list.Count == 0)
		{
			return list2;
		}
		if (list.Count > count)
		{
			list2 = list.ToList<T>();
			int num = list2.Count - count;
			for (int i = 0; i < num; i++)
			{
				T item = list2.Where(condition).RandomElement<T>();
				list2.Remove(item);
			}
			return list2;
		}
		if (list.Count == count)
		{
			return list.ToList<T>();
		}
		Debug.LogError("not implemented yet");
		return list.ToList<T>();
	}

	// Token: 0x06002E20 RID: 11808 RVA: 0x000CD760 File Offset: 0x000CB960
	public static IList<T> ShakeElements<T>(this IReadOnlyList<T> list, int count)
	{
		List<T> list2 = new List<T>();
		System.Random random = new System.Random();
		for (int i = 0; i < count; i++)
		{
			int num = random.Next(list2.Count + 1);
			if (num == list2.Count)
			{
				list2.Add(list[i]);
			}
			else
			{
				list2.Add(list2[num]);
				list2[num] = list[i];
			}
		}
		return list2;
	}

	// Token: 0x06002E21 RID: 11809 RVA: 0x000CD7C8 File Offset: 0x000CB9C8
	public static IList<T> ShakeElements<T>(this List<T> list)
	{
		return list.ShakeElements(list.Count);
	}

	// Token: 0x06002E22 RID: 11810 RVA: 0x000CCB40 File Offset: 0x000CAD40
	public static Vector3 Rotate90(Vector3 n, GClass778.ESideTurn side)
	{
		if (side == GClass778.ESideTurn.Left)
		{
			return new Vector3(-n.z, n.y, n.x);
		}
		return new Vector3(n.z, n.y, -n.x);
	}

	// Token: 0x06002E23 RID: 11811 RVA: 0x000CD7D6 File Offset: 0x000CB9D6
	public static Vector3 Rotate90(Vector3 n, int side)
	{
		if (side != 1)
		{
			return new Vector3(n.z, n.y, -n.x);
		}
		return new Vector3(-n.z, n.y, n.x);
	}

	// Token: 0x06002E24 RID: 11812 RVA: 0x000CD80D File Offset: 0x000CBA0D
	[CanBeNull]
	public static T RandomElement<T>(this IEnumerable<T> list)
	{
		return list.ToList<T>().RandomElement<T>();
	}

	// Token: 0x06002E25 RID: 11813 RVA: 0x000CD81A File Offset: 0x000CBA1A
	public static void ForceAddValue<T>(this List<T> l, T v)
	{
		if (!l.Contains(v))
		{
			l.Add(v);
		}
	}

	// Token: 0x06002E26 RID: 11814 RVA: 0x000CD82C File Offset: 0x000CBA2C
	public static string SplitCurrencyNumber(this int number, string delimiter = " ")
	{
		return ((float)number).SplitCurrencyNumber(delimiter);
	}

	// Token: 0x06002E27 RID: 11815 RVA: 0x000CD838 File Offset: 0x000CBA38
	public static string SplitCurrencyNumber(this float number, string delimiter = " ")
	{
		NumberFormatInfo provider = new NumberFormatInfo
		{
			NumberGroupSeparator = delimiter
		};
		return number.ToString("N0", provider);
	}

	// Token: 0x06002E28 RID: 11816 RVA: 0x000CD860 File Offset: 0x000CBA60
	public static string SplitNumber(long number, string delimiter = " ", int count = 3)
	{
		StringBuilder stringBuilder = new StringBuilder(number.ToString());
		if (stringBuilder.Length > count)
		{
			for (int i = stringBuilder.Length - count; i > 0; i -= count)
			{
				stringBuilder = stringBuilder.Insert(i, delimiter);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06002E29 RID: 11817 RVA: 0x000CD8A8 File Offset: 0x000CBAA8
	public static void SearchTransform<T>(Transform transform, List<T> findObjects) where T : Behaviour
	{
		if (transform == null)
		{
			return;
		}
		T component = transform.gameObject.GetComponent<T>();
		if (component != null)
		{
			findObjects.Add(component);
		}
		foreach (object obj in transform)
		{
			GClass778.SearchTransform<T>((Transform)obj, findObjects);
		}
	}

	// Token: 0x06002E2A RID: 11818 RVA: 0x000CD928 File Offset: 0x000CBB28
	public static float GreateRandom(float val)
	{
		return val * GClass778.Random(0.8f, 1.2f);
	}

	// Token: 0x06002E2B RID: 11819 RVA: 0x000CD93B File Offset: 0x000CBB3B
	public static float GreateRandom(float val, float fraction)
	{
		return val * GClass778.Random(1f - fraction, 1f + fraction);
	}

	// Token: 0x06002E2C RID: 11820 RVA: 0x000CD952 File Offset: 0x000CBB52
	public static float GreateRandom(int val)
	{
		return (float)((int)((float)val * GClass778.Random(0.8f, 1.2f)));
	}

	// Token: 0x06002E2D RID: 11821 RVA: 0x000CD968 File Offset: 0x000CBB68
	public static Delegate CreateDelegate(this MethodInfo methodInfo, object target)
	{
		bool flag = methodInfo.ReturnType.Equals(typeof(void));
		IEnumerable<Type> enumerable = methodInfo.GetParameters().Select(new Func<ParameterInfo, Type>(GClass778.Class362.class362_0.method_0));
		Func<Type[], Type> func;
		if (flag)
		{
			func = new Func<Type[], Type>(Expression.GetActionType);
		}
		else
		{
			func = new Func<Type[], Type>(Expression.GetFuncType);
			enumerable = enumerable.Concat(new Type[]
			{
				methodInfo.ReturnType
			});
		}
		if (methodInfo.IsStatic)
		{
			return Delegate.CreateDelegate(func(enumerable.ToArray<Type>()), methodInfo);
		}
		return Delegate.CreateDelegate(func(enumerable.ToArray<Type>()), target, methodInfo.Name);
	}

	// Token: 0x06002E2E RID: 11822 RVA: 0x000CDA1C File Offset: 0x000CBC1C
	public static int ParseToInt(this string str)
	{
		if (str == "∞")
		{
			return 0;
		}
		int result = 0;
		if (!int.TryParse(str, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06002E2F RID: 11823 RVA: 0x000CDA47 File Offset: 0x000CBC47
	public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
	{
		key = kvp.Key;
		value = kvp.Value;
	}

	// Token: 0x06002E30 RID: 11824 RVA: 0x000CDA64 File Offset: 0x000CBC64
	public static bool StartsWith(this string test, IEnumerable<string> variations)
	{
		foreach (string value in variations)
		{
			if (test.StartsWith(value, StringComparison.InvariantCulture))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002E31 RID: 11825 RVA: 0x000CDAB8 File Offset: 0x000CBCB8
	public static void ExecuteForEach<TKey, TValue>([NotNull] this IReadOnlyDictionary<TKey, TValue> dictionary, [NotNull] Action<TKey, TValue> action)
	{
		foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
		{
			TKey tkey;
			TValue tvalue;
			kvp.Deconstruct(out tkey, out tvalue);
			TKey arg = tkey;
			TValue arg2 = tvalue;
			action(arg, arg2);
		}
	}

	// Token: 0x06002E32 RID: 11826 RVA: 0x000CDB10 File Offset: 0x000CBD10
	public static void ExecuteForEach<T>([NotNull] this IEnumerable<T> collection, [NotNull] Action<T> action)
	{
		foreach (T obj in collection)
		{
			action(obj);
		}
	}

	// Token: 0x06002E33 RID: 11827 RVA: 0x000CDB5C File Offset: 0x000CBD5C
	public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
	{
		return collection == null || !collection.Any<T>();
	}

	// Token: 0x06002E34 RID: 11828 RVA: 0x000CDB6C File Offset: 0x000CBD6C
	public static void SetCount<T>(this List<T> list, int count)
	{
		int count2 = list.Count;
		int num = count - count2;
		if (num == 0)
		{
			return;
		}
		if (num > 0)
		{
			if (list.Capacity < count)
			{
				list.Capacity = count;
			}
			for (int i = 0; i < num; i++)
			{
				list.Add(default(T));
			}
			return;
		}
		num = -num;
		list.RemoveRange(count2 - num, num);
	}

	// Token: 0x0400272C RID: 10028
	private static System.Random random_0;

	// Token: 0x0400272D RID: 10029
	private static readonly Color32 color32_0 = new Color32(84, 193, byte.MaxValue, byte.MaxValue);

	// Token: 0x0400272E RID: 10030
	private static readonly Color32 color32_1 = new Color32(196, 0, 0, byte.MaxValue);

	// Token: 0x020006D7 RID: 1751
	public enum ESideTurn
	{
		// Token: 0x04002730 RID: 10032
		Left,
		// Token: 0x04002731 RID: 10033
		Right
	}

	// Token: 0x020006D8 RID: 1752
	[CompilerGenerated]
	[Serializable]
	private sealed class Class358<T>
	{
		// Token: 0x06002E37 RID: 11831 RVA: 0x0007A88D File Offset: 0x00078A8D
		internal float method_0(T x)
		{
			return GClass778.Random(0f, 5f);
		}

		// Token: 0x04002732 RID: 10034
		public static readonly GClass778.Class358<T> class358_0 = new GClass778.Class358<T>();

		// Token: 0x04002733 RID: 10035
		public static Func<T, float> func_0;
	}

	// Token: 0x020006D9 RID: 1753
	[CompilerGenerated]
	[Serializable]
	private sealed class Class359<T>
	{
		// Token: 0x06002E3A RID: 11834 RVA: 0x000CDBDD File Offset: 0x000CBDDD
		internal int method_0(T item)
		{
			return GClass778.random_0.Next(0, 1000);
		}

		// Token: 0x04002734 RID: 10036
		public static readonly GClass778.Class359<T> class359_0 = new GClass778.Class359<T>();

		// Token: 0x04002735 RID: 10037
		public static Func<T, int> func_0;
	}

	// Token: 0x020006DA RID: 1754
	[CompilerGenerated]
	private sealed class Class360<T>
	{
		// Token: 0x06002E3C RID: 11836 RVA: 0x000CDBF0 File Offset: 0x000CBDF0
		internal int method_0(T item)
		{
			int num = this.offset + this.index;
			int num2 = this.index + 1;
			this.index = num2;
			if (num >= this.length)
			{
				num -= this.length;
			}
			else if (num < 0)
			{
				num += this.length;
			}
			return num;
		}

		// Token: 0x04002736 RID: 10038
		public int offset;

		// Token: 0x04002737 RID: 10039
		public int index;

		// Token: 0x04002738 RID: 10040
		public int length;
	}

	// Token: 0x020006DC RID: 1756
	[CompilerGenerated]
	[Serializable]
	private sealed class Class362
	{
		// Token: 0x06002E48 RID: 11848 RVA: 0x000CDDEF File Offset: 0x000CBFEF
		internal Type method_0(ParameterInfo p)
		{
			return p.ParameterType;
		}

		// Token: 0x04002742 RID: 10050
		public static readonly GClass778.Class362 class362_0 = new GClass778.Class362();

		// Token: 0x04002743 RID: 10051
		public static Func<ParameterInfo, Type> func_0;
	}
}
