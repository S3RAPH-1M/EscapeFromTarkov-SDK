using System;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.Visual
{
	public class IkLight : MonoBehaviour
	{
		[CanBeNull]
		[SerializeField]
		public Light Light;

		[SerializeField]
		[CanBeNull]
		public MultiFlareLight FlareLight;

		private float float_0;


		private void OnValidate()
		{
			if (!Application.isPlaying && Light != null)
			{
				Light.color = Color.red;
			}
		}

		private void Awake()
		{
			if (Light != null)
			{
				Light.color = Color.red;
				float_0 = Light.intensity;
			}
		}

		private void OnEnable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(method_0));
		}

		private void OnDisable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(method_0));
		}

		private void method_0(Camera cam)
		{

		}
	}
}
