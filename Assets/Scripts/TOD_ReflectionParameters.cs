using System;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020000B6 RID: 182
[Serializable]
public class TOD_ReflectionParameters
{
	// Token: 0x040003B3 RID: 947
	[Tooltip("Reflection probe mode.")]
	public TOD_ReflectionType Mode;

	// Token: 0x040003B4 RID: 948
	[Tooltip("Clear flags to use for the reflection.")]
	public ReflectionProbeClearFlags ClearFlags = ReflectionProbeClearFlags.Skybox;

	// Token: 0x040003B5 RID: 949
	[Tooltip("Layers to include in the reflection.")]
	public LayerMask CullingMask = 0;

	// Token: 0x040003B6 RID: 950
	[Tooltip("Time slicing behaviour to spread out rendering cost over multiple frames.")]
	public ReflectionProbeTimeSlicingMode TimeSlicing;

	// Token: 0x040003B7 RID: 951
	[Tooltip("Refresh interval of the reflection cubemap in seconds.")]
	public float UpdateInterval = 1f;
}
