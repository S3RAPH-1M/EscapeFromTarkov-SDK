// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

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
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			Cull Front
			Fog {
				Mode Off
			}
			GpuProgramID 59421
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float color : COLOR0;
				float4 texcoord2 : TEXCOORD2;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _Width;
			float _UVYScale;
			float _DiffusionStrength;
			float _StartFade;
			float _EndFade;
			float _End;
			// $Globals ConstantBuffers for Fragment Shader
			float _InvFade;
			float _Alpha;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _CameraDepthTexture;
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0.xy = v.texcoord1.yy * unity_MatrixV._m01_m11;
                tmp0.xy = unity_MatrixV._m00_m10 * v.texcoord1.xx + tmp0.xy;
                tmp0.xy = unity_MatrixV._m02_m12 * v.texcoord1.zz + tmp0.xy;
                tmp0.z = dot(tmp0.xy, tmp0.xy);
                tmp0.z = rsqrt(tmp0.z);
                tmp0.xy = tmp0.zz * tmp0.xy;
                tmp0.z = -tmp0.y;
                tmp0.xy = tmp0.zx * v.texcoord.xx;
                tmp0.z = v.texcoord.z * v.texcoord.z;
                tmp0.z = tmp0.z * _DiffusionStrength + _Width;
                tmp1 = v.vertex.yyyy * unity_MatrixV._m01_m11_m21_m31;
                tmp1 = unity_MatrixV._m00_m10_m20_m30 * v.vertex.xxxx + tmp1;
                tmp1 = unity_MatrixV._m02_m12_m22_m32 * v.vertex.zzzz + tmp1;
                tmp1 = unity_MatrixV._m03_m13_m23_m33 * v.vertex.wwww + tmp1;
                tmp0.xy = tmp0.xy * tmp0.zz + tmp1.xy;
                tmp2 = tmp0.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp0 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp0.xxxx + tmp2;
                tmp0 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp1.zzzz + tmp0;
                tmp0 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp1.wwww + tmp0;
                o.sv_position = tmp0;
                tmp0.z = saturate(v.texcoord.z / _StartFade);
                tmp0.z = tmp0.z * v.color.w;
                tmp1.x = _End - v.texcoord.z;
                tmp1.x = saturate(tmp1.x / _EndFade);
                o.color.x = tmp0.z * tmp1.x;
                o.texcoord.x = max(v.texcoord.x, 0.0);
                o.texcoord.y = v.texcoord.y * _UVYScale;
                tmp0.y = tmp0.y * _ProjectionParams.x;
                tmp1.xzw = tmp0.xwy * float3(0.5, 0.5, 0.5);
                o.texcoord2.w = tmp0.w;
                o.texcoord2.xy = tmp1.zz + tmp1.xw;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp0.y = tmp0.y * unity_MatrixV._m21;
                tmp0.x = unity_MatrixV._m20 * tmp0.x + tmp0.y;
                tmp0.x = unity_MatrixV._m22 * tmp0.z + tmp0.x;
                tmp0.x = unity_MatrixV._m23 * tmp0.w + tmp0.x;
                o.texcoord2.z = -tmp0.x;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0.xy = inp.texcoord2.xy / inp.texcoord2.ww;
                tmp0 = tex2D(_CameraDepthTexture, tmp0.xy);
                tmp0.x = _ZBufferParams.z * tmp0.x + _ZBufferParams.w;
                tmp0.x = 1.0 / tmp0.x;
                tmp0.x = tmp0.x - inp.texcoord2.z;
                tmp0.x = saturate(tmp0.x * _InvFade);
                tmp0.x = tmp0.x * inp.color.x;
                tmp0.x = tmp0.x * _Alpha;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                o.sv_target.w = tmp0.x * tmp1.w;
                o.sv_target.xyz = tmp1.xyz;
                return o;
			}
			ENDCG
		}
	}
}