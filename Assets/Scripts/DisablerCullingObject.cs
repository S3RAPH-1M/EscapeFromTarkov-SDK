using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using EFT.Interactive;
using UnityEngine;

// Token: 0x02000A82 RID: 2690
[ExecuteInEditMode]
public class DisablerCullingObject : DisablerCullingObjectBase
{
	// Token: 0x04004349 RID: 17225
	[SerializeField]
	protected List<Component> _componentsToTurnOff = new List<Component>();

	// Token: 0x0400434A RID: 17226
	[SerializeField]
	protected List<Component> _compsToTurnOffWhoIgnoreInversedColliders = new List<Component>();

	// Token: 0x0400434B RID: 17227
	[HideInInspector]
	[SerializeField]
	private List<DisablerCullingObject.ComponentState> _componentsToTurnOffDefaultState;

	// Token: 0x0400434C RID: 17228
	[SerializeField]
	protected List<GameObject> _gameObjectsToTurnOff;

	// Token: 0x0400434D RID: 17229
	[SerializeField]
	protected Bounds _componentsBounds;

	// Token: 0x0400434E RID: 17230
	[SerializeField]
	public bool AllowLootCulling = true;

	// Token: 0x0400434F RID: 17231
	[Header("Performance:")]
	[SerializeField]
	private int _componentsSwitchPerFrameOnEnable = 25;

	// Token: 0x04004350 RID: 17232
	[SerializeField]
	private int _objectsSwitchPerFrameOnEnable = 25;

	// Token: 0x04004351 RID: 17233
	[SerializeField]
	private int _componentsSwitchPerFrameOnDisable = 25;

	// Token: 0x04004352 RID: 17234
	[SerializeField]
	private int _objectsSwitchPerFrameOnDisable = 25;

	// Token: 0x04004353 RID: 17235
	[HideInInspector]
	public bool ExcludeLowPolyColliderLayer = true;

	// Token: 0x04004354 RID: 17236
	[HideInInspector]
	public bool ExcludeDefaultLayerWithCollider;

	// Token: 0x04004355 RID: 17237
	[HideInInspector]
	public bool ExcludeBallisticCollider;

	// Token: 0x04004356 RID: 17238
	[HideInInspector]
	public bool IncludeInactive;

	// Token: 0x04004357 RID: 17239
	[Header("View:")]
	public Color GizmosColor = new Color(0f, 1f, 0f, 0.16f);

	// Token: 0x04004358 RID: 17240
	public Color GizmosInverseColor = new Color(1f, 0f, 0f, 0.1f);

	// Token: 0x04004359 RID: 17241
	[SerializeField]
	private Color _unselectedGizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.16f);

	// Token: 0x02000A83 RID: 2691
	[Serializable]
	public class ComponentState
	{
		// Token: 0x04004361 RID: 17249
		public Component component;

		// Token: 0x04004362 RID: 17250
		public bool isEnabled;
	}
}