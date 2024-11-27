using System;
using UnityEngine;

namespace EFT.CameraControl
{
	// Token: 0x02002BCC RID: 11212
	public class ScopeThermalVisionData : MonoBehaviour
	{
		public bool ThermalVision;
		public bool ThermalVisionIsGlitch;
		public bool ThermalVisionIsPixelated;
		public bool ThermalVisionIsNoisy;
		public bool ThermalVisionIsMotionBlurred;
		public bool ThermalVisionIsFpsStuck;
		public ThermalVisionUtilities ThermalVisionUtilities;
		public StuckFPSUtilities StuckFPSUtilities;
		public MotionBlurUtilities MotionBlurUtilities;
		public GlitchUtilities GlitchUtilities;
		public PixelationUtilities PixelationUtilities;
		public float ChromaticAberrationThermalShift;
		public float UnsharpBias;
		public float UnsharpRadiusBlur;
	}
}
