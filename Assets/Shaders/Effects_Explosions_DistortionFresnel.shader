Shader "Effects/Explosions/DistortionFresnel" {
	Properties {
		_BumpAmt ("Distortion", Float) = 10
		_FresnelPow ("Fresnel Pow", Float) = 5
		_FresnelR0 ("Fresnel R0", Float) = 0.04
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		GrabPass {
		}
		Pass {
			Name "BASE"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 10469
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float4 texcoord : TEXCOORD0;
				float4 color : COLOR0;
				float texcoord4 : TEXCOORD4;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _FresnelPow;
			float _FresnelR0;
			// $Globals ConstantBuffers for Fragment Shader
			float _BumpAmt;
			float4 _GrabTexture_TexelSize;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _GrabTexture;
			
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
                tmp0 = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.sv_position = tmp0;
                tmp0.xy = tmp0.xy * float2(1.0, -1.0) + tmp0.ww;
                o.texcoord.zw = tmp0.ww;
                o.texcoord.xy = tmp0.xy * float2(0.5, 0.5);
                o.color = v.color;
                tmp0.xyz = _WorldSpaceCameraPos * unity_WorldToObject._m01_m11_m21;
                tmp0.xyz = unity_WorldToObject._m00_m10_m20 * _WorldSpaceCameraPos + tmp0.xyz;
                tmp0.xyz = unity_WorldToObject._m02_m12_m22 * _WorldSpaceCameraPos + tmp0.xyz;
                tmp0.xyz = tmp0.xyz + unity_WorldToObject._m03_m13_m23;
                tmp0.xyz = tmp0.xyz - v.vertex.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.w = dot(v.normal.xyz, v.normal.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * v.normal.xyz;
                tmp0.x = dot(tmp1.xyz, tmp0.xyz);
                tmp0.x = 1.0 - abs(tmp0.x);
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _FresnelPow;
                tmp0.x = exp(tmp0.x);
                tmp0.y = 1.0 - _FresnelR0;
                o.texcoord4.x = saturate(tmp0.y * tmp0.x + _FresnelR0);
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0.x = saturate(inp.texcoord4.x);
                tmp0.xy = tmp0.xx * _GrabTexture_TexelSize.xy;
                tmp0.xy = tmp0.xy * _BumpAmt.xx;
                tmp0.xy = tmp0.xy * inp.color.ww;
                tmp0.xy = tmp0.xy * inp.texcoord.zz + inp.texcoord.xy;
                tmp0.xy = tmp0.xy / inp.texcoord.ww;
                tmp0 = tex2D(_GrabTexture, tmp0.xy);
                tmp0 = tmp0 * inp.color;
                o.sv_target.w = saturate(tmp0.w);
                o.sv_target.xyz = tmp0.xyz;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Effects/Distortion/Free/CullOff"
}