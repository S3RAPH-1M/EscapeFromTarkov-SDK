using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000921 RID: 2337
public class CollimatorSight : MonoBehaviour
{
	// Token: 0x14000093 RID: 147
	// (add) Token: 0x060039E0 RID: 14816 RVA: 0x00116884 File Offset: 0x00114A84
	// (remove) Token: 0x060039E1 RID: 14817 RVA: 0x001168B8 File Offset: 0x00114AB8
	public static event Action<CollimatorSight> OnCollimatorEnabled
	{
		[CompilerGenerated]
		add
		{
			Action<CollimatorSight> action = CollimatorSight.action_0;
			Action<CollimatorSight> action2;
			do
			{
				action2 = action;
				Action<CollimatorSight> value2 = (Action<CollimatorSight>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange<Action<CollimatorSight>>(ref CollimatorSight.action_0, value2, action2);
			}
			while (action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<CollimatorSight> action = CollimatorSight.action_0;
			Action<CollimatorSight> action2;
			do
			{
				action2 = action;
				Action<CollimatorSight> value2 = (Action<CollimatorSight>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange<Action<CollimatorSight>>(ref CollimatorSight.action_0, value2, action2);
			}
			while (action != action2);
		}
	}

	// Token: 0x14000094 RID: 148
	// (add) Token: 0x060039E2 RID: 14818 RVA: 0x001168EC File Offset: 0x00114AEC
	// (remove) Token: 0x060039E3 RID: 14819 RVA: 0x00116920 File Offset: 0x00114B20
	public static event Action<CollimatorSight> OnCollimatorDisabled
	{
		[CompilerGenerated]
		add
		{
			Action<CollimatorSight> action = CollimatorSight.action_1;
			Action<CollimatorSight> action2;
			do
			{
				action2 = action;
				Action<CollimatorSight> value2 = (Action<CollimatorSight>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange<Action<CollimatorSight>>(ref CollimatorSight.action_1, value2, action2);
			}
			while (action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<CollimatorSight> action = CollimatorSight.action_1;
			Action<CollimatorSight> action2;
			do
			{
				action2 = action;
				Action<CollimatorSight> value2 = (Action<CollimatorSight>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange<Action<CollimatorSight>>(ref CollimatorSight.action_1, value2, action2);
			}
			while (action != action2);
		}
	}

	// Token: 0x14000095 RID: 149
	// (add) Token: 0x060039E4 RID: 14820 RVA: 0x00116954 File Offset: 0x00114B54
	// (remove) Token: 0x060039E5 RID: 14821 RVA: 0x00116988 File Offset: 0x00114B88
	public static event Action<CollimatorSight> OnCollimatorUpdated
	{
		[CompilerGenerated]
		add
		{
			Action<CollimatorSight> action = CollimatorSight.action_2;
			Action<CollimatorSight> action2;
			do
			{
				action2 = action;
				Action<CollimatorSight> value2 = (Action<CollimatorSight>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange<Action<CollimatorSight>>(ref CollimatorSight.action_2, value2, action2);
			}
			while (action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<CollimatorSight> action = CollimatorSight.action_2;
			Action<CollimatorSight> action2;
			do
			{
				action2 = action;
				Action<CollimatorSight> value2 = (Action<CollimatorSight>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange<Action<CollimatorSight>>(ref CollimatorSight.action_2, value2, action2);
			}
			while (action != action2);
		}
	}

	// Token: 0x060039E6 RID: 14822 RVA: 0x001169BB File Offset: 0x00114BBB
	private void Awake()
	{
		this.CollimatorMeshRenderer = base.GetComponent<MeshRenderer>();
		this.CollimatorMaterial = this.CollimatorMeshRenderer.sharedMaterial;
	}

	// Token: 0x060039E7 RID: 14823 RVA: 0x001169DA File Offset: 0x00114BDA
	private void OnEnable()
	{
		Action<CollimatorSight> action = CollimatorSight.action_0;
		if (action == null)
		{
			return;
		}
		action(this);
	}

	// Token: 0x060039E8 RID: 14824 RVA: 0x001169EC File Offset: 0x00114BEC
	private void OnDisable()
	{
		Action<CollimatorSight> action = CollimatorSight.action_1;
		if (action == null)
		{
			return;
		}
		action(this);
	}

	// Token: 0x060039E9 RID: 14825 RVA: 0x001169FE File Offset: 0x00114BFE
	public void LookAt(Vector3 point, Vector3 worldUp)
	{
		base.transform.LookAt(point, worldUp);
		base.transform.localRotation *= CollimatorSight.quaternion_0;
		Action<CollimatorSight> action = CollimatorSight.action_2;
		if (action == null)
		{
			return;
		}
		action(this);
	}

	// Token: 0x04003975 RID: 14709
	[CompilerGenerated]
	private static Action<CollimatorSight> action_0;

	// Token: 0x04003976 RID: 14710
	[CompilerGenerated]
	private static Action<CollimatorSight> action_1;

	// Token: 0x04003977 RID: 14711
	[CompilerGenerated]
	private static Action<CollimatorSight> action_2;

	// Token: 0x04003978 RID: 14712
	private static readonly Quaternion quaternion_0 = Quaternion.Euler(-90f, 0f, 0f);

	// Token: 0x04003979 RID: 14713
	public MeshRenderer CollimatorMeshRenderer;

	// Token: 0x0400397A RID: 14714
	public Material CollimatorMaterial;
}
