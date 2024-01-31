// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

Shader "Custom/multiFlareOffScreen" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Intensity ("Intensity", Float) = 2
		_FallofShift ("Fallof Shift", Float) = 3
		_FallofStrength ("Fallof Strength", Float) = 1
		_DepthOffset ("DepthOffset", Float) = 0.1
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+100" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+100" "RenderType" = "Transparent" }
			Blend One One, One One
			ColorMask RGB -1
			ZTest Always
			ZWrite Off
			Fog {
				Mode Off
			}
			GpuProgramID 22847
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
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
			// $Globals ConstantBuffers for Fragment Shader
			float _Intensity;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                float4 tmp4;
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
                tmp1.x = tmp0.z < 0.55;
                tmp1.y = v.color.w < 0.005;
                tmp1.x = uint1(tmp1.y) | uint1(tmp1.x);
                if (tmp1.x) {
                    o.position = float4(-100.0, -100.0, -100.0, 1.0);
                    o.color = v.color;
                    o.texcoord.xy = v.texcoord.xy;
                    return o;
                }
                tmp1.xy = tmp0.xy / tmp0.ww;
                tmp1.xy = _FallofShift.xx - abs(tmp1.xy);
                tmp1.xy = saturate(tmp1.xy * _FallofStrength.xx);
                tmp1.x = tmp1.y * tmp1.x;
                tmp1.y = tmp0.z - v.normal.x;
                tmp1.y = saturate(tmp1.y * v.normal.y);
                tmp1.yz = v.tangent.xy * tmp1.yy + float2(1.0, 1.0);
                tmp2.xy = tmp0.xy * v.normal.zz;
                tmp2.xy = tmp2.xy / tmp0.ww;
                tmp1.w = dot(tmp2.xy, tmp2.xy);
                tmp1.w = tmp1.w - v.tangent.z;
                tmp1.w = saturate(-abs(tmp1.w) * v.tangent.w + 1.0);
                tmp2.x = -tmp0.z;
                tmp2.y = 0.0;
                tmp2 = tmp0.yxxy * v.normal.zzzz + tmp2.xyxy;
                tmp3.x = dot(tmp2.xy, tmp2.xy);
                tmp3.x = rsqrt(tmp3.x);
                tmp3.xy = tmp2.xy * tmp3.xx;
                tmp3.z = -tmp3.y;
                tmp3 = tmp3.xyzx * v.texcoord1.xxyy;
                tmp2.xy = tmp3.zw + tmp3.xy;
                tmp3.x = v.texcoord.x >= 0.0;
                tmp3.y = v.texcoord.y < 0.0;
                tmp3.z = dot(tmp2.xy, tmp2.xy);
                tmp3.z = rsqrt(tmp3.z);
                tmp4.xy = tmp2.zw * tmp3.zz;
                tmp4.z = -tmp4.y;
                tmp4 = tmp4.xyzx * v.texcoord1.xxyy;
                tmp2.zw = tmp4.zw + tmp4.xy;
                tmp2 = tmp0.zzzz * tmp2;
                tmp3.zw = tmp0.zz * v.texcoord1.xy;
                tmp2.zw = tmp3.yy ? tmp2.zw : tmp3.zw;
                tmp2.xy = tmp3.xx ? tmp2.zw : tmp2.xy;
                tmp2.xy = tmp1.yy * tmp2.xy;
                tmp3.x = tmp2.x * UNITY_MATRIX_P._m00;
                tmp3.y = tmp2.y * UNITY_MATRIX_P._m11;
                o.position.xy = tmp0.xy * v.normal.zz + tmp3.xy;
                tmp2 = tmp1.zzzz * v.color;
                tmp2 = tmp1.xxxx * tmp2;
                tmp1 = tmp1.wwww * tmp2;
                o.color = tmp1 * v.color.wwww;
                o.position.zw = tmp0.zw;
                o.texcoord.xy = v.texcoord.xy;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0 = tmp0 * inp.color;
                o.sv_target = tmp0 * _Intensity.xxxx;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Hidden/Internal-BlackError"
}