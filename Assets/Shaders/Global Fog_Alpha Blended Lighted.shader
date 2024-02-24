Shader "Global Fog/Alpha Blended Lighted" {
	Properties {
		_TintColor ("Tint Color", Vector) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
		_LocalMinimalAmbientLight ("Local Minimal Ambient Light", Vector) = (0,0,0,1)
		[Toggle(_FOG_ON)] _Fog ("Enable Fog", Float) = 1
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			Cull Off
			GpuProgramID 5676
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float4 color : COLOR0;
				float2 texcoord : TEXCOORD0;
				float texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _GFogStrength;
			float _GFogY;
			float _GFogMax;
			float _GFogStart;
			float4 _GFogFuncVals;
			float4 _GFogTopFuncVals;
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
			float4 _TintColor;
			float4 _LocalMinimalAmbientLight;
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _EFT_Ambient;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			
			// Keywords: GAMMA LDR
			v2f vert(appdata_full v)
			{
                v2f o;
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
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                o.sv_position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                tmp2.xyz = tmp1.yyy * unity_MatrixV._m01_m11_m21;
                tmp2.xyz = unity_MatrixV._m00_m10_m20 * tmp1.xxx + tmp2.xyz;
                tmp1.xyz = unity_MatrixV._m02_m12_m22 * tmp1.zzz + tmp2.xyz;
                tmp1.xyz = unity_MatrixV._m03_m13_m23 * tmp1.www + tmp1.xyz;
                tmp2.xyz = glstate_lightmodel_ambient.xyz + glstate_lightmodel_ambient.xyz;
                tmp2.xyz = max(tmp2.xyz, _LocalMinimalAmbientLight.xyz);
                tmp3.xyz = tmp2.xyz;
                tmp0.w = 0.0;
                for (int i = tmp0.w; i < 4; i += 1) {
                    tmp4.xyz = -tmp1.xyz * unity_LightPosition[i].www + unity_LightPosition[i].xyz;
                    tmp1.w = dot(tmp4.xyz, tmp4.xyz);
                    tmp1.w = tmp1.w * unity_LightAtten[i].z + 1.0;
                    tmp1.w = 1.0 / tmp1.w;
                    tmp3.xyz = unity_LightColor[i].xyz * tmp1.www + tmp3.xyz;
                }
                tmp1.xyz = max(tmp3.xyz, float3(0.0, 0.0, 0.0));
                tmp1.xyz = min(tmp1.xyz, float3(0.7, 0.7, 0.7));
                tmp1.w = v.color.w;
                o.color = tmp1 * _TintColor;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0.xyz = tmp0.xyz - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp1.x = sqrt(tmp0.w);
                tmp1.y = max(tmp1.x, 0.000001);
                tmp1.y = -tmp0.y / tmp1.y;
                tmp1.z = min(tmp1.x, _GFogMax);
                tmp1.w = _GFogY - _WorldSpaceCameraPos.y;
                tmp2.y = tmp1.z * tmp1.y + tmp1.w;
                tmp1.z = tmp1.y * _GFogStart + tmp1.w;
                tmp1.w = tmp1.y > 0.0;
                tmp2.z = min(tmp2.y, tmp1.z);
                tmp1.z = max(tmp2.y, tmp1.z);
                tmp2.x = tmp1.w ? tmp2.z : tmp1.z;
                tmp1.zw = max(tmp2.xy, float2(0.0, 0.0));
                tmp2.zw = tmp1.zw + _GFogFuncVals.zz;
                tmp2.zw = log(tmp2.zw);
                tmp2.zw = tmp2.zw * _GFogFuncVals.yy;
                tmp2.zw = tmp2.zw * float2(0.6931472, 0.6931472);
                tmp1.zw = _GFogFuncVals.xx * tmp1.zw + -tmp2.zw;
                tmp2.xy = max(tmp2.xy, _GFogTopFuncVals.xx);
                tmp2.zw = tmp2.xy * tmp2.xy;
                tmp2.xy = tmp2.zw * _GFogTopFuncVals.yy + tmp2.xy;
                tmp1.zw = tmp2.xy * _GFogTopFuncVals.zz + tmp1.zw;
                tmp1.z = tmp1.w - tmp1.z;
                tmp1.z = tmp1.z * _GFogStrength;
                tmp1.y = max(abs(tmp1.y), 0.000001);
                tmp1.y = tmp1.z / tmp1.y;
                tmp1.y = sqrt(abs(tmp1.y));
                o.texcoord2.x = min(tmp1.y, 1.0);
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp1.y = tmp0.y + _Density.y;
                tmp1.y = tmp1.y * _Density.x;
                tmp1.y = max(tmp1.y, 0.0);
                tmp1.y = tmp1.y + 1.0;
                tmp1.y = 1.0 / tmp1.y;
                tmp1.x = tmp1.y * tmp1.x;
                tmp1.x = tmp1.x * _Density.z;
                tmp1.x = min(tmp1.x, 10.0);
                tmp1.x = tmp1.x * -1.442695;
                tmp1.x = exp(tmp1.x);
                tmp1.x = 1.0 - tmp1.x;
                tmp0.w = rsqrt(tmp0.w);
                tmp2.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = tmp0.y * tmp0.w + 0.03125;
                tmp0.yz = tmp2.yy > float2(0.03125, -0.03125);
                tmp0.x = tmp0.x * tmp0.x;
                tmp0.x = tmp0.x * 8.0;
                tmp0.x = tmp0.y ? tmp2.y : tmp0.x;
                tmp2.w = tmp0.z ? tmp0.x : 0.0;
                tmp0.x = tmp1.x * TOD_kScale.x;
                tmp3.y = TOD_kRadius.x + TOD_kScale.w;
                tmp0.y = tmp2.w * tmp2.w;
                tmp0.y = tmp0.y * TOD_kRadius.y + TOD_kRadius.w;
                tmp0.y = tmp0.y - TOD_kRadius.y;
                tmp0.y = sqrt(tmp0.y);
                tmp0.y = -TOD_kRadius.x * tmp2.w + tmp0.y;
                tmp0.z = -TOD_kScale.w * TOD_kScale.z;
                tmp0.yz = tmp0.yz * float2(0.25, 1.442695);
                tmp0.z = exp(tmp0.z);
                tmp0.w = tmp2.w * tmp3.y;
                tmp0.w = tmp0.w / tmp3.y;
                tmp0.w = 1.0 - tmp0.w;
                tmp1.y = tmp0.w * 5.25 + -6.8;
                tmp1.y = tmp0.w * tmp1.y + 3.83;
                tmp1.y = tmp0.w * tmp1.y + 0.459;
                tmp0.w = tmp0.w * tmp1.y + -0.00287;
                tmp0.w = tmp0.w * 1.442695;
                tmp0.w = exp(tmp0.w);
                tmp0.xz = tmp0.xw * tmp0.yz;
                tmp1.yzw = tmp0.yyy * tmp2.xwz;
                tmp3.xz = float2(0.0, 0.0);
                tmp1.yzw = tmp1.yzw * float3(0.5, 0.5, 0.5) + tmp3.xyz;
                tmp3.xyz = TOD_k4PI.www + TOD_k4PI.xyz;
                tmp4.xyz = tmp1.yzw;
                tmp5.xyz = float3(0.0, 0.0, 0.0);
                tmp0.w = 0.0;
                for (int j = tmp0.w; j < 4; j += 1) {
                    tmp3.w = dot(tmp4.xyz, tmp4.xyz);
                    tmp3.w = sqrt(tmp3.w);
                    tmp4.w = 1.0 / tmp3.w;
                    tmp3.w = TOD_kRadius.x - tmp3.w;
                    tmp3.w = tmp3.w * TOD_kScale.z;
                    tmp3.w = tmp3.w * 1.442695;
                    tmp3.w = exp(tmp3.w);
                    tmp5.w = tmp0.x * tmp3.w;
                    tmp6.x = dot(tmp2.xyz, tmp4.xyz);
                    tmp6.y = dot(TOD_LocalSunDirection, tmp4.xyz);
                    tmp6.y = -tmp6.y * tmp4.w + 1.0;
                    tmp6.z = tmp6.y * 5.25 + -6.8;
                    tmp6.z = tmp6.y * tmp6.z + 3.83;
                    tmp6.z = tmp6.y * tmp6.z + 0.459;
                    tmp6.y = tmp6.y * tmp6.z + -0.00287;
                    tmp6.y = tmp6.y * 1.442695;
                    tmp6.y = exp(tmp6.y);
                    tmp4.w = -tmp6.x * tmp4.w + 1.0;
                    tmp6.x = tmp4.w * 5.25 + -6.8;
                    tmp6.x = tmp4.w * tmp6.x + 3.83;
                    tmp6.x = tmp4.w * tmp6.x + 0.459;
                    tmp4.w = tmp4.w * tmp6.x + -0.00287;
                    tmp4.w = tmp4.w * 1.442695;
                    tmp4.w = exp(tmp4.w);
                    tmp4.w = tmp4.w * 0.25;
                    tmp4.w = tmp6.y * 0.25 + -tmp4.w;
                    tmp3.w = tmp3.w * tmp4.w;
                    tmp3.w = tmp0.z * 0.25 + tmp3.w;
                    tmp6.xyz = tmp3.xyz * -tmp3.www;
                    tmp6.xyz = tmp6.xyz * float3(1.442695, 1.442695, 1.442695);
                    tmp6.xyz = exp(tmp6.xyz);
                    tmp5.xyz = tmp6.xyz * tmp5.www + tmp5.xyz;
                    tmp4.xyz = tmp2.xwz * tmp0.yyy + tmp4.xyz;
                }
                tmp0.xyz = tmp5.xyz * TOD_SunSkyColor;
                tmp1.yzw = tmp0.xyz * TOD_kSun.xyz;
                tmp0.xyz = tmp0.xyz * TOD_kSun.www;
                tmp0.w = saturate(tmp2.y * -0.8);
                tmp2.w = tmp0.w * -2.0 + 3.0;
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * tmp2.w;
                tmp2.w = dot(TOD_LocalSunDirection, tmp2.xyz);
                tmp3.x = tmp2.w * tmp2.w;
                tmp3.x = tmp3.x * 0.75 + 0.75;
                tmp3.y = tmp2.w * tmp2.w + 1.0;
                tmp3.y = tmp3.y * TOD_kBetaMie.x;
                tmp2.w = TOD_kBetaMie.z * tmp2.w + TOD_kBetaMie.y;
                tmp2.w = log(tmp2.w);
                tmp2.w = tmp2.w * 1.5;
                tmp2.w = exp(tmp2.w);
                tmp2.w = tmp3.y / tmp2.w;
                tmp0.xyz = tmp0.xyz * tmp2.www;
                tmp0.xyz = tmp3.xxx * tmp1.yzw + tmp0.xyz;
                tmp1.yzw = tmp2.yyy * -TOD_MoonSkyColor + TOD_MoonSkyColor;
                tmp0.xyz = tmp0.xyz + tmp1.yzw;
                tmp1.y = dot(tmp2.xyz, TOD_LocalMoonDirection);
                tmp1.y = max(tmp1.y, 0.0);
                tmp1.y = log(tmp1.y);
                tmp1.y = tmp1.y * TOD_MoonHaloPower;
                tmp1.y = exp(tmp1.y);
                tmp0.xyz = TOD_MoonHaloColor * tmp1.yyy + tmp0.xyz;
                tmp1.y = tmp0.y + tmp0.x;
                tmp1.y = tmp0.z + tmp1.y;
                tmp1.yzw = tmp1.yyy * float3(0.333, 0.333, 0.333) + -tmp0.xyz;
                tmp0.xyz = TOD_Fogginess.xxx * tmp1.yzw + tmp0.xyz;
                tmp1.yzw = TOD_GroundColor - tmp0.xyz;
                tmp0.xyz = tmp0.www * tmp1.yzw + tmp0.xyz;
                tmp0.xyz = tmp0.xyz * TOD_ScatteringBrightness.xxx;
                tmp0.xyz = log(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * TOD_Contrast.xxx;
                tmp0.xyz = exp(tmp0.xyz);
                tmp0.xyz = tmp0.xyz + tmp0.xyz;
                tmp0.xyz = tmp0.xyz * -TOD_Brightness.xxx;
                tmp0.xyz = exp(tmp0.xyz);
                tmp0.xyz = float3(1.0, 1.0, 1.0) - tmp0.xyz;
                tmp0.xyz = sqrt(tmp0.xyz);
                tmp0.xyz = tmp0.xyz - float3(0.0000001, 0.0000001, 0.0000001);
                o.texcoord3.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
                o.texcoord3.w = tmp1.x;
                return o;
			}
			// Keywords: GAMMA LDR
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0 = tmp0 * inp.color;
                tmp0.xyz = tmp0.xyz * _EFT_Ambient.xyz + tmp0.xyz;
                o.sv_target.w = tmp0.w;
                tmp1.xyz = inp.texcoord3.xyz - tmp0.xyz;
                o.sv_target.xyz = inp.texcoord3.www * tmp1.xyz + tmp0.xyz;
                return o;
			}
			ENDCG
		}
	}
}