using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TracerSystem : MonoBehaviour
{
	private class Class513
	{
		public int Pos4;

		public Vector3[] Vertices = new Vector3[8];

		public Vector2 Uv2Val;

		public Color32 Color;

		public void Calc(Vector3 start, Vector3 end, float size, float time, Color32 color)
		{
			Vector3 vector = (start - end).normalized * size;
			Vector3 vector2 = new Vector3(0f - vector.z, 0f, vector.x);
			Vector3 vector3 = new Vector3(vector.y * vector2.z, vector.z * vector2.x - vector.x * vector2.z, (0f - vector.y) * vector2.x) * 3f;
			Vertices[0] = start + vector2;
			Vertices[1] = start - vector2;
			Vertices[2] = end - vector2;
			Vertices[3] = end + vector2;
			Vertices[4] = start + vector3;
			Vertices[5] = start - vector3;
			Vertices[6] = end - vector3;
			Vertices[7] = end + vector3;
			Uv2Val.x = Time.time;
			Uv2Val.y = time;
			Color = color;
		}

		public void Update(Vector3[] vertices, Vector2[] uv2, Color32[] colors)
		{
			for (int i = 0; i < 8; i++)
			{
				int num = Pos4 + i;
				vertices[num] = Vertices[i];
				uv2[num] = Uv2Val;
				colors[num] = Color;
			}
		}
	}

	public int Count = 128;

	public float Size = 0.3f;

	private int int_0;

	private LinkedList<Class513> linkedList_0;

	private Class513[] class513_0;

	private int int_1;

	private Vector3[] vector3_0;

	private Vector3[] vector3_1;

	private Vector4[] vector4_0;

	private Vector2[] vector2_0;

	private Vector2[] vector2_1;

	private Color32[] color32_0;

	private int[] int_2;

	private Mesh mesh_0;

	private Vector3 vector3_2 = Vector3.zero;

	private Vector3 vector3_3 = Vector3.zero;

	private void Awake()
	{
		if (SystemInfo.graphicsShaderLevel < 20)
		{
			base.enabled = false;
			return;
		}
		int_0 = Count << 1;
		linkedList_0 = new LinkedList<Class513>();
		class513_0 = new Class513[Count];
		for (int i = 0; i < Count; i++)
		{
			class513_0[i] = new Class513();
			class513_0[i].Pos4 = i << 3;
		}
		int num = int_0 << 2;
		vector3_0 = new Vector3[num];
		vector3_1 = new Vector3[num];
		vector4_0 = new Vector4[num];
		vector2_0 = new Vector2[num];
		vector2_1 = new Vector2[num];
		color32_0 = new Color32[num];
		int_2 = new int[int_0 * 6];
		int j = 0;
		int num2 = 0;
		for (; j < int_0; j++)
		{
			int num3 = j << 2;
			int_2[num2++] = num3;
			int_2[num2++] = num3 + 1;
			int_2[num2++] = num3 + 2;
			int_2[num2++] = num3 + 2;
			int_2[num2++] = num3 + 3;
			int_2[num2++] = num3;
		}
		int k = 0;
		int num4 = 0;
		for (; k < int_0; k++)
		{
			vector2_0[num4++] = new Vector2(0f, 0f);
			vector2_0[num4++] = new Vector2(0f, 1f);
			vector2_0[num4++] = new Vector2(1f, 1f);
			vector2_0[num4++] = new Vector2(1f, 0f);
		}
		mesh_0 = new Mesh
		{
			vertices = vector3_0,
			normals = vector3_1,
			tangents = vector4_0,
			uv = vector2_0,
			uv2 = vector2_1,
			triangles = int_2,
			name = "TracerSystem _mesh"
		};
		mesh_0.MarkDynamic();
		mesh_0.bounds = new Bounds(Vector3.zero, Vector3.zero);
		GetComponent<MeshFilter>().mesh = mesh_0;
	}

	private void LateUpdate()
	{
		if (linkedList_0.Count == 0)
		{
			return;
		}
		foreach (Class513 item in linkedList_0)
		{
			item.Update(vector3_0, vector2_1, color32_0);
		}
		linkedList_0.Clear();
		mesh_0.vertices = vector3_0;
		mesh_0.uv2 = vector2_1;
		mesh_0.colors32 = color32_0;
	}

	public void Add(Vector3 start, Vector3 end, Color32 color)
	{
		if (class513_0 != null)
		{
			Class513 @class = class513_0[int_1];
			if (++int_1 >= Count)
			{
				int_1 = 0;
			}
			linkedList_0.AddLast(@class);
			@class.Calc(start, end, Size, 1f, color);
			method_0(start);
			method_0(end);
		}
	}

	public void Add(Vector3 start, Vector3 end, Color32 color, float size, float time = 1f)
	{
		if (class513_0 != null)
		{
			Class513 @class = class513_0[int_1];
			if (++int_1 >= Count)
			{
				int_1 = 0;
			}
			linkedList_0.AddLast(@class);
			@class.Calc(start, end, size, time, color);
			method_0(start);
			method_0(end);
		}
	}

	private void method_0(Vector3 position)
	{
		if (!(position.x > vector3_2.x) || !(position.y > vector3_2.y) || !(position.z > vector3_2.z) || !(position.x < vector3_3.x) || !(position.y < vector3_3.y) || !(position.z < vector3_3.z))
		{
			if (position.x < vector3_2.x)
			{
				vector3_2.x = position.x - 50f;
			}
			if (position.y < vector3_2.y)
			{
				vector3_2.y = position.y - 50f;
			}
			if (position.z < vector3_2.z)
			{
				vector3_2.z = position.z - 50f;
			}
			if (position.x > vector3_3.x)
			{
				vector3_3.x = position.x + 50f;
			}
			if (position.y > vector3_3.y)
			{
				vector3_3.y = position.y + 50f;
			}
			if (position.z > vector3_3.z)
			{
				vector3_3.z = position.z + 50f;
			}
			mesh_0.bounds = new Bounds
			{
				min = vector3_2,
				max = vector3_3
			};
		}
	}
}
