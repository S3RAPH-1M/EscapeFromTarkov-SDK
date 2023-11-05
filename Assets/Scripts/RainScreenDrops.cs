using UnityEngine;

[DisallowMultipleComponent]
public class RainScreenDrops : MonoBehaviour
{
	[SerializeField]
	[Header("Appearance settings")]
	private Shader _blitShader;

	[SerializeField]
	[Range(0f, 1f)]
	private float _intensity = 1f;

	[SerializeField]
	private float _refraction = 0.1f;

	[SerializeField]
	private float _refractionWithoutGlass = 0.1f;

	[SerializeField]
	private int _downsamplingCount = 7;

	[Header("Drops settings")]
	[SerializeField]
	private AnimationCurve _dropScaleCurve;

	[SerializeField]
	private int _dropsAmount = 32;

	[SerializeField]
	private float _rainDropsDelay = 0.1f;

	[SerializeField]
	private Vector2 _dropScale = new Vector2(0.025f, 0.6f);

	[SerializeField]
	private float _dropLifetime = 25f;

	[SerializeField]
	private float _dropLifetimeWithoutGlass = 10f;

	[SerializeField]
	private bool _isDropsShouldMove;

	[SerializeField]
	private int _maxDropsAtOnce = 4;

	[SerializeField]
	private Material _dropMaterial;

	[SerializeField]
	private float _scaleMultiplierWithoutGlass = 3f;

	private Material material_0;

	public RenderTexture DuDvMap;

	[Space(10f)]
	private RenderTexture renderTexture_0;

	private GameObject gameObject_0;



	private float float_0 = 25f;

	private float float_1;


	private bool bool_0;

	[HideInInspector]
	public int Mode;

	[HideInInspector]
	[SerializeField]
	public float InputMinL;

	[HideInInspector]
	[SerializeField]
	public float InputMaxL = 255f;

	[HideInInspector]
	[SerializeField]
	public float InputGammaL = 1f;

	[SerializeField]
	[HideInInspector]
	public float InputMinR;

	[HideInInspector]
	[SerializeField]
	public float InputMaxR = 255f;

	[HideInInspector]
	[SerializeField]
	public float InputGammaR = 1f;

	[SerializeField]
	[HideInInspector]
	public float InputMinG;

	[SerializeField]
	[HideInInspector]
	public float InputMaxG = 255f;

	[SerializeField]
	[HideInInspector]
	public float InputGammaG = 1f;

	[SerializeField]
	[HideInInspector]
	public float InputMinB;

	[HideInInspector]
	[SerializeField]
	public float InputMaxB = 255f;

	[HideInInspector]
	[SerializeField]
	public float InputGammaB = 1f;

	[HideInInspector]
	[SerializeField]
	public float OutputMinL;

	[HideInInspector]
	[SerializeField]
	public float OutputMaxL = 255f;

	[HideInInspector]
	[SerializeField]
	public float OutputMinR;

	[SerializeField]
	[HideInInspector]
	public float OutputMaxR = 255f;

	[SerializeField]
	[HideInInspector]
	public float OutputMinG;

	[SerializeField]
	[HideInInspector]
	public float OutputMaxG = 255f;

	[HideInInspector]
	[SerializeField]
	public float OutputMinB;

	[SerializeField]
	[HideInInspector]
	public float OutputMaxB = 255f;

	private static readonly int int_0 = Shader.PropertyToID("_inputMin");

	private static readonly int int_1 = Shader.PropertyToID("_inputMax");

	private static readonly int int_2 = Shader.PropertyToID("_inputGamma");

	private static readonly int int_3 = Shader.PropertyToID("_outputMin");

	private static readonly int int_4 = Shader.PropertyToID("_outputMax");

	private static readonly int int_5 = Shader.PropertyToID("_Blured");

	private static readonly int int_6 = Shader.PropertyToID("_DudvMap");

	private static readonly int int_7 = Shader.PropertyToID("_Refraction");

	private static readonly int int_8 = Shader.PropertyToID("_Intensity");



}
