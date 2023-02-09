using System;
using UnityEngine;

// Token: 0x0200011E RID: 286
[Serializable]
public class CoverPointDefenceInfo
{
	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000702 RID: 1794 RVA: 0x000215F6 File Offset: 0x0001F7F6
	public float DefenceLevel
	{
		get
		{
			return this._defenceLevel;
		}
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000703 RID: 1795 RVA: 0x000215FE File Offset: 0x0001F7FE
	public int DangerCoeff
	{
		get
		{
			return this.distanceCheckSum;
		}
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x000217DE File Offset: 0x0001F9DE
	public void OverrideData(float defenceLevel, int dangerCoeff)
	{
		this._defenceLevel = defenceLevel;
		this.distanceCheckSum = dangerCoeff;
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x000217EE File Offset: 0x0001F9EE
	public bool IsSafe()
	{
		return this.distanceCheckSum < 8;
	}

	// Token: 0x0400073B RID: 1851
	[SerializeField]
	private float _defenceLevel;

	// Token: 0x0400073C RID: 1852
	[SerializeField]
	private int distanceCheckSum;
}