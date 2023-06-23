using System;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000983 RID: 2435
[ExecuteInEditMode]
public class AdvancedLight : MonoBehaviour
{
	// Token: 0x06003C80 RID: 15488 RVA: 0x00120117 File Offset: 0x0011E317
	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position, "AreaLight Gizmo", true);
	}

	// Token: 0x06003C81 RID: 15489 RVA: 0x00120140 File Offset: 0x0011E340
	private void OnDrawGizmosSelected()
	{
		if (!this.ShowDebugShapes)
		{
			return;
		}
		Gizmos.DrawWireMesh(this.Mesh, this.SubMesh, this.transform_0.position, this.transform_0.rotation, this.transform_0.lossyScale);
		Gizmos.DrawWireSphere(this.transform_1.position, this.Radius);
		Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
		Gizmos.DrawMesh(this.Mesh, this.SubMesh, this.transform_0.position, this.transform_0.rotation, this.transform_0.lossyScale);
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(this.CubeShift, this.CubeScale);
	}

	// Token: 0x06003C82 RID: 15490 RVA: 0x0012021C File Offset: 0x0011E41C
	public void Draw(CommandBuffer buffer, Plane[] frustrumPlanes, Camera cam)
	{
		Bounds bounds = this.Mesh.bounds;
		bounds.extents = Vector3.Scale(bounds.extents, base.transform.localScale);
		bounds.center += base.transform.position;
		if (!GeometryUtility.TestPlanesAABB(frustrumPlanes, bounds) && !this.FullScreen)
		{
			return;
		}
		BlendMode blendMode = cam.allowHDR ? BlendMode.One : BlendMode.DstColor;
		BlendMode blendMode2 = cam.allowHDR ? BlendMode.One : BlendMode.Zero;
		buffer.SetGlobalFloat(this.int_2, (float)blendMode);
		buffer.SetGlobalFloat(this.int_3, (float)blendMode2);
		this.material_0.SetVector(this.int_0, this.transform_1.position);
		this.material_0.SetVector(this.int_1, this.transform_1.forward);
		buffer.DrawMesh(this.Mesh, base.transform.localToWorldMatrix, this.material_0, this.SubMesh, 0);
	}

	// Token: 0x04003B00 RID: 15104
	public Shader Shader;

	// Token: 0x04003B01 RID: 15105
	public AdvancedLight.LightTypeEnum LightType;

	// Token: 0x04003B02 RID: 15106
	public Mesh Mesh;

	// Token: 0x04003B03 RID: 15107
	public int SubMesh;

	// Token: 0x04003B04 RID: 15108
	public Transform LightPosition;

	// Token: 0x04003B05 RID: 15109
	[ColorUsage(false, true)]
	public Color Color;

	// Token: 0x04003B06 RID: 15110
	public float Radius;

	// Token: 0x04003B07 RID: 15111
	public AdvancedLight.ShadingTypeEnum ShadingType;

	// Token: 0x04003B08 RID: 15112
	public bool ShowDebugShapes;

	// Token: 0x04003B09 RID: 15113
	public Transform CubeControlHelper;

	// Token: 0x04003B0A RID: 15114
	public bool FullScreen;

	// Token: 0x04003B0B RID: 15115
	[HideInInspector]
	public Vector3 CubeScale = AdvancedLight.vector3_0;

	// Token: 0x04003B0C RID: 15116
	[HideInInspector]
	public Vector3 CubeShift = AdvancedLight.vector3_1;

	// Token: 0x04003B0D RID: 15117
	private Material material_0;

	// Token: 0x04003B0E RID: 15118
	private Transform transform_0;

	// Token: 0x04003B0F RID: 15119
	private Transform transform_1;

	// Token: 0x04003B10 RID: 15120
	private int int_0;

	// Token: 0x04003B11 RID: 15121
	private int int_1;

	// Token: 0x04003B12 RID: 15122
	private int int_2;

	// Token: 0x04003B13 RID: 15123
	private int int_3;

	// Token: 0x04003B14 RID: 15124
	private int int_4;

	// Token: 0x04003B15 RID: 15125
	private int int_5;

	// Token: 0x04003B16 RID: 15126
	private float float_0;

	// Token: 0x04003B17 RID: 15127
	private static readonly Vector3 vector3_0 = Vector3.one;

	// Token: 0x04003B18 RID: 15128
	private static readonly Vector3 vector3_1 = Vector3.zero;

	// Token: 0x04003B19 RID: 15129
	private static readonly int int_6 = Shader.PropertyToID("_Color");

	// Token: 0x04003B1A RID: 15130
	private static readonly int int_7 = Shader.PropertyToID("_InvSqRadius");

	// Token: 0x04003B1B RID: 15131
	private static readonly int int_8 = Shader.PropertyToID("_FullScreen");

	// Token: 0x04003B1C RID: 15132
	private static readonly int int_9 = Shader.PropertyToID("_CubeHelperScale");

	// Token: 0x04003B1D RID: 15133
	private static readonly int int_10 = Shader.PropertyToID("_CubeHelperShift");

	// Token: 0x02000984 RID: 2436
	public enum LightTypeEnum
	{
		// Token: 0x04003B1F RID: 15135
		Point,
		// Token: 0x04003B20 RID: 15136
		Directional
	}

	// Token: 0x02000985 RID: 2437
	public enum ShadingTypeEnum
	{
		// Token: 0x04003B22 RID: 15138
		Diffuse,
		// Token: 0x04003B23 RID: 15139
		Specular,
		// Token: 0x04003B24 RID: 15140
		DiffuseAndSpecular
	}
}