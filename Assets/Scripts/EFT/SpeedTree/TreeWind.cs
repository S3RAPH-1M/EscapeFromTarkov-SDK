using System;
using System.Collections.Generic;
using UnityEngine;

namespace EFT.SpeedTree
{
	// Token: 0x02001AB9 RID: 6841
	[ExecuteInEditMode]
	public class TreeWind : MonoBehaviour
	{
		// Token: 0x0600A098 RID: 41112 RVA: 0x002CA250 File Offset: 0x002C8450
		public void Init(MaterialPropertyBlock mpb)
		{
			this.materialPropertyBlock_0 = mpb;
			Tree component = base.GetComponent<Tree>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
				base.Invoke("SetParams", 0.5f);
				return;
			}
			this.SetParams();
		}

		// Token: 0x0600A099 RID: 41113 RVA: 0x002CA294 File Offset: 0x002C8494
		public void FillSettings()
		{
			this.settings = default(TreeWind.Settings);
			this.settings.BaseMinWindData = this.BaseMinWindData;
			this.settings.BaseMaxWindData = this.BaseMaxWindData;
			this.settings.MinWindData = this.MinWindData;
			this.settings.MaxWindData = this.MaxWindData;
		}

		// Token: 0x0600A09A RID: 41114 RVA: 0x002CA2F1 File Offset: 0x002C84F1
		public void SetDrawMotionVectors(bool isEnable)
		{
			base.GetComponent<Renderer>().motionVectorGenerationMode = (isEnable ? MotionVectorGenerationMode.Object : MotionVectorGenerationMode.Camera);
		}

		// Token: 0x0600A09B RID: 41115 RVA: 0x002CA305 File Offset: 0x002C8505
		[ContextMenu("SetParams")]
		public void SetParamsForce()
		{
			this.SetParams(TreeWind.CreateMaterialPropertyBlock(this.BaseMinWindData, this.BaseMaxWindData, this.MinWindData, this.MaxWindData));
		}

		// Token: 0x0600A09C RID: 41116 RVA: 0x002CA32A File Offset: 0x002C852A
		public void SetParams()
		{
			if (this.materialPropertyBlock_0 == null)
			{
				Debug.LogError("_mpb == null");
				this.SetParamsForce();
				return;
			}
			this.SetParams(this.materialPropertyBlock_0);
		}

		// Token: 0x0600A09D RID: 41117 RVA: 0x002CA354 File Offset: 0x002C8554
		public void SetParams(MaterialPropertyBlock mpb)
		{
			Renderer renderer;
			if (base.TryGetComponent<Renderer>(out renderer))
			{
				renderer.SetPropertyBlock(mpb);
			}
		}

