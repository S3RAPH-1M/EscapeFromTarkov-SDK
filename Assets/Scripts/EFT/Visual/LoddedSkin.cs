using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Diz.Skinning;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace EFT.Visual
{
	// Token: 0x02001506 RID: 5382
	public class LoddedSkin : MonoBehaviour
	{
		// Token: 0x0400790C RID: 30988
		[SerializeField]
		[FormerlySerializedAs("Skins")]
		private AbstractSkin[] _lods;

	}
}
