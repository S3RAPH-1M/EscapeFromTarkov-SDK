Shader "Transparent/DepthZwrite" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_SpecColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		_ReflectColor ("Reflection Color", Vector) = (1,1,1,0.5)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_SpecTex ("Specular (R), Gloss (A)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_Cube ("Reflection Cubemap", Cube) = "" {}
		_SpecPower ("Specular Power", Range(0.01, 10)) = 1
		_Glossness ("Glossness", Range(0.01, 10)) = 1
		_SpecVals ("Specular Vals", Vector) = (1.1,2,0,0)
		_DefVals ("Defuse Vals", Vector) = (0.5,0.7,0,0)
		_GlobalReflectionStrength ("_GlobalReflectionStrength", Float) = 1
		_Temperature2 ("_Temperature2(min, max, factor)", Vector) = (0.1,0.5,0.4,0)
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			ColorMask A -1
			Fog {
				Mode Off
			}
			GpuProgramID 142911
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 color : COLOR0;
				float4 position : SV_POSITION0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			// $Globals ConstantBuffers for Fragment Shader
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                o.color = saturate(v.color);
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                o.sv_target = inp.color;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 13932
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float texcoord6 : TEXCOORD6;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float3 texcoord5 : TEXCOORD5;
				float4 texcoord7 : TEXCOORD7;
				float3 texcoord8 : TEXCOORD8;
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
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float4 _GFogColor;
			float _ReflectionBottomShade;
			float4 _Color;
			float4 _ReflectColor;
			float _SpecPower;
			float _Glossness;
			float3 _SpecVals;
			float3 _DefVals;
			float4 _EFT_Ambient;
			float _GlobalReflectionStrength;
			float4 _Temperature2;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _SpecTex;
			sampler2D _BumpMap;
			samplerCUBE _Cube;
			samplerCUBE _MyGlobalReflectionProbe;
			
			// Keywords: DIRECTIONAL
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
                tmp0.xyz = v.vertex.yyy * unity_ObjectToWorld._m01_m11_m21;
                tmp0.xyz = unity_ObjectToWorld._m00_m10_m20 * v.vertex.xxx + tmp0.xyz;
                tmp0.xyz = unity_ObjectToWorld._m02_m12_m22 * v.vertex.zzz + tmp0.xyz;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp1.xyz = tmp0.xyz - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = sqrt(tmp0.w);
                tmp2.x = max(tmp1.w, 0.000001);
                tmp2.x = -tmp1.y / tmp2.x;
                tmp2.y = min(tmp1.w, _GFogMax);
                tmp2.z = _GFogY - _WorldSpaceCameraPos.y;
                tmp3.y = tmp2.y * tmp2.x + tmp2.z;
                tmp2.y = tmp2.x * _GFogStart + tmp2.z;
                tmp2.z = tmp2.x > 0.0;
                tmp2.w = min(tmp3.y, tmp2.y);
                tmp2.y = max(tmp3.y, tmp2.y);
                tmp3.x = tmp2.z ? tmp2.w : tmp2.y;
                tmp2.yz = max(tmp3.xy, float2(0.0, 0.0));
                tmp3.zw = tmp2.yz + _GFogFuncVals.zz;
                tmp3.zw = log(tmp3.zw);
                tmp3.zw = tmp3.zw * _GFogFuncVals.yy;
                tmp3.zw = tmp3.zw * float2(0.6931472, 0.6931472);
                tmp2.yz = _GFogFuncVals.xx * tmp2.yz + -tmp3.zw;
                tmp3.xy = max(tmp3.xy, _GFogTopFuncVals.xx);
                tmp3.zw = tmp3.xy * tmp3.xy;
                tmp3.xy = tmp3.zw * _GFogTopFuncVals.yy + tmp3.xy;
                tmp2.yz = tmp3.xy * _GFogTopFuncVals.zz + tmp2.yz;
                tmp2.y = tmp2.z - tmp2.y;
                tmp2.y = tmp2.y * _GFogStrength;
                tmp2.x = max(abs(tmp2.x), 0.000001);
                tmp2.x = tmp2.y / tmp2.x;
                tmp2.x = sqrt(abs(tmp2.x));
                o.texcoord6.x = min(tmp2.x, 1.0);
                tmp2.x = tmp1.y + _Density.y;
                tmp2.x = tmp2.x * _Density.x;
                tmp2.x = max(tmp2.x, 0.0);
                tmp2.x = tmp2.x + 1.0;
                tmp2.x = 1.0 / tmp2.x;
                tmp1.w = tmp1.w * tmp2.x;
                tmp1.w = tmp1.w * _Density.z;
                tmp1.w = min(tmp1.w, 10.0);
                tmp1.w = tmp1.w * -1.442695;
                tmp1.w = exp(tmp1.w);
                tmp1.w = 1.0 - tmp1.w;
                tmp0.w = rsqrt(tmp0.w);
                tmp2.xyz = tmp0.www * tmp1.xyz;
                tmp0.w = tmp1.y * tmp0.w + 0.03125;
                tmp1.xy = tmp2.yy > float2(0.03125, -0.03125);
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * 8.0;
                tmp0.w = tmp1.x ? tmp2.y : tmp0.w;
                tmp2.w = tmp1.y ? tmp0.w : 0.0;
                tmp0.w = tmp1.w * TOD_kScale.x;
                tmp1.y = TOD_kRadius.x + TOD_kScale.w;
                tmp3.x = tmp2.w * tmp2.w;
                tmp3.x = tmp3.x * TOD_kRadius.y + TOD_kRadius.w;
                tmp3.x = tmp3.x - TOD_kRadius.y;
                tmp3.x = sqrt(tmp3.x);
                tmp3.x = -TOD_kRadius.x * tmp2.w + tmp3.x;
                tmp3.y = -TOD_kScale.w * TOD_kScale.z;
                tmp3.xy = tmp3.xy * float2(0.25, 1.442695);
                tmp3.y = exp(tmp3.y);
                tmp3.z = tmp1.y * tmp2.w;
                tmp3.z = tmp3.z / tmp1.y;
                tmp3.z = 1.0 - tmp3.z;
                tmp3.w = tmp3.z * 5.25 + -6.8;
                tmp3.w = tmp3.z * tmp3.w + 3.83;
                tmp3.w = tmp3.z * tmp3.w + 0.459;
                tmp3.z = tmp3.z * tmp3.w + -0.00287;
                tmp3.z = tmp3.z * 1.442695;
                tmp3.z = exp(tmp3.z);
                tmp3.y = tmp3.z * tmp3.y;
                tmp0.w = tmp0.w * tmp3.x;
                tmp4.xyz = tmp2.xwz * tmp3.xxx;
                tmp1.xz = float2(0.0, 0.0);
                tmp1.xyz = tmp4.xyz * float3(0.5, 0.5, 0.5) + tmp1.xyz;
                tmp4.xyz = TOD_k4PI.www + TOD_k4PI.xyz;
                tmp5.xyz = tmp1.xyz;
                tmp6.xyz = float3(0.0, 0.0, 0.0);
                tmp3.z = 0.0;
                for (int i = tmp3.z; i < 4; i += 1) {
                    tmp3.w = dot(tmp5.xyz, tmp5.xyz);
                    tmp3.w = sqrt(tmp3.w);
                    tmp4.w = 1.0 / tmp3.w;
                    tmp3.w = TOD_kRadius.x - tmp3.w;
                    tmp3.w = tmp3.w * TOD_kScale.z;
                    tmp3.w = tmp3.w * 1.442695;
                    tmp3.w = exp(tmp3.w);
                    tmp5.w = tmp0.w * tmp3.w;
                    tmp6.w = dot(tmp2.xyz, tmp5.xyz);
                    tmp7.x = dot(TOD_LocalSunDirection, tmp5.xyz);
                    tmp7.x = -tmp7.x * tmp4.w + 1.0;
                    tmp7.y = tmp7.x * 5.25 + -6.8;
                    tmp7.y = tmp7.x * tmp7.y + 3.83;
                    tmp7.y = tmp7.x * tmp7.y + 0.459;
                    tmp7.x = tmp7.x * tmp7.y + -0.00287;
                    tmp7.x = tmp7.x * 1.442695;
                    tmp7.x = exp(tmp7.x);
                    tmp4.w = -tmp6.w * tmp4.w + 1.0;
                    tmp6.w = tmp4.w * 5.25 + -6.8;
                    tmp6.w = tmp4.w * tmp6.w + 3.83;
                    tmp6.w = tmp4.w * tmp6.w + 0.459;
                    tmp4.w = tmp4.w * tmp6.w + -0.00287;
                    tmp4.w = tmp4.w * 1.442695;
                    tmp4.w = exp(tmp4.w);
                    tmp4.w = tmp4.w * 0.25;
                    tmp4.w = tmp7.x * 0.25 + -tmp4.w;
                    tmp3.w = tmp3.w * tmp4.w;
                    tmp3.w = tmp3.y * 0.25 + tmp3.w;
                    tmp7.xyz = tmp4.xyz * -tmp3.www;
                    tmp7.xyz = tmp7.xyz * float3(1.442695, 1.442695, 1.442695);
                    tmp7.xyz = exp(tmp7.xyz);
                    tmp6.xyz = tmp7.xyz * tmp5.www + tmp6.xyz;
                    tmp5.xyz = tmp2.xwz * tmp3.xxx + tmp5.xyz;
                }
                tmp1.xyz = tmp6.xyz * TOD_SunSkyColor;
                tmp3.xyz = tmp1.xyz * TOD_kSun.xyz;
                tmp1.xyz = tmp1.xyz * TOD_kSun.www;
                tmp0.w = saturate(tmp2.y * -0.8);
                tmp2.w = tmp0.w * -2.0 + 3.0;
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * tmp2.w;
                tmp2.w = dot(TOD_LocalSunDirection, tmp2.xyz);
                tmp3.w = tmp2.w * tmp2.w;
                tmp3.w = tmp3.w * 0.75 + 0.75;
                tmp4.x = tmp2.w * tmp2.w + 1.0;
                tmp4.x = tmp4.x * TOD_kBetaMie.x;
                tmp2.w = TOD_kBetaMie.z * tmp2.w + TOD_kBetaMie.y;
                tmp2.w = log(tmp2.w);
                tmp2.w = tmp2.w * 1.5;
                tmp2.w = exp(tmp2.w);
                tmp2.w = tmp4.x / tmp2.w;
                tmp1.xyz = tmp1.xyz * tmp2.www;
                tmp1.xyz = tmp3.www * tmp3.xyz + tmp1.xyz;
                tmp3.xyz = tmp2.yyy * -TOD_MoonSkyColor + TOD_MoonSkyColor;
                tmp1.xyz = tmp1.xyz + tmp3.xyz;
                tmp2.x = dot(tmp2.xyz, TOD_LocalMoonDirection);
                tmp2.x = max(tmp2.x, 0.0);
                tmp2.x = log(tmp2.x);
                tmp2.x = tmp2.x * TOD_MoonHaloPower;
                tmp2.x = exp(tmp2.x);
                tmp1.xyz = TOD_MoonHaloColor * tmp2.xxx + tmp1.xyz;
                tmp2.x = tmp1.y + tmp1.x;
                tmp2.x = tmp1.z + tmp2.x;
                tmp2.xyz = tmp2.xxx * float3(0.333, 0.333, 0.333) + -tmp1.xyz;
                tmp1.xyz = TOD_Fogginess.xxx * tmp2.xyz + tmp1.xyz;
                tmp2.xyz = TOD_GroundColor - tmp1.xyz;
                tmp1.xyz = tmp0.www * tmp2.xyz + tmp1.xyz;
                tmp1.xyz = tmp1.xyz * TOD_ScatteringBrightness.xxx;
                tmp1.xyz = log(tmp1.xyz);
                tmp1.xyz = tmp1.xyz * TOD_Contrast.xxx;
                tmp1.xyz = exp(tmp1.xyz);
                tmp1.xyz = tmp1.xyz * float3(2.0, 2.0, 2.0) + float3(-0.0000001, -0.0000001, -0.0000001);
                o.texcoord7.xyz = max(tmp1.xyz, float3(0.0, 0.0, 0.0));
                tmp2 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp2 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp2;
                tmp2 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp2;
                tmp2 = tmp2 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp3 = tmp2.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp3 = unity_MatrixVP._m00_m10_m20_m30 * tmp2.xxxx + tmp3;
                tmp3 = unity_MatrixVP._m02_m12_m22_m32 * tmp2.zzzz + tmp3;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp2.wwww + tmp3;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp2 = tmp0.wwww * tmp1.xyzz;
                tmp1.xyz = v.tangent.yyy * unity_ObjectToWorld._m11_m21_m01;
                tmp1.xyz = unity_ObjectToWorld._m10_m20_m00 * v.tangent.xxx + tmp1.xyz;
                tmp1.xyz = unity_ObjectToWorld._m12_m22_m02 * v.tangent.zzz + tmp1.xyz;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp1.xyz;
                tmp0.w = v.tangent.w * unity_WorldTransformParams.w;
                tmp3.xyz = tmp1.xyz * tmp2.wxy;
                tmp3.xyz = tmp2.ywx * tmp1.yzx + -tmp3.xyz;
                tmp3.xyz = tmp0.www * tmp3.xyz;
                tmp4 = tmp2.ywzx * tmp2;
                tmp5.x = dot(unity_SHBr, tmp4);
                tmp5.y = dot(unity_SHBg, tmp4);
                tmp5.z = dot(unity_SHBb, tmp4);
                tmp0.w = tmp2.y * tmp2.y;
                tmp0.w = tmp2.x * tmp2.x + -tmp0.w;
                o.texcoord8.xyz = unity_SHC.xyz * tmp0.www + tmp5.xyz;
                o.texcoord2.x = tmp1.z;
                o.texcoord2.y = tmp3.x;
                o.texcoord2.z = tmp2.x;
                o.texcoord2.w = tmp0.x;
                o.texcoord3.x = tmp1.x;
                o.texcoord3.y = tmp3.y;
                o.texcoord3.z = tmp2.y;
                o.texcoord3.w = tmp0.y;
                o.texcoord4.x = tmp1.y;
                o.texcoord4.y = tmp3.z;
                o.texcoord4.z = tmp2.w;
                o.texcoord4.w = tmp0.z;
                o.texcoord7.w = tmp1.w;
                o.texcoord5.xyz = float3(0.0, 0.0, 0.0);
                return o;
			}
			// Keywords: DIRECTIONAL
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
                float4 tmp8;
                float4 tmp9;
                float4 tmp10;
                float4 tmp11;
                tmp0.y = inp.texcoord2.w;
                tmp0.z = inp.texcoord3.w;
                tmp0.w = inp.texcoord4.w;
                tmp1.xyz = _WorldSpaceCameraPos - tmp0.yzw;
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2.xyz = tmp0.xxx * tmp1.xyz;
                tmp3.xyz = tmp2.yyy * inp.texcoord3.xyz;
                tmp3.xyz = inp.texcoord2.xyz * tmp2.xxx + tmp3.xyz;
                tmp3.xyz = inp.texcoord4.xyz * tmp2.zzz + tmp3.xyz;
                tmp2.xyz = -tmp2.xyz;
                tmp4 = tex2D(_MainTex, inp.texcoord.xy);
                tmp4 = tmp4 * _Color;
                tmp5 = tex2D(_SpecTex, inp.texcoord.zw);
                tmp6 = tex2D(_BumpMap, inp.texcoord1.xy);
                tmp6.x = tmp6.w * tmp6.x;
                tmp6.xy = tmp6.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.w = dot(tmp6.xy, tmp6.xy);
                tmp1.w = min(tmp1.w, 1.0);
                tmp1.w = 1.0 - tmp1.w;
                tmp6.z = sqrt(tmp1.w);
                tmp5.yz = tmp5.xw * float2(_SpecPower.x, _Glossness.x);
                tmp7.xyz = tmp5.yyy * _ReflectColor.xyz;
                tmp1.w = dot(tmp6.xyz, tmp6.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp8.xyz = tmp1.www * tmp6.xyz;
                tmp9.xyz = tmp0.yzw - _WorldSpaceCameraPos;
                tmp1.w = dot(tmp9.xyz, tmp9.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp9.xyz = tmp1.www * tmp9.xyz;
                tmp1.w = max(tmp7.y, tmp7.x);
                tmp1.w = max(tmp7.z, tmp1.w);
                tmp1.w = 1.0 - tmp1.w;
                tmp2.w = dot(tmp9.xyz, tmp8.xyz);
                tmp2.w = tmp2.w + tmp2.w;
                tmp10.xyz = tmp8.xyz * -tmp2.www + tmp9.xyz;
                tmp2.w = -tmp5.w * _Glossness + 1.0;
                tmp3.w = -tmp2.w * 0.7 + 1.7;
                tmp3.w = tmp2.w * tmp3.w;
                tmp3.w = tmp3.w * 6.0;
                tmp11 = texCUBElod(_MyGlobalReflectionProbe, float4(tmp10.xyz, tmp3.w));
                tmp3.w = saturate(tmp10.y + _ReflectionBottomShade);
                tmp10.xyz = tmp3.www * tmp11.xyz;
                tmp3.w = dot(tmp8.xyz, -tmp9.xyz);
                tmp6.w = tmp2.w * tmp2.w;
                tmp6.w = max(tmp6.w, 0.002);
                tmp6.w = tmp6.w * 0.28;
                tmp2.w = -tmp6.w * tmp2.w + 1.0;
                tmp1.w = tmp5.w * _Glossness + -tmp1.w;
                tmp1.w = saturate(tmp1.w + 1.0);
                tmp8.xyz = tmp10.xyz * tmp2.www;
                tmp2.w = 1.0 - abs(tmp3.w);
                tmp3.w = tmp2.w * tmp2.w;
                tmp3.w = tmp3.w * tmp3.w;
                tmp2.w = tmp2.w * tmp3.w;
                tmp9.xyz = -tmp5.yyy * _ReflectColor.xyz + tmp1.www;
                tmp7.xyz = tmp2.www * tmp9.xyz + tmp7.xyz;
                tmp7.xyz = tmp7.xyz * tmp8.xyz;
                tmp2 = texCUBE(_Cube, tmp2.xyz);
                tmp2.xyz = tmp2.xyz * _ReflectColor.xyz;
                tmp2.xyz = tmp5.xxx * tmp2.xyz;
                tmp2.xyz = tmp7.xyz * _GlobalReflectionStrength.xxx + tmp2.xyz;
                tmp7.xyz = tmp4.xyz * tmp5.xxx;
                tmp7.xyz = tmp7.xyz * _EFT_Ambient.xyz;
                tmp2.xyz = tmp7.xyz * float3(2.0, 2.0, 2.0) + tmp2.xyz;
                tmp1.w = dot(tmp3.xyz, tmp3.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp3.xyz = tmp1.www * tmp3.xyz;
                tmp1.w = dot(tmp3.xyz, tmp6.xyz);
                tmp1.w = 1.0 - tmp1.w;
                tmp1.w = tmp1.w * tmp1.w;
                tmp1.w = tmp1.w * 0.5;
                tmp2.w = _SpecVals.y * tmp1.w + _SpecVals.x;
                tmp2.w = tmp2.w * 0.5;
                tmp1.w = _DefVals.y * tmp1.w + _DefVals.x;
                tmp4.xyz = tmp1.www * tmp4.xyz;
                tmp1.w = tmp2.w * tmp5.z;
                tmp3.xyz = tmp2.www * tmp2.xyz;
                tmp2.xyz = -tmp2.xyz * tmp2.www + _GFogColor.xyz;
                tmp2.xyz = inp.texcoord6.xxx * tmp2.xyz + tmp3.xyz;
                tmp3.xyz = inp.texcoord7.xyz - tmp2.xyz;
                tmp2.xyz = inp.texcoord7.www * tmp3.xyz + tmp2.xyz;
                tmp2.w = _ThermalVisionOn > 0.0;
                tmp3.xyz = tmp4.xyz * _Temperature2.zzz;
                tmp3.xyz = max(tmp3.xyz, _Temperature2.xxx);
                tmp3.xyz = min(tmp3.xyz, _Temperature2.yyy);
                tmp3.xyz = tmp3.xyz + _Temperature2.www;
                tmp3.w = 1.0;
                tmp3 = tmp2.wwww ? tmp3 : tmp4;
                tmp2.w = unity_ProbeVolumeParams.x == 1.0;
                if (tmp2.w) {
                    tmp4.x = unity_ProbeVolumeParams.y == 1.0;
                    tmp4.yzw = inp.texcoord3.www * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp4.yzw = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.www + tmp4.yzw;
                    tmp4.yzw = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord4.www + tmp4.yzw;
                    tmp4.yzw = tmp4.yzw + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp4.xyz = tmp4.xxx ? tmp4.yzw : tmp0.yzw;
                    tmp4.xyz = tmp4.xyz - unity_ProbeVolumeMin;
                    tmp4.yzw = tmp4.xyz * unity_ProbeVolumeSizeInv;
                    tmp4.y = tmp4.y * 0.25 + 0.75;
                    tmp5.x = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp4.x = max(tmp4.y, tmp5.x);
                    tmp4 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp4.xzw);
                } else {
                    tmp4 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp4.x = saturate(dot(tmp4, unity_OcclusionMaskSelector));
                tmp7.x = dot(inp.texcoord2.xyz, tmp6.xyz);
                tmp7.y = dot(inp.texcoord3.xyz, tmp6.xyz);
                tmp7.z = dot(inp.texcoord4.xyz, tmp6.xyz);
                tmp4.y = dot(tmp7.xyz, tmp7.xyz);
                tmp4.y = rsqrt(tmp4.y);
                tmp6.xyz = tmp4.yyy * tmp7.xyz;
                tmp4.xyz = tmp4.xxx * _LightColor0.xyz;
                if (tmp2.w) {
                    tmp2.w = unity_ProbeVolumeParams.y == 1.0;
                    tmp5.xzw = inp.texcoord3.www * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp5.xzw = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.www + tmp5.xzw;
                    tmp5.xzw = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord4.www + tmp5.xzw;
                    tmp5.xzw = tmp5.xzw + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp0.yzw = tmp2.www ? tmp5.xzw : tmp0.yzw;
                    tmp0.yzw = tmp0.yzw - unity_ProbeVolumeMin;
                    tmp7.yzw = tmp0.yzw * unity_ProbeVolumeSizeInv;
                    tmp0.y = tmp7.y * 0.25;
                    tmp0.z = unity_ProbeVolumeParams.z * 0.5;
                    tmp0.w = -unity_ProbeVolumeParams.z * 0.5 + 0.25;
                    tmp0.y = max(tmp0.z, tmp0.y);
                    tmp7.x = min(tmp0.w, tmp0.y);
                    tmp8 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp7.xzw);
                    tmp0.yzw = tmp7.xzw + float3(0.25, 0.0, 0.0);
                    tmp9 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp0.yzw);
                    tmp0.yzw = tmp7.xzw + float3(0.5, 0.0, 0.0);
                    tmp7 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp0.yzw);
                    tmp6.w = 1.0;
                    tmp8.x = dot(tmp8, tmp6);
                    tmp8.y = dot(tmp9, tmp6);
                    tmp8.z = dot(tmp7, tmp6);
                } else {
                    tmp6.w = 1.0;
                    tmp8.x = dot(unity_SHAr, tmp6);
                    tmp8.y = dot(unity_SHAg, tmp6);
                    tmp8.z = dot(unity_SHAb, tmp6);
                }
                tmp0.yzw = tmp8.xyz + inp.texcoord8.xyz;
                tmp0.yzw = max(tmp0.yzw, float3(0.0, 0.0, 0.0));
                tmp0.yzw = log(tmp0.yzw);
                tmp0.yzw = tmp0.yzw * float3(0.4166667, 0.4166667, 0.4166667);
                tmp0.yzw = exp(tmp0.yzw);
                tmp0.yzw = tmp0.yzw * float3(1.055, 1.055, 1.055) + float3(-0.055, -0.055, -0.055);
                tmp0.yzw = max(tmp0.yzw, float3(0.0, 0.0, 0.0));
                tmp1.xyz = tmp1.xyz * tmp0.xxx + _WorldSpaceLightPos0.xyz;
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp1.xyz = tmp0.xxx * tmp1.xyz;
                tmp0.x = dot(tmp6.xyz, _WorldSpaceLightPos0.xyz);
                tmp0.x = max(tmp0.x, 0.0);
                tmp1.x = dot(tmp6.xyz, tmp1.xyz);
                tmp1.x = max(tmp1.x, 0.0);
                tmp1.y = tmp5.y * 128.0;
                tmp1.x = log(tmp1.x);
                tmp1.x = tmp1.x * tmp1.y;
                tmp1.x = exp(tmp1.x);
                tmp1.x = tmp1.w * tmp1.x;
                tmp1.yzw = tmp3.xyz * tmp4.xyz;
                tmp4.xyz = tmp4.xyz * _SpecColor.xyz;
                tmp4.xyz = tmp1.xxx * tmp4.xyz;
                tmp1.xyz = tmp1.yzw * tmp0.xxx + tmp4.xyz;
                tmp0.xyz = tmp3.xyz * tmp0.yzw + tmp1.xyz;
                o.sv_target.xyz = tmp2.xyz + tmp0.xyz;
                o.sv_target.w = tmp3.w;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDADD" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha One, SrcAlpha One
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 89329
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float texcoord7 : TEXCOORD7;
				float3 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord4 : TEXCOORD4;
				float3 texcoord5 : TEXCOORD5;
				float3 texcoord6 : TEXCOORD6;
				float4 texcoord8 : TEXCOORD8;
				float3 texcoord9 : TEXCOORD9;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4x4 unity_WorldToLight;
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
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float4 _Color;
			float _SpecPower;
			float _Glossness;
			float3 _SpecVals;
			float3 _DefVals;
			float4 _Temperature2;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _SpecTex;
			sampler2D _BumpMap;
			sampler2D _LightTexture0;
			
			// Keywords: POINT
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
                tmp0.xyz = v.vertex.yyy * unity_ObjectToWorld._m01_m11_m21;
                tmp0.xyz = unity_ObjectToWorld._m00_m10_m20 * v.vertex.xxx + tmp0.xyz;
                tmp0.xyz = unity_ObjectToWorld._m02_m12_m22 * v.vertex.zzz + tmp0.xyz;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp1.xyz = tmp0.xyz - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = sqrt(tmp0.w);
                tmp2.x = max(tmp1.w, 0.000001);
                tmp2.x = -tmp1.y / tmp2.x;
                tmp2.y = min(tmp1.w, _GFogMax);
                tmp2.z = _GFogY - _WorldSpaceCameraPos.y;
                tmp3.y = tmp2.y * tmp2.x + tmp2.z;
                tmp2.y = tmp2.x * _GFogStart + tmp2.z;
                tmp2.z = tmp2.x > 0.0;
                tmp2.w = min(tmp3.y, tmp2.y);
                tmp2.y = max(tmp3.y, tmp2.y);
                tmp3.x = tmp2.z ? tmp2.w : tmp2.y;
                tmp2.yz = max(tmp3.xy, float2(0.0, 0.0));
                tmp3.zw = tmp2.yz + _GFogFuncVals.zz;
                tmp3.zw = log(tmp3.zw);
                tmp3.zw = tmp3.zw * _GFogFuncVals.yy;
                tmp3.zw = tmp3.zw * float2(0.6931472, 0.6931472);
                tmp2.yz = _GFogFuncVals.xx * tmp2.yz + -tmp3.zw;
                tmp3.xy = max(tmp3.xy, _GFogTopFuncVals.xx);
                tmp3.zw = tmp3.xy * tmp3.xy;
                tmp3.xy = tmp3.zw * _GFogTopFuncVals.yy + tmp3.xy;
                tmp2.yz = tmp3.xy * _GFogTopFuncVals.zz + tmp2.yz;
                tmp2.y = tmp2.z - tmp2.y;
                tmp2.y = tmp2.y * _GFogStrength;
                tmp2.x = max(abs(tmp2.x), 0.000001);
                tmp2.x = tmp2.y / tmp2.x;
                tmp2.x = sqrt(abs(tmp2.x));
                o.texcoord7.x = min(tmp2.x, 1.0);
                tmp2.x = tmp1.y + _Density.y;
                tmp2.x = tmp2.x * _Density.x;
                tmp2.x = max(tmp2.x, 0.0);
                tmp2.x = tmp2.x + 1.0;
                tmp2.x = 1.0 / tmp2.x;
                tmp1.w = tmp1.w * tmp2.x;
                tmp1.w = tmp1.w * _Density.z;
                tmp1.w = min(tmp1.w, 10.0);
                tmp1.w = tmp1.w * -1.442695;
                tmp1.w = exp(tmp1.w);
                tmp1.w = 1.0 - tmp1.w;
                tmp0.w = rsqrt(tmp0.w);
                tmp2.xyz = tmp0.www * tmp1.xyz;
                tmp0.w = tmp1.y * tmp0.w + 0.03125;
                tmp1.xy = tmp2.yy > float2(0.03125, -0.03125);
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * 8.0;
                tmp0.w = tmp1.x ? tmp2.y : tmp0.w;
                tmp2.w = tmp1.y ? tmp0.w : 0.0;
                tmp0.w = tmp1.w * TOD_kScale.x;
                tmp1.y = TOD_kRadius.x + TOD_kScale.w;
                tmp3.x = tmp2.w * tmp2.w;
                tmp3.x = tmp3.x * TOD_kRadius.y + TOD_kRadius.w;
                tmp3.x = tmp3.x - TOD_kRadius.y;
                tmp3.x = sqrt(tmp3.x);
                tmp3.x = -TOD_kRadius.x * tmp2.w + tmp3.x;
                tmp3.y = -TOD_kScale.w * TOD_kScale.z;
                tmp3.xy = tmp3.xy * float2(0.25, 1.442695);
                tmp3.y = exp(tmp3.y);
                tmp3.z = tmp1.y * tmp2.w;
                tmp3.z = tmp3.z / tmp1.y;
                tmp3.z = 1.0 - tmp3.z;
                tmp3.w = tmp3.z * 5.25 + -6.8;
                tmp3.w = tmp3.z * tmp3.w + 3.83;
                tmp3.w = tmp3.z * tmp3.w + 0.459;
                tmp3.z = tmp3.z * tmp3.w + -0.00287;
                tmp3.z = tmp3.z * 1.442695;
                tmp3.z = exp(tmp3.z);
                tmp3.y = tmp3.z * tmp3.y;
                tmp0.w = tmp0.w * tmp3.x;
                tmp4.xyz = tmp2.xwz * tmp3.xxx;
                tmp1.xz = float2(0.0, 0.0);
                tmp1.xyz = tmp4.xyz * float3(0.5, 0.5, 0.5) + tmp1.xyz;
                tmp4.xyz = TOD_k4PI.www + TOD_k4PI.xyz;
                tmp5.xyz = tmp1.xyz;
                tmp6.xyz = float3(0.0, 0.0, 0.0);
                tmp3.z = 0.0;
                for (int i = tmp3.z; i < 4; i += 1) {
                    tmp3.w = dot(tmp5.xyz, tmp5.xyz);
                    tmp3.w = sqrt(tmp3.w);
                    tmp4.w = 1.0 / tmp3.w;
                    tmp3.w = TOD_kRadius.x - tmp3.w;
                    tmp3.w = tmp3.w * TOD_kScale.z;
                    tmp3.w = tmp3.w * 1.442695;
                    tmp3.w = exp(tmp3.w);
                    tmp5.w = tmp0.w * tmp3.w;
                    tmp6.w = dot(tmp2.xyz, tmp5.xyz);
                    tmp7.x = dot(TOD_LocalSunDirection, tmp5.xyz);
                    tmp7.x = -tmp7.x * tmp4.w + 1.0;
                    tmp7.y = tmp7.x * 5.25 + -6.8;
                    tmp7.y = tmp7.x * tmp7.y + 3.83;
                    tmp7.y = tmp7.x * tmp7.y + 0.459;
                    tmp7.x = tmp7.x * tmp7.y + -0.00287;
                    tmp7.x = tmp7.x * 1.442695;
                    tmp7.x = exp(tmp7.x);
                    tmp4.w = -tmp6.w * tmp4.w + 1.0;
                    tmp6.w = tmp4.w * 5.25 + -6.8;
                    tmp6.w = tmp4.w * tmp6.w + 3.83;
                    tmp6.w = tmp4.w * tmp6.w + 0.459;
                    tmp4.w = tmp4.w * tmp6.w + -0.00287;
                    tmp4.w = tmp4.w * 1.442695;
                    tmp4.w = exp(tmp4.w);
                    tmp4.w = tmp4.w * 0.25;
                    tmp4.w = tmp7.x * 0.25 + -tmp4.w;
                    tmp3.w = tmp3.w * tmp4.w;
                    tmp3.w = tmp3.y * 0.25 + tmp3.w;
                    tmp7.xyz = tmp4.xyz * -tmp3.www;
                    tmp7.xyz = tmp7.xyz * float3(1.442695, 1.442695, 1.442695);
                    tmp7.xyz = exp(tmp7.xyz);
                    tmp6.xyz = tmp7.xyz * tmp5.www + tmp6.xyz;
                    tmp5.xyz = tmp2.xwz * tmp3.xxx + tmp5.xyz;
                }
                tmp1.xyz = tmp6.xyz * TOD_SunSkyColor;
                tmp3.xyz = tmp1.xyz * TOD_kSun.xyz;
                tmp1.xyz = tmp1.xyz * TOD_kSun.www;
                tmp0.w = saturate(tmp2.y * -0.8);
                tmp2.w = tmp0.w * -2.0 + 3.0;
                tmp0.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * tmp2.w;
                tmp2.w = dot(TOD_LocalSunDirection, tmp2.xyz);
                tmp3.w = tmp2.w * tmp2.w;
                tmp3.w = tmp3.w * 0.75 + 0.75;
                tmp4.x = tmp2.w * tmp2.w + 1.0;
                tmp4.x = tmp4.x * TOD_kBetaMie.x;
                tmp2.w = TOD_kBetaMie.z * tmp2.w + TOD_kBetaMie.y;
                tmp2.w = log(tmp2.w);
                tmp2.w = tmp2.w * 1.5;
                tmp2.w = exp(tmp2.w);
                tmp2.w = tmp4.x / tmp2.w;
                tmp1.xyz = tmp1.xyz * tmp2.www;
                tmp1.xyz = tmp3.www * tmp3.xyz + tmp1.xyz;
                tmp3.xyz = tmp2.yyy * -TOD_MoonSkyColor + TOD_MoonSkyColor;
                tmp1.xyz = tmp1.xyz + tmp3.xyz;
                tmp2.x = dot(tmp2.xyz, TOD_LocalMoonDirection);
                tmp2.x = max(tmp2.x, 0.0);
                tmp2.x = log(tmp2.x);
                tmp2.x = tmp2.x * TOD_MoonHaloPower;
                tmp2.x = exp(tmp2.x);
                tmp1.xyz = TOD_MoonHaloColor * tmp2.xxx + tmp1.xyz;
                tmp2.x = tmp1.y + tmp1.x;
                tmp2.x = tmp1.z + tmp2.x;
                tmp2.xyz = tmp2.xxx * float3(0.333, 0.333, 0.333) + -tmp1.xyz;
                tmp1.xyz = TOD_Fogginess.xxx * tmp2.xyz + tmp1.xyz;
                tmp2.xyz = TOD_GroundColor - tmp1.xyz;
                tmp1.xyz = tmp0.www * tmp2.xyz + tmp1.xyz;
                tmp1.xyz = tmp1.xyz * TOD_ScatteringBrightness.xxx;
                tmp1.xyz = log(tmp1.xyz);
                tmp1.xyz = tmp1.xyz * TOD_Contrast.xxx;
                tmp1.xyz = exp(tmp1.xyz);
                tmp1.xyz = tmp1.xyz * float3(2.0, 2.0, 2.0) + float3(-0.0000001, -0.0000001, -0.0000001);
                o.texcoord8.xyz = max(tmp1.xyz, float3(0.0, 0.0, 0.0));
                tmp2 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp2 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp2;
                tmp2 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp2;
                tmp3 = tmp2 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp4 = tmp3.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp4 = unity_MatrixVP._m00_m10_m20_m30 * tmp3.xxxx + tmp4;
                tmp4 = unity_MatrixVP._m02_m12_m22_m32 * tmp3.zzzz + tmp4;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp3.wwww + tmp4;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp1.xyz;
                tmp3.xyz = v.tangent.yyy * unity_ObjectToWorld._m11_m21_m01;
                tmp3.xyz = unity_ObjectToWorld._m10_m20_m00 * v.tangent.xxx + tmp3.xyz;
                tmp3.xyz = unity_ObjectToWorld._m12_m22_m02 * v.tangent.zzz + tmp3.xyz;
                tmp0.w = dot(tmp3.xyz, tmp3.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * tmp3.xyz;
                tmp0.w = v.tangent.w * unity_WorldTransformParams.w;
                tmp4.xyz = tmp1.xyz * tmp3.xyz;
                tmp4.xyz = tmp1.zxy * tmp3.yzx + -tmp4.xyz;
                tmp4.xyz = tmp0.www * tmp4.xyz;
                tmp2 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp2;
                tmp5.xyz = tmp2.yyy * unity_WorldToLight._m01_m11_m21;
                tmp5.xyz = unity_WorldToLight._m00_m10_m20 * tmp2.xxx + tmp5.xyz;
                tmp2.xyz = unity_WorldToLight._m02_m12_m22 * tmp2.zzz + tmp5.xyz;
                o.texcoord9.xyz = unity_WorldToLight._m03_m13_m23 * tmp2.www + tmp2.xyz;
                o.texcoord8.w = tmp1.w;
                o.texcoord2.x = tmp3.z;
                o.texcoord2.y = tmp4.x;
                o.texcoord2.z = tmp1.y;
                o.texcoord3.x = tmp3.x;
                o.texcoord3.y = tmp4.y;
                o.texcoord3.z = tmp1.z;
                o.texcoord4.x = tmp3.y;
                o.texcoord4.y = tmp4.z;
                o.texcoord4.z = tmp1.x;
                o.texcoord5.xyz = tmp0.xyz;
                o.texcoord6.xyz = float3(0.0, 0.0, 0.0);
                return o;
			}
			// Keywords: POINT
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
                tmp0.xyz = _WorldSpaceLightPos0.xyz - inp.texcoord5.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp0.xyz;
                tmp2.xyz = _WorldSpaceCameraPos - inp.texcoord5.xyz;
                tmp1.w = dot(tmp2.xyz, tmp2.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp2.xyz = tmp1.www * tmp2.xyz;
                tmp3.xyz = tmp2.yyy * inp.texcoord3.xyz;
                tmp3.xyz = inp.texcoord2.xyz * tmp2.xxx + tmp3.xyz;
                tmp3.xyz = inp.texcoord4.xyz * tmp2.zzz + tmp3.xyz;
                tmp4 = tex2D(_MainTex, inp.texcoord.xy);
                tmp4 = tmp4 * _Color;
                tmp5 = tex2D(_SpecTex, inp.texcoord.zw);
                tmp6 = tex2D(_BumpMap, inp.texcoord1.xy);
                tmp6.x = tmp6.w * tmp6.x;
                tmp6.xy = tmp6.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.w = dot(tmp6.xy, tmp6.xy);
                tmp1.w = min(tmp1.w, 1.0);
                tmp1.w = 1.0 - tmp1.w;
                tmp6.z = sqrt(tmp1.w);
                tmp5.xy = tmp5.xw * float2(_SpecPower.x, _Glossness.x);
                tmp1.w = dot(tmp3.xyz, tmp3.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp3.xyz = tmp1.www * tmp3.xyz;
                tmp1.w = dot(tmp3.xyz, tmp6.xyz);
                tmp1.w = 1.0 - tmp1.w;
                tmp1.w = tmp1.w * tmp1.w;
                tmp1.w = tmp1.w * 0.5;
                tmp2.w = _SpecVals.y * tmp1.w + _SpecVals.x;
                tmp2.w = tmp2.w * 0.5;
                tmp1.w = _DefVals.y * tmp1.w + _DefVals.x;
                tmp4.xyz = tmp1.www * tmp4.xyz;
                tmp1.w = tmp2.w * tmp5.y;
                tmp2.w = _ThermalVisionOn > 0.0;
                tmp3.xyz = tmp4.xyz * _Temperature2.zzz;
                tmp3.xyz = max(tmp3.xyz, _Temperature2.xxx);
                tmp3.xyz = min(tmp3.xyz, _Temperature2.yyy);
                tmp3.xyz = tmp3.xyz + _Temperature2.www;
                tmp3.w = 1.0;
                tmp3 = tmp2.wwww ? tmp3 : tmp4;
                tmp4.xyz = inp.texcoord5.yyy * unity_WorldToLight._m01_m11_m21;
                tmp4.xyz = unity_WorldToLight._m00_m10_m20 * inp.texcoord5.xxx + tmp4.xyz;
                tmp4.xyz = unity_WorldToLight._m02_m12_m22 * inp.texcoord5.zzz + tmp4.xyz;
                tmp4.xyz = tmp4.xyz + unity_WorldToLight._m03_m13_m23;
                tmp2.w = unity_ProbeVolumeParams.x == 1.0;
                if (tmp2.w) {
                    tmp2.w = unity_ProbeVolumeParams.y == 1.0;
                    tmp5.yzw = inp.texcoord5.yyy * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp5.yzw = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord5.xxx + tmp5.yzw;
                    tmp5.yzw = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord5.zzz + tmp5.yzw;
                    tmp5.yzw = tmp5.yzw + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp5.yzw = tmp2.www ? tmp5.yzw : inp.texcoord5.xyz;
                    tmp5.yzw = tmp5.yzw - unity_ProbeVolumeMin;
                    tmp7.yzw = tmp5.yzw * unity_ProbeVolumeSizeInv;
                    tmp2.w = tmp7.y * 0.25 + 0.75;
                    tmp4.w = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp7.x = max(tmp2.w, tmp4.w);
                    tmp7 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp7.xzw);
                } else {
                    tmp7 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp2.w = saturate(dot(tmp7, unity_OcclusionMaskSelector));
                tmp4.x = dot(tmp4.xyz, tmp4.xyz);
                tmp4 = tex2D(_LightTexture0, tmp4.xx);
                tmp2.w = tmp2.w * tmp4.x;
                tmp4.x = dot(inp.texcoord2.xyz, tmp6.xyz);
                tmp4.y = dot(inp.texcoord3.xyz, tmp6.xyz);
                tmp4.z = dot(inp.texcoord4.xyz, tmp6.xyz);
                tmp4.w = dot(tmp4.xyz, tmp4.xyz);
                tmp4.w = rsqrt(tmp4.w);
                tmp4.xyz = tmp4.www * tmp4.xyz;
                tmp5.yzw = tmp2.www * _LightColor0.xyz;
                tmp0.xyz = tmp0.xyz * tmp0.www + tmp2.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.w = dot(tmp4.xyz, tmp1.xyz);
                tmp0.x = dot(tmp4.xyz, tmp0.xyz);
                tmp0.xw = max(tmp0.xw, float2(0.0, 0.0));
                tmp0.y = tmp5.x * 128.0;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp1.w * tmp0.x;
                tmp1.xyz = tmp3.xyz * tmp5.yzw;
                tmp2.xyz = tmp5.yzw * _SpecColor.xyz;
                tmp0.xyz = tmp0.xxx * tmp2.xyz;
                o.sv_target.xyz = tmp1.xyz * tmp0.www + tmp0.xyz;
                o.sv_target.w = tmp3.w;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Reflective/Bumped Diffuse"
}