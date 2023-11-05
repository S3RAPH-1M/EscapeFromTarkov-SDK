using System;
using UnityEngine;

namespace EFT.Weather
{
	[Serializable]
	public class WiresController
	{
		public float StrengthMultiplyer = 120f;

		public float MaxValue = 0.4f;

		public float FreqDelta = 1f;

		public float WindScale = 0.08f;

		public float WindFreq = 0.8f;

		public float MaxWinFreq = 1f;

		public float DetailWindAmp = 0.05f;

		public float DetailWindScale = 0.3f;

		public float DetailWindFreq = 2f;

		public float WiresMaxWindOffsetMultiplier = 2.1f;

		public float WiresMaxWindAmplitudeMultiplier = 0.3f;

		private Vector2 _windFuncOffsetAndScale = new Vector2(0f, 1f);

		private static readonly int _wireWind = Shader.PropertyToID("_WireWind");

		private static readonly int _wireWindFreq = Shader.PropertyToID("_WireWindFreq");

		private static readonly int _wireWindScale = Shader.PropertyToID("_WireWindScale");

		private static readonly int _wireDetailWindScale = Shader.PropertyToID("_WireDetailWindScale");

		private static readonly int _wireDetailWindFreq = Shader.PropertyToID("_WireDetailWindFreq");

		private static readonly int _wireDetailWindAmp = Shader.PropertyToID("_WireDetailWindAmp");

		private static readonly int _funcOffsetAndScale = Shader.PropertyToID("_WindFuncOffsetAndScale");

		public void Update(Vector2 wind)
		{
			Vector3 normalized = new Vector3(wind.x, 0f, wind.y).normalized;
			float num = Mathf.Min(wind.magnitude * StrengthMultiplyer, MaxValue);
			normalized *= num;
			float freqMult = 1f + num * FreqDelta;
			float num2 = num / MaxValue;
			_windFuncOffsetAndScale.x = WiresMaxWindOffsetMultiplier * num2;
			_windFuncOffsetAndScale.y = Mathf.Lerp(1f, WiresMaxWindAmplitudeMultiplier, num2);
			method_0(normalized, num2, freqMult);
		}

		private void method_0(Vector3 wind, float magnitudeNormalized, float freqMult)
		{
			Shader.SetGlobalVector(_wireWind, wind);
			Shader.SetGlobalFloat(_wireWindFreq, Mathf.Lerp(WindFreq, MaxWinFreq, magnitudeNormalized) * freqMult);
			Shader.SetGlobalFloat(_wireWindScale, WindScale);
			Shader.SetGlobalFloat(_wireDetailWindScale, DetailWindScale);
			Shader.SetGlobalFloat(_wireDetailWindFreq, DetailWindFreq * freqMult);
			Shader.SetGlobalFloat(_wireDetailWindAmp, DetailWindAmp);
			Shader.SetGlobalVector(_funcOffsetAndScale, _windFuncOffsetAndScale);
		}
	}
}
