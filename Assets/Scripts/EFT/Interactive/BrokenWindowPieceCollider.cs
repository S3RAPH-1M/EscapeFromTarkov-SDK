using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace EFT.Interactive
{
	public sealed class BrokenWindowPieceCollider : MonoBehaviour
	{
		[CompilerGenerated]
		private Action<Vector3, Vector3> action_0;

		public BoxCollider Collider;

		private float float_0;

		public string Description => "BrokenWindowPieceCollider";

		

		public event Action<Vector3, Vector3> OnPlayerCollision
		{
			[CompilerGenerated]
			add
			{
				Action<Vector3, Vector3> action = action_0;
				Action<Vector3, Vector3> action2;
				do
				{
					action2 = action;
					Action<Vector3, Vector3> value2 = (Action<Vector3, Vector3>)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref action_0, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action<Vector3, Vector3> action = action_0;
				Action<Vector3, Vector3> action2;
				do
				{
					action2 = action;
					Action<Vector3, Vector3> value2 = (Action<Vector3, Vector3>)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref action_0, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		
	}
}
