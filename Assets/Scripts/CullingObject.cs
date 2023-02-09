using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class CullingObject : MonoBehaviour
{
	public bool IsVisible { get; private set; }
	
	public Vector3 Position
	{
		get
		{
			return this.GetTransform().position + this._shift;
		}
	}
	
	protected virtual Transform GetTransform()
	{
		return this._transform;
	}
	
	private void OnDrawGizmosSelected()
	{
		if (!this._drawSphere)
		{
			return;
		}
		Gizmos.color = (this.IsVisible ? Color.yellow : Color.red);
		Gizmos.DrawWireSphere(this.Position, this._radius);
	}

	// Token: 0x04004326 RID: 17190
	[SerializeField]
	protected float CullDistance = 80f;

	// Token: 0x04004327 RID: 17191
	[SerializeField]
	protected float _radius = 1f;

	// Token: 0x04004328 RID: 17192
	[SerializeField]
	protected Vector3 _shift;

	// Token: 0x04004329 RID: 17193
	[SerializeField]
	private bool _drawSphere = true;

	// Token: 0x0400432A RID: 17194
	[SerializeField]
	private bool _cullByDistanceOnly = true;

	// Token: 0x0400432B RID: 17195
	[SerializeField]
	protected List<Component> _componentsToTurnOff = new List<Component>();

	// Token: 0x0400432C RID: 17196
	[HideInInspector]
	[SerializeField]
	private List<DisablerCullingObject.ComponentState> _componentsToTurnOffDefaultState;

	// Token: 0x0400432D RID: 17197
	[SerializeField]
	private List<GameObject> _gameObjectsToTurnOff;

	// Token: 0x0400432E RID: 17198
	[SerializeField]
	private Transform _transform;

	// Token: 0x0400432F RID: 17199
	[CompilerGenerated]
	private int int_0;

	// Token: 0x04004330 RID: 17200
	private Vector3 vector3_0;

	// Token: 0x04004331 RID: 17201
	[CompilerGenerated]
	private bool bool_0;

	// Token: 0x04004332 RID: 17202
	[CompilerGenerated]
	private float float_0;

	// Token: 0x04004333 RID: 17203
	[CompilerGenerated]
	private bool bool_1;

	// Token: 0x04004334 RID: 17204
	[SerializeField]
	private int _componentsSwitchPerFrameOnEnable = 25;

	// Token: 0x04004335 RID: 17205
	[SerializeField]
	private int _objectsSwitchPerFrameOnEnable = 25;

	// Token: 0x04004336 RID: 17206
	[SerializeField]
	private int _componentsSwitchPerFrameOnDisable = 25;

	// Token: 0x04004337 RID: 17207
	[SerializeField]
	private int _objectsSwitchPerFrameOnDisable = 25;

	// Token: 0x04004338 RID: 17208
	private Stopwatch stopwatch_0 = new Stopwatch();

	// Token: 0x04004339 RID: 17209
	private IEnumerator ienumerator_0;
}