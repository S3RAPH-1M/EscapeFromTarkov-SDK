Shader "Time of Day/Cloud Layer 2" {
	Properties {
		_CloudColor ("Cloud Color", Vector) = (1,1,1,1)
		_MapLow ("_MapLow", 2D) = "white" {}
		_MapHigh ("_MapHigh", 2D) = "white" {}
		_Noise ("_Noise", 2D) = "white" {}
		[Space(32)] _CloudRoughnessMin ("_RoughnessMin", Range(0, 1)) = 1
		_CloudNoiseMapRoughness ("_NoiseMapRoughness", Range(0, 1)) = 1
		_CloudDensity ("_Density", Range(-1, 1)) = 1
		[Space(16)] [HDR] _SunMultyplyer ("_SunMultyplyer", Vector) = (1,1,1,1)
		_ForwardLight ("_ForwardLight", Float) = 1
		_ForwardLightWidth ("_ForwardLightWidth", Range(0, 1)) = 1
		[Space(8)] _SunScattering ("_SunScattering", Float) = 1
		_MoonScattering ("_MoonScattering", Float) = 1
		_SkyScattering ("_SkyScattering", Float) = 1
		[Space(8)] [HDR] _BottomReflections ("_BottomReflections", Vector) = (1,1,1,1)
		[Space(16)] _CloudDisplacementNormal ("_DisplacementNormal", Float) = 1
		_DisplacementScattering ("_DisplacementScattering", Float) = 1
		_FogDensity ("_FogDensity", Float) = 0.15
		_CloudCurviness ("_Curviness", Float) = 1
		_CloudScale ("_Scale", Float) = 0.1
		_CloudPosition ("_CloudPosition", Vector) = (0,0,0,0)
		_HorizontToAlphaFadingIntensity ("_HorizontToAlphaFadingIntensity", Float) = 32
		_HorizontToAlphaFadingPosition ("_HorizontToAlphaFadingPosition", Float) = -0.2
		_PlanetSize ("_PlanetSize", Float) = 3
		_LerpToAtmosphere ("_LerpToAtmosphere", Range(0, 1)) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
}