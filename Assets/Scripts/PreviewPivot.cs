using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x020005F2 RID: 1522
public class PreviewPivot : MonoBehaviour
{

#if UNITY_EDITOR
	[ContextMenu("Apply Default Settings")]
	public void ApplyDefaultSettings()
	{
		UnityEditor.Undo.RecordObject(this, "Applied default PreviewPivot settings");
		pivotPosition = ItemPreview.GetBounds(gameObject).center;
		pivotRotation = new Quaternion(0f, 0.7071068f, 0, 0.7071068f);
		Icon = new IconSettings
		{
			rotation = new Quaternion(0f, 0.8433914f, 0f, -0.537299633f),
			boundsScale = 0.9f
		};
		UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
	}

	public void Awake()
	{
		_oldRotation = Icon.rotation;
	}

	public void OnValidate()
	{
		if (!_oldRotation.Equals(Icon.rotation))
		{
			_oldRotation = Icon.rotation;
			Icon.rotationEuler = Icon.rotation.eulerAngles;
		}
		else
		{
			Icon.rotation = Quaternion.Euler(Icon.rotationEuler);
		}
	}
#endif
	public Vector3 pivotPosition = Vector3.zero;

	// Token: 0x04002407 RID: 9223
	public Quaternion pivotRotation = Quaternion.identity;

	// Token: 0x04002408 RID: 9224
	public Vector3 scale = Vector3.one;

	// Token: 0x04002409 RID: 9225
	public Vector3 SpawnPosition = Vector3.zero;

	// Token: 0x0400240A RID: 9226
	public IconSettings Icon;

	private Quaternion _oldRotation;

	// Token: 0x020005F3 RID: 1523
	[Serializable]
	public class IconSettings
	{
		// Token: 0x0600288A RID: 10378 RVA: 0x000B7400 File Offset: 0x000B5600
		public void Apply(PreviewPivot.IconSettings newSettings)
		{
			this.position = newSettings.position;
			this.hasOffset = newSettings.hasOffset;
			this.rotation = newSettings.rotation;
			this.boundsScale = newSettings.boundsScale;
			this.perspective = newSettings.perspective;
			this.orthographic = newSettings.orthographic;
			this.orthographicSize = newSettings.orthographicSize;
		}

		// Token: 0x0400240B RID: 9227
		public Vector3 position;

		// Token: 0x0400240C RID: 9228
		public bool hasOffset;

		// Token: 0x0400240D RID: 9229
		public Quaternion rotation;
		#if UNITY_EDITOR
		public Vector3 rotationEuler;
		#endif
		// Token: 0x0400240E RID: 9230
		public float boundsScale = 1f;

		// Token: 0x0400240F RID: 9231
		public float perspective = 15f;

		// Token: 0x04002410 RID: 9232
		public bool orthographic;

		// Token: 0x04002411 RID: 9233
		public float orthographicSize = 10f;
	}
}