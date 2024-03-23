using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT;
using EFT.InventoryLogic;
using UnityEngine;

public class TacticalComboVisualController : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class Class58
	{
		public static readonly Class58 class58_0 = new Class58();

		public static Predicate<Transform> predicate_0;

		internal bool method_0(Transform mod)
		{
			return mod.name == "mode_000";
		}
	}

	public const string DISABLED_TRANSFORM_NAME = "mode_000";

	public const string LIGHT_BEAM_TRANSFORM_NAME = "mode_";

	private readonly List<Transform> list_0 = new List<Transform>();

	public LightComponent LightMod;

	private Transform transform_0;

	[SerializeField]
	private float _shadowNearPlaneShift = 0.05f;

	private Light[] light_0;

	private void Awake()
	{
		Init();
	}

	public void Init()
	{

	}

	private void OnEnable()
	{

	}

	public void UpdateBeams()
	{

	}

	public void SetPointOfView(EPointOfView pointOfView)
	{
	}
}
