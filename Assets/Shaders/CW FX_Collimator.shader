Shader "CW FX/Collimator" {
	Properties {
		_Color ("Color", Vector) = (0.5,0.5,0.5,0.1)
		_NoiseTex ("Noise Texture (R)", 2D) = "white" {}
		_MarkTex ("Mark Texture (A)", 2D) = "white" {}
		_FadeTex ("Fade Texture (R)", 2D) = "white" {}
		_MarkShift ("Mark Shift", Vector) = (0,0,0,0)
		_MarkScale ("Mark Scale", Float) = 0
		_HDR ("HDR", Float) = 4
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
}