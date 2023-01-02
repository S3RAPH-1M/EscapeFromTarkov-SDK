using System;
using System.Collections.Generic;
using UnityEngine;

namespace Diz.Skinning
{
	// Token: 0x020023C4 RID: 9156
	public class Skeleton : MonoBehaviour, ISerializationCallbackReceiver
	{
		// Token: 0x0600CF9B RID: 53147 RVA: 0x003766E0 File Offset: 0x003748E0
		public void OnBeforeSerialize()
		{
			this._keys.Clear();
			this._values.Clear();
			foreach (KeyValuePair<string, Transform> keyValuePair in this.Bones)
			{
				this._keys.Add(keyValuePair.Key);
				this._values.Add(keyValuePair.Value);
			}
		}

		// Token: 0x0600CF9C RID: 53148 RVA: 0x00376768 File Offset: 0x00374968
		public void OnAfterDeserialize()
		{
			this.Bones.Clear();
			int count = this._keys.Count;
			for (int i = 0; i < count; i++)
			{
				this.Bones.Add(this._keys[i], this._values[i]);
			}
		}

		// Token: 0x0400BAF6 RID: 47862
		public Dictionary<string, Transform> Bones = new Dictionary<string, Transform>();

		// Token: 0x0400BAF7 RID: 47863
		[SerializeField]
		private List<string> _keys = new List<string>();

		// Token: 0x0400BAF8 RID: 47864
		[SerializeField]
		private List<Transform> _values = new List<Transform>();
	}
}
