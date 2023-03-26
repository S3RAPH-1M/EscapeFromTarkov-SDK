Shader "CW FX/OpticSight" {
	Properties {
		_MarkTex ("Mark Texture", 2D) = "white" {}
		_MaskTex ("Mask Texture(A)", 2D) = "white" {}
		_MaskTex2 ("Mask Texture2(A)", 2D) = "white" {}
		_MarkLightness ("Mark Lightness", Range(0, 0.1)) = 0.015
		_ShiftDirection ("_ShiftDirection", Vector) = (0,0,1,0)
		_Shifts ("_Shifts", Vector) = (0,0,0,0)
		_Scales ("_Scales", Vector) = (100,100,100,100)
		_NormalHideness ("_NormalHideness", Range(1, 256)) = 6
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
	//CustomEditor "OpticSightEditor"
}