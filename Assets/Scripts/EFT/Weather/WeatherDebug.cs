using System;
using UnityEngine;

namespace EFT.Weather
{
	// Token: 0x02001634 RID: 5684
	[Serializable]
	public class WeatherDebug
	{
		// Token: 0x04007DFF RID: 32255
		[SerializeField]
		private bool isEnabled;

		// Token: 0x04007E00 RID: 32256
		public bool IsDynamicSunWeatherDebug;

		// Token: 0x04007E01 RID: 32257
		[Range(0f, 1f)]
		public float WindMagnitude;

		// Token: 0x04007E02 RID: 32258
		public WeatherDebug.Direction WindDirection = WeatherDebug.Direction.North;

		// Token: 0x04007E03 RID: 32259
		public Vector2 TopWindDirection;

		// Token: 0x04007E04 RID: 32260
		[Range(-1f, 1f)]
		public float CloudDensity;

		// Token: 0x04007E05 RID: 32261
		[Range(0f, 1f)]
		public float Fog;

		// Token: 0x04007E06 RID: 32262
		[Range(0f, 1f)]
		public float Rain;

		// Token: 0x04007E07 RID: 32263
		[Range(0f, 1f)]
		public float LightningThunderProbability;

		// Token: 0x04007E08 RID: 32264
		[Range(-50f, 50f)]
		public float Temperature;

		// Token: 0x04007E0A RID: 32266
		private static WeatherDebug cachedWeather;

		// Token: 0x02001635 RID: 5685
		public enum Direction
		{
			// Token: 0x04007E0C RID: 32268
			East = 1,
			// Token: 0x04007E0D RID: 32269
			North,
			// Token: 0x04007E0E RID: 32270
			West,
			// Token: 0x04007E0F RID: 32271
			South,
			// Token: 0x04007E10 RID: 32272
			SE,
			// Token: 0x04007E11 RID: 32273
			SW,
			// Token: 0x04007E12 RID: 32274
			NW,
			// Token: 0x04007E13 RID: 32275
			NE
		}
	}
}
