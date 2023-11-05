Shader "Time of Day/Cloud Layer 2 Light" {
	Properties {
		_CloudColor ("Cloud Color", Vector) = (1,1,1,1)
		[HDR] _LightColor ("_LightColor", Vector) = (1,1,1,1)
		_MapLow ("_MapLow", 2D) = "white" {}
		_MapHigh ("_MapHigh", 2D) = "white" {}
		_Noise ("_Noise", 2D) = "white" {}
		_LightMap ("_LightMap", 2D) = "white" {}
		_MapSize ("_MapSize", Float) = 1
		[Space(32)] _CloudRoughnessMin ("_RoughnessMin", Range(0, 1)) = 1
		_CloudNoiseMapRoughness ("_NoiseMapRoughness", Range(0, 1)) = 1
		_CloudDensity ("_Density", Range(-1, 1)) = 1
		[Space(16)] _Light ("_Light", Float) = 1
		[Space(16)] _DisplacementNormal ("_DisplacementNormal", Float) = 1
		_FogDensity ("_FogDensity", Float) = 0.15
		_CloudCurviness ("_Curviness", Float) = 1
		_CloudScale ("_Scale", Float) = 1
		_CloudPosition ("_CloudPosition", Vector) = (0,0,0,0)
		_RealHeight ("_RealHeight", Float) = 1
		_MapTransform ("_MapTransform", Vector) = (0,0,0,0)
		_DetailAdd ("_DetailAdd", Float) = 0
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