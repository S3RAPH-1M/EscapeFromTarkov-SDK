Shader "Particles/Smoke Distorted Grenade" {
	Properties {
		[Header(Vertex Color (R)smoke lightness   (G)distortion   (A)alpha )] _TintColor ("Tint Color", Vector) = (0.5,0.5,0.5,0.5)
		_IndoorTintColor ("Indoor Tint Color Color", Vector) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_NoiseTex ("Noise Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
		_AnimationSpeed ("Animation Speed", Float) = 1
		_Distortion ("Distortion", Range(0, 1)) = 1
		[HideInInspector] _Indoor ("Indoor", Float) = 0
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent+1010" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Vertex" "QUEUE" = "Transparent+1010" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			Cull Off
			GpuProgramID 12694
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
				float4 texcoord4 : TEXCOORD4;
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
			float4 _MinAmbientColor;
			float4 _TopHorizontSkyColor;
			float _AnimationSpeed;
			float _DirectionLightShadow;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _GFogColor;
			float4 _TintColor;
			float4 _IndoorTintColor;
			float _Indoor;
			float _ForceIndoor;
			float _Distortion;
			float _ThermalVisionOn;
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
                float4 tmp8;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                tmp2 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                tmp3.xz = tmp2.xw * float2(0.5, 0.5);
                tmp0.w = tmp2.y * _ProjectionParams.x;
                tmp3.w = tmp0.w * 0.5;
                o.texcoord4.xy = tmp3.zz + tmp3.xw;
                tmp3 = tmp1.yyyy * unity_MatrixV._m21_m01_m11_m21;
                tmp3 = unity_MatrixV._m20_m00_m10_m20 * tmp1.xxxx + tmp3;
                tmp3 = unity_MatrixV._m22_m02_m12_m22 * tmp1.zzzz + tmp3;
                tmp1 = unity_MatrixV._m23_m03_m13_m23 * tmp1.wwww + tmp3;
                o.texcoord4.z = -tmp1.x;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0.xyz = tmp0.xyz - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp1.x = sqrt(tmp0.w);
                tmp3.x = max(tmp1.x, 0.000001);
                tmp3.x = -tmp0.y / tmp3.x;
                tmp3.y = min(tmp1.x, _GFogMax);
                tmp3.z = _GFogY - _WorldSpaceCameraPos.y;
                tmp4.y = tmp3.y * tmp3.x + tmp3.z;
                tmp3.y = tmp3.x * _GFogStart + tmp3.z;
                tmp3.z = tmp3.x > 0.0;
                tmp3.w = min(tmp4.y, tmp3.y);
                tmp3.y = max(tmp4.y, tmp3.y);
                tmp4.x = tmp3.z ? tmp3.w : tmp3.y;
                tmp3.yz = max(tmp4.xy, float2(0.0, 0.0));
                tmp4.zw = tmp3.yz + _GFogFuncVals.zz;
                tmp4.zw = log(tmp4.zw);
                tmp4.zw = tmp4.zw * _GFogFuncVals.yy;
                tmp4.zw = tmp4.zw * float2(0.6931472, 0.6931472);
                tmp3.yz = _GFogFuncVals.xx * tmp3.yz + -tmp4.zw;
                tmp4.xy = max(tmp4.xy, _GFogTopFuncVals.xx);
                tmp4.zw = tmp4.xy * tmp4.xy;
                tmp4.xy = tmp4.zw * _GFogTopFuncVals.yy + tmp4.xy;
                tmp3.yz = tmp4.xy * _GFogTopFuncVals.zz + tmp3.yz;
                tmp3.y = tmp3.z - tmp3.y;
                tmp3.y = tmp3.y * _GFogStrength;
                tmp3.x = max(abs(tmp3.x), 0.000001);
                tmp3.x = tmp3.y / tmp3.x;
                tmp3.x = sqrt(abs(tmp3.x));
                o.texcoord2.y = min(tmp3.x, 1.0);
                tmp3.x = tmp0.y + _Density.y;
                tmp3.x = tmp3.x * _Density.x;
                tmp3.x = max(tmp3.x, 0.0);
                tmp3.x = tmp3.x + 1.0;
                tmp3.x = 1.0 / tmp3.x;
                tmp1.x = tmp1.x * tmp3.x;
                tmp1.x = tmp1.x * _Density.z;
                tmp1.x = min(tmp1.x, 10.0);
                tmp1.x = tmp1.x * -1.442695;
                tmp1.x = exp(tmp1.x);
                tmp1.x = 1.0 - tmp1.x;
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = tmp0.y * tmp0.w + 0.03125;
                tmp0.yz = tmp3.yy > float2(0.03125, -0.03125);
                tmp0.x = tmp0.x * tmp0.x;
                tmp0.x = tmp0.x * 8.0;
                tmp0.x = tmp0.y ? tmp3.y : tmp0.x;
                tmp3.w = tmp0.z ? tmp0.x : 0.0;
                tmp0.x = tmp1.x * TOD_kScale.x;
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
                tmp4.w = tmp0.w * 5.25 + -6.8;
                tmp4.w = tmp0.w * tmp4.w + 3.83;
                tmp4.w = tmp0.w * tmp4.w + 0.459;
                tmp0.w = tmp0.w * tmp4.w + -0.00287;
                tmp0.w = tmp0.w * 1.442695;
                tmp0.w = exp(tmp0.w);
                tmp0.xz = tmp0.xw * tmp0.yz;
                tmp5.xyz = tmp0.yyy * tmp3.xwz;
                tmp4.xz = float2(0.0, 0.0);
                tmp4.xyz = tmp5.xyz * float3(0.5, 0.5, 0.5) + tmp4.xyz;
                tmp5.xyz = TOD_k4PI.www + TOD_k4PI.xyz;
                tmp6.xyz = tmp4.xyz;
                tmp7.xyz = float3(0.0, 0.0, 0.0);
                tmp0.w = 0.0;
                for (int i = tmp0.w; i < 4; i += 1) {
                    tmp4.w = dot(tmp6.xyz, tmp6.xyz);
                    tmp4.w = sqrt(tmp4.w);
                    tmp5.w = 1.0 / tmp4.w;
                    tmp4.w = TOD_kRadius.x - tmp4.w;
                    tmp4.w = tmp4.w * TOD_kScale.z;
                    tmp4.w = tmp4.w * 1.442695;
                    tmp4.w = exp(tmp4.w);
                    tmp6.w = tmp0.x * tmp4.w;
                    tmp7.w = dot(tmp3.xyz, tmp6.xyz);
                    tmp8.x = dot(TOD_LocalSunDirection, tmp6.xyz);
                    tmp8.x = -tmp8.x * tmp5.w + 1.0;
                    tmp8.y = tmp8.x * 5.25 + -6.8;
                    tmp8.y = tmp8.x * tmp8.y + 3.83;
                    tmp8.y = tmp8.x * tmp8.y + 0.459;
                    tmp8.x = tmp8.x * tmp8.y + -0.00287;
                    tmp8.x = tmp8.x * 1.442695;
                    tmp8.x = exp(tmp8.x);
                    tmp5.w = -tmp7.w * tmp5.w + 1.0;
                    tmp7.w = tmp5.w * 5.25 + -6.8;
                    tmp7.w = tmp5.w * tmp7.w + 3.83;
                    tmp7.w = tmp5.w * tmp7.w + 0.459;
                    tmp5.w = tmp5.w * tmp7.w + -0.00287;
                    tmp5.w = tmp5.w * 1.442695;
                    tmp5.w = exp(tmp5.w);
                    tmp5.w = tmp5.w * 0.25;
                    tmp5.w = tmp8.x * 0.25 + -tmp5.w;
                    tmp4.w = tmp4.w * tmp5.w;
                    tmp4.w = tmp0.z * 0.25 + tmp4.w;
                    tmp8.xyz = tmp5.xyz * -tmp4.www;
                    tmp8.xyz = tmp8.xyz * float3(1.442695, 1.442695, 1.442695);
                    tmp8.xyz = exp(tmp8.xyz);
                    tmp7.xyz = tmp8.xyz * tmp6.www + tmp7.xyz;
                    tmp6.xyz = tmp3.xwz * tmp0.yyy + tmp6.xyz;
                }
                tmp0.xyz = tmp7.xyz * TOD_SunSkyColor;
                tmp4.xyz = tmp0.xyz * TOD_kSun.xyz;
                tmp0.xyz = tmp0.xyz * TOD_kSun.www;
                tmp0.w = saturate(tmp3.y * -0.8);
                tmp3.w = tmp0.w * -2.0 + 3.0;
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * tmp3.w;
                tmp3.w = dot(TOD_LocalSunDirection, tmp3.xyz);
                tmp4.w = tmp3.w * tmp3.w;
                tmp4.w = tmp4.w * 0.75 + 0.75;
                tmp5.x = tmp3.w * tmp3.w + 1.0;
                tmp5.x = tmp5.x * TOD_kBetaMie.x;
                tmp3.w = TOD_kBetaMie.z * tmp3.w + TOD_kBetaMie.y;
                tmp3.w = log(tmp3.w);
                tmp3.w = tmp3.w * 1.5;
                tmp3.w = exp(tmp3.w);
                tmp3.w = tmp5.x / tmp3.w;
                tmp0.xyz = tmp0.xyz * tmp3.www;
                tmp0.xyz = tmp4.www * tmp4.xyz + tmp0.xyz;
                tmp4.xyz = tmp3.yyy * -TOD_MoonSkyColor + TOD_MoonSkyColor;
                tmp0.xyz = tmp0.xyz + tmp4.xyz;
                tmp3.x = dot(tmp3.xyz, TOD_LocalMoonDirection);
                tmp3.x = max(tmp3.x, 0.0);
                tmp3.x = log(tmp3.x);
                tmp3.x = tmp3.x * TOD_MoonHaloPower;
                tmp3.x = exp(tmp3.x);
                tmp0.xyz = TOD_MoonHaloColor * tmp3.xxx + tmp0.xyz;
                tmp3.x = tmp0.y + tmp0.x;
                tmp3.x = tmp0.z + tmp3.x;
                tmp3.xyz = tmp3.xxx * float3(0.333, 0.333, 0.333) + -tmp0.xyz;
                tmp0.xyz = TOD_Fogginess.xxx * tmp3.xyz + tmp0.xyz;
                tmp3.xyz = TOD_GroundColor - tmp0.xyz;
                tmp0.xyz = tmp0.www * tmp3.xyz + tmp0.xyz;
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
                tmp0.xyz = glstate_lightmodel_ambient.xyz + glstate_lightmodel_ambient.xyz;
                tmp0.xyz = max(tmp0.xyz, _MinAmbientColor.xyz);
                tmp3.xyz = saturate(_TopHorizontSkyColor.xyz);
                tmp0.xyz = max(tmp0.xyz, tmp3.xyz);
                tmp3.xyz = tmp0.xyz;
                tmp0.w = 0.0;
                for (int j = tmp0.w; j < 8; j += 1) {
                    tmp4.xyz = -tmp1.yzw * unity_LightPosition[j].www + unity_LightPosition[j].xyz;
                    tmp3.w = dot(tmp4.xyz, tmp4.xyz);
                    tmp4.w = rsqrt(tmp3.w);
                    tmp4.xyz = tmp4.www * tmp4.xyz;
                    tmp3.w = tmp3.w * unity_LightAtten[j].z + 1.0;
                    tmp3.w = 1.0 / tmp3.w;
                    tmp4.x = dot(tmp4.xyz, unity_SpotDirection[j].xyz);
                    tmp4.x = max(tmp4.x, 0.0);
                    tmp4.x = tmp4.x - unity_LightAtten[j].x;
                    tmp4.x = saturate(tmp4.x * unity_LightAtten[j].y);
                    tmp3.w = tmp3.w * tmp4.x;
                    tmp4.x = unity_LightPosition[j].w == 0.0;
                    tmp4.x = tmp4.x ? 1.0 : 0.0;
                    tmp4.x = -_DirectionLightShadow * tmp4.x + 1.0;
                    tmp3.w = tmp3.w * tmp4.x;
                    tmp3.w = tmp3.w * unity_LightPosition[j].w;
                    tmp3.xyz = unity_LightColor[j].xyz * tmp3.www + tmp3.xyz;
                }
                o.color.xyz = tmp3.xyz * v.color.xxx;
                o.position = tmp2;
                o.color.w = v.color.w;
                o.texcoord.xyz = v.texcoord.xyx;
                o.texcoord4.w = tmp2.w;
                o.texcoord5.w = tmp1.x;
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
                tmp1.x = max(_ForceIndoor, _Indoor);
                tmp2 = _IndoorTintColor - _TintColor;
                tmp1 = tmp1.xxxx * tmp2 + _TintColor;
                tmp1 = tmp1 * inp.color;
                tmp2.xyz = -tmp1.xyz * tmp0.xyz + _GFogColor.xyz;
                tmp0 = tmp0 * tmp1;
                tmp0.xyz = inp.texcoord2.yyy * tmp2.xyz + tmp0.xyz;
                o.sv_target.w = tmp0.w;
                tmp1.xyz = inp.texcoord5.xyz - tmp0.xyz;
                tmp0.w = inp.texcoord5.w * 0.125;
                tmp0.xyz = tmp0.www * tmp1.xyz + tmp0.xyz;
                tmp0.w = _ThermalVisionOn > 0.0;
                o.sv_target.xyz = tmp0.www ? float3(0.0, 0.0, 0.0) : tmp0.xyz;
                return o;
			}
			ENDCG
		}
	}
}