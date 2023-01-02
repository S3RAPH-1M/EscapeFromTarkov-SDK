using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009A0 RID: 2464
public class MuzzleManager : MonoBehaviour
{
	// Token: 0x17000869 RID: 2153
	// (get) Token: 0x06003CF3 RID: 15603 RVA: 0x00122EF3 File Offset: 0x001210F3
	// (set) Token: 0x06003CF4 RID: 15604 RVA: 0x00122EFB File Offset: 0x001210FB
	public GameObject[] MuzzleJets { get; private set; }

	// Token: 0x04003BC3 RID: 15299
	public Material JetMaterial;

	// Token: 0x04003BC4 RID: 15300
	public int AtlasXCount;

	// Token: 0x04003BC5 RID: 15301
	public int AtlasYCount;

	// Token: 0x04003BC6 RID: 15302
	public AnimationCurve MoveCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	// Token: 0x04003BC7 RID: 15303
	public AnimationCurve JetLightCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	// Token: 0x04003BC8 RID: 15304
	public float ShotLength = 0.1f;

	// Token: 0x04003BC9 RID: 15305
	public bool TestPlay;

	// Token: 0x04003BCA RID: 15306
	public bool TestShoot;

	// Token: 0x04003BCB RID: 15307
	public bool TestHold;

	// Token: 0x04003BCC RID: 15308
	public float TestDebugPosition;

	// Token: 0x04003BCD RID: 15309
	public float TestDelay;

	// Token: 0x04003BCE RID: 15310
	public MuzzleLight Light;

	// Token: 0x04003BCF RID: 15311
	public string MeshParentName = "weapon";

	// Token: 0x04003BD0 RID: 15312
	private MuzzleJet[] muzzleJet_0;

	// Token: 0x04003BD1 RID: 15313
	private MuzzleSparks[] muzzleSparks_0;

	// Token: 0x04003BD2 RID: 15314
	private MuzzleFume[] muzzleFume_0;

	// Token: 0x04003BD3 RID: 15315
	private MuzzleFume[] muzzleFume_1;

	// Token: 0x04003BD4 RID: 15316
	private MuzzleSmoke[] muzzleSmoke_0;

	// Token: 0x04003BD5 RID: 15317
	private HeatEmitter[] heatEmitter_0;

	// Token: 0x04003BD6 RID: 15318
	private HeatHazeEmitter[] heatHazeEmitter_0;

	// Token: 0x04003BD7 RID: 15319
	private Vector2 vector2_0;

	// Token: 0x04003BD8 RID: 15320
	private float float_0;

	// Token: 0x04003BD9 RID: 15321
	public Transform Hierarchy;

	// Token: 0x04003BDA RID: 15322
	private float float_1;

	// Token: 0x04003BDB RID: 15323
	private static readonly int int_0 = Shader.PropertyToID("_ShotVals");

	// Token: 0x04003BDC RID: 15324
	private float float_2;

	// Token: 0x04003BDD RID: 15325
	private float float_3;

	// Token: 0x04003BDE RID: 15326
	private bool bool_0;

	// Token: 0x04003BDF RID: 15327
	private bool bool_1;

	// Token: 0x04003BE0 RID: 15328
	[CompilerGenerated]
	private GameObject[] gameObject_0;

	// Token: 0x020009A1 RID: 2465
	[CompilerGenerated]
	private sealed class Class486
	{
		// Token: 0x06003D09 RID: 15625 RVA: 0x001238B8 File Offset: 0x00121AB8
		internal bool method_0(MuzzleEffect x)
		{
			return !this.launcherGo.Contains(x.gameObject);
		}

		// Token: 0x04003BE1 RID: 15329
		public GameObject[] launcherGo;
	}

	// Token: 0x020009A2 RID: 2466
	[CompilerGenerated]
	[Serializable]
	private sealed class Class487
	{
		// Token: 0x06003D0C RID: 15628 RVA: 0x001238DA File Offset: 0x00121ADA
		internal GameObject method_0(MuzzleFume f)
		{
			return f.gameObject;
		}

		// Token: 0x06003D0D RID: 15629 RVA: 0x001238DA File Offset: 0x00121ADA
		internal GameObject method_1(MuzzleEffect x)
		{
			return x.gameObject;
		}

		// Token: 0x06003D0E RID: 15630 RVA: 0x001238E2 File Offset: 0x00121AE2
		internal float method_2(MuzzleJet x)
		{
			return x.Chance;
		}

		// Token: 0x04003BE2 RID: 15330
		public static readonly MuzzleManager.Class487 class487_0 = new MuzzleManager.Class487();

		// Token: 0x04003BE3 RID: 15331
		public static Func<MuzzleFume, GameObject> func_0;

		// Token: 0x04003BE4 RID: 15332
		public static Func<MuzzleEffect, GameObject> func_1;

		// Token: 0x04003BE5 RID: 15333
		public static Func<MuzzleJet, float> func_2;
	}
}
