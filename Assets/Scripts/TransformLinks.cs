using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x02000613 RID: 1555
public class TransformLinks : MonoBehaviour
{
	// Token: 0x04002349 RID: 9033
	public Transform[] Transforms;

	// Token: 0x0400234A RID: 9034
	public Transform Self;

	public static Func<Transform, bool> func_0;

	[SerializeField]
	private TransformLinks.CachedTransform[] _cachedTransforms;

	[Serializable]
	public struct CachedTransform
	{
		// Token: 0x06002964 RID: 10596 RVA: 0x000BB875 File Offset: 0x000B9A75
		public void Reset()
		{
			this.Transform.localPosition = this.Position;
			this.Transform.localRotation = this.Rotation;
			this.Transform.gameObject.SetActive(true);
		}

		// Token: 0x0400234E RID: 9038
		public Vector3 Position;

		// Token: 0x0400234F RID: 9039
		public Quaternion Rotation;

		// Token: 0x04002350 RID: 9040
		public Transform Transform;
	}
}
