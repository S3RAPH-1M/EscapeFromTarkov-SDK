using System;

using UnityEngine;
using UnityEngine.Profiling;

public class DepthPhotograper : MonoBehaviour
{
	[SerializeField]
	private PowOfTwoDimensions _depthTextureDimension = PowOfTwoDimensions._4096;

	[SerializeField]
	private float _yBias;

	private float float_0;

	private float float_1;

	private Vector3 vector3_0;

	private Camera camera_0;

	private Material material_0;

	[SerializeField]
	private RenderTexture _depthRT;

	private RenderTexture renderTexture_0;

	private static readonly int int_0 = Shader.PropertyToID("_MapStart");

	private static readonly int int_1 = Shader.PropertyToID("_MapScale");

	private static readonly int int_2 = Shader.PropertyToID("_WeatherDepthMap");

	private const float float_2 = 100f;

	private int int_3 = 11;

	private CustomSampler customSampler_0 = CustomSampler.Create("CheckIfCameraUnderRain");

	private Bounds bounds_0;

	private float Single_0 => Math.Max(bounds_0.size.x, bounds_0.size.z);

	

	
}
