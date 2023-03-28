Shader "Hidden/Time of Day/Scattering" {
	Properties {
		_DitheringTexture ("Dithering Lookup Texture (A)", 2D) = "black" {}
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			GpuProgramID 14201
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float2 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float3 normal : NORMAL0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4x4 TOD_World2Sky;
			float4x4 _FrustumCornersWS;
			float4 _MainTex_TexelSize;
			// $Globals ConstantBuffers for Fragment Shader
			float3 TOD_SunSkyColor;
			float3 TOD_MoonSkyColor;
			float3 TOD_GroundColor;
			float3 TOD_MoonHaloColor;
			float3 TOD_LocalSunDirection;
			float3 TOD_LocalMoonDirection;
			float TOD_Contrast;
			float TOD_Brightness;
			float TOD_ScatteringBrightness;
			float TOD_Fogginess;
			float TOD_MoonHaloPower;
			float3 TOD_kBetaMie;
			float4 TOD_kSun;
			float4 TOD_k4PI;
			float4 TOD_kRadius;
			float4 TOD_kScale;
			float4 _Density;
			float _SunrizeGlow;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _CameraDepthTexture;
			sampler2D _DitheringTexture;
			
			// Keywords: GAMMA LDR
			v2f vert(appdata_full v)
			{
                v2f o;
                const float4 icb[4] = {
                    float4(1.0, 0.0, 0.0, 0.0),
                    float4(0.0, 1.0, 0.0, 0.0),
                    float4(0.0, 0.0, 1.0, 0.0),
                    float4(0.0, 0.0, 0.0, 1.0)
                };
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                float4 tmp0;
                float4 tmp1;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * float4(0.1, 0.1, 0.1, 0.1) + tmp0;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                tmp0.x = _MainTex_TexelSize.y < 0.0;
                tmp0.y = 1.0 - v.texcoord.y;
                o.texcoord.y = tmp0.x ? tmp0.y : v.texcoord.y;
                o.texcoord1 = v.texcoord.xxy;
                tmp0.xy = v.texcoord.xy * _ScreenParams.xy;
                o.texcoord2.xy = tmp0.xy * float2(0.125, 0.125);
                tmp0.x = asint(v.vertex.z);
                tmp1.x = dot(_FrustumCornersWS._m00_m10_m20_m30, icb[tmp0.x + 0]);
                tmp1.y = dot(_FrustumCornersWS._m01_m11_m21_m31, icb[tmp0.x + 0]);
                tmp1.z = dot(_FrustumCornersWS._m02_m12_m22_m32, icb[tmp0.x + 0]);
                o.texcoord3.xyz = tmp1.xyz;
                tmp0.xyz = tmp1.yyy * TOD_World2Sky._m01_m11_m21;
                tmp0.xyz = TOD_World2Sky._m00_m10_m20 * tmp1.xxx + tmp0.xyz;
                tmp0.xyz = TOD_World2Sky._m02_m12_m22 * tmp1.zzz + tmp0.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                o.normal.xyz = tmp0.www * tmp0.xyz;
                return o;
			}
			// Keywords: GAMMA LDR
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
                float4 tmp7;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp1 = tex2D(_CameraDepthTexture, inp.texcoord1.xy);
                tmp1.x = _ZBufferParams.x * tmp1.x + _ZBufferParams.y;
                tmp1.x = 1.0 / tmp1.x;
                tmp1.yzw = tmp1.xxx * inp.texcoord3.xyz;
                tmp1.y = dot(tmp1.xyz, tmp1.xyz);
                tmp1.y = sqrt(tmp1.y);
                tmp1.z = tmp1.x * inp.texcoord3.y + _Density.y;
                tmp1.z = tmp1.z * _Density.x;
                tmp1.z = max(tmp1.z, 0.0);
                tmp1.z = tmp1.z + 1.0;
                tmp1.z = 1.0 / tmp1.z;
                tmp1.y = tmp1.z * tmp1.y;
                tmp1.y = tmp1.y * _Density.z;
                tmp1.y = min(tmp1.y, 10.0);
                tmp1.y = tmp1.y * -1.442695;
                tmp1.y = exp(tmp1.y);
                tmp1.y = 1.0 - tmp1.y;
                tmp1.x = tmp1.x < 1.0;
                tmp1.x = tmp1.x ? 1.0 : 0.0;
                tmp1.x = tmp1.x * tmp1.y;
                tmp1.y = tmp1.x == 0.0;
                if (tmp1.y) {
                    o.sv_target = tmp0;
                    return o;
                }
                tmp1.y = dot(inp.normal.xyz, inp.normal.xyz);
                tmp1.y = rsqrt(tmp1.y);
                tmp1.yzw = tmp1.yyy * inp.normal.xyz;
                tmp2.xyz = tmp1.yzw * _SunrizeGlow.xxx;
                tmp3 = tex2D(_DitheringTexture, inp.texcoord2.xy);
                tmp1.y = tmp1.z * _SunrizeGlow + 0.03125;
                tmp1.zw = tmp2.yy > float2(0.03125, -0.03125);
                tmp1.y = tmp1.y * tmp1.y;
                tmp1.y = tmp1.y * 8.0;
                tmp1.y = tmp1.z ? tmp2.y : tmp1.y;
                tmp2.w = tmp1.y ? tmp1.w : 0.0;
                tmp1.y = tmp1.x * TOD_kScale.x;
                tmp3.y = TOD_kRadius.x + TOD_kScale.w;
                tmp1.z = tmp2.w * tmp2.w;
                tmp1.z = tmp1.z * TOD_kRadius.y + TOD_kRadius.w;
                tmp1.z = tmp1.z - TOD_kRadius.y;
                tmp1.z = sqrt(tmp1.z);
                tmp1.z = -TOD_kRadius.x * tmp2.w + tmp1.z;
                tmp1.w = -TOD_kScale.w * TOD_kScale.z;
                tmp1.zw = tmp1.zw * float2(0.25, 1.442695);
                tmp1.w = exp(tmp1.w);
                tmp4.x = tmp2.w * tmp3.y;
                tmp4.x = tmp4.x / tmp3.y;
                tmp4.x = 1.0 - tmp4.x;
                tmp4.y = tmp4.x * 5.25 + -6.8;
                tmp4.y = tmp4.x * tmp4.y + 3.83;
                tmp4.y = tmp4.x * tmp4.y + 0.459;
                tmp4.x = tmp4.x * tmp4.y + -0.00287;
                tmp4.x = tmp4.x * 1.442695;
                tmp4.x = exp(tmp4.x);
                tmp1.w = tmp1.w * tmp4.x;
                tmp1.y = tmp1.y * tmp1.z;
                tmp4.xyz = tmp1.zzz * tmp2.xwz;
                tmp3.xz = float2(0.0, 0.0);
                tmp3.xyz = tmp4.xyz * float3(0.5, 0.5, 0.5) + tmp3.xyz;
                tmp4.xyz = TOD_k4PI.www + TOD_k4PI.xyz;
                tmp5.xyz = tmp3.xyz;
                tmp6.xyz = float3(0.0, 0.0, 0.0);
                tmp4.w = 0.0;
                for (int i = tmp4.w; i < 4; i += 1) {
                    tmp5.w = dot(tmp5.xyz, tmp5.xyz);
                    tmp5.w = sqrt(tmp5.w);
                    tmp6.w = 1.0 / tmp5.w;
                    tmp5.w = TOD_kRadius.x - tmp5.w;
                    tmp5.w = tmp5.w * TOD_kScale.z;
                    tmp5.w = tmp5.w * 1.442695;
                    tmp5.w = exp(tmp5.w);
                    tmp7.x = tmp1.y * tmp5.w;
                    tmp7.y = dot(tmp2.xyz, tmp5.xyz);
                    tmp7.z = dot(TOD_LocalSunDirection, tmp5.xyz);
                    tmp7.z = -tmp7.z * tmp6.w + 1.0;
                    tmp7.w = tmp7.z * 5.25 + -6.8;
                    tmp7.w = tmp7.z * tmp7.w + 3.83;
                    tmp7.w = tmp7.z * tmp7.w + 0.459;
                    tmp7.z = tmp7.z * tmp7.w + -0.00287;
                    tmp7.z = tmp7.z * 1.442695;
                    tmp7.z = exp(tmp7.z);
                    tmp6.w = -tmp7.y * tmp6.w + 1.0;
                    tmp7.y = tmp6.w * 5.25 + -6.8;
                    tmp7.y = tmp6.w * tmp7.y + 3.83;
                    tmp7.y = tmp6.w * tmp7.y + 0.459;
                    tmp6.w = tmp6.w * tmp7.y + -0.00287;
                    tmp6.w = tmp6.w * 1.442695;
                    tmp6.w = exp(tmp6.w);
                    tmp6.w = tmp6.w * 0.25;
                    tmp6.w = tmp7.z * 0.25 + -tmp6.w;
                    tmp5.w = tmp5.w * tmp6.w;
                    tmp5.w = tmp1.w * 0.25 + tmp5.w;
                    tmp7.yzw = tmp4.xyz * -tmp5.www;
                    tmp7.yzw = tmp7.yzw * float3(1.442695, 1.442695, 1.442695);
                    tmp7.yzw = exp(tmp7.yzw);
                    tmp6.xyz = tmp7.yzw * tmp7.xxx + tmp6.xyz;
                    tmp5.xyz = tmp2.xwz * tmp1.zzz + tmp5.xyz;
                }
                tmp1.yzw = tmp6.xyz * TOD_SunSkyColor;
                tmp3.xyz = tmp1.yzw * TOD_kSun.xyz;
                tmp1.yzw = tmp1.yzw * TOD_kSun.www;
                tmp2.w = saturate(tmp2.y * -0.8);
                tmp4.x = tmp2.w * -2.0 + 3.0;
                tmp2.w = tmp2.w * tmp2.w;
                tmp2.w = tmp2.w * tmp4.x;
                tmp4.x = dot(TOD_LocalSunDirection, tmp2.xyz);
                tmp4.y = tmp4.x * tmp4.x;
                tmp4.y = tmp4.y * 0.75 + 0.75;
                tmp4.z = tmp4.x * tmp4.x + 1.0;
                tmp4.z = tmp4.z * TOD_kBetaMie.x;
                tmp4.x = TOD_kBetaMie.z * tmp4.x + TOD_kBetaMie.y;
                tmp4.x = log(tmp4.x);
                tmp4.x = tmp4.x * 1.5;
                tmp4.x = exp(tmp4.x);
                tmp4.x = tmp4.z / tmp4.x;
                tmp1.yzw = tmp1.yzw * tmp4.xxx;
                tmp1.yzw = tmp4.yyy * tmp3.xyz + tmp1.yzw;
                tmp3.xyz = tmp2.yyy * -TOD_MoonSkyColor + TOD_MoonSkyColor;
                tmp1.yzw = tmp1.yzw + tmp3.xyz;
                tmp2.x = dot(tmp2.xyz, TOD_LocalMoonDirection);
                tmp2.x = max(tmp2.x, 0.0);
                tmp2.x = log(tmp2.x);
                tmp2.x = tmp2.x * TOD_MoonHaloPower;
                tmp2.x = exp(tmp2.x);
                tmp1.yzw = TOD_MoonHaloColor * tmp2.xxx + tmp1.yzw;
                tmp2.x = tmp1.z + tmp1.y;
                tmp2.x = tmp1.w + tmp2.x;
                tmp2.xyz = tmp2.xxx * float3(0.333, 0.333, 0.333) + -tmp1.yzw;
                tmp1.yzw = TOD_Fogginess.xxx * tmp2.xyz + tmp1.yzw;
                tmp2.xyz = TOD_GroundColor - tmp1.yzw;
                tmp1.yzw = tmp2.www * tmp2.xyz + tmp1.yzw;
                tmp1.yzw = tmp1.yzw * TOD_ScatteringBrightness.xxx;
                tmp1.yzw = log(tmp1.yzw);
                tmp1.yzw = tmp1.yzw * TOD_Contrast.xxx;
                tmp1.yzw = exp(tmp1.yzw);
                tmp1.yzw = tmp3.www * float3(0.0153846, 0.0153846, 0.0153846) + tmp1.yzw;
                tmp1.yzw = tmp1.yzw * -TOD_Brightness.xxx;
                tmp1.yzw = exp(tmp1.yzw);
                tmp1.yzw = float3(1.0, 1.0, 1.0) - tmp1.yzw;
                tmp1.yzw = sqrt(tmp1.yzw);
                tmp1.yzw = tmp1.yzw - tmp0.xyz;
                o.sv_target.xyz = tmp1.xxx * tmp1.yzw + tmp0.xyz;
                o.sv_target.w = tmp0.w;
                return o;
			}
			ENDCG
		}
	}
}