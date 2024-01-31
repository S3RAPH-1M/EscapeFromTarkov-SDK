using System;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;

// Token: 0x020009AD RID: 2477
public class GrassTrampler : MonoBehaviour
{
	// Token: 0x04003B6D RID: 15213
	[SerializeField]
	private AnimationCurve _angleCurve;

	// Token: 0x04003B6E RID: 15214
	[SerializeField]
	public float TransitionTimeBetweenStates;

	// Token: 0x04003B6F RID: 15215
	[SerializeField]
	public GrassValues StandGrassValues;

	// Token: 0x04003B70 RID: 15216
	[SerializeField]
	public GrassValues DuckGrassValues;

	// Token: 0x04003B71 RID: 15217
	[SerializeField]
	public GrassValues ProneGrassValues;

	// Token: 0x04003B72 RID: 15218
	private const string string_0 = "_GrassPlayerPosition";

	// Token: 0x04003B73 RID: 15219
	private const string string_1 = "_GrassPlayerDirection";

	// Token: 0x04003B74 RID: 15220
	private const string string_2 = "_GrassValues";

	// Token: 0x04003B75 RID: 15221
	private AnimationCurve animationCurve_0;

	// Token: 0x04003B76 RID: 15222
	private GrassValues grassValues_0;

	// Token: 0x04003B77 RID: 15223
	private Vector3 vector3_0;

	// Token: 0x04003B78 RID: 15224
	private Vector3 vector3_1;

	// Token: 0x04003B79 RID: 15225
	private Vector3 vector3_2;

	// Token: 0x04003B7A RID: 15226
	private EPlayerPose eplayerPose_0;

	// Token: 0x04003B7B RID: 15227
	private bool bool_0;

	// Token: 0x04003B7C RID: 15228
	private float float_0;

	// Token: 0x04003B7D RID: 15229
	private float float_1;

	// Token: 0x04003B7E RID: 15230
	private float float_2;

	// Token: 0x04003B7F RID: 15231
	private float float_3;

	// Token: 0x04003B80 RID: 15232
	private float float_4;

	// Token: 0x04003B81 RID: 15233
	private float float_5;

	// Token: 0x04003B82 RID: 15234
	private GrassValues grassValues_1;

	// Token: 0x04003B83 RID: 15235
	private float float_6;
}
