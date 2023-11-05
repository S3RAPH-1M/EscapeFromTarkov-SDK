using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[ExecuteInEditMode]
public class AmbientHighlight: MonoBehaviour
{
	[Serializable]
	private struct AmbientDirectionalLight
	{
		public Transform LightTransform;

		public Color Color;

		public float Intensity;
	}

	public enum StencilType
	{
		Static = 0,
		Characters = 1,
		Hands = 2
	}

	[Serializable]
	private class HighlightSettings
	{
		public float HighlightMinMultiplier = 0.2f;

		public float HighlightMaxMultiplier = 1.7f;

		public AnimationCurve HighlightIntensityCurve = new AnimationCurve(new Keyframe(-1f, 0f), new Keyframe(0f, 0f), new Keyframe(0.3f, 1f));

		public StencilType StencilTypeToUse = StencilType.Hands;

		[HideInInspector]
		public Material HighlightMaterial;
	}

	public Shader ScreenAmbientShader;

	public float AmbientBlur = 1f;

	[SerializeField]
	private HighlightSettings[] _highlightSettings = new HighlightSettings[0];

	[SerializeField]
	private AmbientDirectionalLight[] _additionalLights;

	private Material material_0;


	private static Mesh mesh_0;

	private static readonly Matrix4x4 matrix4x4_0 = Matrix4x4.identity;

	private static readonly int int_0 = Shader.PropertyToID("_SrcBlend");

	private static readonly int int_1 = Shader.PropertyToID("_DstBlend");

	private static readonly int[] int_2 = new int[3]
	{
		Shader.PropertyToID("_SHAr"),
		Shader.PropertyToID("_SHAg"),
		Shader.PropertyToID("_SHAb")
	};

	private static readonly int[] int_3 = new int[3]
	{
		Shader.PropertyToID("_SHBr"),
		Shader.PropertyToID("_SHBg"),
		Shader.PropertyToID("_SHBb")
	};

	private static readonly int int_4 = Shader.PropertyToID("_SHC");

	private static readonly int int_5 = Shader.PropertyToID("_StencilType");

	private static readonly int int_6 = Shader.PropertyToID("_HighlightMultiplier");

	private static readonly int int_7 = Shader.PropertyToID("_AmbientBlur");




}
