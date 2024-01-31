using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class PhysicsTriggerHandler : MonoBehaviour, IPhysicsTrigger
{
	[CompilerGenerated]
	private Action<Collider> action_0;

	[CompilerGenerated]
	private Action<Collider> action_1;

	public Collider trigger;

	public string Description => "PhysicsTriggerHandler";

	bool IPhysicsTrigger.enabled
	{
		get
		{
			return base.enabled;
		}
		set
		{
			base.enabled = value;
		}
	}

	public event Action<Collider> OnTriggerEnter
	{
		[CompilerGenerated]
		add
		{
			Action<Collider> action = action_0;
			Action<Collider> action2;
			do
			{
				action2 = action;
				Action<Collider> value2 = (Action<Collider>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Collider> action = action_0;
			Action<Collider> action2;
			do
			{
				action2 = action;
				Action<Collider> value2 = (Action<Collider>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action<Collider> OnTriggerExit
	{
		[CompilerGenerated]
		add
		{
			Action<Collider> action = action_1;
			Action<Collider> action2;
			do
			{
				action2 = action;
				Action<Collider> value2 = (Action<Collider>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Collider> action = action_1;
			Action<Collider> action2;
			do
			{
				action2 = action;
				Action<Collider> value2 = (Action<Collider>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	private void Awake()
	{
		if (trigger == null)
		{
			trigger = GetComponent<Collider>();
		}
	}

	void IPhysicsTrigger.OnTriggerEnter(Collider col)
	{
		if (base.enabled)
		{
			action_0?.Invoke(col);
		}
	}

	void IPhysicsTrigger.OnTriggerExit(Collider col)
	{
		if (base.enabled)
		{
			action_1?.Invoke(col);
		}
	}

	private void OnDestroy()
	{
		action_0 = null;
		action_1 = null;
	}
}
