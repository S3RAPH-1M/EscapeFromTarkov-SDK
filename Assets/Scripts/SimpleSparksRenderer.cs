using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class SimpleSparksRenderer : MonoBehaviour
{
	public int Segments;

	public int Count = 250;

	private Vector3[] vector3_0;

	private Vector3[] vector3_1;

	private Vector4[] vector4_0;

	private Color32[] color32_0;

	private Mesh mesh_0;

	private Bounds bounds_0;

	private bool bool_0;

	private int int_0;

	private float float_0;

	private Renderer renderer_0;

	private MaterialPropertyBlock materialPropertyBlock_0;

	private static readonly int int_1 = Shader.PropertyToID("_MainTime");

	private static readonly int int_2 = Shader.PropertyToID("_LastMainTime");

	private void OnValidate()
	{
		Segments = Math.Max(Segments, 2);
		Count = Math.Max(Count, 1);
		int num = Segments + 1 << 1;
		int val = 65535 / num;
		Count = Math.Min(Count, val);
	}

	public void Awake()
	{
		int num = Segments + 1 << 1;
		int num2 = Count * num;
		int num3 = Count * Segments * 6;
		vector3_0 = new Vector3[num2];
		int[] triangles = new int[num3];
		Vector2[] array = new Vector2[num2];
		Vector2[] array2 = new Vector2[num2];
		Vector2[] array3 = new Vector2[num2];
		vector3_1 = new Vector3[num2];
		vector4_0 = new Vector4[num2];
		color32_0 = new Color32[num2];
		for (int i = 0; i < Count; i++)
		{
			Fill(i, array, array2, triangles);
		}
		float[] array4 = new float[num];
		for (int j = 0; j < Segments + 1; j++)
		{
			float num4 = (float)Mathf.Clamp(j - 1, 0, Segments - 2) / (float)(Segments - 2);
			array4[j << 1] = (array4[(j << 1) + 1] = num4);
		}
		int k = 0;
		int num5 = 0;
		for (; k < Count; k++)
		{
			float value = UnityEngine.Random.value;
			int num6 = 0;
			while (num6 < num)
			{
				array3[num5] = new Vector2(array4[num6], value);
				num6++;
				num5++;
			}
		}
		if (mesh_0 != null)
		{
			UnityEngine.Object.Destroy(mesh_0);
		}
		bounds_0 = new Bounds(Vector3.zero, Vector3.zero);
		mesh_0 = new Mesh
		{
			vertices = vector3_0,
			triangles = triangles,
			uv = array,
			uv2 = array2,
			uv3 = array3,
			normals = vector3_1,
			tangents = vector4_0,
			colors32 = color32_0,
			name = "SimpleSparksRenderer _mesh"
		};
		GetComponent<MeshFilter>().mesh = mesh_0;
		renderer_0 = GetComponent<Renderer>();
		materialPropertyBlock_0 = new MaterialPropertyBlock();
	}

	private void OnDestroy()
	{
		if (mesh_0 != null)
		{
			UnityEngine.Object.Destroy(mesh_0);
		}
	}

	public void Fill(int pos, Vector2[] uv0, Vector2[] uv1, int[] triangles)
	{
		int num = Segments + 1;
		int num2 = num << 1;
		int num3 = pos * num2;
		int num4 = num - 1;
		for (int i = 1; i < num4; i++)
		{
			int num5 = num3 + (i << 1);
			int num6 = num5 + 1;
			uv0[num5] = new Vector2(0.5f, 0f);
			uv0[num6] = new Vector2(0.5f, 1f);
			uv1[num5] = new Vector2(0f, -1f);
			uv1[num6] = new Vector2(0f, 1f);
		}
		int num7 = num3;
		int num8 = num3 + 1;
		uv0[num7] = new Vector2(0f, 0f);
		uv0[num8] = new Vector2(0f, 1f);
		uv1[num7] = new Vector2(-1f, -1f);
		uv1[num8] = new Vector2(-1f, 1f);
		int num9 = num3 + num2 - 2;
		int num10 = num9 + 1;
		uv0[num9] = new Vector2(1f, 0f);
		uv0[num10] = new Vector2(1f, 1f);
		uv1[num9] = new Vector2(1f, -1f);
		uv1[num10] = new Vector2(1f, 1f);
		int num11 = pos * Segments * 6;
		for (int j = 0; j < Segments; j++)
		{
			int num12 = num3 + (j << 1);
			int num13 = num12++;
			int num14 = num12++;
			int num15 = num12++;
			triangles[num11++] = num13;
			triangles[num11++] = num15;
			triangles[num11++] = num12;
			triangles[num11++] = num12;
			triangles[num11++] = num14;
			triangles[num11++] = num13;
		}
	}

	public void EmitSeg(Vector3 position, Vector3 velocity, float time, float gravity, float drag, float lifeTime, byte emission = byte.MaxValue, byte size = byte.MaxValue, byte turbulence = byte.MaxValue, byte frequency = byte.MaxValue)
	{
		int num = Segments + 1 << 1;
		int i = int_0 * num;
		int num2 = i + num;
		int num3 = 0;
		for (; i < num2; i++)
		{
			vector3_0[i] = position;
			vector3_1[i] = velocity;
			vector4_0[i] = new Vector4(time, lifeTime, gravity, drag);
			color32_0[i] = new Color32(emission, size, turbulence, frequency);
			num3++;
		}
		int_0++;
		if (int_0 >= Count)
		{
			int_0 = 0;
		}
		float size2 = (velocity.x + velocity.y + velocity.z) * lifeTime + gravity * lifeTime * lifeTime;
		ExpandBoundsFast(ref bounds_0, position, size2);
		bool_0 = true;
	}

	public static void ExpandBoundsFast(ref Bounds bounds, Vector3 position, float size)
	{
		position.x = ((position.x > 0f) ? position.x : (0f - position.x));
		position.y = ((position.y > 0f) ? position.y : (0f - position.y));
		position.z = ((position.z > 0f) ? position.z : (0f - position.z));
		position.x += size;
		position.y += size;
		position.z += size;
		Vector3 extents = bounds.extents;
		extents.x = ((extents.x > position.x) ? extents.x : position.x);
		extents.y = ((extents.y > position.y) ? extents.y : position.y);
		extents.z = ((extents.z > position.z) ? extents.z : position.z);
		bounds.extents = extents;
	}

	private void LateUpdate()
	{
		if (bool_0)
		{
			mesh_0.vertices = vector3_0;
			mesh_0.normals = vector3_1;
			mesh_0.tangents = vector4_0;
			mesh_0.colors32 = color32_0;
			mesh_0.bounds = bounds_0;
			bool_0 = false;
		}
	}

	private void Update()
	{
		materialPropertyBlock_0.SetFloat(int_1, Time.time);
		materialPropertyBlock_0.SetFloat(int_2, float_0);
		renderer_0.SetPropertyBlock(materialPropertyBlock_0);
		float_0 = Time.time;
	}
}
