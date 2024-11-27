using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Bsg.GameSettings;
using EFT.CameraControl;
using EFT.InputSystem;
using EFT.InventoryLogic;
using UnityEngine;

// Token: 0x02000A5A RID: 2650
public class ScopeZoomHandler : MonoBehaviour
{
	[CompilerGenerated]
	private Action<ESmoothScopeState> action_0;
	[CompilerGenerated]
	private Action<float> action_1;
	private const float float_0 = 0.0001f;
	public Transform ScopeSwitcher;
	public Transform StartPivot;
	public Transform EndPivot;
	[Space]
	public bool InverseRotation;
	[CompilerGenerated]
	private ScopePrefabCache scopePrefabCache_0;
	[CompilerGenerated]
	private ScopeSmoothCameraData scopeSmoothCameraData_0;
	private float float_1;
	private float float_2;
	private float float_3;
	private float float_4;
	private float float_5 = 1f;
	private float float_6;
	private float float_7;
	private bool bool_0;
	private bool bool_1;
	private ESmoothScopeState esmoothScopeState_0;
	private ESmoothScopeState esmoothScopeState_1;
	private IAdjustableOpticData iadjustableOpticData_0;
	private float float_8;
	private SightComponent sightComponent_0;
}