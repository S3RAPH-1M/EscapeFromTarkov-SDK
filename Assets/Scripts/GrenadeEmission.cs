using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Systems.Effects;
using EFT;
using EFT.EnvironmentEffect;
using UnityEngine;

public class GrenadeEmission : MonoBehaviour
{

	private Transform transform_0;

	private Vector3 vector3_0;

	private string string_0;

	[SerializeField]
	private ParticleSystem _particleSystem;

	[SerializeField]
	private ParticleSystem[] _crucialSystems;

	[SerializeField]
	private ParticleSystem _fillSystem;

	[SerializeField]
	private float _defaultStartFillDelay = 25f;

	[SerializeField]
	private float _startFillSize = 3.5f;

	[SerializeField]
	private float _startFillDistance = 1f;

	private float float_0 = 25f;

	private float float_1 = 65f;

	private bool bool_0;

	[SerializeField]
	private AudioClip _startAudioClip;

	[SerializeField]
	private AudioClip _audioClip;

	[SerializeField]
	private AudioClip _endAudioClip;

	[SerializeField]
	private float _removalDelay = 90f;

	private Vector3 vector3_1;

	private BetterSource betterSource_0;

	private List<Material> list_0 = new List<Material>();

	private float float_2;

	private float float_3;

	[SerializeField]
	[Header("Auto-fill parameters")]
	private ColliderExtrusion _extrusion;

	[SerializeField]
	private Vector2[] _startSpeed;

	private static readonly int int_0 = Shader.PropertyToID("_Indoor");
}
