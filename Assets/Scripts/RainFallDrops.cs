using UnityEngine;
using UnityEngine.Rendering;

public class RainFallDrops : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 1f)]
	private float _intensity = 1f;

	[SerializeField]
	[Range(0f, 1f)]
	private float _intensityThreshold = 0.001f;

	[Range(128f, 16383f)]
	public int Count = 8191;

	public Vector2 MinSize = new Vector2(0.04f, 0.15f);

	public Vector2 MaxSize = new Vector2(0.04f, 0.15f);

	[GAttribute6(0f, 1f, -1f)]
	public Vector2 MinMaxSideSpeed = new Vector2(0f, 1f);

	[GAttribute6(0f, 2f, -1f)]
	public Vector2 MinMaxDensity = new Vector2(0f, 1f);

	[SerializeField]
	private Material _close;

	[SerializeField]
	[Range(0f, 1f)]
	public float DropsAlphaClose = 0.116f;

	[SerializeField]
	[Range(0f, 1f)]
	public float MinAmbient = 0.2f;

	[SerializeField]
	[Range(0f, 1f)]
	public float MinAmbientAddition = 0.4f;

	[SerializeField]
	[Range(0f, 1f)]
	public float MinAmbientAdditionCoef;

	public float SideSpeed;

	private const int int_0 = 16383;

	private MeshRenderer meshRenderer_0;

	private GameObject gameObject_0;

	private Material material_0;

	private static readonly int int_1 = Shader.PropertyToID("_AlphaMult");

	private static readonly int int_2 = Shader.PropertyToID("_FallingVector");

	private static readonly int int_3 = Shader.PropertyToID("_Intensity");

	private static readonly int int_4 = Shader.PropertyToID("_SideSpeed");

	private static readonly int int_5 = Shader.PropertyToID("_RainDensity");

	private static readonly int int_6 = Shader.PropertyToID("_Size");

	private static readonly int int_7 = Shader.PropertyToID("_MinAmbient");

	
}
