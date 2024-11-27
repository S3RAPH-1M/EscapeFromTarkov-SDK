using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EFT.StreamingAnimatorSystem
{
	// Token: 0x020020E9 RID: 8425
	[RequireComponent(typeof(Animator))]
	public class StreamingAnimator : MonoBehaviour
	{				
		public List<string> StreamingParameters;

		// Token: 0x0400B5A5 RID: 46501
		[SerializeField]
		private Animator _recipientAnimator;
	}
}
