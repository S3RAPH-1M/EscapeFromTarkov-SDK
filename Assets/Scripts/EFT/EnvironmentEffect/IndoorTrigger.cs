using System;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.EnvironmentEffect
{
	// Token: 0x02002402 RID: 9218
	public class IndoorTrigger : MonoBehaviour, EnvironmentManagerBase.GInterface16
	{
		// Token: 0x0600D1AD RID: 53677 RVA: 0x0036E0AE File Offset: 0x0036C2AE
		private void OnValidate()
		{
			if (Application.isPlaying)
			{
				return;
			}
			this.Awake();
		}

		// Token: 0x0600D1AE RID: 53678 RVA: 0x0036E0C0 File Offset: 0x0036C2C0
		private void Awake()
		{
			if (this.Bounds.size.magnitude < Mathf.Epsilon)
			{
				this.Reinit();
			}
		}

		// Token: 0x0600D1AF RID: 53679 RVA: 0x0036E0F0 File Offset: 0x0036C2F0
		public void Reinit()
		{
			float num = 0.5f;
			Vector3 vector = base.transform.TransformPoint(new Vector3(num, num, num));
			Vector3 vector2 = base.transform.TransformPoint(new Vector3(-0.5f, -0.5f, -0.5f));
			Vector3 vector3 = base.transform.TransformPoint(new Vector3(-0.5f, num, num));
			Vector3 vector4 = base.transform.TransformPoint(new Vector3(num, -0.5f, num));
			Vector3 vector5 = base.transform.TransformPoint(new Vector3(num, num, -0.5f));
			Vector3 vector6 = base.transform.TransformPoint(new Vector3(num, -0.5f, -0.5f));
			Vector3 vector7 = base.transform.TransformPoint(new Vector3(-0.5f, -0.5f, num));
			Vector3 vector8 = base.transform.TransformPoint(new Vector3(-0.5f, num, -0.5f));
			Vector3 b = new Vector3(Mathf.Min(new float[]
			{
				vector.x,
				vector2.x,
				vector3.x,
				vector4.x,
				vector5.x,
				vector6.x,
				vector7.x,
				vector8.x
			}), Mathf.Min(new float[]
			{
				vector.y,
				vector2.y,
				vector3.y,
				vector4.y,
				vector5.y,
				vector6.y,
				vector7.y,
				vector8.y
			}), Mathf.Min(new float[]
			{
				vector.z,
				vector2.z,
				vector3.z,
				vector4.z,
				vector5.z,
				vector6.z,
				vector7.z,
				vector8.z
			}));
			Vector3 size = new Vector3(Mathf.Max(new float[]
			{
				vector.x,
				vector2.x,
				vector3.x,
				vector4.x,
				vector5.x,
				vector6.x,
				vector7.x,
				vector8.x
			}), Mathf.Max(new float[]
			{
				vector.y,
				vector2.y,
				vector3.y,
				vector4.y,
				vector5.y,
				vector6.y,
				vector7.y,
				vector8.y
			}), Mathf.Max(new float[]
			{
				vector.z,
				vector2.z,
				vector3.z,
				vector4.z,
				vector5.z,
				vector6.z,
				vector7.z,
				vector8.z
			})) - b;
			this.Bounds = new Bounds(base.transform.position, size);
		}

		// Token: 0x0600D1B0 RID: 53680 RVA: 0x0036E418 File Offset: 0x0036C618
		[CanBeNull]
		public IndoorTrigger Check(Vector3 pos)
		{
			if (!this.Bounds.Contains(pos))
			{
				return null;
			}
			Vector3 vector = base.transform.InverseTransformPoint(pos);
			if (Mathf.Abs(vector.x) >= 0.5f || Mathf.Abs(vector.y) >= 0.5f || Mathf.Abs(vector.z) >= 0.5f)
			{
				return null;
			}
			return this;
		}

		// Token: 0x0600D1B1 RID: 53681 RVA: 0x0036E480 File Offset: 0x0036C680
		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.color = new Color(0f, 0.2f, 0.4f, 0.4f);
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
			Gizmos.color = new Color(0f, 0.5f, 0f, 0.9f);
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		}

		// Token: 0x0600D1B2 RID: 53682 RVA: 0x0036E4F7 File Offset: 0x0036C6F7
		private void OnDrawGizmos()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.color = new Color(0f, 0.2f, 0.4f, 0.3f);
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
		}

		// Token: 0x0400B685 RID: 46725
		[SerializeField]
		public bool IsBunker;

		// Token: 0x0400B686 RID: 46726
		[SerializeField]
		public float FadeTime = 1f;

		// Token: 0x0400B687 RID: 46727
		[Space(15f)]
		[SerializeField]
		public float ExposureSpeed = 4f;

		// Token: 0x0400B688 RID: 46728
		[SerializeField]
		public float ExposureOffset = 0.14f;

		// Token: 0x0400B689 RID: 46729
		[SerializeField]
		public float RainVolume = 0.7f;

		// Token: 0x0400B68A RID: 46730
		[SerializeField]
		public Bounds Bounds;

		// Token: 0x0400B68B RID: 46731
		private static int int_0;

		// Token: 0x0400B68C RID: 46732
		public int AreaAutoId;
	}
}
