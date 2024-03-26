using UnityEngine;

namespace EFT.Visual
{
	public class LightFlicker : Flicker
	{
		[SerializeField]
		private Light _light;

		protected override void Awake()
		{
			if (_light == null)
			{
				_light = GetComponent<Light>();
			}
			base.Awake();
		}

		public override void ManualUpdate()
		{
			float num = TimeShift + Time.time * Frequency;
			_light.intensity = (FullRandomCurve ? ((IntensityShift + Mathf.PerlinNoise(num, RandomSeed) * Intensity) * CullingCoef) : ((IntensityShift + Curve.Evaluate(num) * Intensity) * CullingCoef));
		}
	}
}
