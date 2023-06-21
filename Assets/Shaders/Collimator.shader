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
	SubShader {
		Tags { "DisableBatching" = "true" "IGNOREPROJECTOR" = "true" "QUEUE" = "Overlay+11" "RenderType" = "Transparent" }
		Pass {
			Tags { "DisableBatching" = "true" "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Overlay+11" "RenderType" = "Transparent" }
			Blend One OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZWrite Off
			Cull Off
			GpuProgramID 7425
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float2 texcoord2 : TEXCOORD2;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MarkShift;
			float _MarkScale;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _Color;
			float _HDR;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MarkTex;
			sampler2D _NoiseTex;
			sampler2D _FadeTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                o.sv_position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.texcoord1 = v.texcoord.xyxy * float4(1234.568, 1234.568, 1.0, 1.0);
                tmp0.xyz = _WorldSpaceCameraPos * unity_WorldToObject._m01_m11_m21;
                tmp0.xyz = unity_WorldToObject._m00_m10_m20 * _WorldSpaceCameraPos + tmp0.xyz;
                tmp0.xyz = unity_WorldToObject._m02_m12_m22 * _WorldSpaceCameraPos + tmp0.xyz;
                tmp0.xyz = tmp0.xyz + unity_WorldToObject._m03_m13_m23;
                tmp0.xyz = tmp0.xyz - _MarkShift.xyz;
                tmp1.xyz = v.vertex.xyz / _MarkScale.xxx;
                tmp0.xyz = tmp0.xyz - tmp1.xyz;
                tmp0.w = _MarkShift.y * _MarkShift.y;
                tmp0.y = tmp0.w / tmp0.y;
                tmp0.xy = tmp0.yy * tmp0.xz;
                tmp0.xy = tmp0.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp0.z = 1.0 - tmp0.y;
                o.texcoord2.xy = tmp0.xz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_MarkTex, inp.texcoord2.xy);
                tmp0.xyz = tmp0.www * _Color.xyz;
                tmp1 = tex2D(_NoiseTex, inp.texcoord.xy);
                tmp0.xyz = tmp0.xyz * tmp1.xxx;
                tmp0.xyz = tmp0.xyz * float3(0.7692308, 0.7692308, 0.7692308);
                tmp1 = tex2D(_FadeTex, inp.texcoord1.xy);
                tmp0.xyz = tmp0.xyz * tmp1.xxx;
                tmp0.xyz = tmp0.xyz * _HDR.xxx;
                tmp1.x = _ThermalVisionOn > 0.0;
                tmp0.w = 0.0;
                o.sv_target = tmp1.xxxx ? float4(0.0, 0.0, 0.0, 1.0) : tmp0;
                return o;
			}
			ENDCG
		}
	}
}