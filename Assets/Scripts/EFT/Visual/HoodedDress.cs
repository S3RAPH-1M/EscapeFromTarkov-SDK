using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EFT.Visual
{
	// Token: 0x02001AC3 RID: 6851
	public class HoodedDress : MonoBehaviour
	{
		public bool IsHooded { get; set; }
		[SerializeField]
		private GameObject[] _hooded;

		[SerializeField]
		private GameObject[] _notHooded;

		[CompilerGenerated]
		private bool bool_0;
	}
}
