using UnityEngine;

public class RainSplashController : MonoBehaviour
{
	[SerializeField]
	private DepthPhotograper _depthPhoto;

	[SerializeField]
	private ParticleSystem _splashes;

	[SerializeField]
	private float _splashLifetime = 0.3f;

	[SerializeField]
	private Vector2 _particleSizeRange = new Vector2(0.01f, 0.08f);

	[SerializeField]
	private float _splashesOffset;

	[SerializeField]
	private float _minDistance = 1.25f;

	[SerializeField]
	private float _maxDistance = 20f;

	[SerializeField]
	private float _maxGeneratedParticlesInFrame = 50f;

	[SerializeField]
	private AnimationCurve _falloffCurve;

	[SerializeField]
	private AnimationCurve _dispersionCurve;

	private Transform transform_0;

	private float float_0;



	public float Intensity
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = Mathf.Clamp01(value);
		}
	}

	public void Init(Camera targetCamera)
	{
		transform_0 = targetCamera.transform;
	}

	
}
