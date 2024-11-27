using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x02000889 RID: 2185
[Serializable]
public abstract class SerializableEnumDictionary<TEnum, T> : Dictionary<TEnum, T>
{

    // Token: 0x0400318C RID: 12684
    [SerializeField]
    private List<string> _keys = new List<string>();

	// Token: 0x0400318D RID: 12685
	[SerializeField]
	private List<T> _values = new List<T>();
}
