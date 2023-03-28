// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

Shader "Hidden/Custom Global Fog" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 891
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			// $Globals ConstantBuffers for Fragment Shader
			float _GFogStrength;
			float _GFogY;
			float _GFogMax;
			float _GFogStart;
			float4 _GFogColor;
			float4 _GFogFuncVals;
			float4 _GFogTopFuncVals;
			float _BlendType;
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
                o.sv_position.z = 0.0;
                tmp0.xyz = v.vertex.yyy * UNITY_MATRIX_P._m01_m11_m31;
                tmp0.xyz = UNITY_MATRIX_P._m00_m10_m30 * v.vertex.xxx + tmp0.xyz;
                tmp0.xyz = UNITY_MATRIX_P._m02_m12_m32 * v.vertex.zzz + tmp0.xyz;
                tmp0.xyz = UNITY_MATRIX_P._m03_m13_m33 * v.vertex.www + tmp0.xyz;
                o.sv_position.xyw = tmp0.xyz;
                tmp0.y = tmp0.y * _ProjectionParams.x;
                tmp1.xzw = tmp0.xzy * float3(0.5, 0.5, 0.5);
                tmp0.xy = tmp1.zz + tmp1.xw;
                o.texcoord.xy = tmp0.xy / tmp0.zz;
                tmp0.xyz = v.vertex.xyz * float3(-1.0, -1.0, 1.0);
                tmp0.w = _ProjectionParams.z / tmp0.z;
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp1.xyz = tmp0.yyy * unity_CameraToWorld._m01_m11_m21;
                tmp0.xyw = unity_CameraToWorld._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                o.texcoord1.xyz = unity_CameraToWorld._m02_m12_m22 * tmp0.zzz + tmp0.xyw;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                float4 tmp4;
                float4 tmp5;
                float4 tmp6;
                tmp0 = tex2D(_CameraDepthTexture, inp.texcoord.xy);
                tmp0.x = _ZBufferParams.x * tmp0.x + _ZBufferParams.y;
                tmp0.x = 1.0 / tmp0.x;
                tmp0.xyz = tmp0.xxx * inp.texcoord1.xyz;
                tmp0.x = dot(tmp0.xyz, tmp0.xyz);
                tmp0.x = sqrt(tmp0.x);
                tmp0.y = -tmp0.y / tmp0.x;
                tmp0.x = min(tmp0.x, _GFogMax);
                tmp0.z = _GFogY - _WorldSpaceCameraPos.y;
                tmp1.y = tmp0.x * tmp0.y + tmp0.z;
                tmp0.x = tmp0.y * _GFogStart + tmp0.z;
                tmp0.z = tmp0.y > 0.0;
                tmp0.w = min(tmp1.y, tmp0.x);
                tmp0.x = max(tmp1.y, tmp0.x);
                tmp1.x = tmp0.z ? tmp0.w : tmp0.x;
                tmp0.xz = max(tmp1.xy, float2(0.0, 0.0));
                tmp1.zw = tmp0.xz + _GFogFuncVals.zz;
                tmp1.zw = log(tmp1.zw);
                tmp1.zw = tmp1.zw * _GFogFuncVals.yy;
                tmp1.zw = tmp1.zw * float2(0.6931472, 0.6931472);
                tmp0.xz = _GFogFuncVals.xx * tmp0.xz + -tmp1.zw;
                tmp1.xy = max(tmp1.xy, _GFogTopFuncVals.xx);
                tmp1.zw = tmp1.xy * tmp1.xy;
                tmp1.xy = tmp1.zw * _GFogTopFuncVals.yy + tmp1.xy;
                tmp0.xz = tmp1.xy * _GFogTopFuncVals.zz + tmp0.xz;
                tmp0.x = tmp0.z - tmp0.x;
                tmp0.x = tmp0.x * _GFogStrength;
                tmp0.x = tmp0.x / abs(tmp0.y);
                tmp0.x = sqrt(abs(tmp0.x));
                tmp0.x = min(tmp0.x, 1.0);
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp2 = tmp0.xxxx * _GFogColor;
                tmp0.y = _BlendType == 1.0;
                if (tmp0.y) {
                    o.sv_target = max(tmp1, tmp2);
                    return o;
                }
                tmp0.y = _BlendType == 2.0;
                if (tmp0.y) {
                    tmp3 = float4(1.0, 1.0, 1.0, 1.0) - tmp1;
                    tmp4 = -_GFogColor * tmp0.xxxx + float4(1.0, 1.0, 1.0, 1.0);
                    o.sv_target = -tmp3 * tmp4 + float4(1.0, 1.0, 1.0, 1.0);
                    return o;
                }
                tmp0.y = _BlendType == 3.0;
                if (tmp0.y) {
                    tmp3 = tmp1 > float4(0.5, 0.5, 0.5, 0.5);
                    tmp3 = tmp3 ? 1.0 : 0.0;
                    tmp4 = tmp1 - float4(0.5, 0.5, 0.5, 0.5);
                    tmp4 = -tmp4 * float4(2.0, 2.0, 2.0, 2.0) + float4(1.0, 1.0, 1.0, 1.0);
                    tmp5 = -_GFogColor * tmp0.xxxx + float4(1.0, 1.0, 1.0, 1.0);
                    tmp4 = -tmp4 * tmp5 + float4(1.0, 1.0, 1.0, 1.0);
                    tmp5 = tmp1 <= float4(0.5, 0.5, 0.5, 0.5);
                    tmp5 = tmp5 ? 1.0 : 0.0;
                    tmp6 = tmp1 * tmp2;
                    tmp6 = tmp6 + tmp6;
                    tmp5 = tmp5 * tmp6;
                    o.sv_target = tmp3 * tmp4 + tmp5;
                    return o;
                }
                tmp0.y = _BlendType == 4.0;
                if (tmp0.y) {
                    tmp3 = tmp2 > float4(0.5, 0.5, 0.5, 0.5);
                    tmp3 = tmp3 ? 1.0 : 0.0;
                    tmp4 = float4(1.0, 1.0, 1.0, 1.0) - tmp1;
                    tmp5 = _GFogColor * tmp0.xxxx + float4(-0.5, -0.5, -0.5, -0.5);
                    tmp5 = float4(1.0, 1.0, 1.0, 1.0) - tmp5;
                    tmp4 = -tmp4 * tmp5 + float4(1.0, 1.0, 1.0, 1.0);
                    tmp2 = tmp2 <= float4(0.5, 0.5, 0.5, 0.5);
                    tmp2 = tmp2 ? 1.0 : 0.0;
                    tmp5 = _GFogColor * tmp0.xxxx + float4(0.5, 0.5, 0.5, 0.5);
                    tmp5 = tmp1 * tmp5;
                    tmp2 = tmp2 * tmp5;
                    o.sv_target = tmp3 * tmp4 + tmp2;
                    return o;
                }
                tmp2 = _GFogColor - tmp1;
                o.sv_target = tmp0.xxxx * tmp2 + tmp1;
                return o;
			}
			ENDCG
		}
	}
}