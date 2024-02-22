using System;
using Prism.Utils;
using UnityEngine;

namespace Prism.Demo
{
	// Token: 0x02000C55 RID: 3157
	public class PrismLerpPresetExample : MonoBehaviour
	{
		// Token: 0x06004E23 RID: 20003 RVA: 0x0017FA4C File Offset: 0x0017DC4C
		private void Start()
		{
			this.prismEffects_0 = Camera.main.GetComponent<PrismEffects>();
			if (!this.prismEffects_0)
			{
				Debug.LogWarning("Main camera had no PRISM on it! Can't initialize demo script.");
				base.enabled = false;
			}
		}

		// Token: 0x06004E24 RID: 20004 RVA: 0x0017FA7C File Offset: 0x0017DC7C
		private void Update()
		{
			this.t = Vector3.Distance(base.transform.position, Camera.main.transform.position);
			this.t = this.cameraDistanceCurve.Evaluate(this.t);
			this.prismEffects_0.LerpToPreset(this.target, this.t);
		}

		// Token: 0x04004DAC RID: 19884
		private PrismEffects prismEffects_0;

		// Token: 0x04004DAD RID: 19885
		[Header("This script lerps a PRISM preset based on distance to the camera")]
		[Header("NOTE: This is an example script, you should only have one per scene")]
		public float maxDistance = 500f;

		// Token: 0x04004DAE RID: 19886
		public float t;

		// Token: 0x04004DAF RID: 19887
		[Tooltip("The Prism-Preset to lerp TO")]
		public PrismPreset target;

		// Token: 0x04004DB0 RID: 19888
		public AnimationCurve cameraDistanceCurve;
	}
}
