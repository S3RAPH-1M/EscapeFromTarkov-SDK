using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT.Ballistics;
using UnityEngine;
using UnityEngine.Rendering;

namespace DeferredDecals
{
	// Token: 0x02000B4A RID: 2890
	public class DeferredDecalRenderer : MonoBehaviour
	{
		// Token: 0x0400488F RID: 18575
		[Range(0.001f, 3f)]
		[SerializeField]
		private float _decalProjectorHeight;

		// Token: 0x04004890 RID: 18576
		[SerializeField]
		[Range(0.001f, 3f)]
		private float _decalProjectorHeightForGrenade;

		// Token: 0x04004891 RID: 18577
		[Range(1f, 1024f)]
		[SerializeField]
		private int _maxDecals;

		// Token: 0x04004892 RID: 18578
		[Range(1f, 1024f)]
		[SerializeField]
		private int _maxDynamicDecals;

		// Token: 0x04004893 RID: 18579
		[Range(1f, 1000f)]
		[SerializeField]
		private int _cullDistance;

		// Token: 0x04004894 RID: 18580
		[SerializeField]
		private DeferredDecalRenderer.SingleDecal[] _decals;

		// Token: 0x04004895 RID: 18581
		[SerializeField]
		private DeferredDecalRenderer.SingleDecal _environmentBlood;

		// Token: 0x04004896 RID: 18582
		[SerializeField]
		private DeferredDecalRenderer.SingleDecal _bleedingDecal;

		// Token: 0x04004897 RID: 18583
		[SerializeField]
		private DeferredDecalRenderer.SingleDecal _grenadeDecal;

		// Token: 0x04004898 RID: 18584
		[SerializeField]
		private DeferredDecalRenderer.SingleDecal _genericDecal;

		// Token: 0x04004899 RID: 18585
		[SerializeField]
		private Mesh _cube;

		// Token: 0x0400489A RID: 18586
		private readonly Queue<DeferredDecalRenderer.GClass826> queue_0;

		// Token: 0x0400489B RID: 18587
		private readonly Dictionary<Material, DeferredDecalRenderer.GClass826> dictionary_0;

		// Token: 0x0400489C RID: 18588
		private readonly Dictionary<MaterialType, DeferredDecalRenderer.SingleDecal> dictionary_1;

		// Token: 0x0400489D RID: 18589
		private int int_0;

		// Token: 0x0400489E RID: 18590
		private int int_1;

		// Token: 0x0400489F RID: 18591
		private int int_2;

		// Token: 0x040048A0 RID: 18592
		private Dictionary<Camera, DeferredDecalRenderer.Class578> dictionary_2;

		// Token: 0x040048A1 RID: 18593
		private BoundingSphere[] boundingSphere_0;

		// Token: 0x040048A2 RID: 18594
		private int int_3;

		// Token: 0x040048A3 RID: 18595
		private List<DynamicDeferredDecalRenderer> list_0;

		// Token: 0x040048A4 RID: 18596
		private Vector4[] vector4_0;

		// Token: 0x040048A5 RID: 18597
		private Vector4[] vector4_1;

		// Token: 0x040048A6 RID: 18598
		private Vector4[] vector4_2;

		// Token: 0x040048A7 RID: 18599
		private Vector3[] vector3_0;

		// Token: 0x040048A8 RID: 18600
		private Vector3[] vector3_1;

		// Token: 0x040048A9 RID: 18601
		private Vector4[] vector4_3;

		// Token: 0x040048AA RID: 18602
		private Transform transform_0;

		// Token: 0x040048AB RID: 18603
		private const float float_0 = 0.4f;

		// Token: 0x040048AC RID: 18604
		private CommandBuffer commandBuffer_0;

		// Token: 0x040048AD RID: 18605
		private CommandBuffer commandBuffer_1;

		// Token: 0x040048AE RID: 18606
		private bool bool_0;

		// Token: 0x02000B4B RID: 2891
		public class GClass826 : IDisposable
		{
			// Token: 0x060048FD RID: 18685 RVA: 0x00002050 File Offset: 0x00000250
			[MethodImpl(MethodImplOptions.NoInlining)]
			public void Dispose()
			{
				throw null;
			}

			// Token: 0x040048AF RID: 18607
			public readonly int VertexCount;

			// Token: 0x040048B0 RID: 18608
			public readonly Mesh Mesh;

			// Token: 0x040048B1 RID: 18609
			public readonly Vector3[] Vertices;

			// Token: 0x040048B2 RID: 18610
			public readonly Vector3[] Normals;

			// Token: 0x040048B3 RID: 18611
			public readonly Vector4[] Tangents;

			// Token: 0x040048B4 RID: 18612
			public readonly List<Vector4> Uvs0;

			// Token: 0x040048B5 RID: 18613
			public readonly List<Vector4> Uvs1;

			// Token: 0x040048B6 RID: 18614
			public readonly List<Vector4> Uvs2;

			// Token: 0x040048B7 RID: 18615
			private static int[] int_0;

			// Token: 0x040048B8 RID: 18616
			private static int int_1;

			// Token: 0x040048B9 RID: 18617
			private const int int_2 = 10000;
		}

		// Token: 0x02000B4C RID: 2892
		[Serializable]
		public class SingleDecal
		{
			// Token: 0x040048BA RID: 18618
			public bool RandomizeRotation;

			// Token: 0x040048BB RID: 18619
			[GAttribute6(0f, 2f, -1f)]
			public Vector2 DecalSize;

			// Token: 0x040048BC RID: 18620
			[Range(1f, 10f)]
			public int TileSheetRows;

			// Token: 0x040048BD RID: 18621
			[Range(1f, 10f)]
			public int TileSheetColumns;

			// Token: 0x040048BE RID: 18622
			public MaterialType[] DecalMaterialType;

			// Token: 0x040048BF RID: 18623
			public Material DecalMaterial;

			// Token: 0x040048C0 RID: 18624
			public Material DynamicDecalMaterial;

			// Token: 0x040048C1 RID: 18625
			[HideInInspector]
			public float TileUSize;

			// Token: 0x040048C2 RID: 18626
			[HideInInspector]
			public float TileVSize;

			// Token: 0x040048C3 RID: 18627
			[HideInInspector]
			public bool IsTiled;
		}

		// Token: 0x02000B4D RID: 2893
		private class Class578
		{
			// Token: 0x040048C4 RID: 18628
			public CommandBuffer StaticDecalsBuffer;

			// Token: 0x040048C5 RID: 18629
			public CommandBuffer DynamicDecalsBuffer;

			// Token: 0x040048C6 RID: 18630
			public CullingGroup CullGroup;

			// Token: 0x040048C7 RID: 18631
			public bool IsStaticBufferDirty;

			// Token: 0x040048C8 RID: 18632
			public bool IsDynamicBufferDirty;
		}
	}
}
