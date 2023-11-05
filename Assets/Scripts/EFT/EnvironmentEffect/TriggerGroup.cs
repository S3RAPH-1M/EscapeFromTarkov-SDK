using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.EnvironmentEffect
{
	public class TriggerGroup : MonoBehaviour
	{
		[SerializeField]
		public Bounds Bounds;

		[SerializeField]
		public List<IndoorTrigger> _childrenTriggers = new List<IndoorTrigger>();

		[SerializeField]
		public List<TriggerGroup> _childrenGroups = new List<TriggerGroup>();
	}
}
