Shader "Custom/TextureGlitch" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_SpecMap ("SpecularMap (R)", 2D) = "white" {}
		_SpecColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		_Glossness ("Glossness", Range(0.01, 10)) = 1
		_Specularness ("Specularness", Range(0.01, 10)) = 0.078125
		_ReflectColor ("Reflection Color", Vector) = (1,1,1,0.5)
		_MainTex ("Base (RGB) RefStrGloss (A)", 2D) = "white" {}
		_Cube ("Reflection Cubemap", Cube) = "" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_EmissionMap ("EmissionMap", 2D) = "white" {}
		_EmissionVisibility ("EmissionVisibility", Range(0, 1)) = 1
		_EmissionPower ("EmissionPower", Range(0, 10)) = 1
		_SpecVals ("Specular Vals", Vector) = (1.1,2,0,0)
		_DefVals ("Defuse Vals", Vector) = (0.5,0.7,0,0)
		_BumpTiling ("_BumpTiling", Float) = 1
		_Factor ("Z Offset Angle", Float) = 0
		_Units ("Z Offset Forward", Float) = 0
		_DispTex ("Displacement Map", 2D) = "bump" {}
		_DigitalMistakeIntensity ("_DigitalMistakeIntensity", Range(0, 1)) = 0.007
		_ColorSwitchFilterRadius ("_ColorSwitchFilterRadius", Range(0, 10)) = 2
		_ScanLineJitter ("_ScanLineJitter (displacement, threshold)", Vector) = (0.05,0.7,0,0)
		_VerticalJump ("_VerticalJump (amount, scale)", Vector) = (0.1,7,0,0)
		_HorizontalShake ("_HorizontalShake", Range(0, 1)) = 0
		_ColorDrift ("_ColorDrift", Range(0, 1)) = 0.002
		_Temperature2 ("_Temperature2(min, max, factor)", Vector) = (0.1,0.5,0.4,0)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Hidden/Internal-BlackError"
	//CustomEditor "FresnelMaterialEditor"
}