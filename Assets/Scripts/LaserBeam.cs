using UnityEngine;

public class LaserBeam : MonoBehaviour
{
	public float RayStart = 0.1f;

	public float MaxDistance = 100f;

	public bool UsePointLight = true;

	public Material BeamMaterial;

	public Material PointMaterial;

	public LayerMask Mask;

	public float BeamSize;

	public float PointSizeClose;

	public float PointSizeFar;

	public float SurfaceOffsetForLight;

	public float LightRange;

	public float LightIntensity;

	[SerializeField]
	private float IntensityFactor = 1f;

	public Texture Cookie;

	public Vector2 AngleCloseFar = new Vector2(4f, 200f);

	private Mesh mesh_0;

	private Mesh mesh_1;

	private Light light_0;

	private MaterialPropertyBlock materialPropertyBlock_0;

	private MaterialPropertyBlock materialPropertyBlock_1;

	private static readonly int int_0 = Shader.PropertyToID("_Distance");

	private static readonly int int_1 = Shader.PropertyToID("_Intensity");

	private static readonly int int_2 = Shader.PropertyToID("_Size");

	private static readonly int int_3 = Shader.PropertyToID("_MaxDist");

	private static readonly int int_4 = Shader.PropertyToID("_Color");

	private static readonly int int_5 = Shader.PropertyToID("_Factor");

	private void Awake()
	{
		mesh_0 = new Mesh
		{
			name = "LaserBeam _pointMesh",
			vertices = new Vector3[4]
			{
				new Vector3(-1f, -1f),
				new Vector3(1f, -1f),
				new Vector3(-1f, 1f),
				new Vector3(1f, 1f)
			},
			uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			},
			triangles = new int[6] { 0, 1, 3, 3, 2, 0 }
		};
		mesh_0.RecalculateBounds();
		mesh_1 = new Mesh
		{
			name = "LaserBeam _beamMesh",
			vertices = new Vector3[4]
			{
				new Vector3(0f - BeamSize, 0f),
				new Vector3(BeamSize, 0f),
				new Vector3(0f - BeamSize, 1f),
				new Vector3(BeamSize, 1f)
			},
			uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			},
			triangles = new int[6] { 0, 1, 3, 3, 2, 0 },
			bounds = new Bounds(new Vector3(BeamSize, BeamSize, MaxDistance * 0.5f), new Vector3(BeamSize * 2f, BeamSize * 2f, MaxDistance))
		};
		Mask = (int)Mask | LayerMask.GetMask("HitCollider");
		materialPropertyBlock_0 = new MaterialPropertyBlock();
		materialPropertyBlock_1 = new MaterialPropertyBlock();
		method_0();
	}

	[ContextMenu("Reset")]
	private void Reset()
	{
		method_0();
	}

	private void method_0()
	{
		float @float = BeamMaterial.GetFloat(int_5);
		Color color = BeamMaterial.GetColor(int_4);
		GameObject gameObject = new GameObject("laserBeamLight");
		light_0 = gameObject.AddComponent<Light>();
		light_0.enabled = UsePointLight;
		light_0.type = LightType.Spot;
		light_0.color = color * @float;
		light_0.range = LightRange;
		light_0.cookie = Cookie;
		light_0.shadows = LightShadows.None;
		light_0.transform.SetParent(base.transform, worldPositionStays: true);
	}

	private void LateUpdate()
	{
		Vector3 position = base.transform.position;
		Vector3 forward = base.transform.forward;
		if (Physics.Raycast(position + forward * RayStart, forward, out var hitInfo, MaxDistance, Mask))
		{
			float value = Mathf.Lerp(PointSizeClose, PointSizeFar, hitInfo.distance / MaxDistance);
			float num = (1f - hitInfo.distance / MaxDistance) * IntensityFactor;
			materialPropertyBlock_0.SetFloat(int_0, hitInfo.distance + RayStart);
			materialPropertyBlock_0.SetFloat(int_1, num);
			materialPropertyBlock_1.SetFloat(int_1, num);
			materialPropertyBlock_1.SetFloat(int_2, value);
			materialPropertyBlock_1.SetFloat(int_3, MaxDistance);
			Vector3 vector = hitInfo.point + (hitInfo.normal - forward).normalized * SurfaceOffsetForLight;
			light_0.transform.SetPositionAndRotation(vector, Quaternion.Lerp(Quaternion.LookRotation(hitInfo.point - vector, Vector3.up), base.transform.rotation, 0.25f));
			light_0.intensity = num * LightIntensity;
			light_0.spotAngle = Mathf.Lerp(AngleCloseFar.x, AngleCloseFar.y, hitInfo.distance / MaxDistance);
			Vector3 normal = hitInfo.normal;
			Graphics.DrawMesh(mesh_0, hitInfo.point, Quaternion.LookRotation(normal), PointMaterial, LayerMask.NameToLayer("Default"), null, 0, materialPropertyBlock_1);
		}
		else
		{
			light_0.intensity = 0f;
			materialPropertyBlock_0.SetFloat(int_0, MaxDistance);
			materialPropertyBlock_0.SetFloat(int_1, IntensityFactor);
		}
		Graphics.DrawMesh(mesh_1, base.transform.position, base.transform.rotation, BeamMaterial, LayerMask.NameToLayer("Default"), null, 0, materialPropertyBlock_0);
	}

	private void OnDestroy()
	{
		Object.Destroy(mesh_0);
		Object.Destroy(mesh_1);
	}
}
