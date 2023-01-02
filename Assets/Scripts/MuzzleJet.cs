using System;
using UnityEngine;

// Token: 0x0200099C RID: 2460
public class MuzzleJet : MuzzleEffect
{
	public const string MeshName = "MuzzleJetCombinedMesh";

	// Token: 0x04003BA8 RID: 15272
	public MuzzleJet.Particle[] Particles;

	// Token: 0x04003BA9 RID: 15273
	public MuzzleJet.EditorType Type;

	// Token: 0x04003BAA RID: 15274
	public int ParticlesCount = 3;

	// Token: 0x04003BAB RID: 15275
	public Vector3 JetBounds = new Vector3(0f, 1f, 1.5f);

	// Token: 0x04003BAC RID: 15276
	public AnimationCurve PositionDensity = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0.5f),
		new Keyframe(1f, 0.5f)
	});

	// Token: 0x04003BAD RID: 15277
	public AnimationCurve Sizes = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f, 1f, 1f),
		new Keyframe(1f, 1f, 1f, 1f)
	});

	// Token: 0x04003BAE RID: 15278
	public AnimationCurve RandomShiftsX = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(1f, 0f)
	});

	// Token: 0x04003BAF RID: 15279
	public AnimationCurve RandomShiftsY = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(1f, 0f)
	});

	// Token: 0x04003BB0 RID: 15280
	public AnimationCurve AxisShift = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(1f, 0f)
	});

	// Token: 0x04003BB1 RID: 15281
	public float SizesMult = 1f;

	// Token: 0x04003BB2 RID: 15282
	public float AxisShiftMult = 1f;

	// Token: 0x04003BB3 RID: 15283
	public float Chance = 1f;

	// Token: 0x04003BB4 RID: 15284
	public Vector2 RandomShiftsMult = Vector2.one;
	public enum EditorType
	{
		// Token: 0x04003BB9 RID: 15289
		CurveDriven,
		// Token: 0x04003BBA RID: 15290
		Manually
	}

	// Token: 0x0200099E RID: 2462
	[Serializable]
	public class Particle
	{
		// Token: 0x04003BBB RID: 15291
		public float Position;

		// Token: 0x04003BBC RID: 15292
		public float Size = 1f;

		// Token: 0x04003BBD RID: 15293
		public Vector2 RandomShift;

		// Token: 0x04003BBE RID: 15294
		public float AxisShift;
	}
}
