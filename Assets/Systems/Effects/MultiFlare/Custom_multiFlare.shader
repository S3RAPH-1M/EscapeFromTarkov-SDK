// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

Shader "Custom/multiFlare" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Intensity ("Intensity", Float) = 2
		_FallofShift ("Fallof Shift", Float) = 0.5
		_FallofStrength ("Fallof Strength", Float) = 32
		_DepthOffset ("DepthOffset", Float) = 0.1
		_FadeDepthOffset ("DepthOffset for fading", Float) = 0.2
		_Volume ("Volume", Range(0, 5)) = 1
		_VolumeStep ("Volume step", Float) = 3
		_VisibilityCheckerSize ("Visibility Checker Size", Float) = 0.01
	}
	SubShader {
		Tags { "DisableBatching" = "true" "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+1001" "RenderType" = "Transparent" }
		Pass {
			Tags { "DisableBatching" = "true" "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+1001" "RenderType" = "Transparent" }
			Blend One One, One One
			ZTest Always
			ZWrite Off
			Fog {
				Mode off
			}
			GpuProgramID 43916
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
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
			float _VisibilityCheckerSize;
			// $Globals ConstantBuffers for Fragment Shader
			float _Intensity;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			sampler2D _CameraDepthTexture;
			// Texture params for Fragment Shader
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
                float4 tmp6;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp0;
                tmp1.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp0.xyz = tmp1.xyz * _DepthOffset.xxx + tmp0.xyz;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp0 = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                tmp0.z = tmp0.w - tmp0.z;
                tmp1.xyz = tmp0.xyz / tmp0.www;
                tmp2.xy = tmp1.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp3.x = UNITY_MATRIX_P._m00;
                tmp3.y = UNITY_MATRIX_P._m11;
                tmp3.zw = tmp3.xy * _VisibilityCheckerSize.xx;
                tmp3.zw = tmp3.zw / tmp1.zz;
                tmp2.z = 1.0 - tmp2.y;
                tmp1.w = 0.0;
                tmp2.y = 0.0;
                for (int i = tmp2.y; i < 23; i += 1) {
                    tmp4.xy = icb[i + 0].xy * tmp3.zw + tmp2.xz;
                    tmp4 = tex2Dlod(_CameraDepthTexture, float4(tmp4.xy, 0, 0.0));
                    tmp2.w = 1.0 - tmp4.x;
                    tmp2.w = tmp1.z < tmp2.w;
                    tmp2.w = tmp2.w ? 1.0 : 0.0;
                    tmp1.w = tmp1.w + tmp2.w;
                }
                tmp1.z = tmp1.w * 0.0434783;
                tmp1.xy = _FallofShift.xx - abs(tmp1.xy);
                tmp1.xy = saturate(tmp1.xy * _FallofStrength.xx);
                tmp1.x = tmp1.y * tmp1.x;
                tmp1.y = tmp0.z - v.normal.x;
                tmp1.y = saturate(tmp1.y * v.normal.y);
                tmp1.yw = v.tangent.xy * tmp1.yy + float2(1.0, 1.0);
                tmp2.xy = tmp0.xy * v.normal.zz;
                tmp2.zw = tmp2.xy / tmp0.ww;
                tmp2.z = dot(tmp2.xy, tmp2.xy);
                tmp2.z = tmp2.z - v.tangent.z;
                tmp2.z = saturate(-abs(tmp2.z) * v.tangent.w + 1.0);
                tmp4.x = -tmp0.z;
                tmp4.y = 0.0;
                tmp5 = tmp0.yxxy * v.normal.zzzz + tmp4.xyxy;
                tmp0.x = dot(tmp5.xy, tmp5.xy);
                tmp0.x = rsqrt(tmp0.x);
                tmp6.xy = tmp0.xx * tmp5.xy;
                tmp6.z = -tmp6.y;
                tmp6 = tmp6.xyzx * v.texcoord1.xxyy;
                tmp0.xy = tmp6.zw + tmp6.xy;
                tmp0.xy = tmp0.zz * tmp0.xy;
                tmp2.w = v.texcoord.x >= 0.0;
                tmp3.z = v.texcoord.y < 0.0;
                tmp3.w = dot(tmp5.xy, tmp5.xy);
                tmp3.w = rsqrt(tmp3.w);
                tmp5.xy = tmp3.ww * tmp5.zw;
                tmp5.z = -tmp5.y;
                tmp5 = tmp5.xyzx * v.texcoord1.xxyy;
                tmp4.yz = tmp5.zw + tmp5.xy;
                tmp4.yz = tmp0.zz * tmp4.yz;
                tmp5.xy = tmp0.zz * v.texcoord1.xy;
                tmp3.zw = tmp3.zz ? tmp4.yz : tmp5.xy;
                tmp0.xy = tmp2.ww ? tmp3.zw : tmp0.xy;
                tmp0.xy = tmp1.zz * tmp0.xy;
                tmp0.xy = tmp1.yy * tmp0.xy;
                o.position.xy = tmp0.xy * tmp3.xy + tmp2.xy;
                tmp3 = tmp1.wwww * v.color;
                tmp3 = tmp1.xxxx * tmp3;
                tmp2 = tmp2.zzzz * tmp3;
                tmp2 = tmp2 * v.color.wwww;
                o.color = tmp1.zzzz * tmp2;
                tmp0.x = v.color.w < 0.005;
                tmp0.y = tmp0.w + tmp4.x;
                o.position.z = tmp0.x ? 1.0 : tmp0.y;
                o.position.w = tmp0.w;
                o.texcoord.xy = v.texcoord.xy;
                o.texcoord1.y = 0.0;
                o.texcoord1.x = tmp1.z;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0.x = _ThermalVisionOn > 0.0;
                if (tmp0.x) {
                    o.sv_target = float4(0.0, 0.0, 0.0, 0.0);
                    return o;
                }
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0 = tmp0 * inp.color;
                tmp0 = tmp0 * _Intensity.xxxx;
                o.sv_target = tmp0 * inp.texcoord1.xxxx;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Hidden/Internal-BlackError"
}