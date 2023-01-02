using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Token: 0x02000863 RID: 2147
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class VolumetricFog : MonoBehaviour
{
	// Token: 0x04003281 RID: 12929
	private Material material_0;

	// Token: 0x04003282 RID: 12930
	[HideInInspector]
	public Shader m_DebugShader;

	// Token: 0x04003283 RID: 12931
	[HideInInspector]
	public Shader m_ShadowmapShader;

	// Token: 0x04003284 RID: 12932
	[HideInInspector]
	public ComputeShader m_InjectLightingAndDensity;

	// Token: 0x04003285 RID: 12933
	[HideInInspector]
	public ComputeShader m_Scatter;

	// Token: 0x04003286 RID: 12934
	private Material material_1;

	// Token: 0x04003287 RID: 12935
	[HideInInspector]
	public Shader m_ApplyToOpaqueShader;

	// Token: 0x04003288 RID: 12936
	private Material material_2;

	// Token: 0x04003289 RID: 12937
	[HideInInspector]
	public Shader m_BlurShadowmapShader;

	// Token: 0x0400328A RID: 12938
	[HideInInspector]
	public Texture2D m_Noise;

	// Token: 0x0400328B RID: 12939
	[HideInInspector]
	public bool m_Debug;

	// Token: 0x0400328C RID: 12940
	[Range(0f, 1f)]
	[HideInInspector]
	public float m_Z = 1f;

	// Token: 0x0400328D RID: 12941
	[Header("Size")]
	public float m_NearClip = 0.1f;

	// Token: 0x0400328E RID: 12942
	public float m_FarClipMax = 100f;

	// Token: 0x0400328F RID: 12943
	[Header("Fog Density")]
	[FormerlySerializedAs("m_Density")]
	public float m_GlobalDensityMult = 1f;

	// Token: 0x04003292 RID: 12946
	private RenderTexture renderTexture_0;

	// Token: 0x04003293 RID: 12947
	private RenderTexture renderTexture_1;

	// Token: 0x04003295 RID: 12949
	private Camera camera_0;

	// Token: 0x04003296 RID: 12950
	public float m_ConstantFog;

	// Token: 0x04003297 RID: 12951
	public float m_HeightFogAmount;

	// Token: 0x04003298 RID: 12952
	public float m_HeightFogExponent;

	// Token: 0x04003299 RID: 12953
	public float m_HeightFogOffset;

	// Token: 0x0400329A RID: 12954
	[Tooltip("Noise multiplies with constant fog and height fog, but not with fog ellipsoids.")]
	[Range(0f, 1f)]
	public float m_NoiseFogAmount;

	// Token: 0x0400329B RID: 12955
	public float m_NoiseFogScale = 1f;

	// Token: 0x0400329C RID: 12956
	[Range(0f, 0.999f)]
	public float m_Anisotropy;

	// Token: 0x0400329E RID: 12958
	[Header("Lights")]
	[FormerlySerializedAs("m_Intensity")]
	public float m_GlobalIntensityMult = 1f;

	// Token: 0x0400329F RID: 12959
	public float m_AmbientLightIntensity;

	// Token: 0x040032A0 RID: 12960
	public Color m_AmbientLightColor = Color.white;

	// Token: 0x040032A1 RID: 12961
	private VolumetricFog.Struct67[] struct67_0;

	// Token: 0x040032A2 RID: 12962
	private ComputeBuffer computeBuffer_0;

	// Token: 0x040032A3 RID: 12963
	private VolumetricFog.Struct68[] struct68_0;

	// Token: 0x040032A4 RID: 12964
	private ComputeBuffer computeBuffer_1;

	// Token: 0x040032A5 RID: 12965
	private VolumetricFog.Struct69[] struct69_0;

	// Token: 0x040032A6 RID: 12966
	private ComputeBuffer computeBuffer_2;

	// Token: 0x040032A7 RID: 12967
	private VolumetricFog.Struct70[] struct70_0;

	// Token: 0x040032A8 RID: 12968
	private ComputeBuffer computeBuffer_3;

	// Token: 0x040032A9 RID: 12969
	private ComputeBuffer computeBuffer_4;

	// Token: 0x040032AA RID: 12970
	private float[] float_0;

	// Token: 0x040032AC RID: 12972
	private float[] float_1;

	// Token: 0x040032AD RID: 12973
	private float[] float_2;

	// Token: 0x040032AE RID: 12974
	private float[] float_3;

	// Token: 0x040032AF RID: 12975
	private float[] float_4;

	// Token: 0x040032B0 RID: 12976
	private static readonly Vector2[] vector2_0 = new Vector2[]
	{
		new Vector2(0f, 0f),
		new Vector2(1f, 0f),
		new Vector2(1f, 1f),
		new Vector2(0f, 1f)
	};

	// Token: 0x040032B1 RID: 12977
	private static float[] float_5 = new float[16];

	// Token: 0x040032B2 RID: 12978
	private static readonly int int_0 = Shader.PropertyToID("_VolumeInject");

	// Token: 0x040032B3 RID: 12979
	private static readonly int int_1 = Shader.PropertyToID("_VolumeScatter");

	// Token: 0x040032B4 RID: 12980
	private static readonly int int_2 = Shader.PropertyToID("_Z");

	// Token: 0x040032B5 RID: 12981
	private static readonly int int_3 = Shader.PropertyToID("_MainTex");

	// Token: 0x040032B6 RID: 12982
	private static readonly int int_4 = Shader.PropertyToID("_Screen_TexelSize");

	// Token: 0x040032B7 RID: 12983
	private static readonly int int_5 = Shader.PropertyToID("_VolumeScatter_TexelSize");

	// Token: 0x040032B8 RID: 12984
	private static readonly int int_6 = Shader.PropertyToID("_CameraFarOverMaxFar");

	// Token: 0x040032B9 RID: 12985
	private static readonly int int_7 = Shader.PropertyToID("_NearOverFarClip");

	private struct Struct67
	{
		// Token: 0x040032BD RID: 12989
		public Vector3 pos;

		// Token: 0x040032BE RID: 12990
		public float range;

		// Token: 0x040032BF RID: 12991
		public Vector3 color;

		// Token: 0x040032C0 RID: 12992
		private float float_0;
	}

	// Token: 0x02000866 RID: 2150
	private struct Struct68
	{
		// Token: 0x040032C1 RID: 12993
		public Vector3 start;

		// Token: 0x040032C2 RID: 12994
		public float range;

		// Token: 0x040032C3 RID: 12995
		public Vector3 end;

		// Token: 0x040032C4 RID: 12996
		public float radius;

		// Token: 0x040032C5 RID: 12997
		public Vector3 color;

		// Token: 0x040032C6 RID: 12998
		private float float_0;
	}

	// Token: 0x02000867 RID: 2151
	private struct Struct69
	{
		// Token: 0x040032C7 RID: 12999
		public Matrix4x4 mat;

		// Token: 0x040032C8 RID: 13000
		public Vector4 pos;

		// Token: 0x040032C9 RID: 13001
		public Vector3 color;

		// Token: 0x040032CA RID: 13002
		public float bounded;
	}

	// Token: 0x02000868 RID: 2152
	private struct Struct70
	{
		// Token: 0x040032CB RID: 13003
		public Vector3 pos;

		// Token: 0x040032CC RID: 13004
		public float radius;

		// Token: 0x040032CD RID: 13005
		public Vector3 axis;

		// Token: 0x040032CE RID: 13006
		public float stretch;

		// Token: 0x040032CF RID: 13007
		public float density;

		// Token: 0x040032D0 RID: 13008
		public float noiseAmount;

		// Token: 0x040032D1 RID: 13009
		public float noiseSpeed;

		// Token: 0x040032D2 RID: 13010
		public float noiseScale;

		// Token: 0x040032D3 RID: 13011
		public float feather;

		// Token: 0x040032D4 RID: 13012
		public float blend;

		// Token: 0x040032D5 RID: 13013
		public float padding1;

		// Token: 0x040032D6 RID: 13014
		public float padding2;
	}
}
