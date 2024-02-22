using UnityEngine;
using UnityEngine.Rendering;

public class SnowFlakes : MonoBehaviour
{
	public float CloseSize;

	public float FarSize;

	public Material Close;

	public Material Far;

	private MeshRenderer[] meshRenderer_0;

	private bool bool_0;

	private bool bool_1;

	private static readonly int int_0 = Shader.PropertyToID("_Size");

	private const int int_1 = 16383;

	private const int int_2 = 8191;

	private const int int_3 = 4095;

	
}