		// Token: 0x0600A09E RID: 41118 RVA: 0x002CA374 File Offset: 0x002C8574
		public static MaterialPropertyBlock CreateMaterialPropertyBlock(TreeWind.BaseTreeData baseMinWindData, TreeWind.BaseTreeData baseMaxWindData, TreeWind.FactorTreeData minWindData, TreeWind.FactorTreeData maxWindData)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetFloat(TreeWind.int_0, (baseMinWindData._ST_WindGlobal.magnitude > 0f) ? 1f : 0f);
			materialPropertyBlock.SetVector(TreeWind.int_1, baseMinWindData._ST_WindGlobal);
			materialPropertyBlock.SetVector(TreeWind.int_2, baseMinWindData._ST_WindBranch);
			materialPropertyBlock.SetVector(TreeWind.int_3, baseMinWindData._ST_WindBranchTwitch);
			materialPropertyBlock.SetVector(TreeWind.int_4, baseMinWindData._ST_WindBranchWhip);
			materialPropertyBlock.SetVector(TreeWind.int_5, baseMinWindData._ST_WindBranchAnchor);
			materialPropertyBlock.SetVector(TreeWind.int_6, baseMinWindData._ST_WindBranchAdherences);
			materialPropertyBlock.SetVector(TreeWind.int_7, baseMinWindData._ST_WindTurbulences);
			materialPropertyBlock.SetVector(TreeWind.int_8, baseMinWindData._ST_WindLeaf1Ripple);
			materialPropertyBlock.SetVector(TreeWind.int_9, baseMinWindData._ST_WindLeaf1Tumble);
			materialPropertyBlock.SetVector(TreeWind.int_10, baseMinWindData._ST_WindLeaf1Twitch);
			materialPropertyBlock.SetVector(TreeWind.int_11, baseMinWindData._ST_WindLeaf2Ripple);
			materialPropertyBlock.SetVector(TreeWind.int_12, baseMinWindData._ST_WindLeaf2Tumble);
			materialPropertyBlock.SetVector(TreeWind.int_13, baseMinWindData._ST_WindLeaf2Twitch);
			materialPropertyBlock.SetVector(TreeWind.int_14, baseMinWindData._ST_WindFrondRipple);
			materialPropertyBlock.SetVector(TreeWind.int_15, baseMaxWindData._ST_WindGlobal);
			materialPropertyBlock.SetVector(TreeWind.int_16, baseMaxWindData._ST_WindBranch);
			materialPropertyBlock.SetVector(TreeWind.int_17, baseMaxWindData._ST_WindBranchTwitch);
			materialPropertyBlock.SetVector(TreeWind.int_18, baseMaxWindData._ST_WindBranchWhip);
			materialPropertyBlock.SetVector(TreeWind.int_19, baseMaxWindData._ST_WindBranchAnchor);
			materialPropertyBlock.SetVector(TreeWind.int_20, baseMaxWindData._ST_WindBranchAdherences);
			materialPropertyBlock.SetVector(TreeWind.int_21, baseMaxWindData._ST_WindTurbulences);
			materialPropertyBlock.SetVector(TreeWind.int_22, baseMaxWindData._ST_WindLeaf1Ripple);
			materialPropertyBlock.SetVector(TreeWind.int_23, baseMaxWindData._ST_WindLeaf1Tumble);
			materialPropertyBlock.SetVector(TreeWind.int_24, baseMaxWindData._ST_WindLeaf1Twitch);
			materialPropertyBlock.SetVector(TreeWind.int_25, baseMaxWindData._ST_WindLeaf2Ripple);
			materialPropertyBlock.SetVector(TreeWind.int_26, baseMaxWindData._ST_WindLeaf2Tumble);
			materialPropertyBlock.SetVector(TreeWind.int_27, baseMaxWindData._ST_WindLeaf2Twitch);
			materialPropertyBlock.SetVector(TreeWind.int_28, baseMaxWindData._ST_WindFrondRipple);
			materialPropertyBlock.SetVector(TreeWind.int_29, maxWindData._ST_WindGlobal_B);
			materialPropertyBlock.SetVector(TreeWind.int_30, maxWindData._ST_WindBranch_B);
			materialPropertyBlock.SetVector(TreeWind.int_31, maxWindData._ST_WindLeaf1Ripple_B);
			materialPropertyBlock.SetVector(TreeWind.int_32, maxWindData._ST_WindLeaf1Tumble_B);
			materialPropertyBlock.SetVector(TreeWind.int_33, maxWindData._ST_WindLeaf1Twitch_B);
			materialPropertyBlock.SetVector(TreeWind.int_34, maxWindData._ST_WindLeaf2Ripple_B);
			materialPropertyBlock.SetVector(TreeWind.int_35, maxWindData._ST_WindLeaf2Tumble_B);
			materialPropertyBlock.SetVector(TreeWind.int_36, maxWindData._ST_WindLeaf2Twitch_B);
			materialPropertyBlock.SetVector(TreeWind.int_37, maxWindData._ST_WindFrondRipple_B);
			materialPropertyBlock.SetVector(TreeWind.int_38, minWindData._ST_WindGlobal_B);
			materialPropertyBlock.SetVector(TreeWind.int_39, minWindData._ST_WindBranch_B);
			materialPropertyBlock.SetVector(TreeWind.int_40, minWindData._ST_WindLeaf1Ripple_B);
			materialPropertyBlock.SetVector(TreeWind.int_41, minWindData._ST_WindLeaf1Tumble_B);
			materialPropertyBlock.SetVector(TreeWind.int_42, minWindData._ST_WindLeaf1Twitch_B);
			materialPropertyBlock.SetVector(TreeWind.int_43, minWindData._ST_WindLeaf2Ripple_B);
			materialPropertyBlock.SetVector(TreeWind.int_44, minWindData._ST_WindLeaf2Tumble_B);
			materialPropertyBlock.SetVector(TreeWind.int_45, minWindData._ST_WindLeaf2Twitch_B);
			materialPropertyBlock.SetVector(TreeWind.int_46, minWindData._ST_WindFrondRipple_B);
			return materialPropertyBlock;
		}

		// Token: 0x0600A09F RID: 41119 RVA: 0x002CA6BE File Offset: 0x002C88BE
		[ContextMenu("Clear Wind")]
		public void SetClearWind()
		{
			this.materialPropertyBlock_0 = new MaterialPropertyBlock();
			this.SetParams(this.materialPropertyBlock_0);
		}

		// Token: 0x0400924D RID: 37453
		public TreeWind.BaseTreeData BaseMinWindData;

		// Token: 0x0400924E RID: 37454
		public TreeWind.BaseTreeData BaseMaxWindData;

		// Token: 0x0400924F RID: 37455
		public TreeWind.FactorTreeData MinWindData;

		// Token: 0x04009250 RID: 37456
		public TreeWind.FactorTreeData MaxWindData;

		// Token: 0x04009251 RID: 37457
		[HideInInspector]
		public TreeWind.Settings settings;

		// Token: 0x04009252 RID: 37458
		private MaterialPropertyBlock materialPropertyBlock_0;

		// Token: 0x04009253 RID: 37459
		private static readonly int int_0 = Shader.PropertyToID("_WindEnabled");

		// Token: 0x04009254 RID: 37460
		private static readonly int int_1 = Shader.PropertyToID("_ST_WindGlobal");

		// Token: 0x04009255 RID: 37461
		private static readonly int int_2 = Shader.PropertyToID("_ST_WindBranch");

		// Token: 0x04009256 RID: 37462
		private static readonly int int_3 = Shader.PropertyToID("_ST_WindBranchTwitch");

		// Token: 0x04009257 RID: 37463
		private static readonly int int_4 = Shader.PropertyToID("_ST_WindBranchWhip");

		// Token: 0x04009258 RID: 37464
		private static readonly int int_5 = Shader.PropertyToID("_ST_WindBranchAnchor");

		// Token: 0x04009259 RID: 37465
		private static readonly int int_6 = Shader.PropertyToID("_ST_WindBranchAdherences");

		// Token: 0x0400925A RID: 37466
		private static readonly int int_7 = Shader.PropertyToID("_ST_WindTurbulences");

		// Token: 0x0400925B RID: 37467
		private static readonly int int_8 = Shader.PropertyToID("_ST_WindLeaf1Ripple");

		// Token: 0x0400925C RID: 37468
		private static readonly int int_9 = Shader.PropertyToID("_ST_WindLeaf1Tumble");

		// Token: 0x0400925D RID: 37469
		private static readonly int int_10 = Shader.PropertyToID("_ST_WindLeaf1Twitch");

		// Token: 0x0400925E RID: 37470
		private static readonly int int_11 = Shader.PropertyToID("_ST_WindLeaf2Ripple");

		// Token: 0x0400925F RID: 37471
		private static readonly int int_12 = Shader.PropertyToID("_ST_WindLeaf2Tumble");

		// Token: 0x04009260 RID: 37472
		private static readonly int int_13 = Shader.PropertyToID("_ST_WindLeaf2Twitch");

		// Token: 0x04009261 RID: 37473
		private static readonly int int_14 = Shader.PropertyToID("_ST_WindFrondRipple");

		// Token: 0x04009262 RID: 37474
		private static readonly int int_15 = Shader.PropertyToID("_ST_WindGlobal_A");

		// Token: 0x04009263 RID: 37475
		private static readonly int int_16 = Shader.PropertyToID("_ST_WindBranch_A");

		// Token: 0x04009264 RID: 37476
		private static readonly int int_17 = Shader.PropertyToID("_ST_WindBranchTwitch_A");

		// Token: 0x04009265 RID: 37477
		private static readonly int int_18 = Shader.PropertyToID("_ST_WindBranchWhip_A");

		// Token: 0x04009266 RID: 37478
		private static readonly int int_19 = Shader.PropertyToID("_ST_WindBranchAnchor_A");

		// Token: 0x04009267 RID: 37479
		private static readonly int int_20 = Shader.PropertyToID("_ST_WindBranchAdherences_A");

		// Token: 0x04009268 RID: 37480
		private static readonly int int_21 = Shader.PropertyToID("_ST_WindTurbulences_A");

		// Token: 0x04009269 RID: 37481
		private static readonly int int_22 = Shader.PropertyToID("_ST_WindLeaf1Ripple_A");

		// Token: 0x0400926A RID: 37482
		private static readonly int int_23 = Shader.PropertyToID("_ST_WindLeaf1Tumble_A");

		// Token: 0x0400926B RID: 37483
		private static readonly int int_24 = Shader.PropertyToID("_ST_WindLeaf1Twitch_A");

		// Token: 0x0400926C RID: 37484
		private static readonly int int_25 = Shader.PropertyToID("_ST_WindLeaf2Ripple_A");

		// Token: 0x0400926D RID: 37485
		private static readonly int int_26 = Shader.PropertyToID("_ST_WindLeaf2Tumble_A");

		// Token: 0x0400926E RID: 37486
		private static readonly int int_27 = Shader.PropertyToID("_ST_WindLeaf2Twitch_A");

		// Token: 0x0400926F RID: 37487
		private static readonly int int_28 = Shader.PropertyToID("_ST_WindFrondRipple_A");

		// Token: 0x04009270 RID: 37488
		private static readonly int int_29 = Shader.PropertyToID("_ST_WindGlobal_B");

		// Token: 0x04009271 RID: 37489
		private static readonly int int_30 = Shader.PropertyToID("_ST_WindBranch_B");

		// Token: 0x04009272 RID: 37490
		private static readonly int int_31 = Shader.PropertyToID("_ST_WindLeaf1Ripple_B");

		// Token: 0x04009273 RID: 37491
		private static readonly int int_32 = Shader.PropertyToID("_ST_WindLeaf1Tumble_B");

		// Token: 0x04009274 RID: 37492
		private static readonly int int_33 = Shader.PropertyToID("_ST_WindLeaf1Twitch_B");

		// Token: 0x04009275 RID: 37493
		private static readonly int int_34 = Shader.PropertyToID("_ST_WindLeaf2Ripple_B");

		// Token: 0x04009276 RID: 37494
		private static readonly int int_35 = Shader.PropertyToID("_ST_WindLeaf2Tumble_B");

		// Token: 0x04009277 RID: 37495
		private static readonly int int_36 = Shader.PropertyToID("_ST_WindLeaf2Twitch_B");

		// Token: 0x04009278 RID: 37496
		private static readonly int int_37 = Shader.PropertyToID("_ST_WindFrondRipple_B");

		// Token: 0x04009279 RID: 37497
		private static readonly int int_38 = Shader.PropertyToID("_ST_WindGlobal_C");

		// Token: 0x0400927A RID: 37498
		private static readonly int int_39 = Shader.PropertyToID("_ST_WindBranch_C");

		// Token: 0x0400927B RID: 37499
		private static readonly int int_40 = Shader.PropertyToID("_ST_WindLeaf1Ripple_C");

		// Token: 0x0400927C RID: 37500
		private static readonly int int_41 = Shader.PropertyToID("_ST_WindLeaf1Tumble_C");

		// Token: 0x0400927D RID: 37501
		private static readonly int int_42 = Shader.PropertyToID("_ST_WindLeaf1Twitch_C");

		// Token: 0x0400927E RID: 37502
		private static readonly int int_43 = Shader.PropertyToID("_ST_WindLeaf2Ripple_C");

		// Token: 0x0400927F RID: 37503
		private static readonly int int_44 = Shader.PropertyToID("_ST_WindLeaf2Tumble_C");

		// Token: 0x04009280 RID: 37504
		private static readonly int int_45 = Shader.PropertyToID("_ST_WindLeaf2Twitch_C");

		// Token: 0x04009281 RID: 37505
		private static readonly int int_46 = Shader.PropertyToID("_ST_WindFrondRipple_C");

		// Token: 0x02001ABA RID: 6842
		[Serializable]
		public struct BaseTreeData
		{
			// Token: 0x0600A0A2 RID: 41122 RVA: 0x002CA9A8 File Offset: 0x002C8BA8
			public bool Equals(TreeWind.BaseTreeData other)
			{
				return this._ST_WindGlobal.Equals(other._ST_WindGlobal) && this._ST_WindBranch.Equals(other._ST_WindBranch) && this._ST_WindBranchTwitch.Equals(other._ST_WindBranchTwitch) && this._ST_WindBranchWhip.Equals(other._ST_WindBranchWhip) && this._ST_WindBranchAnchor.Equals(other._ST_WindBranchAnchor) && this._ST_WindBranchAdherences.Equals(other._ST_WindBranchAdherences) && this._ST_WindTurbulences.Equals(other._ST_WindTurbulences) && this._ST_WindLeaf1Ripple.Equals(other._ST_WindLeaf1Ripple) && this._ST_WindLeaf1Tumble.Equals(other._ST_WindLeaf1Tumble) && this._ST_WindLeaf1Twitch.Equals(other._ST_WindLeaf1Twitch) && this._ST_WindLeaf2Ripple.Equals(other._ST_WindLeaf2Ripple) && this._ST_WindLeaf2Tumble.Equals(other._ST_WindLeaf2Tumble) && this._ST_WindLeaf2Twitch.Equals(other._ST_WindLeaf2Twitch) && this._ST_WindFrondRipple.Equals(other._ST_WindFrondRipple);
			}

			// Token: 0x0600A0A3 RID: 41123 RVA: 0x002CAAD4 File Offset: 0x002C8CD4
			public override bool Equals(object obj)
			{
				if (obj is TreeWind.BaseTreeData)
				{
					TreeWind.BaseTreeData other = (TreeWind.BaseTreeData)obj;
					return this.Equals(other);
				}
				return false;
			}

			// Token: 0x0600A0A4 RID: 41124 RVA: 0x002CAAFC File Offset: 0x002C8CFC
			public override int GetHashCode()
			{
				return ((((((((((((this._ST_WindGlobal.GetHashCode() * 397 ^ this._ST_WindBranch.GetHashCode()) * 397 ^ this._ST_WindBranchTwitch.GetHashCode()) * 397 ^ this._ST_WindBranchWhip.GetHashCode()) * 397 ^ this._ST_WindBranchAnchor.GetHashCode()) * 397 ^ this._ST_WindBranchAdherences.GetHashCode()) * 397 ^ this._ST_WindTurbulences.GetHashCode()) * 397 ^ this._ST_WindLeaf1Ripple.GetHashCode()) * 397 ^ this._ST_WindLeaf1Tumble.GetHashCode()) * 397 ^ this._ST_WindLeaf1Twitch.GetHashCode()) * 397 ^ this._ST_WindLeaf2Ripple.GetHashCode()) * 397 ^ this._ST_WindLeaf2Tumble.GetHashCode()) * 397 ^ this._ST_WindLeaf2Twitch.GetHashCode()) * 397 ^ this._ST_WindFrondRipple.GetHashCode();
			}

			// Token: 0x04009282 RID: 37506
			public Vector4 _ST_WindGlobal;

			// Token: 0x04009283 RID: 37507
			public Vector4 _ST_WindBranch;

			// Token: 0x04009284 RID: 37508
			public Vector4 _ST_WindBranchTwitch;

			// Token: 0x04009285 RID: 37509
			public Vector4 _ST_WindBranchWhip;

			// Token: 0x04009286 RID: 37510
			public Vector4 _ST_WindBranchAnchor;

			// Token: 0x04009287 RID: 37511
			public Vector4 _ST_WindBranchAdherences;

			// Token: 0x04009288 RID: 37512
			public Vector4 _ST_WindTurbulences;

			// Token: 0x04009289 RID: 37513
			public Vector4 _ST_WindLeaf1Ripple;

			// Token: 0x0400928A RID: 37514
			public Vector4 _ST_WindLeaf1Tumble;

			// Token: 0x0400928B RID: 37515
			public Vector4 _ST_WindLeaf1Twitch;

			// Token: 0x0400928C RID: 37516
			public Vector4 _ST_WindLeaf2Ripple;

			// Token: 0x0400928D RID: 37517
			public Vector4 _ST_WindLeaf2Tumble;

			// Token: 0x0400928E RID: 37518
			public Vector4 _ST_WindLeaf2Twitch;

			// Token: 0x0400928F RID: 37519
			public Vector4 _ST_WindFrondRipple;
		}

		// Token: 0x02001ABB RID: 6843
		[Serializable]
		public struct FactorTreeData
		{
			// Token: 0x0600A0A5 RID: 41125 RVA: 0x002CAC54 File Offset: 0x002C8E54
			public bool Equals(TreeWind.FactorTreeData other)
			{
				return this._ST_WindGlobal_B.Equals(other._ST_WindGlobal_B) && this._ST_WindBranch_B.Equals(other._ST_WindBranch_B) && this._ST_WindLeaf1Ripple_B.Equals(other._ST_WindLeaf1Ripple_B) && this._ST_WindLeaf1Tumble_B.Equals(other._ST_WindLeaf1Tumble_B) && this._ST_WindLeaf1Twitch_B.Equals(other._ST_WindLeaf1Twitch_B) && this._ST_WindLeaf2Ripple_B.Equals(other._ST_WindLeaf2Ripple_B) && this._ST_WindLeaf2Tumble_B.Equals(other._ST_WindLeaf2Tumble_B) && this._ST_WindLeaf2Twitch_B.Equals(other._ST_WindLeaf2Twitch_B) && this._ST_WindFrondRipple_B.Equals(other._ST_WindFrondRipple_B);
			}

			// Token: 0x0600A0A6 RID: 41126 RVA: 0x002CAD14 File Offset: 0x002C8F14
			public override bool Equals(object obj)
			{
				if (obj is TreeWind.FactorTreeData)
				{
					TreeWind.FactorTreeData other = (TreeWind.FactorTreeData)obj;
					return this.Equals(other);
				}
				return false;
			}

			// Token: 0x0600A0A7 RID: 41127 RVA: 0x002CAD3C File Offset: 0x002C8F3C
			public override int GetHashCode()
			{
				return (((((((this._ST_WindGlobal_B.GetHashCode() * 397 ^ this._ST_WindBranch_B.GetHashCode()) * 397 ^ this._ST_WindLeaf1Ripple_B.GetHashCode()) * 397 ^ this._ST_WindLeaf1Tumble_B.GetHashCode()) * 397 ^ this._ST_WindLeaf1Twitch_B.GetHashCode()) * 397 ^ this._ST_WindLeaf2Ripple_B.GetHashCode()) * 397 ^ this._ST_WindLeaf2Tumble_B.GetHashCode()) * 397 ^ this._ST_WindLeaf2Twitch_B.GetHashCode()) * 397 ^ this._ST_WindFrondRipple_B.GetHashCode();
			}

			// Token: 0x04009290 RID: 37520
			public Vector4 _ST_WindGlobal_B;

			// Token: 0x04009291 RID: 37521
			public Vector4 _ST_WindBranch_B;

			// Token: 0x04009292 RID: 37522
			public Vector4 _ST_WindLeaf1Ripple_B;

			// Token: 0x04009293 RID: 37523
			public Vector4 _ST_WindLeaf1Tumble_B;

			// Token: 0x04009294 RID: 37524
			public Vector4 _ST_WindLeaf1Twitch_B;

			// Token: 0x04009295 RID: 37525
			public Vector4 _ST_WindLeaf2Ripple_B;

			// Token: 0x04009296 RID: 37526
			public Vector4 _ST_WindLeaf2Tumble_B;

			// Token: 0x04009297 RID: 37527
			public Vector4 _ST_WindLeaf2Twitch_B;

			// Token: 0x04009298 RID: 37528
			public Vector4 _ST_WindFrondRipple_B;
		}

		// Token: 0x02001ABC RID: 6844
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700145B RID: 5211
			// (get) Token: 0x0600A0A8 RID: 41128 RVA: 0x002CAE1A File Offset: 0x002C901A
			public static IEqualityComparer<TreeWind.Settings> SettingsComparer { get; } = new TreeWind.Settings.Class1731();

			// Token: 0x0400929A RID: 37530
			public TreeWind.BaseTreeData BaseMinWindData;

			// Token: 0x0400929B RID: 37531
			public TreeWind.BaseTreeData BaseMaxWindData;

			// Token: 0x0400929C RID: 37532
			public TreeWind.FactorTreeData MinWindData;

			// Token: 0x0400929D RID: 37533
			public TreeWind.FactorTreeData MaxWindData;

			// Token: 0x02001ABD RID: 6845
			private sealed class Class1731 : IEqualityComparer<TreeWind.Settings>
			{
				// Token: 0x0600A0AA RID: 41130 RVA: 0x002CAE30 File Offset: 0x002C9030
				public bool Equals(TreeWind.Settings x, TreeWind.Settings y)
				{
					return x.BaseMinWindData.Equals(y.BaseMinWindData) && x.BaseMaxWindData.Equals(y.BaseMaxWindData) && x.MinWindData.Equals(y.MinWindData) && x.MaxWindData.Equals(y.MaxWindData);
				}

				// Token: 0x0600A0AB RID: 41131 RVA: 0x002CAE90 File Offset: 0x002C9090
				public int GetHashCode(TreeWind.Settings obj)
				{
					return ((obj.BaseMinWindData.GetHashCode() * 397 ^ obj.BaseMaxWindData.GetHashCode()) * 397 ^ obj.MinWindData.GetHashCode()) * 397 ^ obj.MaxWindData.GetHashCode();
				}
			}
		}
	}
}