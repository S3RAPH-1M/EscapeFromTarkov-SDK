using System;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000948 RID: 2376
[RequireComponent(typeof(Light))]
public class VolumetricLight : MonoBehaviour
{
	// Token: 0x04003AFA RID: 15098
	private Light light_0;

	// Token: 0x04003AFB RID: 15099
	private Shader shader_0;

	// Token: 0x04003AFC RID: 15100
	private Material material_0;

	// Token: 0x04003AFD RID: 15101
	private CommandBuffer commandBuffer_0;

	// Token: 0x04003AFE RID: 15102
	private CommandBuffer commandBuffer_1;

	// Token: 0x04003AFF RID: 15103
	[Range(1f, 64f)]
	public int SampleCount = 8;

	// Token: 0x04003B00 RID: 15104
	[Range(0f, 1f)]
	public float ScatteringCoef = 0.5f;

	// Token: 0x04003B01 RID: 15105
	[Range(0f, 50f)]
	public float ExtinctionCoef = 0.01f;

	// Token: 0x04003B02 RID: 15106
	[Range(0f, 50f)]
	public float SkyboxExtinctionCoef = 0.9f;

	// Token: 0x04003B03 RID: 15107
	[Range(0f, 50f)]
	public float MieG = 0.1f;

	// Token: 0x04003B04 RID: 15108
	public bool HeightFog;

	// Token: 0x04003B05 RID: 15109
	[Range(0f, 0.5f)]
	public float HeightScale = 0.1f;

	// Token: 0x04003B06 RID: 15110
	public float GroundLevel;

	// Token: 0x04003B07 RID: 15111
	public bool Noise;

	// Token: 0x04003B08 RID: 15112
	public float NoiseScale = 0.015f;

	// Token: 0x04003B09 RID: 15113
	public float NoiseIntensity = 1f;

	// Token: 0x04003B0A RID: 15114
	public float NoiseIntensityOffset = 0.3f;

	// Token: 0x04003B0B RID: 15115
	public Vector2 NoiseVelocity = new Vector2(3f, 3f);

	// Token: 0x04003B0C RID: 15116
	[Tooltip("")]
	public float MaxRayLength = 400f;

	// Token: 0x04003B0D RID: 15117
	private Vector4[] vector4_0 = new Vector4[4];

	// Token: 0x04003B0E RID: 15118
	private bool bool_0;

	// Token: 0x04003B0F RID: 15119
	private Vector3 vector3_0;

	// Token: 0x04003B10 RID: 15120
	private Quaternion quaternion_0;

	// Token: 0x04003B11 RID: 15121
	private float float_0;

	// Token: 0x04003B12 RID: 15122
	private float float_1;

	// Token: 0x04003B13 RID: 15123
	private Matrix4x4 matrix4x4_0;

	// Token: 0x04003B14 RID: 15124
	private Matrix4x4 matrix4x4_1;

	// Token: 0x04003B15 RID: 15125
	private Matrix4x4 matrix4x4_2;

	// Token: 0x04003B16 RID: 15126
	private Matrix4x4 matrix4x4_3;

	// Token: 0x04003B17 RID: 15127
	private Matrix4x4 matrix4x4_4;

	// Token: 0x04003B18 RID: 15128
	private Matrix4x4 matrix4x4_5;

	// Token: 0x04003B19 RID: 15129
	private Matrix4x4 matrix4x4_6;

	// Token: 0x04003B1A RID: 15130
	private Matrix4x4 matrix4x4_7;

	// Token: 0x04003B1B RID: 15131
	private Vector3 vector3_1;

	// Token: 0x04003B1C RID: 15132
	private Vector3 vector3_2;

	// Token: 0x04003B1D RID: 15133
	private int int_0 = -2;

	// Token: 0x04003B1E RID: 15134
	private Mesh mesh_0;

	// Token: 0x04003B1F RID: 15135
	private static readonly int int_1 = Shader.PropertyToID("_SampleCount");

	// Token: 0x04003B20 RID: 15136
	private static readonly int int_2 = Shader.PropertyToID("_NoiseVelocity");

	// Token: 0x04003B21 RID: 15137
	private static readonly int int_3 = Shader.PropertyToID("_NoiseData");

	// Token: 0x04003B22 RID: 15138
	private static readonly int int_4 = Shader.PropertyToID("_MieG");

	// Token: 0x04003B23 RID: 15139
	private static readonly int int_5 = Shader.PropertyToID("_VolumetricLight");

	// Token: 0x04003B24 RID: 15140
	private static readonly int int_6 = Shader.PropertyToID("_ZTest");

	// Token: 0x04003B25 RID: 15141
	private static readonly int int_7 = Shader.PropertyToID("_HeightFog");

	// Token: 0x04003B26 RID: 15142
	private static readonly int int_8 = Shader.PropertyToID("_CameraForward");

	// Token: 0x04003B27 RID: 15143
	private static readonly int int_9 = Shader.PropertyToID("_CameraDepthTexture");

	// Token: 0x04003B28 RID: 15144
	private static readonly int int_10 = Shader.PropertyToID("_LightTexture0");

	// Token: 0x04003B29 RID: 15145
	private static readonly int int_11 = Shader.PropertyToID("_LightPos");

	// Token: 0x04003B2A RID: 15146
	private static readonly int int_12 = Shader.PropertyToID("_MyLightMatrix0");

	// Token: 0x04003B2B RID: 15147
	private static readonly int int_13 = Shader.PropertyToID("_WorldViewProj");

	// Token: 0x04003B2C RID: 15148
	private static readonly int int_14 = Shader.PropertyToID("_WorldView");

	// Token: 0x04003B2D RID: 15149
	private static readonly int int_15 = Shader.PropertyToID("_LightColor");

	// Token: 0x04003B2E RID: 15150
	private static readonly int int_16 = Shader.PropertyToID("_CosAngle");

	// Token: 0x04003B2F RID: 15151
	private static readonly int int_17 = Shader.PropertyToID("_PlaneD");

	// Token: 0x04003B30 RID: 15152
	private static readonly int int_18 = Shader.PropertyToID("_ConeApex");

	// Token: 0x04003B31 RID: 15153
	private static readonly int int_19 = Shader.PropertyToID("_ConeAxis");

	// Token: 0x04003B32 RID: 15154
	private static readonly int int_20 = Shader.PropertyToID("_MyWorld2Shadow");

	// Token: 0x04003B33 RID: 15155
	private static readonly int int_21 = Shader.PropertyToID("_MaxRayLength");

	// Token: 0x04003B34 RID: 15156
	private static readonly int int_22 = Shader.PropertyToID("_LightDir");

	// Token: 0x04003B35 RID: 15157
	private static readonly int int_23 = Shader.PropertyToID("_FrustumCorners");
}
