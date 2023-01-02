using System;
using UnityEngine;

// Token: 0x02000491 RID: 1169
[Serializable]
public sealed class ClassVector3
{
	// Token: 0x06001FA5 RID: 8101 RVA: 0x0009A2AE File Offset: 0x000984AE
	public Vector3 ToUnityVector3()
	{
		return new Vector3(this.x, this.y, this.z);
	}

	// Token: 0x06001FA6 RID: 8102 RVA: 0x0009A2C7 File Offset: 0x000984C7
	public ClassVector3 Clone()
	{
		return new ClassVector3
		{
			x = this.x,
			y = this.y,
			z = this.z
		};
	}

	// Token: 0x06001FA7 RID: 8103 RVA: 0x0009A2F2 File Offset: 0x000984F2
	public static ClassVector3 FromUnityVector3(Vector3 v)
	{
		return new ClassVector3
		{
			x = v.x,
			y = v.y,
			z = v.z
		};
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x0009A31D File Offset: 0x0009851D
	public static implicit operator Vector3(ClassVector3 vec)
	{
		return vec.ToUnityVector3();
	}

	// Token: 0x06001FA9 RID: 8105 RVA: 0x0009A325 File Offset: 0x00098525
	public static implicit operator ClassVector3(Vector3 vec)
	{
		return ClassVector3.FromUnityVector3(vec);
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x0009A32D File Offset: 0x0009852D
	public static Vector3 operator -(ClassVector3 a, ClassVector3 b)
	{
		return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
	}

	// Token: 0x04001BEE RID: 7150
	public float x;

	// Token: 0x04001BEF RID: 7151
	public float y;

	// Token: 0x04001BF0 RID: 7152
	public float z;
}
