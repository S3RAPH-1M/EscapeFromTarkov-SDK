using System;
using UnityEngine;

// Token: 0x020004B5 RID: 1205
public class GAttribute7 : PropertyAttribute
{
	// Token: 0x0600216A RID: 8554 RVA: 0x000A2097 File Offset: 0x000A0297
	public GAttribute7(string data, bool withLable = true)
	{
		this.Data = data;
		this.WithLable = withLable;
		this.Lines = data.Split(new char[] { '\n' }).Length;
	}

	// Token: 0x04001CCF RID: 7375
	public readonly string Data;

	// Token: 0x04001CD0 RID: 7376
	public readonly bool WithLable;

	// Token: 0x04001CD1 RID: 7377
	public readonly int Lines;
}
