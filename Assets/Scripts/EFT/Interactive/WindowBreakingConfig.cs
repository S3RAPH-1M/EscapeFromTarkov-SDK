using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EFT.Interactive
{
	public class WindowBreakingConfig : ScriptableObject
	{
		[Serializable]
		public class Polygon
		{
			public Vector2[] Points;

			public float[] Distances;

			public float[] RandomRanges;

			public float Mass;

			public bool Intersects;

			public Polygon(Vector2[] points, float mass)
			{
				Points = points;
				Mass = mass;
			}

			public Polygon CutPolygon(Vector4 box)
			{
				bool noIntersects;
				return new Polygon(smethod_5(Points, box, out noIntersects), Mass)
				{
					Intersects = !noIntersects
				};
			}

			public Polygon CutPolygon(Vector4 box, Vector2 xAxis)
			{
				bool noIntersects;
				return new Polygon(smethod_5(smethod_4(Points, xAxis), box, out noIntersects), Mass)
				{
					Intersects = !noIntersects
				};
			}

			public void DebugDraw(Color color)
			{
				if (Points != null && Points.Length >= 3)
				{
					Vector2 vector = Points[Points.Length - 1];
					for (int i = 0; i < Points.Length; i++)
					{
						Debug.DrawLine(vector, Points[i], color);
						vector = Points[i];
					}
				}
			}
		}

		[Serializable]
		public class Crack
		{
			public Polygon[] Polygons;

			public bool GetFromSelectedMeshes;

			public float Scale = 1f;

			public GameObject Glass;
		}

		public class GClass2612
		{
			public int[] Triangles;

			public Vector3[] Vertices;

			public Vector3[] Normals;

			public Vector2[] Uv;

			public Mesh GetMesh(Vector2 center)
			{
				Vector3[] array = new Vector3[Vertices.Length];
				for (int i = 0; i < array.Length; i++)
				{
					Vector3 vector = Vertices[i];
					array[i] = new Vector3(vector.x - center.x, vector.y - center.y, vector.z);
				}
				return new Mesh
				{
					vertices = array,
					triangles = Triangles,
					normals = Normals,
					uv = Uv,
					name = "WindowBreakingConfig GetMesh"
				};
			}
		}

		private static readonly List<Vector2> list_0 = new List<Vector2>(512);

		private static readonly List<Vector2> list_1 = new List<Vector2>(512);

		public Crack[] Cracks;

		private const int int_0 = 128;

		private static Vector2[] vector2_0;

		private static int int_1;

		private void OnValidate()
		{
		}

		public static Mesh GenerateMesh(Vector2[] points, Vector2 center, float halfWith)
		{
			if (points != null && points.Length >= 3)
			{
				int num = points.Length - 2;
				int num2 = points.Length << 1;
				int[] array = new int[(num2 + (num << 1)) * 3];
				Vector3[] array2 = new Vector3[num2];
				Vector3[] array3 = new Vector3[array2.Length];
				int num3 = num * 3;
				int num4 = points.Length;
				int i = 2;
				int num5 = 0;
				for (; i < num4; i++)
				{
					int num6 = num5++;
					int num7 = num5++;
					int num8 = num5++;
					array[num6] = 0;
					array[num8] = i - 1;
					array[num7] = i;
					array[num6 + num3] = num4;
					array[num7 + num3] = i - 1 + num4;
					array[num8 + num3] = i + num4;
				}
				int num9 = num4 - 1;
				int j = 0;
				int num10 = num3 << 1;
				for (; j < num4; j++)
				{
					int num11 = j;
					int num12 = j + 1;
					int num13 = j + num4;
					int num14 = num13 + 1;
					if (j == num9)
					{
						num12 -= num4;
						num14 -= num4;
					}
					array[num10++] = num11;
					array[num10++] = num12;
					array[num10++] = num14;
					array[num10++] = num14;
					array[num10++] = num13;
					array[num10++] = num11;
				}
				for (int k = 0; k < num4; k++)
				{
					Vector2 vector = points[k] - center;
					array2[k] = new Vector3(vector.x, vector.y, halfWith);
					array2[k + num4] = new Vector3(vector.x, vector.y, 0f - halfWith);
					array3[k] = new Vector3(0f, 0f, 1f);
					array3[k + num4] = new Vector3(0f, 0f, -1f);
				}
				return new Mesh
				{
					vertices = array2,
					triangles = array,
					normals = array3,
					name = "WindowBreakingConfig GenerateMesh"
				};
			}
			return null;
		}

		public static Mesh GenerateMesh(Vector2[] points, Vector2 center, bool swap, Vector2 uvMult, Vector2 uvAdd, Vector2 zSurfs)
		{
			if (points != null && points.Length >= 3)
			{
				int num = points.Length - 2;
				int num2 = points.Length << 1;
				int[] array = new int[(num2 + (num << 1)) * 3];
				Vector3[] array2 = new Vector3[num2];
				Vector3[] array3 = new Vector3[array2.Length];
				Vector2[] array4 = new Vector2[array2.Length];
				int num3 = num * 3;
				int num4 = points.Length;
				int i = 2;
				int num5 = 0;
				for (; i < num4; i++)
				{
					int num6 = num5++;
					int num7 = num5++;
					int num8 = num5++;
					array[num6] = 0;
					array[num8] = i - 1;
					array[num7] = i;
					array[num6 + num3] = num4;
					array[num7 + num3] = i - 1 + num4;
					array[num8 + num3] = i + num4;
				}
				int num9 = num4 - 1;
				int j = 0;
				int num10 = num3 << 1;
				for (; j < num4; j++)
				{
					int num11 = j;
					int num12 = j + 1;
					int num13 = j + num4;
					int num14 = num13 + 1;
					if (j == num9)
					{
						num12 -= num4;
						num14 -= num4;
					}
					array[num10++] = num11;
					array[num10++] = num12;
					array[num10++] = num14;
					array[num10++] = num14;
					array[num10++] = num13;
					array[num10++] = num11;
				}
				for (int k = 0; k < num4; k++)
				{
					int num15 = k + num4;
					Vector2 vector = points[k] - center;
					array2[k] = new Vector3(vector.x, vector.y, zSurfs.x);
					array2[num15] = new Vector3(vector.x, vector.y, zSurfs.y);
					array3[k] = new Vector3(0f, 0f, 1f);
					array3[num15] = new Vector3(0f, 0f, -1f);
					vector = points[k];
					array4[k] = Vector2.Scale(vector, uvMult) + uvAdd;
					array4[num15] = array4[k];
				}
				return new Mesh
				{
					vertices = array2,
					triangles = array,
					normals = array3,
					uv = array4,
					name = "WindowBreakingConfig GenerateMesh"
				};
			}
			return null;
		}

		public static GClass2612 GenerateMeshPice(Vector2[] points, bool swap, Vector2 uvMult, Vector2 uvAdd, Vector2 zSurfs, float edgesWidth)
		{
			if (points != null && points.Length >= 3)
			{
				if (vector2_0 == null)
				{
					vector2_0 = smethod_11(128);
				}
				int num = points.Length - 2;
				int num2 = points.Length << 1;
				int[] array = new int[(num2 + (num << 1)) * 3];
				Vector3[] array2 = new Vector3[num2];
				Vector3[] array3 = new Vector3[array2.Length];
				Vector2[] array4 = new Vector2[array2.Length];
				int num3 = num * 3;
				int num4 = points.Length;
				int i = 2;
				int num5 = 0;
				for (; i < num4; i++)
				{
					int num6 = num5++;
					int num7 = num5++;
					int num8 = num5++;
					array[num6] = 0;
					array[num8] = i - 1;
					array[num7] = i;
					array[num6 + num3] = num4;
					array[num7 + num3] = i - 1 + num4;
					array[num8 + num3] = i + num4;
				}
				int num9 = num4 - 1;
				int j = 0;
				int num10 = num3 << 1;
				for (; j < num4; j++)
				{
					int num11 = j;
					int num12 = j + 1;
					int num13 = j + num4;
					int num14 = num13 + 1;
					if (j == num9)
					{
						num12 -= num4;
						num14 -= num4;
					}
					array[num10++] = num11;
					array[num10++] = num12;
					array[num10++] = num14;
					array[num10++] = num14;
					array[num10++] = num13;
					array[num10++] = num11;
				}
				for (int k = 0; k < num4; k++)
				{
					int num15 = k + num4;
					Vector2 a = points[k];
					float num16 = Math.Max(0f, edgesWidth - Math.Abs(a.x) * edgesWidth);
					float num17 = Math.Max(0f, edgesWidth - Math.Abs(a.y) * edgesWidth);
					Vector2 vector = vector2_0[int_1++ % 128];
					array2[k] = new Vector3(a.x, a.y, zSurfs.x);
					array2[num15] = new Vector3(a.x + vector.x * num16, a.y + vector.y * num17, zSurfs.y);
					array3[k] = new Vector3(0f, 0f, -1f);
					array3[num15] = new Vector3(0f, 0f, 1f);
					array4[k] = Vector2.Scale(a, uvMult) + uvAdd;
					array4[num15] = array4[k];
				}
				return new GClass2612
				{
					Vertices = array2,
					Triangles = array,
					Normals = array3,
					Uv = array4
				};
			}
			return null;
		}

		public static Mesh CombineMeshPieces(GClass2612[] pieces)
		{
			int num = 0;
			int num2 = 0;
			foreach (GClass2612 gClass in pieces)
			{
				num += gClass.Vertices.Length;
				num2 += gClass.Triangles.Length;
			}
			int[] array = new int[num2];
			Vector3[] array2 = new Vector3[num];
			Vector3[] array3 = new Vector3[num];
			Vector2[] array4 = new Vector2[num];
			int num3 = 0;
			int num4 = 0;
			foreach (GClass2612 gClass2 in pieces)
			{
				gClass2.Vertices.CopyTo(array2, num3);
				gClass2.Normals.CopyTo(array3, num3);
				gClass2.Uv.CopyTo(array4, num3);
				for (int k = 0; k < gClass2.Triangles.Length; k++)
				{
					array[num4++] = gClass2.Triangles[k] + num3;
				}
				num3 += gClass2.Vertices.Length;
			}
			return new Mesh
			{
				vertices = array2,
				triangles = array,
				normals = array3,
				uv = array4,
				name = "WindowBreakingConfig CombineMeshPieces"
			};
		}

		public static Polygon GetPolygonFormMesh(Mesh mesh, float scale)
		{
			Vector3[] vertices = mesh.vertices;
			int[] triangles = mesh.triangles;
			smethod_10(vertices, out var axisX, out var axisY);
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] *= scale;
			}
			HashSet<int>[] array = new HashSet<int>[vertices.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = new HashSet<int>();
			}
			int num = triangles.Length / 3;
			int k = 0;
			int num2 = 0;
			for (; k < num; k++)
			{
				int num3 = triangles[num2++];
				int num4 = triangles[num2++];
				int num5 = triangles[num2++];
				if (!array[num3].Add(num4))
				{
					array[num3].Remove(num4);
				}
				if (!array[num3].Add(num5))
				{
					array[num3].Remove(num5);
				}
				if (!array[num4].Add(num3))
				{
					array[num4].Remove(num3);
				}
				if (!array[num4].Add(num5))
				{
					array[num4].Remove(num5);
				}
				if (!array[num5].Add(num3))
				{
					array[num5].Remove(num3);
				}
				if (!array[num5].Add(num4))
				{
					array[num5].Remove(num4);
				}
			}
			Vector2 vector = Vector3.zero;
			Vector3[] array2 = vertices;
			for (int l = 0; l < array2.Length; l++)
			{
				Vector3 vector2 = array2[l];
				vector += new Vector2(vector2[axisX], vector2[axisY]);
			}
			vector /= (float)vertices.Length;
			int[] array3 = new int[vertices.Length];
			array3[0] = 0;
			int[] array4 = new int[2];
			array[0].CopyTo(array4);
			array3[1] = array4[0];
			Vector2 vector3 = new Vector2(vertices[0][axisX], vertices[0][axisY]);
			Vector2 vector4 = new Vector2(vertices[array4[0]][axisX], vertices[array4[0]][axisY]) - vector3;
			vector4 = new Vector2(vector4.y, 0f - vector4.x);
			Vector2 rhs = vector - vector3;
			if (Vector2.Dot(vector4, rhs) < 0f)
			{
				array3[1] = array4[0];
			}
			else
			{
				array3[1] = array4[1];
			}
			for (int m = 2; m < array3.Length; m++)
			{
				int num6 = array3[m - 1];
				int num7 = array3[m - 2];
				int[] array5 = new int[2];
				array[num6].CopyTo(array5);
				if (array5[0] == num7)
				{
					array3[m] = array5[1];
				}
				else if (array5[1] == num7)
				{
					array3[m] = array5[0];
				}
				else
				{
					Debug.Log("Error");
				}
			}
			Vector2[] array6 = new Vector2[vertices.Length];
			for (int n = 0; n < array6.Length; n++)
			{
				Vector3 vector5 = vertices[array3[n]];
				array6[n] = new Vector2(vector5[axisX], vector5[axisY]);
			}
			return new Polygon(array6, smethod_9(array6));
		}

		private static int smethod_0(ref Vector2 p0, ref Vector2 p1, Vector4 box)
		{
			Vector2 vector = p1 - p0;
			bool flag = true;
			if (p0.x < box.x)
			{
				if (p1.x < box.x)
				{
					return -1;
				}
				p0 = new Vector2(box.x, p0.y + vector.y * (box.x - p0.x) / vector.x);
				flag = false;
			}
			if (p0.x > box.z)
			{
				if (p1.x > box.z)
				{
					return -1;
				}
				p0 = new Vector2(box.z, p0.y + vector.y * (box.z - p0.x) / vector.x);
				flag = false;
			}
			if (p0.y < box.y)
			{
				if (p1.y < box.y)
				{
					return -1;
				}
				p0 = new Vector2(p0.x + vector.x * (box.y - p0.y) / vector.y, box.y);
				flag = false;
			}
			if (p0.y > box.w)
			{
				if (p1.y > box.w)
				{
					return -1;
				}
				p0 = new Vector2(p0.x + vector.x * (box.w - p0.y) / vector.y, box.w);
				flag = false;
			}
			if (p1.x < box.x)
			{
				p1 = new Vector2(box.x, p1.y + vector.y * (box.x - p1.x) / vector.x);
				flag = false;
			}
			if (p1.x > box.z)
			{
				p1 = new Vector2(box.z, p1.y + vector.y * (box.z - p1.x) / vector.x);
				flag = false;
			}
			if (p1.y < box.y)
			{
				p1 = new Vector2(p1.x + vector.x * (box.y - p1.y) / vector.y, box.y);
				flag = false;
			}
			if (p1.y > box.w)
			{
				p1 = new Vector2(p1.x + vector.x * (box.w - p1.y) / vector.y, box.w);
				flag = false;
			}
			if (!flag)
			{
				return 0;
			}
			return 1;
		}

		private static int smethod_1(ref Vector2 p0, ref Vector2 p1, bool xAxis, bool positive, float value)
		{
			Vector2 vector = p1 - p0;
			int index = ((!xAxis) ? 1 : 0);
			int index2 = (xAxis ? 1 : 0);
			bool num = (positive ? (p0[index] < value) : (p0[index] > value));
			bool flag = (positive ? (p1[index] < value) : (p1[index] > value));
			if (num)
			{
				if (flag)
				{
					return -1;
				}
				p0[index2] += vector[index2] * (value - p0[index]) / vector[index];
				p0[index] = value;
				return 0;
			}
			if (flag)
			{
				p1[index2] += vector[index2] * (value - p1[index]) / vector[index];
				p1[index] = value;
				return 0;
			}
			return 1;
		}

		private static Vector2 smethod_2(Vector2 pIn, Vector2 pOut, bool xAxis, float value)
		{
			Vector2 vector = pOut - pIn;
			if (xAxis)
			{
				pOut.y += vector.y * (value - pOut.x) / vector.x;
				pOut.x = value;
			}
			else
			{
				pOut.x += vector.x * (value - pOut.y) / vector.y;
				pOut.y = value;
			}
			return pOut;
		}

		private static void smethod_3(List<Vector2> newList, List<Vector2> points, bool xAxis, bool positive, float value)
		{
			int count = points.Count;
			Vector2 vector = points[count - 1];
			int index = ((!xAxis) ? 1 : 0);
			bool flag = positive == vector[index] < value;
			for (int i = 0; i < count; i++)
			{
				Vector2 vector2 = points[i];
				bool flag2 = positive == vector2[index] < value;
				if (flag == flag2)
				{
					if (!flag2)
					{
						newList.Add(vector2);
					}
				}
				else if (flag2)
				{
					newList.Add(smethod_2(vector, vector2, xAxis, value));
				}
				else
				{
					newList.Add(smethod_2(vector2, vector, xAxis, value));
					newList.Add(vector2);
				}
				vector = vector2;
				flag = flag2;
			}
		}

		public static Vector2 GetXAxis(float angle)
		{
			float f = angle * ((float)Math.PI * 2f);
			return new Vector2(y: Mathf.Sin(f), x: Mathf.Cos(f));
		}

		private static Vector2[] smethod_4(Vector2[] points, Vector2 xAxis)
		{
			Vector2[] array = new Vector2[points.Length];
			float x = xAxis.x;
			float y = xAxis.y;
			float num = 0f - y;
			for (int i = 0; i < points.Length; i++)
			{
				float x2 = points[i].x;
				float y2 = points[i].y;
				array[i].x = x2 * x + y2 * num;
				array[i].y = x2 * y + y2 * x;
			}
			return array;
		}

		private static Vector2[] smethod_5(Vector2[] points, Vector4 box, out bool noIntersects)
		{
			List<Vector2> list = points.ToList();
			noIntersects = true;
			bool flag = true;
			switch (smethod_7(list, xAxis: true, positive: true, box.x))
			{
			case 0:
			{
				List<Vector2> list2 = list_0;
				list2.Clear();
				smethod_3(list2, list, xAxis: true, positive: true, box.x);
				list = list2;
				flag = false;
				noIntersects = false;
				break;
			}
			case -1:
				return null;
			}
			switch (smethod_7(list, xAxis: true, positive: false, box.z))
			{
			case 0:
			{
				List<Vector2> obj = (flag ? list_0 : list_1);
				obj.Clear();
				smethod_3(obj, list, xAxis: true, positive: false, box.z);
				list = obj;
				flag = !flag;
				noIntersects = false;
				break;
			}
			case -1:
				return null;
			}
			switch (smethod_7(list, xAxis: false, positive: true, box.y))
			{
			case 0:
			{
				List<Vector2> obj2 = (flag ? list_0 : list_1);
				obj2.Clear();
				smethod_3(obj2, list, xAxis: false, positive: true, box.y);
				list = obj2;
				flag = !flag;
				noIntersects = false;
				break;
			}
			case -1:
				return null;
			}
			switch (smethod_7(list, xAxis: false, positive: false, box.w))
			{
			case 0:
			{
				List<Vector2> obj3 = (flag ? list_0 : list_1);
				obj3.Clear();
				smethod_3(obj3, list, xAxis: false, positive: false, box.w);
				list = obj3;
				noIntersects = false;
				break;
			}
			case -1:
				return null;
			}
			if (!noIntersects)
			{
				points = new Vector2[list.Count];
				list.CopyTo(points, 0);
			}
			return points;
		}

		private static int smethod_6(Vector2[] points, Vector4 box)
		{
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < points.Length; i++)
			{
				Vector2 vector = points[i];
				if (vector.x < box.x)
				{
					flag = true;
				}
				else if (vector.x > box.z)
				{
					flag = true;
				}
				else if (vector.y < box.y)
				{
					flag = true;
				}
				else if (vector.y > box.w)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
				}
			}
			if (!flag)
			{
				return 1;
			}
			if (!flag2)
			{
				return -1;
			}
			return 0;
		}

		private static int smethod_7(List<Vector2> points, bool xAxis, bool positive, float value)
		{
			bool flag = false;
			bool flag2 = false;
			if (xAxis)
			{
				for (int i = 0; i < points.Count; i++)
				{
					if (points[i].x < value)
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			else
			{
				for (int j = 0; j < points.Count; j++)
				{
					if (points[j].y < value)
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			if (positive)
			{
				bool num = flag2;
				flag2 = flag;
				flag = num;
			}
			if (!flag2)
			{
				return 1;
			}
			if (!flag)
			{
				return -1;
			}
			return 0;
		}

		private static int[] smethod_8(Vector2[] points)
		{
			int num = points.Length - 2;
			int[] array = new int[num + (num << 1)];
			int i = 2;
			int num2 = 0;
			for (; i < points.Length; i++)
			{
				array[num2++] = 0;
				array[num2++] = i - 1;
				array[num2++] = i;
			}
			return array;
		}

		private static float smethod_9(Vector2[] points)
		{
			float num = 0f;
			for (int i = 0; i < points.Length; i++)
			{
				Vector2 vector = points[i];
				Vector2 vector2 = points[(i + 1) % points.Length];
				float num2 = vector2.x - vector.x;
				float num3 = (vector2.y + vector.y) * 0.5f;
				num += num2 * num3;
			}
			return num;
		}

		private static void smethod_10(Vector3[] points, out int axisX, out int axisY)
		{
			Vector3 vector = points[0];
			Vector3 vector2 = points[0];
			foreach (Vector3 rhs in points)
			{
				vector = Vector3.Min(vector, rhs);
				vector2 = Vector3.Max(vector2, rhs);
			}
			DetectPlane(vector2 - vector, out axisX, out axisY);
		}

		public static void DetectPlane(Vector3 size, out int axisX, out int axisY)
		{
			int axisZ = 0;
			DetectPlane(size, out axisX, out axisY, out axisZ);
		}

		public static void DetectPlane(Vector3 size, out int axisX, out int axisY, out int axisZ)
		{
			int num = 0;
			float num2 = size[0];
			for (int i = 1; i < 3; i++)
			{
				if (size[i] < num2)
				{
					num = i;
					num2 = size[i];
				}
			}
			axisZ = num;
			if (axisZ == 0)
			{
				axisX = 1;
				axisY = 2;
			}
			else if (axisZ == 1)
			{
				axisX = 0;
				axisY = 2;
			}
			else
			{
				axisX = 0;
				axisY = 1;
			}
		}

		private static Vector2[] smethod_11(int count)
		{
			Vector2[] array = new Vector2[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = UnityEngine.Random.insideUnitCircle.normalized;
			}
			return array;
		}
	}
}
