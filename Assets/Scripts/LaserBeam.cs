using System;
using UnityEngine;

// Token: 0x02000AB5 RID: 2741
public class LaserBeam : MonoBehaviour
{
	// Token: 0x04004169 RID: 16745
	public float RayStart = 0.1f;

	// Token: 0x0400416A RID: 16746
	public float MaxDistance = 100f;

	// Token: 0x0400416B RID: 16747
	public bool UsePointLight = true;

	// Token: 0x0400416C RID: 16748
	public Material BeamMaterial;

	// Token: 0x0400416D RID: 16749
	public Material PointMaterial;

	// Token: 0x0400416E RID: 16750
	public LayerMask Mask;

	// Token: 0x0400416F RID: 16751
	public float BeamSize;

	// Token: 0x04004170 RID: 16752
	public float PointSizeClose;

	// Token: 0x04004171 RID: 16753
	public float PointSizeFar;

	// Token: 0x04004172 RID: 16754
	public float SurfaceOffsetForLight;

	// Token: 0x04004173 RID: 16755
	public float LightRange;

	// Token: 0x04004174 RID: 16756
	public float LightIntensity;

	// Token: 0x04004175 RID: 16757
	[SerializeField]
	private float IntensityFactor = 1f;

	// Token: 0x04004176 RID: 16758
	public Texture Cookie;

	// Token: 0x04004177 RID: 16759
	public Vector2 AngleCloseFar = new Vector2(4f, 200f);

	// Token: 0x04004178 RID: 16760
	private bool bool_0;

	// Token: 0x04004179 RID: 16761
	private UnityEngine.Mesh mesh_0;

	// Token: 0x0400417A RID: 16762
	private UnityEngine.Mesh mesh_1;

	// Token: 0x0400417B RID: 16763
	private Light light_0;

	// Token: 0x0400417C RID: 16764
	private MaterialPropertyBlock materialPropertyBlock_0;

	// Token: 0x0400417D RID: 16765
	private MaterialPropertyBlock materialPropertyBlock_1;

	// Token: 0x0400417E RID: 16766
	private static readonly int int_0 = Shader.PropertyToID("_Distance");

	// Token: 0x0400417F RID: 16767
	private static readonly int int_1 = Shader.PropertyToID("_Intensity");

	// Token: 0x04004180 RID: 16768
	private static readonly int int_2 = Shader.PropertyToID("_Size");

	// Token: 0x04004181 RID: 16769
	private static readonly int int_3 = Shader.PropertyToID("_MaxDist");

	// Token: 0x04004182 RID: 16770
	private static readonly int int_4 = Shader.PropertyToID("_Color");

	// Token: 0x04004183 RID: 16771
	private static readonly int int_5 = Shader.PropertyToID("_Factor");
}
