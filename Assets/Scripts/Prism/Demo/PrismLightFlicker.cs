using System;
using UnityEngine;

namespace Prism.Demo
{
	// Token: 0x02000C56 RID: 3158
	[RequireComponent(typeof(Light))]
	public class PrismLightFlicker : MonoBehaviour
	{
		// Token: 0x06004E26 RID: 20006 RVA: 0x0017FAEF File Offset: 0x0017DCEF
		private void Start()
		{
			this.light_0 = base.GetComponent<Light>();
			this.float_1 = this.light_0.intensity;
		}

		// Token: 0x06004E27 RID: 20007 RVA: 0x0017FB0E File Offset: 0x0017DD0E
		private static float smethod_0(float start, float end, float t)
		{
			end -= start;
			return end * t * t * t + start;
		}

		// Token: 0x06004E28 RID: 20008 RVA: 0x0017FB20 File Offset: 0x0017DD20
		private void Update()
		{
			this.light_0.intensity = PrismLightFlicker.smethod_0(this.light_0.intensity, this.float_2, this.float_3);
			this.float_3 += Time.deltaTime * this.flickerSpeed;
			this.float_3 = Mathf.Min(this.float_3, 1f);
			if (Time.time < this.float_0)
			{
				return;
			}
			float num = UnityEngine.Random.Range(0f, 1f);
			if (num > this.flickerChance)
			{
				num += this.offset;
				this.float_2 = this.float_1 * num;
				this.float_0 = Time.time + UnityEngine.Random.Range(this.minAliveTime, this.maxAliveTime);
				this.float_3 = 0f;
			}
		}

		// Token: 0x04004DB1 RID: 19889
		[Range(-2f, 2f)]
		public float offset = 0.3f;

		// Token: 0x04004DB2 RID: 19890
		[Range(0f, 1f)]
		public float flickerChance = 0.395f;

		// Token: 0x04004DB3 RID: 19891
		[Range(0f, 5f)]
		public float minAliveTime = 0.04f;

		// Token: 0x04004DB4 RID: 19892
		[Range(0f, 5f)]
		public float maxAliveTime = 0.52f;

		// Token: 0x04004DB5 RID: 19893
		[Range(0f, 5f)]
		public float flickerSpeed = 2f;

		// Token: 0x04004DB6 RID: 19894
		private float float_0;

		// Token: 0x04004DB7 RID: 19895
		private Light light_0;

		// Token: 0x04004DB8 RID: 19896
		private float float_1;

		// Token: 0x04004DB9 RID: 19897
		private float float_2;

		// Token: 0x04004DBA RID: 19898
		private float float_3;
	}
}
