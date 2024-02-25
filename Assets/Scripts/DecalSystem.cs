using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class DecalSystem : MonoBehaviour
{
	public int Count = 2048;

	public float SizeMin = 1f;

	public float SizeRandomRange;

	private bool bool_0;

	public int TileSheetRows = 1;

	public int TileSheetColumns = 1;

	private Vector2[][] vector2_0;

	private int int_0 = 1;

	private bool bool_1;

	private int int_1;

	private Vector3[] vector3_0;

	private Vector3[] vector3_1;

	private Vector4[] vector4_0;

	private Vector2[] vector2_1;

	private Vector2[] vector2_2;

	private int[] int_2;

	private Mesh mesh_0;

	private Vector3 vector3_2 = Vector3.zero;

	private Vector3 vector3_3 = Vector3.zero;
}
