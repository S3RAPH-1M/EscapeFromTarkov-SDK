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
}
