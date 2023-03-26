using System;
using UnityEngine;

// Token: 0x0200072E RID: 1838
[Serializable]
public class DeluxeFilmicCurve
{
	// Token: 0x04002AFA RID: 11002
	[SerializeField]
	public float m_BlackPoint;

	// Token: 0x04002AFB RID: 11003
	[SerializeField]
	public float m_WhitePoint = 1f;

	// Token: 0x04002AFC RID: 11004
	[SerializeField]
	public float m_CrossOverPoint = 0.3f;

	// Token: 0x04002AFD RID: 11005
	[SerializeField]
	public float m_ToeStrength = 0.98f;

	// Token: 0x04002AFE RID: 11006
	[SerializeField]
	public float m_ShoulderStrength;

	// Token: 0x04002AFF RID: 11007
	[SerializeField]
	public float m_Highlights = 0.5f;

	// Token: 0x04002B00 RID: 11008
	public float m_k;

	// Token: 0x04002B01 RID: 11009
	public Vector4 m_ToeCoef;

	// Token: 0x04002B02 RID: 11010
	public Vector4 m_ShoulderCoef;
}
