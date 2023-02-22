Shader "Custom/MuzzleSmoke" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_Alpha ("_Alpha", Float) = 1
		_Width ("_Width", Float) = 1
		_UVYScale ("_UVYScale", Float) = 0.1
		_DiffusionStrength ("_DiffusionStrength", Float) = 0.1
		_StartFade ("_StartFade", Float) = 1
		_EndFade ("_EndFade", Float) = 1
		_End ("_End", Float) = 4
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}