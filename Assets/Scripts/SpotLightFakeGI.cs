using System;
using UnityEngine;

public class SpotLightFakeGI : MonoBehaviour
{
	[Serializable]
	public class Circle
	{
		[Range(0f, 1f)]
		public float Radius;

		public int Count;
	}

	public float GILightOffsetA = 0.5f;

	public float GILightOffsetB = 0.5f;

	public float GILightScale = 2f;

	public float GILightIntensity = 0.2f;

	public LayerMask CheckLayerMask;

	public Circle[] CheckCircles;

	public AnimationCurve GIIntensityByDistanceMultyplier;
}
