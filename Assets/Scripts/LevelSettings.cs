using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000760 RID: 1888
[AddComponentMenu("Scripts/Game/Components/LevelSettings")]
public class LevelSettings : MonoBehaviour
{
	public void OnValidate()
	{
		RenderSettings.ambientMode = this.AmbientMode;
		RenderSettings.ambientEquatorColor = this.EquatorColor;
		RenderSettings.ambientGroundColor = this.GroundColor;
		RenderSettings.ambientSkyColor = this.SkyColor;
		RenderSettings.ambientLight = this.SkyColor;
		RenderSettings.ambientIntensity = this.AmbientIntensity;
		RenderSettings.fog = this.fog;
		RenderSettings.fogColor = this.fogColor;
		RenderSettings.fogDensity = this.fogDensity;
		RenderSettings.fogEndDistance = this.fogEndDistance;
		RenderSettings.fogMode = this.fogMode;
		RenderSettings.fogStartDistance = this.fogStartDistance;
		RenderSettings.skybox = this.skybox;
	}

	public Camera CameraPrefab;

	// Token: 0x04002FC5 RID: 12229
	public Material skybox;

	// Token: 0x04002FC6 RID: 12230
	public Bounds RainBounds = new Bounds(Vector3.zero, new Vector3(1000f, 220f, 1000f));

	// Token: 0x04002FC7 RID: 12231
	[Header("Ambient")]
	public AmbientMode AmbientMode = AmbientMode.Flat;

	// Token: 0x04002FC8 RID: 12232
	public Color SkyColor = Color.black;

	// Token: 0x04002FC9 RID: 12233
	public Color EquatorColor = new Color(0.6039216f, 0.635294139f, 0.6509804f);

	// Token: 0x04002FCA RID: 12234
	public Color GroundColor = new Color(0.6039216f, 0.635294139f, 0.6509804f);

	// Token: 0x04002FCB RID: 12235
	public float AmbientIntensity;

	// Token: 0x04002FCC RID: 12236
	[Header("NightVisionAmbient")]
	public Color NightVisionSkyColor = Color.black;

	// Token: 0x04002FCD RID: 12237
	public Color NightVisionEquatorColor = Color.black;

	// Token: 0x04002FCE RID: 12238
	public Color NightVisionGroundColor = Color.black;

	// Token: 0x04002FCF RID: 12239
	public float NightVisionAmbientIntensity;

	// Token: 0x04002FD0 RID: 12240
	[SerializeField]
	[Space]
	private Color _minSmokeAmbientColor = Color.clear;

	// Token: 0x04002FD1 RID: 12241
	public float SSRFactor = 1f;

	// Token: 0x04002FD2 RID: 12242
	[Header("Fog")]
	public bool fog;

	// Token: 0x04002FD3 RID: 12243
	public Color fogColor;

	// Token: 0x04002FD4 RID: 12244
	public float fogDensity;

	// Token: 0x04002FD5 RID: 12245
	public float fogEndDistance;

	// Token: 0x04002FD6 RID: 12246
	public FogMode fogMode;

	// Token: 0x04002FD7 RID: 12247
	public float fogStartDistance;

	// Token: 0x04002FD8 RID: 12248
	[Header("Sun")]
	public Color SunColor = new Color32(byte.MaxValue, 209, 145, byte.MaxValue);

	// Token: 0x04002FD9 RID: 12249
	public float SunScratchesIntensity = 6f;

	// Token: 0x04002FDA RID: 12250
	public float SunShaftsIntensity = 0.2f;

	// Token: 0x04002FDB RID: 12251
	public float SunShaftsDensity = 0.15f;

	// Token: 0x04002FDC RID: 12252
	public bool SunLensFlares = true;

	// Token: 0x04002FDD RID: 12253
	public bool SunBackGroung = true;

	// Token: 0x04002FDE RID: 12254
	public float LyingWater;

	// Token: 0x04002FDF RID: 12255
	[Range(0f, 1f)]
	public float DirectionLightShadowForUnshadowedShaders;

	// Token: 0x04002FE0 RID: 12256
	[Header("Scattering")]
	[Range(0f, 1f)]
	public float HeightFalloff = 0.029f;

	// Token: 0x04002FE1 RID: 12257
	public float ZeroLevel = -78.64f;

	// Token: 0x04002FE8 RID: 12264
	[Header("Compass")]
	[SerializeField]
	[Range(0f, 360f)]
	private float _northDirection;

	// Token: 0x04002FE9 RID: 12265
	[SerializeField]
	public Vector4 MaxMapTextureMemory = new Vector4(1024f, 1024f, 1024f, 1024f);
}
