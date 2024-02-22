using System;
using UnityEngine;
using UnityEngine.Profiling;

// Token: 0x02000AA8 RID: 2728
public class DepthPhotograper : MonoBehaviour
{
	// Token: 0x040043EB RID: 17387
	[SerializeField]
	private PowOfTwoDimensions _depthTextureDimension = PowOfTwoDimensions._4096;

	// Token: 0x040043EC RID: 17388
	[SerializeField]
	private float _yBias;

	// Token: 0x040043ED RID: 17389
	private float float_0;

	// Token: 0x040043EE RID: 17390
	private float float_1;

	// Token: 0x040043EF RID: 17391
	private Vector3 vector3_0;

	// Token: 0x040043F0 RID: 17392
	private Camera camera_0;

	// Token: 0x040043F1 RID: 17393
	private Material material_0;

	// Token: 0x040043F2 RID: 17394
	[SerializeField]
	private RenderTexture _depthRT;

	// Token: 0x040043F3 RID: 17395
	private RenderTexture renderTexture_0;

	// Token: 0x040043F4 RID: 17396
	private static readonly int int_0 = Shader.PropertyToID("_MapStart");

	// Token: 0x040043F5 RID: 17397
	private static readonly int int_1 = Shader.PropertyToID("_MapScale");

	// Token: 0x040043F6 RID: 17398
	private static readonly int int_2 = Shader.PropertyToID("_WeatherDepthMap");

	// Token: 0x040043F7 RID: 17399
	private const float float_2 = 100f;

	// Token: 0x040043F8 RID: 17400
	private int int_3 = 11;

	// Token: 0x040043F9 RID: 17401
	private CustomSampler customSampler_0 = CustomSampler.Create("CheckIfCameraUnderRain");

	// Token: 0x040043FA RID: 17402
	private Bounds bounds_0;
}
