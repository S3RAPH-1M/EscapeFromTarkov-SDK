// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

Shader "Custom/ShitOnScreen" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_ShitTex ("Shit (RGB)", 2D) = "white" {}
		_Intensity ("Intensity", Float) = 2
		_FallofShift ("Fallof Shift", Float) = 0.5
		_FallofStrength ("Fallof Strength", Float) = 32
		_DepthOffset ("DepthOffset", Float) = 0.1
		_FadeDepthOffset ("DepthOffset for fading", Float) = 0.1
		_NoiseScale ("_NoiseScale", Vector) = (1,1,1,1)
		_NoiseIntensity ("_NoiseIntensity", Float) = 1
		_VisibilityCheckerSize ("Visibility Checker Size", Float) = 0.01
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+1000" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+1000" "RenderType" = "Transparent" }
			Blend One One, One One
			ZTest Always
			ZWrite Off
			Fog {
				Mode off
			}
			GpuProgramID 17569
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord2 : TEXCOORD2;
				float2 texcoord3 : TEXCOORD3;
				float2 texcoord4 : TEXCOORD4;
				float4 color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _FallofShift;
			float _FallofStrength;
			float _DepthOffset;
			float _FadeDepthOffset;
			float2 _NoiseScale;
			float _VisibilityCheckerSize;
			// $Globals ConstantBuffers for Fragment Shader
			float _Intensity;
			float _NoiseIntensity;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			sampler2D _CameraDepthTexture;
			// Texture params for Fragment Shader
			sampler2D _ShitTex;
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                const float4 icb[23] = {
                    float4(-0.668, -0.632, 0.0, 0.0),
                    float4(-0.359, -0.839, 0.0, 0.0),
                    float4(-0.175, -0.498, 0.0, 0.0),
                    float4(0.612, -0.636, 0.0, 0.0),
                    float4(-0.444, -0.297, 0.0, 0.0),
                    float4(0.151, -0.402, 0.0, 0.0),
                    float4(0.205, -0.849, 0.0, 0.0),
                    float4(0.847, -0.317, 0.0, 0.0),
                    float4(-0.858, -0.263, 0.0, 0.0),
                    float4(-0.098, -0.041, 0.0, 0.0),
                    float4(0.297, 0.093, 0.0, 0.0),
                    float4(0.517, -0.22, 0.0, 0.0),
                    float4(-0.839, 0.031, 0.0, 0.0),
                    float4(-0.824, 0.361, 0.0, 0.0),
                    float4(-0.507, 0.076, 0.0, 0.0),
                    float4(0.002, 0.423, 0.0, 0.0),
                    float4(0.351, 0.497, 0.0, 0.0),
                    float4(0.756, 0.108, 0.0, 0.0),
                    float4(0.766, 0.524, 0.0, 0.0),
                    float4(-0.124, 0.878, 0.0, 0.0),
                    float4(-0.536, 0.724, 0.0, 0.0),
                    float4(0.288, 0.895, 0.0, 0.0),
                    float4(-0.373, 0.397, 0.0, 0.0)
                };
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                float4 tmp4;
                float4 tmp5;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp0;
                tmp1.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp2.xyz = tmp1.xyz * _FadeDepthOffset.xxx + tmp0.xyz;
                tmp0.xyz = tmp1.xyz * _DepthOffset.xxx + tmp0.xyz;
                tmp1 = tmp2.yyyy * unity_MatrixV._m01_m11_m21_m31;
                tmp1 = unity_MatrixV._m00_m10_m20_m30 * tmp2.xxxx + tmp1;
                tmp1 = unity_MatrixV._m02_m12_m22_m32 * tmp2.zzzz + tmp1;
                tmp1 = unity_MatrixV._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                tmp2 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp2;
                tmp0 = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp2;
                tmp2 = tmp1 + float4(0.0875, 0.0, 0.0, 0.0);
                tmp3 = tmp2.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp3 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp2.xxxx + tmp3;
                tmp3 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp2.zzzz + tmp3;
                tmp2 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp2.wwww + tmp3;
                tmp2.xyz = tmp2.xyz / tmp2.www;
                tmp3.xy = tmp2.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp3.z = 1.0 - tmp3.y;
                tmp3 = tex2Dlod(_CameraDepthTexture, float4(tmp3.xz, 0, 0.0));
                tmp2.x = saturate(tmp3.x - tmp2.z);
                tmp2.x = ceil(tmp2.x);
                tmp2.x = 1.0 - tmp2.x;
                tmp2.x = tmp2.x * -0.125 + 1.0;
                tmp3 = tmp1 + float4(0.075, 0.0, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.75, 1.0) - tmp2.xz;
                tmp2.x = tmp2.y * tmp2.z + tmp2.x;
                tmp3 = tmp1 + float4(0.0625, 0.0, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.625, 1.0) - tmp2.xz;
                tmp2.x = tmp2.y * tmp2.z + tmp2.x;
                tmp3 = tmp1 + float4(0.05, 0.0, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.5, 1.0) - tmp2.xz;
                tmp2.x = tmp2.y * tmp2.z + tmp2.x;
                tmp3 = tmp1 + float4(0.0375, 0.0, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.375, 1.0) - tmp2.xz;
                tmp2.x = tmp2.y * tmp2.z + tmp2.x;
                tmp3 = tmp1 + float4(0.025, 0.0, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.25, 1.0) - tmp2.xz;
                tmp2.x = tmp2.y * tmp2.z + tmp2.x;
                tmp3 = tmp1 + float4(0.0125, 0.0, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.125, 1.0) - tmp2.xz;
                tmp2.x = tmp2.y * tmp2.z + tmp2.x;
                tmp3 = tmp1 - float4(0.0875, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.875, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 - float4(0.075, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.75, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 - float4(0.0625, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.625, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 - float4(0.05, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.5, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 - float4(0.0375, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.375, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 - float4(0.025, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.25, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 - float4(0.0125, -0.0, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.z = saturate(tmp4.x - tmp3.z);
                tmp2.z = ceil(tmp2.z);
                tmp2.yz = float2(0.125, 1.0) - tmp2.xz;
                tmp2.y = tmp2.y * tmp2.z + tmp2.x;
                tmp2.x = min(tmp2.y, tmp2.x);
                tmp3 = tmp1 + float4(0.0, 0.0875, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp2.yzw = tmp3.xyz / tmp3.www;
                tmp3.xy = tmp2.yz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp3.z = 1.0 - tmp3.y;
                tmp3 = tex2Dlod(_CameraDepthTexture, float4(tmp3.xz, 0, 0.0));
                tmp2.y = saturate(tmp3.x - tmp2.w);
                tmp2.y = ceil(tmp2.y);
                tmp2.y = 1.0 - tmp2.y;
                tmp2.y = tmp2.y * -0.125 + 1.0;
                tmp3 = tmp1 + float4(0.0, 0.075, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.75, 1.0) - tmp2.yw;
                tmp2.y = tmp2.z * tmp2.w + tmp2.y;
                tmp3 = tmp1 + float4(0.0, 0.0625, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.625, 1.0) - tmp2.yw;
                tmp2.y = tmp2.z * tmp2.w + tmp2.y;
                tmp3 = tmp1 + float4(0.0, 0.05, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.5, 1.0) - tmp2.yw;
                tmp2.y = tmp2.z * tmp2.w + tmp2.y;
                tmp3 = tmp1 + float4(0.0, 0.0375, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.375, 1.0) - tmp2.yw;
                tmp2.y = tmp2.z * tmp2.w + tmp2.y;
                tmp3 = tmp1 + float4(0.0, 0.025, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.25, 1.0) - tmp2.yw;
                tmp2.y = tmp2.z * tmp2.w + tmp2.y;
                tmp3 = tmp1 + float4(0.0, 0.0125, 0.0, 0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.125, 1.0) - tmp2.yw;
                tmp2.y = tmp2.z * tmp2.w + tmp2.y;
                tmp3 = tmp1 - float4(-0.0, 0.0875, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.875, 1.0) - tmp2.yw;
                tmp2.z = tmp2.z * tmp2.w + tmp2.y;
                tmp2.y = min(tmp2.z, tmp2.y);
                tmp3 = tmp1 - float4(-0.0, 0.075, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.75, 1.0) - tmp2.yw;
                tmp2.z = tmp2.z * tmp2.w + tmp2.y;
                tmp2.y = min(tmp2.z, tmp2.y);
                tmp3 = tmp1 - float4(-0.0, 0.0625, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.625, 1.0) - tmp2.yw;
                tmp2.z = tmp2.z * tmp2.w + tmp2.y;
                tmp2.y = min(tmp2.z, tmp2.y);
                tmp3 = tmp1 - float4(-0.0, 0.05, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.5, 1.0) - tmp2.yw;
                tmp2.z = tmp2.z * tmp2.w + tmp2.y;
                tmp2.y = min(tmp2.z, tmp2.y);
                tmp3 = tmp1 - float4(-0.0, 0.0375, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.375, 1.0) - tmp2.yw;
                tmp2.z = tmp2.z * tmp2.w + tmp2.y;
                tmp2.y = min(tmp2.z, tmp2.y);
                tmp3 = tmp1 - float4(-0.0, 0.025, -0.0, -0.0);
                tmp4 = tmp3.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp4 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                tmp3 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                tmp3.xyz = tmp3.xyz / tmp3.www;
                tmp4.xy = tmp3.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp4.z = 1.0 - tmp4.y;
                tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xz, 0, 0.0));
                tmp2.w = saturate(tmp4.x - tmp3.z);
                tmp2.w = ceil(tmp2.w);
                tmp2.zw = float2(0.25, 1.0) - tmp2.yw;
                tmp2.z = tmp2.z * tmp2.w + tmp2.y;
                tmp2.y = min(tmp2.z, tmp2.y);
                tmp2.z = 0.125 - tmp2.y;
                tmp1 = tmp1 - float4(-0.0, 0.0125, -0.0, -0.0);
                tmp3 = tmp1.yyyy * UNITY_MATRIX_P._m01_m11_m21_m31;
                tmp3 = UNITY_MATRIX_P._m00_m10_m20_m30 * tmp1.xxxx + tmp3;
                tmp3 = UNITY_MATRIX_P._m02_m12_m22_m32 * tmp1.zzzz + tmp3;
                tmp1 = UNITY_MATRIX_P._m03_m13_m23_m33 * tmp1.wwww + tmp3;
                tmp1.xyz = tmp1.xyz / tmp1.www;
                tmp3.xy = tmp1.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp3.z = 1.0 - tmp3.y;
                tmp3 = tex2Dlod(_CameraDepthTexture, float4(tmp3.xz, 0, 0.0));
                tmp1.x = saturate(tmp3.x - tmp1.z);
                tmp1.x = ceil(tmp1.x);
                tmp1.x = 1.0 - tmp1.x;
                tmp1.x = tmp2.z * tmp1.x + tmp2.y;
                tmp1.x = min(tmp1.x, tmp2.y);
                tmp1.yzw = tmp0.xyz / tmp0.www;
                tmp3.xy = tmp1.yz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp3.z = 1.0 - tmp3.y;
                tmp3 = tex2Dlod(_CameraDepthTexture, float4(tmp3.xz, 0, 0.0));
                tmp1.x = tmp1.x * tmp2.x;
                tmp1.w = saturate(tmp3.x - tmp1.w);
                tmp1.w = ceil(tmp1.w);
                tmp2.x = -tmp1.x * tmp1.w + 1.0;
                tmp1.xy = _FallofShift.xx - abs(tmp1.yz);
                tmp1.xy = saturate(tmp1.xy * _FallofStrength.xx);
                tmp1.x = tmp1.y * tmp1.x;
                tmp3.z = tmp0.w - tmp0.z;
                tmp3.xy = tmp0.xy;
                tmp1.yzw = tmp3.xyz / tmp0.www;
                tmp4.xy = tmp1.yz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp0.x = UNITY_MATRIX_P._m00;
                tmp0.y = UNITY_MATRIX_P._m11;
                tmp1.yz = tmp0.xy * _VisibilityCheckerSize.xx;
                tmp1.yz = tmp1.yz / tmp1.ww;
                tmp4.z = 1.0 - tmp4.y;
                tmp2.yw = float2(0.0, 0.0);
                for (int i = tmp2.w; i < 23; i += 1) {
                    tmp4.yw = icb[i + 0].xy * tmp1.yz + tmp4.xz;
                    tmp5 = tex2Dlod(_CameraDepthTexture, float4(tmp4.yw, 0, 0.0));
                    tmp3.w = 1.0 - tmp5.x;
                    tmp3.w = tmp1.w < tmp3.w;
                    tmp3.w = tmp3.w ? 1.0 : 0.0;
                    tmp2.y = tmp2.y + tmp3.w;
                }
                tmp2.z = tmp2.y * 0.0434783;
                tmp1.y = tmp3.z - v.normal.x;
                tmp1.y = saturate(tmp1.y * v.normal.y);
                tmp1.yz = v.tangent.xy * tmp1.yy + float2(1.0, 1.0);
                tmp2.yw = tmp3.xy * v.normal.zz;
                tmp3.xy = tmp2.yw / tmp0.ww;
                tmp1.w = dot(tmp3.xy, tmp3.xy);
                tmp1.w = tmp1.w - v.tangent.z;
                tmp1.w = saturate(-abs(tmp1.w) * v.tangent.w + 1.0);
                tmp3.xy = tmp2.xx * v.texcoord1.xy;
                tmp3.xy = tmp0.zz * tmp3.xy;
                tmp3.xy = tmp1.yy * tmp3.xy;
                tmp0.xy = tmp3.xy * tmp0.xy + tmp2.yw;
                tmp3 = tmp1.zzzz * v.color;
                tmp3 = tmp1.xxxx * tmp3;
                tmp1 = tmp1.wwww * tmp3;
                tmp1 = tmp1 * v.color.wwww;
                tmp1 = tmp2.xxxx * tmp1;
                o.color = tmp2.zzzz * tmp1;
                tmp1.xy = tmp0.xy / tmp0.ww;
                tmp1.xy = tmp1.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp1.z = 1.0 - tmp1.y;
                tmp1.yw = _Time.xx * float2(14345.68, -12345.68);
                tmp1.yw = frac(tmp1.yw);
                o.texcoord2.xy = tmp1.xz * _NoiseScale + tmp1.yw;
                o.position = tmp0;
                o.texcoord.xy = v.texcoord.xy;
                o.texcoord4 = float2(0.0, 0.0);
                o.texcoord4 = tmp2.xz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_ShitTex, inp.texcoord2.xy);
                tmp0.x = tmp0.x * _NoiseIntensity;
                tmp0.x = tmp0.x * inp.texcoord3.x;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0 = tmp0.xxxx * tmp1;
                tmp0 = tmp0 * inp.color;
                tmp0 = tmp0 * _Intensity.xxxx;
                o.sv_target = tmp0 * inp.texcoord4.xxxx;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Hidden/Internal-BlackError"
}