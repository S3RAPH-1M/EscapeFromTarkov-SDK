Shader "Particles/Smoke Distorted" {
	Properties {
		[Header(Vertex Color (R)smoke lightness   (G)distortion   (A)alpha )] _TintColor ("Tint Color", Vector) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_NoiseTex ("Noise Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
		_AnimationSpeed ("Animation Speed", Float) = 1
		_Distortion ("Distortion", Range(0, 1)) = 1
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			Cull Off
			GpuProgramID 64458
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 color : COLOR0;
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float2 texcoord2 : TEXCOORD2;
				float4 texcoord5 : TEXCOORD5;
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
			float TOD_ScatteringBrightness;
			float TOD_Fogginess;
			float TOD_MoonHaloPower;
			float3 TOD_kBetaMie;
			float4 TOD_kSun;
			float4 TOD_k4PI;
			float4 TOD_kRadius;
			float4 TOD_kScale;
			float4 _Density;
			float _AnimationSpeed;
			float _DirectionLightShadow;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _GFogColor;
			float4 _TintColor;
			float _Distortion;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _NoiseTex;
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
                float4 tmp5;
                float4 tmp6;
                float4 tmp7;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0.xyz = tmp0.xyz - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp2.x = sqrt(tmp0.w);
                tmp2.y = max(tmp2.x, 0.000001);
                tmp2.y = -tmp0.y / tmp2.y;
                tmp2.z = min(tmp2.x, _GFogMax);
                tmp2.w = _GFogY - _WorldSpaceCameraPos.y;
                tmp3.y = tmp2.z * tmp2.y + tmp2.w;
                tmp2.z = tmp2.y * _GFogStart + tmp2.w;
                tmp2.w = tmp2.y > 0.0;
                tmp3.z = min(tmp3.y, tmp2.z);
                tmp2.z = max(tmp3.y, tmp2.z);
                tmp3.x = tmp2.w ? tmp3.z : tmp2.z;
                tmp2.zw = max(tmp3.xy, float2(0.0, 0.0));
                tmp3.zw = tmp2.zw + _GFogFuncVals.zz;
                tmp3.zw = log(tmp3.zw);
                tmp3.zw = tmp3.zw * _GFogFuncVals.yy;
                tmp3.zw = tmp3.zw * float2(0.6931472, 0.6931472);
                tmp2.zw = _GFogFuncVals.xx * tmp2.zw + -tmp3.zw;
                tmp3.xy = max(tmp3.xy, _GFogTopFuncVals.xx);
                tmp3.zw = tmp3.xy * tmp3.xy;
                tmp3.xy = tmp3.zw * _GFogTopFuncVals.yy + tmp3.xy;
                tmp2.zw = tmp3.xy * _GFogTopFuncVals.zz + tmp2.zw;
                tmp2.z = tmp2.w - tmp2.z;
                tmp2.z = tmp2.z * _GFogStrength;
                tmp2.y = max(abs(tmp2.y), 0.000001);
                tmp2.y = tmp2.z / tmp2.y;
                tmp2.y = sqrt(abs(tmp2.y));
                o.texcoord2.y = min(tmp2.y, 1.0);
                tmp2.y = tmp0.y + _Density.y;
                tmp2.y = tmp2.y * _Density.x;
                tmp2.y = max(tmp2.y, 0.0);
                tmp2.y = tmp2.y + 1.0;
                tmp2.y = 1.0 / tmp2.y;
                tmp2.x = tmp2.y * tmp2.x;
                tmp2.x = tmp2.x * _Density.z;
                tmp2.x = min(tmp2.x, 10.0);
                tmp2.x = tmp2.x * -1.442695;
                tmp2.x = exp(tmp2.x);
                tmp2.x = 1.0 - tmp2.x;
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = tmp0.y * tmp0.w + 0.03125;
                tmp0.yz = tmp3.yy > float2(0.03125, -0.03125);
                tmp0.x = tmp0.x * tmp0.x;
                tmp0.x = tmp0.x * 8.0;
                tmp0.x = tmp0.y ? tmp3.y : tmp0.x;
                tmp3.w = tmp0.z ? tmp0.x : 0.0;
                tmp0.x = tmp2.x * TOD_kScale.x;
                tmp4.y = TOD_kRadius.x + TOD_kScale.w;
                tmp0.y = tmp3.w * tmp3.w;
                tmp0.y = tmp0.y * TOD_kRadius.y + TOD_kRadius.w;
                tmp0.y = tmp0.y - TOD_kRadius.y;
                tmp0.y = sqrt(tmp0.y);
                tmp0.y = -TOD_kRadius.x * tmp3.w + tmp0.y;
                tmp0.z = -TOD_kScale.w * TOD_kScale.z;
                tmp0.yz = tmp0.yz * float2(0.25, 1.442695);
                tmp0.z = exp(tmp0.z);
                tmp0.w = tmp3.w * tmp4.y;
                tmp0.w = tmp0.w / tmp4.y;
                tmp0.w = 1.0 - tmp0.w;
                tmp2.y = tmp0.w * 5.25 + -6.8;
                tmp2.y = tmp0.w * tmp2.y + 3.83;
                tmp2.y = tmp0.w * tmp2.y + 0.459;
                tmp0.w = tmp0.w * tmp2.y + -0.00287;
                tmp0.w = tmp0.w * 1.442695;
                tmp0.w = exp(tmp0.w);
                tmp0.xz = tmp0.xw * tmp0.yz;
                tmp2.yzw = tmp0.yyy * tmp3.xwz;
                tmp4.xz = float2(0.0, 0.0);
                tmp2.yzw = tmp2.yzw * float3(0.5, 0.5, 0.5) + tmp4.xyz;
                tmp4.xyz = TOD_k4PI.www + TOD_k4PI.xyz;
                tmp5.xyz = tmp2.yzw;
                tmp6.xyz = float3(0.0, 0.0, 0.0);
                tmp0.w = 0.0;
                for (int i = tmp0.w; i < 4; i += 1) {
                    tmp4.w = dot(tmp5.xyz, tmp5.xyz);
                    tmp4.w = sqrt(tmp4.w);
                    tmp5.w = 1.0 / tmp4.w;
                    tmp4.w = TOD_kRadius.x - tmp4.w;
                    tmp4.w = tmp4.w * TOD_kScale.z;
                    tmp4.w = tmp4.w * 1.442695;
                    tmp4.w = exp(tmp4.w);
                    tmp6.w = tmp0.x * tmp4.w;
                    tmp7.x = dot(tmp3.xyz, tmp5.xyz);
                    tmp7.y = dot(TOD_LocalSunDirection, tmp5.xyz);
                    tmp7.y = -tmp7.y * tmp5.w + 1.0;
                    tmp7.z = tmp7.y * 5.25 + -6.8;
                    tmp7.z = tmp7.y * tmp7.z + 3.83;
                    tmp7.z = tmp7.y * tmp7.z + 0.459;
                    tmp7.y = tmp7.y * tmp7.z + -0.00287;
                    tmp7.y = tmp7.y * 1.442695;
                    tmp7.y = exp(tmp7.y);
                    tmp5.w = -tmp7.x * tmp5.w + 1.0;
                    tmp7.x = tmp5.w * 5.25 + -6.8;
                    tmp7.x = tmp5.w * tmp7.x + 3.83;
                    tmp7.x = tmp5.w * tmp7.x + 0.459;
                    tmp5.w = tmp5.w * tmp7.x + -0.00287;
                    tmp5.w = tmp5.w * 1.442695;
                    tmp5.w = exp(tmp5.w);
                    tmp5.w = tmp5.w * 0.25;
                    tmp5.w = tmp7.y * 0.25 + -tmp5.w;
                    tmp4.w = tmp4.w * tmp5.w;
                    tmp4.w = tmp0.z * 0.25 + tmp4.w;
                    tmp7.xyz = tmp4.xyz * -tmp4.www;
                    tmp7.xyz = tmp7.xyz * float3(1.442695, 1.442695, 1.442695);
                    tmp7.xyz = exp(tmp7.xyz);
                    tmp6.xyz = tmp7.xyz * tmp6.www + tmp6.xyz;
                    tmp5.xyz = tmp3.xwz * tmp0.yyy + tmp5.xyz;
                }
                tmp0.xyz = tmp6.xyz * TOD_SunSkyColor;
                tmp2.yzw = tmp0.xyz * TOD_kSun.xyz;
                tmp0.xyz = tmp0.xyz * TOD_kSun.www;
                tmp0.w = saturate(tmp3.y * -0.8);
                tmp3.w = tmp0.w * -2.0 + 3.0;
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * tmp3.w;
                tmp3.w = dot(TOD_LocalSunDirection, tmp3.xyz);
                tmp4.x = tmp3.w * tmp3.w;
                tmp4.x = tmp4.x * 0.75 + 0.75;
                tmp4.y = tmp3.w * tmp3.w + 1.0;
                tmp4.y = tmp4.y * TOD_kBetaMie.x;
                tmp3.w = TOD_kBetaMie.z * tmp3.w + TOD_kBetaMie.y;
                tmp3.w = log(tmp3.w);
                tmp3.w = tmp3.w * 1.5;
                tmp3.w = exp(tmp3.w);
                tmp3.w = tmp4.y / tmp3.w;
                tmp0.xyz = tmp0.xyz * tmp3.www;
                tmp0.xyz = tmp4.xxx * tmp2.yzw + tmp0.xyz;
                tmp2.yzw = tmp3.yyy * -TOD_MoonSkyColor + TOD_MoonSkyColor;
                tmp0.xyz = tmp0.xyz + tmp2.yzw;
                tmp2.y = dot(tmp3.xyz, TOD_LocalMoonDirection);
                tmp2.y = max(tmp2.y, 0.0);
                tmp2.y = log(tmp2.y);
                tmp2.y = tmp2.y * TOD_MoonHaloPower;
                tmp2.y = exp(tmp2.y);
                tmp0.xyz = TOD_MoonHaloColor * tmp2.yyy + tmp0.xyz;
                tmp2.y = tmp0.y + tmp0.x;
                tmp2.y = tmp0.z + tmp2.y;
                tmp2.yzw = tmp2.yyy * float3(0.333, 0.333, 0.333) + -tmp0.xyz;
                tmp0.xyz = TOD_Fogginess.xxx * tmp2.yzw + tmp0.xyz;
                tmp2.yzw = TOD_GroundColor - tmp0.xyz;
                tmp0.xyz = tmp0.www * tmp2.yzw + tmp0.xyz;
                tmp0.xyz = tmp0.xyz * TOD_ScatteringBrightness.xxx;
                tmp0.xyz = log(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * TOD_Contrast.xxx;
                tmp0.xyz = exp(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * float3(2.0, 2.0, 2.0) + float3(-0.0000001, -0.0000001, -0.0000001);
                o.texcoord5.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
                tmp0.xyz = _Time.xxx * float3(0.96, 1.0, 1.03);
                tmp0.xyz = tmp0.xyz * _AnimationSpeed.xxx;
                o.texcoord.w = tmp0.x * 1.0 + v.texcoord.y;
                o.texcoord1.xy = tmp0.yy * float2(0.866, -0.5) + v.texcoord.xy;
                o.texcoord1.zw = tmp0.zz * float2(-0.866, -0.5) + v.texcoord.xy;
                tmp0.xyz = tmp1.yyy * unity_MatrixV._m01_m11_m21;
                tmp0.xyz = unity_MatrixV._m00_m10_m20 * tmp1.xxx + tmp0.xyz;
                tmp0.xyz = unity_MatrixV._m02_m12_m22 * tmp1.zzz + tmp0.xyz;
                tmp0.xyz = unity_MatrixV._m03_m13_m23 * tmp1.www + tmp0.xyz;
                tmp1.xyz = glstate_lightmodel_ambient.xyz + glstate_lightmodel_ambient.xyz;
                tmp2.yzw = tmp1.xyz;
                tmp0.w = 0.0;
                for (int j = tmp0.w; j < 8; j += 1) {
                    tmp3.xyz = -tmp0.xyz * unity_LightPosition[j].www + unity_LightPosition[j].xyz;
                    tmp1.w = dot(tmp3.xyz, tmp3.xyz);
                    tmp3.w = rsqrt(tmp1.w);
                    tmp3.xyz = tmp3.www * tmp3.xyz;
                    tmp1.w = tmp1.w * unity_LightAtten[j].z + 1.0;
                    tmp1.w = 1.0 / tmp1.w;
                    tmp3.x = dot(tmp3.xyz, unity_SpotDirection[j].xyz);
                    tmp3.x = max(tmp3.x, 0.0);
                    tmp3.x = tmp3.x - unity_LightAtten[j].x;
                    tmp3.x = saturate(tmp3.x * unity_LightAtten[j].y);
                    tmp1.w = tmp1.w * tmp3.x;
                    tmp3.x = unity_LightPosition[j].w == 0.0;
                    tmp3.x = tmp3.x ? 1.0 : 0.0;
                    tmp3.x = -_DirectionLightShadow * tmp3.x + 1.0;
                    tmp1.w = tmp1.w * tmp3.x;
                    tmp2.yzw = unity_LightColor[j].xyz * tmp1.www + tmp2.yzw;
                }
                o.color.xyz = tmp2.yzw * v.color.xxx;
                o.color.w = v.color.w;
                o.texcoord.xyz = v.texcoord.xyx;
                o.texcoord5.w = tmp2.x;
                o.texcoord2.x = v.color.y;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0 = tex2D(_NoiseTex, inp.texcoord.zw);
                tmp1 = tex2D(_NoiseTex, inp.texcoord1.xy);
                tmp0.xy = tmp0.xy + tmp1.yz;
                tmp1 = tex2D(_NoiseTex, inp.texcoord1.zw);
                tmp0.xy = tmp0.xy + tmp1.zw;
                tmp0.xy = tmp0.xy - float2(1.5, 1.5);
                tmp0.z = inp.texcoord2.x * _Distortion;
                tmp0.xy = tmp0.xy * tmp0.zz + inp.texcoord.xy;
                tmp0 = tex2D(_MainTex, tmp0.xy);
                tmp1 = inp.color * _TintColor;
                tmp2.xyz = -tmp1.xyz * tmp0.xyz + _GFogColor.xyz;
                tmp0 = tmp0 * tmp1;
                tmp0.xyz = inp.texcoord2.yyy * tmp2.xyz + tmp0.xyz;
                o.sv_target.w = tmp0.w;
                tmp1.xyz = inp.texcoord5.xyz - tmp0.xyz;
                tmp0.w = inp.texcoord5.w * 0.125;
                o.sv_target.xyz = tmp0.www * tmp1.xyz + tmp0.xyz;
                return o;
			}
			ENDCG
		}
	}
}