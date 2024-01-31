Shader "Transparent/DepthZwriteDithered" {
	Properties {
		[MaterialEnum(Off,0,Front,1,Back,2)] _Cull ("Cull", Float) = 2
		[MaterialEnum(Transparent, 0, Tinted, 1)] _Tinted ("Tint", Float) = 0
		[Toggle(_ALPHA_PARALLAX_ON)] _UseDetailMaps ("Use parallax for alpha", Float) = 0
		_FrontParallax ("Front face parallax scale", Range(0, 20)) = 3
		_BackParallax ("Back face parallax scale", Range(0, 20)) = 2
		_Color ("Main Color", Color) = (1,1,1,1)
		_OpacityScale ("Opacity scale", Range(0, 4)) = 1
		_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_SpecTex ("Specular (R), Gloss (A)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_Cube ("Reflection Cubemap", Cube) = "" {}
		_SpecPower ("Specular Power", Range(0.01, 10)) = 1
		_Glossness ("Glossness", Range(0.01, 50)) = 1
		_SpecVals ("Specular Vals", Color) = (1.1,2,0,0)
		_DefVals ("Defuse Vals", Color) = (0.5,0.7,0,0)
		_GlobalReflectionStrength ("Color", Float) = 1
		[Toggle(_ADDITIONAL_REFLECTION)] _AdditionalReflection ("Add fake reflection", Float) = 0
		_AdditionalReflectionStrength ("_AdditionalReflectionStrength", Float) = 0
		_Temperature ("_Temperature", Color) = (0.1,0.5,0.5,0)
	}
	SubShader {
		Tags { "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
		Pass {
			Tags { "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
			ColorMask A -1
			Cull Off
			GpuProgramID 499192
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
                float4 tmp0;
                tmp0.x = inp.color.w <= 0.5;
                if (tmp0.x) {
                    discard;
                }
                o.sv_target = inp.color;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" "SHADOWSUPPORT" = "true" }
			Cull Off
			GpuProgramID 62859
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
				float3 texcoord6 : TEXCOORD6;
				float4 texcoord7 : TEXCOORD7;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float _ReflectionBottomShade;
			float4 _Color;
			float4 _ReflectColor;
			float _SpecPower;
			float _Glossness;
			float _OpacityScale;
			float4 _EFT_Ambient;
			float _GlobalReflectionStrength;
			float _Tinted;
			float4 _Temperature;
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
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                tmp1 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.position = tmp1;
                o.texcoord5 = tmp1;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                o.texcoord2.w = tmp0.x;
                tmp1.xyz = v.tangent.yyy * unity_ObjectToWorld._m11_m21_m01;
                tmp1.xyz = unity_ObjectToWorld._m10_m20_m00 * v.tangent.xxx + tmp1.xyz;
                tmp1.xyz = unity_ObjectToWorld._m12_m22_m02 * v.tangent.zzz + tmp1.xyz;
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp1.xyz = tmp0.xxx * tmp1.xyz;
                o.texcoord2.x = tmp1.z;
                tmp2.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp2.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp2.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.x = dot(tmp2.xyz, tmp2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2 = tmp0.xxxx * tmp2.xyzz;
                tmp3.xyz = tmp1.xyz * tmp2.wxy;
                tmp3.xyz = tmp2.ywx * tmp1.yzx + -tmp3.xyz;
                tmp0.x = v.tangent.w * unity_WorldTransformParams.w;
                tmp3.xyz = tmp0.xxx * tmp3.xyz;
                o.texcoord2.y = tmp3.x;
                o.texcoord2.z = tmp2.x;
                o.texcoord3.x = tmp1.x;
                o.texcoord4.x = tmp1.y;
                o.texcoord3.w = tmp0.y;
                o.texcoord4.w = tmp0.z;
                o.texcoord3.y = tmp3.y;
                o.texcoord4.y = tmp3.z;
                o.texcoord3.z = tmp2.y;
                o.texcoord4.z = tmp2.w;
                tmp0.x = tmp2.y * tmp2.y;
                tmp0.x = tmp2.x * tmp2.x + -tmp0.x;
                tmp1 = tmp2.ywzx * tmp2;
                tmp2.x = dot(unity_SHBr, tmp1);
                tmp2.y = dot(unity_SHBg, tmp1);
                tmp2.z = dot(unity_SHBb, tmp1);
                o.texcoord6.xyz = unity_SHC.xyz * tmp0.xxx + tmp2.xyz;
                o.texcoord7 = float4(0.0, 0.0, 0.0, 0.0);
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
                float4 tmp12;
                tmp0.y = inp.texcoord2.w;
                tmp0.z = inp.texcoord3.w;
                tmp0.w = inp.texcoord4.w;
                tmp1.xyz = _WorldSpaceCameraPos - tmp0.yzw;
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2.xyz = tmp0.xxx * tmp1.xyz;
                tmp3.xyz = tmp2.yyy * inp.texcoord3.xyz;
                tmp2.xyw = inp.texcoord2.xyz * tmp2.xxx + tmp3.xyz;
                tmp2.xyz = inp.texcoord4.xyz * tmp2.zzz + tmp2.xyw;
                tmp3 = tex2D(_MainTex, inp.texcoord.xy);
                tmp4 = tmp3 * _Color;
                tmp5 = tex2D(_SpecTex, inp.texcoord.zw);
                tmp6 = tex2D(_BumpMap, inp.texcoord1.xy);
                tmp6.x = tmp6.w * tmp6.x;
                tmp6.xy = tmp6.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.w = dot(tmp6.xy, tmp6.xy);
                tmp1.w = min(tmp1.w, 1.0);
                tmp1.w = 1.0 - tmp1.w;
                tmp6.z = sqrt(tmp1.w);
                tmp7.w = saturate(tmp4.w * _OpacityScale);
                tmp1.w = tmp5.x * _SpecPower;
                tmp8.x = dot(inp.texcoord2.xyz, tmp6.xyz);
                tmp8.y = dot(inp.texcoord3.xyz, tmp6.xyz);
                tmp8.z = dot(inp.texcoord4.xyz, tmp6.xyz);
                tmp9.xyz = tmp1.www * _ReflectColor.xyz;
                tmp2.w = dot(tmp8.xyz, tmp8.xyz);
                tmp2.w = rsqrt(tmp2.w);
                tmp8.xyz = tmp2.www * tmp8.xyz;
                tmp10.xyz = tmp0.yzw - _WorldSpaceCameraPos;
                tmp2.w = dot(tmp10.xyz, tmp10.xyz);
                tmp2.w = rsqrt(tmp2.w);
                tmp10.xyz = tmp2.www * tmp10.xyz;
                tmp2.w = max(tmp9.y, tmp9.x);
                tmp2.w = max(tmp9.z, tmp2.w);
                tmp2.w = 1.0 - tmp2.w;
                tmp3.w = dot(tmp10.xyz, tmp8.xyz);
                tmp3.w = tmp3.w + tmp3.w;
                tmp11.xyz = tmp8.xyz * -tmp3.www + tmp10.xyz;
                tmp3.w = -tmp5.w * _Glossness + 1.0;
                tmp4.w = -tmp3.w * 0.7 + 1.7;
                tmp4.w = tmp3.w * tmp4.w;
                tmp4.w = tmp4.w * 6.0;
                tmp12 = texCUBElod(_MyGlobalReflectionProbe, float4(tmp11.xyz, tmp4.w));
                tmp4.w = saturate(tmp11.y + _ReflectionBottomShade);
                tmp11.xyz = tmp4.www * tmp12.xyz;
                tmp4.w = dot(tmp8.xyz, -tmp10.xyz);
                tmp5.y = tmp3.w * tmp3.w;
                tmp5.y = max(tmp5.y, 0.002);
                tmp5.y = tmp5.y * 0.28;
                tmp3.w = -tmp5.y * tmp3.w + 1.0;
                tmp2.w = tmp5.w * _Glossness + -tmp2.w;
                tmp2.w = saturate(tmp2.w + 1.0);
                tmp10.xyz = tmp11.xyz * tmp3.www;
                tmp3.w = 1.0 - abs(tmp4.w);
                tmp4.w = tmp3.w * tmp3.w;
                tmp4.w = tmp4.w * tmp4.w;
                tmp3.w = tmp3.w * tmp4.w;
                tmp11.xyz = -tmp1.www * _ReflectColor.xyz + tmp2.www;
                tmp9.xyz = tmp3.www * tmp11.xyz + tmp9.xyz;
                tmp9.xyz = tmp9.xyz * tmp10.xyz;
                tmp2.w = dot(tmp2.xyz, tmp6.xyz);
                tmp2.w = tmp2.w + tmp2.w;
                tmp10.xyz = tmp6.xyz * -tmp2.www + tmp2.xyz;
                tmp10 = texCUBE(_Cube, tmp10.xyz);
                tmp10.xyz = tmp10.xyz * _ReflectColor.xyz;
                tmp9.xyz = tmp9.xyz * _GlobalReflectionStrength.xxx + tmp10.xyz;
                tmp3.xyz = tmp3.xyz * _Color.xyz + tmp9.xyz;
                tmp3.xyz = tmp5.xxx * tmp3.xyz;
                tmp3.xyz = tmp3.xyz * _EFT_Ambient.xyz;
                tmp3.xyz = tmp3.xyz + tmp3.xyz;
                tmp2.w = _Tinted * 4.0 + 1.0;
                tmp2.w = 1.0 / tmp2.w;
                tmp3.xyz = tmp2.www * tmp3.xyz;
                tmp2.w = dot(abs(tmp2.xyz), abs(tmp2.xyz));
                tmp2.w = rsqrt(tmp2.w);
                tmp2.xyz = tmp2.www * abs(tmp2.xyz);
                tmp2.x = dot(tmp2.xyz, tmp6.xyz);
                tmp2.x = 1.0 - tmp2.x;
                tmp2.y = tmp2.x * tmp2.x;
                tmp2.x = tmp2.y * tmp2.x;
                tmp2.x = tmp2.x * 0.7 + 0.3;
                tmp2.y = 1.0 - tmp2.x;
                tmp2.yzw = tmp2.yyy * tmp4.xyz;
                tmp2.yzw = max(tmp2.yzw, tmp4.xyz);
                tmp3.w = tmp5.w * _Glossness + tmp7.w;
                tmp4.x = tmp5.w * _Glossness + -tmp3.w;
                tmp3.w = tmp2.x * tmp4.x + tmp3.w;
                tmp3.xyz = tmp2.xxx * tmp3.xyz;
                tmp2.x = tmp7.w > 0.5;
                tmp2.x = tmp2.x ? 1.0 : 2.0;
                tmp2.yzw = tmp2.xxx * tmp2.yzw;
                tmp4.x = _Tinted > 0.5;
                tmp7.xyz = tmp4.xxx ? float3(0.0, 0.0, 0.0) : tmp2.yzw;
                tmp4.xy = inp.texcoord5.xy / inp.texcoord5.ww;
                tmp2.y = _ProjectionParams.x * -_ProjectionParams.x;
                tmp4.z = tmp2.y * tmp4.y;
                tmp2.yz = tmp4.xz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp2.w = _ThermalVisionOn > 0.0;
                tmp4.xyz = tmp7.xyz * _Temperature.zzz;
                tmp4.xyz = max(tmp4.xyz, _Temperature.xxx);
                tmp4.xyz = min(tmp4.xyz, _Temperature.yyy);
                tmp4.xyz = tmp4.xyz + _Temperature.www;
                tmp4.w = 1.0;
                tmp4 = tmp2.wwww ? tmp4 : tmp7;
                tmp2.yz = tmp2.yz * _ScreenParams.xy;
                tmp2.yz = floor(tmp2.yz);
                tmp2.y = tmp2.z + tmp2.y;
                tmp2.y = tmp2.y * 0.5;
                tmp2.z = tmp2.y >= -tmp2.y;
                tmp2.y = frac(abs(tmp2.y));
                tmp2.y = tmp2.z ? tmp2.y : -tmp2.y;
                tmp2.y = tmp2.y == 0.5;
                tmp2.z = 1.0 - _Tinted;
                tmp2.y = tmp2.y ? tmp2.z : _Tinted;
                tmp2.y = tmp4.w - tmp2.y;
                tmp2.y = tmp2.y + 0.5;
                tmp2.y = tmp2.y < 0.0;
                if (tmp2.y) {
                    discard;
                }
                tmp2.y = unity_ProbeVolumeParams.x == 1.0;
                if (tmp2.y) {
                    tmp2.z = unity_ProbeVolumeParams.y == 1.0;
                    tmp5.xyz = inp.texcoord3.www * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp5.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.www + tmp5.xyz;
                    tmp5.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord4.www + tmp5.xyz;
                    tmp5.xyz = tmp5.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp5.xyz = tmp2.zzz ? tmp5.xyz : tmp0.yzw;
                    tmp5.xyz = tmp5.xyz - unity_ProbeVolumeMin;
                    tmp5.yzw = tmp5.xyz * unity_ProbeVolumeSizeInv;
                    tmp2.z = tmp5.y * 0.25 + 0.75;
                    tmp2.w = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp5.x = max(tmp2.w, tmp2.z);
                    tmp5 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp5.xzw);
                } else {
                    tmp5 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp2.z = saturate(dot(tmp5, unity_OcclusionMaskSelector));
                tmp5.xyz = tmp2.zzz * _LightColor0.xyz;
                if (tmp2.y) {
                    tmp2.y = unity_ProbeVolumeParams.y == 1.0;
                    tmp6.xyz = inp.texcoord3.www * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp6.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.www + tmp6.xyz;
                    tmp6.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord4.www + tmp6.xyz;
                    tmp6.xyz = tmp6.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp0.yzw = tmp2.yyy ? tmp6.xyz : tmp0.yzw;
                    tmp0.yzw = tmp0.yzw - unity_ProbeVolumeMin;
                    tmp6.yzw = tmp0.yzw * unity_ProbeVolumeSizeInv;
                    tmp0.y = tmp6.y * 0.25;
                    tmp0.z = unity_ProbeVolumeParams.z * 0.5;
                    tmp0.w = -unity_ProbeVolumeParams.z * 0.5 + 0.25;
                    tmp0.y = max(tmp0.z, tmp0.y);
                    tmp6.x = min(tmp0.w, tmp0.y);
                    tmp7 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp6.xzw);
                    tmp0.yzw = tmp6.xzw + float3(0.25, 0.0, 0.0);
                    tmp9 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp0.yzw);
                    tmp0.yzw = tmp6.xzw + float3(0.5, 0.0, 0.0);
                    tmp6 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp0.yzw);
                    tmp8.w = 1.0;
                    tmp7.x = dot(tmp7, tmp8);
                    tmp7.y = dot(tmp9, tmp8);
                    tmp7.z = dot(tmp6, tmp8);
                } else {
                    tmp8.w = 1.0;
                    tmp7.x = dot(unity_SHAr, tmp8);
                    tmp7.y = dot(unity_SHAg, tmp8);
                    tmp7.z = dot(unity_SHAb, tmp8);
                }
                tmp0.yzw = tmp7.xyz + inp.texcoord6.xyz;
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
                tmp0.x = dot(tmp8.xyz, _WorldSpaceLightPos0.xyz);
                tmp0.x = max(tmp0.x, 0.0);
                tmp1.x = dot(tmp8.xyz, tmp1.xyz);
                tmp1.x = max(tmp1.x, 0.0);
                tmp1.y = tmp1.w * 128.0;
                tmp1.x = log(tmp1.x);
                tmp1.x = tmp1.x * tmp1.y;
                tmp1.x = exp(tmp1.x);
                tmp1.x = tmp3.w * tmp1.x;
                tmp1.yzw = tmp4.xyz * tmp5.xyz;
                tmp2.yzw = tmp5.xyz * _SpecColor.xyz;
                tmp2.yzw = tmp1.xxx * tmp2.yzw;
                tmp1.xyz = tmp1.yzw * tmp0.xxx + tmp2.yzw;
                tmp0.xyz = tmp4.xyz * tmp0.yzw + tmp1.xyz;
                o.sv_target.xyz = tmp3.xyz * tmp2.xxx + tmp0.xyz;
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			Tags { "LIGHTMODE" = "FORWARDADD" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
			Blend One One, One One
			ZWrite Off
			Cull Off
			GpuProgramID 80981
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord4 : TEXCOORD4;
				float3 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
				float3 texcoord7 : TEXCOORD7;
				float4 texcoord8 : TEXCOORD8;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4x4 unity_WorldToLight;
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float4 _Color;
			float _SpecPower;
			float _Glossness;
			float _OpacityScale;
			float _Tinted;
			float4 _Temperature;
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
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                tmp1 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.position = tmp1;
                o.texcoord6 = tmp1;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp2.xyz = v.tangent.yyy * unity_ObjectToWorld._m11_m21_m01;
                tmp2.xyz = unity_ObjectToWorld._m10_m20_m00 * v.tangent.xxx + tmp2.xyz;
                tmp2.xyz = unity_ObjectToWorld._m12_m22_m02 * v.tangent.zzz + tmp2.xyz;
                tmp1.w = dot(tmp2.xyz, tmp2.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp2.xyz = tmp1.www * tmp2.xyz;
                tmp3.xyz = tmp1.xyz * tmp2.xyz;
                tmp3.xyz = tmp1.zxy * tmp2.yzx + -tmp3.xyz;
                tmp1.w = v.tangent.w * unity_WorldTransformParams.w;
                tmp3.xyz = tmp1.www * tmp3.xyz;
                o.texcoord2.y = tmp3.x;
                o.texcoord2.x = tmp2.z;
                o.texcoord2.z = tmp1.y;
                o.texcoord3.x = tmp2.x;
                o.texcoord4.x = tmp2.y;
                o.texcoord3.z = tmp1.z;
                o.texcoord4.z = tmp1.x;
                o.texcoord3.y = tmp3.y;
                o.texcoord4.y = tmp3.z;
                o.texcoord5.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp0;
                tmp1.xyz = tmp0.yyy * unity_WorldToLight._m01_m11_m21;
                tmp1.xyz = unity_WorldToLight._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                tmp0.xyz = unity_WorldToLight._m02_m12_m22 * tmp0.zzz + tmp1.xyz;
                o.texcoord7.xyz = unity_WorldToLight._m03_m13_m23 * tmp0.www + tmp0.xyz;
                o.texcoord8 = float4(0.0, 0.0, 0.0, 0.0);
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
                tmp7.w = saturate(tmp4.w * _OpacityScale);
                tmp1.w = tmp5.x * _SpecPower;
                tmp2.w = dot(abs(tmp3.xyz), abs(tmp3.xyz));
                tmp2.w = rsqrt(tmp2.w);
                tmp3.xyz = tmp2.www * abs(tmp3.xyz);
                tmp2.w = dot(tmp3.xyz, tmp6.xyz);
                tmp2.w = 1.0 - tmp2.w;
                tmp3.x = tmp2.w * tmp2.w;
                tmp2.w = tmp2.w * tmp3.x;
                tmp2.w = tmp2.w * 0.7 + 0.3;
                tmp3.x = 1.0 - tmp2.w;
                tmp3.xyz = tmp3.xxx * tmp4.xyz;
                tmp3.xyz = max(tmp3.xyz, tmp4.xyz);
                tmp3.w = tmp5.w * _Glossness + tmp7.w;
                tmp4.x = tmp5.w * _Glossness + -tmp3.w;
                tmp2.w = tmp2.w * tmp4.x + tmp3.w;
                tmp3.w = tmp7.w > 0.5;
                tmp3.w = tmp3.w ? 1.0 : 2.0;
                tmp3.xyz = tmp3.www * tmp3.xyz;
                tmp3.w = _Tinted > 0.5;
                tmp7.xyz = tmp3.www ? float3(0.0, 0.0, 0.0) : tmp3.xyz;
                tmp3.xy = inp.texcoord6.xy / inp.texcoord6.ww;
                tmp3.w = _ProjectionParams.x * -_ProjectionParams.x;
                tmp3.z = tmp3.w * tmp3.y;
                tmp3.xy = tmp3.xz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp3.z = _ThermalVisionOn > 0.0;
                tmp4.xyz = tmp7.xyz * _Temperature.zzz;
                tmp4.xyz = max(tmp4.xyz, _Temperature.xxx);
                tmp4.xyz = min(tmp4.xyz, _Temperature.yyy);
                tmp4.xyz = tmp4.xyz + _Temperature.www;
                tmp4.w = 1.0;
                tmp4 = tmp3.zzzz ? tmp4 : tmp7;
                tmp3.xy = tmp3.xy * _ScreenParams.xy;
                tmp3.xy = floor(tmp3.xy);
                tmp3.x = tmp3.y + tmp3.x;
                tmp3.x = tmp3.x * 0.5;
                tmp3.y = tmp3.x >= -tmp3.x;
                tmp3.x = frac(abs(tmp3.x));
                tmp3.x = tmp3.y ? tmp3.x : -tmp3.x;
                tmp3.x = tmp3.x == 0.5;
                tmp3.y = 1.0 - _Tinted;
                tmp3.x = tmp3.x ? tmp3.y : _Tinted;
                tmp3.x = tmp4.w - tmp3.x;
                tmp3.x = tmp3.x + 0.5;
                tmp3.x = tmp3.x < 0.0;
                if (tmp3.x) {
                    discard;
                }
                tmp3.xyz = inp.texcoord5.yyy * unity_WorldToLight._m01_m11_m21;
                tmp3.xyz = unity_WorldToLight._m00_m10_m20 * inp.texcoord5.xxx + tmp3.xyz;
                tmp3.xyz = unity_WorldToLight._m02_m12_m22 * inp.texcoord5.zzz + tmp3.xyz;
                tmp3.xyz = tmp3.xyz + unity_WorldToLight._m03_m13_m23;
                tmp3.w = unity_ProbeVolumeParams.x == 1.0;
                if (tmp3.w) {
                    tmp3.w = unity_ProbeVolumeParams.y == 1.0;
                    tmp5.xyz = inp.texcoord5.yyy * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp5.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord5.xxx + tmp5.xyz;
                    tmp5.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord5.zzz + tmp5.xyz;
                    tmp5.xyz = tmp5.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp5.xyz = tmp3.www ? tmp5.xyz : inp.texcoord5.xyz;
                    tmp5.xyz = tmp5.xyz - unity_ProbeVolumeMin;
                    tmp5.yzw = tmp5.xyz * unity_ProbeVolumeSizeInv;
                    tmp3.w = tmp5.y * 0.25 + 0.75;
                    tmp4.w = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp5.x = max(tmp3.w, tmp4.w);
                    tmp5 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp5.xzw);
                } else {
                    tmp5 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp3.w = saturate(dot(tmp5, unity_OcclusionMaskSelector));
                tmp3.x = dot(tmp3.xyz, tmp3.xyz);
                tmp5 = tex2D(_LightTexture0, tmp3.xx);
                tmp3.x = tmp3.w * tmp5.x;
                tmp5.x = dot(inp.texcoord2.xyz, tmp6.xyz);
                tmp5.y = dot(inp.texcoord3.xyz, tmp6.xyz);
                tmp5.z = dot(inp.texcoord4.xyz, tmp6.xyz);
                tmp3.y = dot(tmp5.xyz, tmp5.xyz);
                tmp3.y = rsqrt(tmp3.y);
                tmp3.yzw = tmp3.yyy * tmp5.xyz;
                tmp5.xyz = tmp3.xxx * _LightColor0.xyz;
                tmp0.xyz = tmp0.xyz * tmp0.www + tmp2.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.w = dot(tmp3.xyz, tmp1.xyz);
                tmp0.x = dot(tmp3.xyz, tmp0.xyz);
                tmp0.xw = max(tmp0.xw, float2(0.0, 0.0));
                tmp0.y = tmp1.w * 128.0;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp2.w * tmp0.x;
                tmp1.xyz = tmp4.xyz * tmp5.xyz;
                tmp2.xyz = tmp5.xyz * _SpecColor.xyz;
                tmp0.xyz = tmp0.xxx * tmp2.xyz;
                o.sv_target.xyz = tmp1.xyz * tmp0.www + tmp0.xyz;
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			Tags { "LIGHTMODE" = "PREPASSBASE" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
			Cull Off
			GpuProgramID 164602
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _Color;
			float _SpecPower;
			float _OpacityScale;
			float _Tinted;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _SpecTex;
			sampler2D _BumpMap;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                tmp1 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.position = tmp1;
                o.texcoord5 = tmp1;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                o.texcoord2.w = tmp0.x;
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp1.xyz = tmp0.xxx * tmp1.xyz;
                tmp2.xyz = v.tangent.yyy * unity_ObjectToWorld._m11_m21_m01;
                tmp2.xyz = unity_ObjectToWorld._m10_m20_m00 * v.tangent.xxx + tmp2.xyz;
                tmp2.xyz = unity_ObjectToWorld._m12_m22_m02 * v.tangent.zzz + tmp2.xyz;
                tmp0.x = dot(tmp2.xyz, tmp2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2.xyz = tmp0.xxx * tmp2.xyz;
                tmp3.xyz = tmp1.xyz * tmp2.xyz;
                tmp3.xyz = tmp1.zxy * tmp2.yzx + -tmp3.xyz;
                tmp0.x = v.tangent.w * unity_WorldTransformParams.w;
                tmp3.xyz = tmp0.xxx * tmp3.xyz;
                o.texcoord2.y = tmp3.x;
                o.texcoord2.x = tmp2.z;
                o.texcoord2.z = tmp1.y;
                o.texcoord3.x = tmp2.x;
                o.texcoord4.x = tmp2.y;
                o.texcoord3.z = tmp1.z;
                o.texcoord4.z = tmp1.x;
                o.texcoord3.w = tmp0.y;
                o.texcoord4.w = tmp0.z;
                o.texcoord3.y = tmp3.y;
                o.texcoord4.y = tmp3.z;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0.x = _ProjectionParams.x * -_ProjectionParams.x;
                tmp1.xy = inp.texcoord5.xy / inp.texcoord5.ww;
                tmp1.z = tmp0.x * tmp1.y;
                tmp0.xy = tmp1.xz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp0.xy = tmp0.xy * _ScreenParams.xy;
                tmp0.xy = floor(tmp0.xy);
                tmp0.x = tmp0.y + tmp0.x;
                tmp0.x = tmp0.x * 0.5;
                tmp0.y = tmp0.x >= -tmp0.x;
                tmp0.x = frac(abs(tmp0.x));
                tmp0.x = tmp0.y ? tmp0.x : -tmp0.x;
                tmp0.x = tmp0.x == 0.5;
                tmp0.y = 1.0 - _Tinted;
                tmp0.x = tmp0.x ? tmp0.y : _Tinted;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0.y = tmp1.w * _Color.w;
                tmp0.y = saturate(tmp0.y * _OpacityScale);
                tmp0.z = _ThermalVisionOn > 0.0;
                tmp0.y = tmp0.z ? 1.0 : tmp0.y;
                tmp0.x = tmp0.y - tmp0.x;
                tmp0.x = tmp0.x + 0.5;
                tmp0.x = tmp0.x < 0.0;
                if (tmp0.x) {
                    discard;
                }
                tmp0 = tex2D(_BumpMap, inp.texcoord1.xy);
                tmp0.x = tmp0.w * tmp0.x;
                tmp0.xy = tmp0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp0.w = dot(tmp0.xy, tmp0.xy);
                tmp0.w = min(tmp0.w, 1.0);
                tmp0.w = 1.0 - tmp0.w;
                tmp0.z = sqrt(tmp0.w);
                tmp1.x = dot(inp.texcoord2.xyz, tmp0.xyz);
                tmp1.y = dot(inp.texcoord3.xyz, tmp0.xyz);
                tmp1.z = dot(inp.texcoord4.xyz, tmp0.xyz);
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp0.xyz = tmp0.xxx * tmp1.xyz;
                o.sv_target.xyz = tmp0.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                tmp0 = tex2D(_SpecTex, inp.texcoord.zw);
                o.sv_target.w = tmp0.x * _SpecPower;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			Tags { "LIGHTMODE" = "PREPASSFINAL" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
			ZWrite Off
			Cull Off
			GpuProgramID 211715
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
				float4 texcoord7 : TEXCOORD7;
				float3 texcoord8 : TEXCOORD8;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _SpecColor;
			float _ReflectionBottomShade;
			float4 _Color;
			float4 _ReflectColor;
			float _SpecPower;
			float _Glossness;
			float _OpacityScale;
			float4 _EFT_Ambient;
			float _GlobalReflectionStrength;
			float _Tinted;
			float4 _Temperature;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _SpecTex;
			sampler2D _BumpMap;
			samplerCUBE _Cube;
			sampler2D _LightBuffer;
			samplerCUBE _MyGlobalReflectionProbe;
			
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
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                tmp1 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.position = tmp1;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                o.texcoord2.w = tmp0.x;
                tmp2.xyz = v.tangent.yyy * unity_ObjectToWorld._m11_m21_m01;
                tmp2.xyz = unity_ObjectToWorld._m10_m20_m00 * v.tangent.xxx + tmp2.xyz;
                tmp2.xyz = unity_ObjectToWorld._m12_m22_m02 * v.tangent.zzz + tmp2.xyz;
                tmp0.x = dot(tmp2.xyz, tmp2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2.xyz = tmp0.xxx * tmp2.xyz;
                o.texcoord2.x = tmp2.z;
                tmp0.x = v.tangent.w * unity_WorldTransformParams.w;
                tmp3.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp3.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp3.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp3.xyz, tmp3.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * tmp3.xyz;
                tmp4.xyz = tmp2.xyz * tmp3.zxy;
                tmp4.xyz = tmp3.yzx * tmp2.yzx + -tmp4.xyz;
                tmp4.xyz = tmp0.xxx * tmp4.xyz;
                o.texcoord2.y = tmp4.x;
                o.texcoord2.z = tmp3.x;
                o.texcoord3.x = tmp2.x;
                o.texcoord4.x = tmp2.y;
                o.texcoord3.w = tmp0.y;
                o.texcoord4.w = tmp0.z;
                o.texcoord3.y = tmp4.y;
                o.texcoord4.y = tmp4.z;
                o.texcoord3.z = tmp3.y;
                o.texcoord4.z = tmp3.z;
                o.texcoord5 = tmp1;
                tmp0.x = tmp1.y * _ProjectionParams.x;
                tmp0.w = tmp0.x * 0.5;
                tmp0.xz = tmp1.xw * float2(0.5, 0.5);
                o.texcoord6.zw = tmp1.zw;
                o.texcoord6.xy = tmp0.zz + tmp0.xw;
                o.texcoord7 = float4(0.0, 0.0, 0.0, 0.0);
                tmp0.x = tmp3.y * tmp3.y;
                tmp0.x = tmp3.x * tmp3.x + -tmp0.x;
                tmp1 = tmp3.yzzx * tmp3.xyzz;
                tmp2.x = dot(unity_SHBr, tmp1);
                tmp2.y = dot(unity_SHBg, tmp1);
                tmp2.z = dot(unity_SHBb, tmp1);
                tmp0.xyz = unity_SHC.xyz * tmp0.xxx + tmp2.xyz;
                tmp3.w = 1.0;
                tmp1.x = dot(unity_SHAr, tmp3);
                tmp1.y = dot(unity_SHAg, tmp3);
                tmp1.z = dot(unity_SHAb, tmp3);
                tmp0.xyz = tmp0.xyz + tmp1.xyz;
                tmp0.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
                tmp0.xyz = log(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * float3(0.4166667, 0.4166667, 0.4166667);
                tmp0.xyz = exp(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * float3(1.055, 1.055, 1.055) + float3(-0.055, -0.055, -0.055);
                o.texcoord8.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
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
                float4 tmp7;
                float4 tmp8;
                tmp0.x = _ProjectionParams.x * -_ProjectionParams.x;
                tmp1.xy = inp.texcoord5.xy / inp.texcoord5.ww;
                tmp1.z = tmp0.x * tmp1.y;
                tmp0.xy = tmp1.xz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp0.xy = tmp0.xy * _ScreenParams.xy;
                tmp0.xy = floor(tmp0.xy);
                tmp0.x = tmp0.y + tmp0.x;
                tmp0.x = tmp0.x * 0.5;
                tmp0.y = tmp0.x >= -tmp0.x;
                tmp0.x = frac(abs(tmp0.x));
                tmp0.x = tmp0.y ? tmp0.x : -tmp0.x;
                tmp0.x = tmp0.x == 0.5;
                tmp0.y = 1.0 - _Tinted;
                tmp0.x = tmp0.x ? tmp0.y : _Tinted;
                tmp0.y = _ThermalVisionOn > 0.0;
                tmp1.w = 1.0;
                tmp0.z = _Tinted > 0.5;
                tmp2.x = inp.texcoord2.w;
                tmp2.y = inp.texcoord3.w;
                tmp2.z = inp.texcoord4.w;
                tmp3.xyz = _WorldSpaceCameraPos - tmp2.xyz;
                tmp2.xyz = tmp2.xyz - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp3.xyz, tmp3.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * tmp3.xyz;
                tmp4.xyz = tmp3.yyy * inp.texcoord3.xyz;
                tmp3.xyw = inp.texcoord2.xyz * tmp3.xxx + tmp4.xyz;
                tmp3.xyz = inp.texcoord4.xyz * tmp3.zzz + tmp3.xyw;
                tmp0.w = dot(abs(tmp3.xyz), abs(tmp3.xyz));
                tmp0.w = rsqrt(tmp0.w);
                tmp4.xyz = tmp0.www * abs(tmp3.xyz);
                tmp5 = tex2D(_BumpMap, inp.texcoord1.xy);
                tmp5.x = tmp5.w * tmp5.x;
                tmp5.xy = tmp5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp0.w = dot(tmp5.xy, tmp5.xy);
                tmp0.w = min(tmp0.w, 1.0);
                tmp0.w = 1.0 - tmp0.w;
                tmp5.z = sqrt(tmp0.w);
                tmp0.w = dot(tmp4.xyz, tmp5.xyz);
                tmp0.w = 1.0 - tmp0.w;
                tmp2.w = tmp0.w * tmp0.w;
                tmp0.w = tmp0.w * tmp2.w;
                tmp0.w = tmp0.w * 0.7 + 0.3;
                tmp2.w = 1.0 - tmp0.w;
                tmp4 = tex2D(_MainTex, inp.texcoord.xy);
                tmp6 = tmp4 * _Color;
                tmp7.xyz = tmp2.www * tmp6.xyz;
                tmp6.xyz = max(tmp6.xyz, tmp7.xyz);
                tmp7.w = saturate(tmp6.w * _OpacityScale);
                tmp2.w = tmp7.w > 0.5;
                tmp2.w = tmp2.w ? 1.0 : 2.0;
                tmp6.xyz = tmp2.www * tmp6.xyz;
                tmp7.xyz = tmp0.zzz ? float3(0.0, 0.0, 0.0) : tmp6.xyz;
                tmp6.xyz = tmp7.xyz * _Temperature.zzz;
                tmp6.xyz = max(tmp6.xyz, _Temperature.xxx);
                tmp6.xyz = min(tmp6.xyz, _Temperature.yyy);
                tmp1.xyz = tmp6.xyz + _Temperature.www;
                tmp1 = tmp0.yyyy ? tmp1 : tmp7;
                tmp0.x = tmp1.w - tmp0.x;
                tmp0.x = tmp0.x + 0.5;
                tmp0.x = tmp0.x < 0.0;
                if (tmp0.x) {
                    discard;
                }
                tmp0.x = dot(inp.texcoord2.xyz, tmp5.xyz);
                tmp0.y = dot(inp.texcoord3.xyz, tmp5.xyz);
                tmp0.z = dot(inp.texcoord4.xyz, tmp5.xyz);
                tmp1.w = dot(tmp0.xyz, tmp0.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp0.xyz = tmp0.xyz * tmp1.www;
                tmp1.w = dot(tmp2.xyz, tmp2.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp2.xyz = tmp1.www * tmp2.xyz;
                tmp1.w = dot(tmp2.xyz, tmp0.xyz);
                tmp1.w = tmp1.w + tmp1.w;
                tmp6.xyz = tmp0.xyz * -tmp1.www + tmp2.xyz;
                tmp0.x = dot(tmp0.xyz, -tmp2.xyz);
                tmp0.x = 1.0 - abs(tmp0.x);
                tmp0.y = saturate(tmp6.y + _ReflectionBottomShade);
                tmp8 = tex2D(_SpecTex, inp.texcoord.zw);
                tmp0.z = -tmp8.w * _Glossness + 1.0;
                tmp1.w = -tmp0.z * 0.7 + 1.7;
                tmp1.w = tmp0.z * tmp1.w;
                tmp1.w = tmp1.w * 6.0;
                tmp6 = texCUBElod(_MyGlobalReflectionProbe, float4(tmp6.xyz, tmp1.w));
                tmp2.xyz = tmp0.yyy * tmp6.xyz;
                tmp0.y = tmp0.z * tmp0.z;
                tmp0.y = max(tmp0.y, 0.002);
                tmp0.y = tmp0.y * 0.28;
                tmp0.y = -tmp0.y * tmp0.z + 1.0;
                tmp2.xyz = tmp2.xyz * tmp0.yyy;
                tmp0.y = tmp0.x * tmp0.x;
                tmp0.y = tmp0.y * tmp0.y;
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.y = tmp8.x * _SpecPower;
                tmp6.xyz = tmp0.yyy * _ReflectColor.xyz;
                tmp0.z = max(tmp6.y, tmp6.x);
                tmp0.z = max(tmp6.z, tmp0.z);
                tmp0.z = 1.0 - tmp0.z;
                tmp0.z = tmp8.w * _Glossness + -tmp0.z;
                tmp0.z = saturate(tmp0.z + 1.0);
                tmp7.xyz = -tmp0.yyy * _ReflectColor.xyz + tmp0.zzz;
                tmp0.xyz = tmp0.xxx * tmp7.xyz + tmp6.xyz;
                tmp0.xyz = tmp0.xyz * tmp2.xyz;
                tmp1.w = dot(tmp3.xyz, tmp5.xyz);
                tmp1.w = tmp1.w + tmp1.w;
                tmp2.xyz = tmp5.xyz * -tmp1.www + tmp3.xyz;
                tmp3 = texCUBE(_Cube, tmp2.xyz);
                tmp2.xyz = tmp3.xyz * _ReflectColor.xyz;
                tmp0.xyz = tmp0.xyz * _GlobalReflectionStrength.xxx + tmp2.xyz;
                tmp0.xyz = tmp4.xyz * _Color.xyz + tmp0.xyz;
                tmp0.xyz = tmp8.xxx * tmp0.xyz;
                tmp0.xyz = tmp0.xyz * _EFT_Ambient.xyz;
                tmp0.xyz = tmp0.xyz + tmp0.xyz;
                tmp1.w = _Tinted * 4.0 + 1.0;
                tmp1.w = 1.0 / tmp1.w;
                tmp0.xyz = tmp0.xyz * tmp1.www;
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp1.w = tmp8.w * _Glossness + tmp7.w;
                tmp2.x = tmp8.w * _Glossness + -tmp1.w;
                tmp0.w = tmp0.w * tmp2.x + tmp1.w;
                tmp2.xy = inp.texcoord6.xy / inp.texcoord6.ww;
                tmp3 = tex2D(_LightBuffer, tmp2.xy);
                tmp3 = log(tmp3);
                tmp0.w = tmp0.w * -tmp3.w;
                tmp2.xyz = inp.texcoord8.xyz - tmp3.xyz;
                tmp3.xyz = tmp2.xyz * _SpecColor.xyz;
                tmp3.xyz = tmp0.www * tmp3.xyz;
                tmp1.xyz = tmp1.xyz * tmp2.xyz + tmp3.xyz;
                o.sv_target.xyz = tmp0.xyz * tmp2.www + tmp1.xyz;
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "DEFERRED"
			Tags { "LIGHTMODE" = "DEFERRED" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
			Cull Off
			GpuProgramID 270730
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
				float3 texcoord6 : TEXCOORD6;
				float4 texcoord7 : TEXCOORD7;
				float3 texcoord8 : TEXCOORD8;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
				float4 sv_target1 : SV_Target1;
				float4 sv_target2 : SV_Target2;
				float4 sv_target3 : SV_Target3;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			float4 _SpecTex_ST;
			float4 _BumpMap_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _SpecColor;
			float _ReflectionBottomShade;
			float4 _Color;
			float4 _ReflectColor;
			float _SpecPower;
			float _Glossness;
			float _OpacityScale;
			float4 _EFT_Ambient;
			float _GlobalReflectionStrength;
			float _Tinted;
			float4 _Temperature;
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
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                tmp1 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.position = tmp1;
                o.texcoord5 = tmp1;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord.zw = v.texcoord.xy * _SpecTex_ST.xy + _SpecTex_ST.zw;
                o.texcoord1.xy = v.texcoord.xy * _BumpMap_ST.xy + _BumpMap_ST.zw;
                o.texcoord2.w = tmp0.x;
                tmp1.xyz = v.tangent.yyy * unity_ObjectToWorld._m01_m11_m21;
                tmp1.xyz = unity_ObjectToWorld._m00_m10_m20 * v.tangent.xxx + tmp1.xyz;
                tmp1.xyz = unity_ObjectToWorld._m02_m12_m22 * v.tangent.zzz + tmp1.xyz;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp1.xyz;
                o.texcoord2.x = tmp1.x;
                tmp0.w = v.tangent.w * unity_WorldTransformParams.w;
                tmp2.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp2.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp2.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp1.w = dot(tmp2.xyz, tmp2.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp2 = tmp1.wwww * tmp2.xyzz;
                tmp3.xyz = tmp1.yzx * tmp2.wxy;
                tmp3.xyz = tmp2.ywx * tmp1.zxy + -tmp3.xyz;
                tmp3.xyz = tmp0.www * tmp3.xyz;
                o.texcoord2.y = tmp3.x;
                o.texcoord2.z = tmp2.x;
                o.texcoord3.x = tmp1.y;
                o.texcoord3.w = tmp0.y;
                o.texcoord3.y = tmp3.y;
                o.texcoord3.z = tmp2.y;
                o.texcoord4.x = tmp1.z;
                o.texcoord4.w = tmp0.z;
                tmp0.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                o.texcoord4.y = tmp3.z;
                o.texcoord6.y = dot(tmp0.xyz, tmp3.xyz);
                o.texcoord4.z = tmp2.w;
                o.texcoord6.x = dot(tmp0.xyz, tmp1.xyz);
                o.texcoord6.z = dot(tmp0.xyz, tmp2.xyz);
                o.texcoord7 = float4(0.0, 0.0, 0.0, 0.0);
                tmp0.x = tmp2.y * tmp2.y;
                tmp0.x = tmp2.x * tmp2.x + -tmp0.x;
                tmp1 = tmp2.ywzx * tmp2;
                tmp2.x = dot(unity_SHBr, tmp1);
                tmp2.y = dot(unity_SHBg, tmp1);
                tmp2.z = dot(unity_SHBb, tmp1);
                o.texcoord8.xyz = unity_SHC.xyz * tmp0.xxx + tmp2.xyz;
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
                float4 tmp7;
                float4 tmp8;
                float4 tmp9;
                float4 tmp10;
                float4 tmp11;
                tmp0.x = dot(inp.texcoord6.xyz, inp.texcoord6.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp0.xyz = tmp0.xxx * inp.texcoord6.xyz;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp2 = tmp1 * _Color;
                tmp3 = tex2D(_SpecTex, inp.texcoord.zw);
                tmp4 = tex2D(_BumpMap, inp.texcoord1.xy);
                tmp4.x = tmp4.w * tmp4.x;
                tmp4.xy = tmp4.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp0.w = dot(tmp4.xy, tmp4.xy);
                tmp0.w = min(tmp0.w, 1.0);
                tmp0.w = 1.0 - tmp0.w;
                tmp4.z = sqrt(tmp0.w);
                tmp5.w = saturate(tmp2.w * _OpacityScale);
                tmp0.w = tmp3.x * _SpecPower;
                tmp6.x = dot(inp.texcoord2.xyz, tmp4.xyz);
                tmp6.y = dot(inp.texcoord3.xyz, tmp4.xyz);
                tmp6.z = dot(inp.texcoord4.xyz, tmp4.xyz);
                tmp7.xyz = tmp0.www * _ReflectColor.xyz;
                tmp1.w = dot(tmp6.xyz, tmp6.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp6.xyz = tmp1.www * tmp6.xyz;
                tmp8.y = inp.texcoord2.w;
                tmp8.z = inp.texcoord3.w;
                tmp8.w = inp.texcoord4.w;
                tmp9.xyz = tmp8.yzw - _WorldSpaceCameraPos;
                tmp1.w = dot(tmp9.xyz, tmp9.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp9.xyz = tmp1.www * tmp9.xyz;
                tmp1.w = max(tmp7.y, tmp7.x);
                tmp1.w = max(tmp7.z, tmp1.w);
                tmp1.w = 1.0 - tmp1.w;
                tmp2.w = dot(tmp9.xyz, tmp6.xyz);
                tmp2.w = tmp2.w + tmp2.w;
                tmp10.xyz = tmp6.xyz * -tmp2.www + tmp9.xyz;
                tmp2.w = -tmp3.w * _Glossness + 1.0;
                tmp3.y = -tmp2.w * 0.7 + 1.7;
                tmp3.y = tmp2.w * tmp3.y;
                tmp3.y = tmp3.y * 6.0;
                tmp11 = texCUBElod(_MyGlobalReflectionProbe, float4(tmp10.xyz, tmp3.y));
                tmp3.y = saturate(tmp10.y + _ReflectionBottomShade);
                tmp10.xyz = tmp3.yyy * tmp11.xyz;
                tmp3.y = dot(tmp6.xyz, -tmp9.xyz);
                tmp3.z = tmp2.w * tmp2.w;
                tmp3.z = max(tmp3.z, 0.002);
                tmp3.z = tmp3.z * 0.28;
                tmp2.w = -tmp3.z * tmp2.w + 1.0;
                tmp1.w = tmp3.w * _Glossness + -tmp1.w;
                tmp1.w = saturate(tmp1.w + 1.0);
                tmp9.xyz = tmp10.xyz * tmp2.www;
                tmp2.w = 1.0 - abs(tmp3.y);
                tmp3.y = tmp2.w * tmp2.w;
                tmp3.y = tmp3.y * tmp3.y;
                tmp2.w = tmp2.w * tmp3.y;
                tmp10.xyz = -tmp0.www * _ReflectColor.xyz + tmp1.www;
                tmp7.xyz = tmp2.www * tmp10.xyz + tmp7.xyz;
                tmp7.xyz = tmp7.xyz * tmp9.xyz;
                tmp1.w = dot(tmp0.xyz, tmp4.xyz);
                tmp1.w = tmp1.w + tmp1.w;
                tmp9.xyz = tmp4.xyz * -tmp1.www + tmp0.xyz;
                tmp9 = texCUBE(_Cube, tmp9.xyz);
                tmp9.xyz = tmp9.xyz * _ReflectColor.xyz;
                tmp7.xyz = tmp7.xyz * _GlobalReflectionStrength.xxx + tmp9.xyz;
                tmp1.xyz = tmp1.xyz * _Color.xyz + tmp7.xyz;
                tmp1.xyz = tmp3.xxx * tmp1.xyz;
                tmp1.xyz = tmp1.xyz * _EFT_Ambient.xyz;
                tmp1.xyz = tmp1.xyz + tmp1.xyz;
                tmp1.w = _Tinted * 4.0 + 1.0;
                tmp1.w = 1.0 / tmp1.w;
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp1.w = dot(abs(tmp0.xyz), abs(tmp0.xyz));
                tmp1.w = rsqrt(tmp1.w);
                tmp0.xyz = abs(tmp0.xyz) * tmp1.www;
                tmp0.x = dot(tmp0.xyz, tmp4.xyz);
                tmp0.x = 1.0 - tmp0.x;
                tmp0.y = tmp0.x * tmp0.x;
                tmp0.x = tmp0.y * tmp0.x;
                tmp0.x = tmp0.x * 0.7 + 0.3;
                tmp0.y = 1.0 - tmp0.x;
                tmp3.xyz = tmp0.yyy * tmp2.xyz;
                tmp2.xyz = max(tmp2.xyz, tmp3.xyz);
                tmp0.y = tmp3.w * _Glossness + tmp5.w;
                tmp0.z = tmp3.w * _Glossness + -tmp0.y;
                tmp0.y = tmp0.x * tmp0.z + tmp0.y;
                tmp1.xyz = tmp0.xxx * tmp1.xyz;
                tmp0.x = tmp5.w > 0.5;
                tmp0.x = tmp0.x ? 1.0 : 2.0;
                tmp2.xyz = tmp0.xxx * tmp2.xyz;
                tmp0.z = _Tinted > 0.5;
                tmp5.xyz = tmp0.zzz ? float3(0.0, 0.0, 0.0) : tmp2.xyz;
                tmp2.xy = inp.texcoord5.xy / inp.texcoord5.ww;
                tmp0.z = _ProjectionParams.x * -_ProjectionParams.x;
                tmp2.z = tmp0.z * tmp2.y;
                tmp2.xy = tmp2.xz * float2(0.5, 0.5) + float2(0.5, 0.5);
                tmp0.z = _ThermalVisionOn > 0.0;
                tmp3.xyz = tmp5.xyz * _Temperature.zzz;
                tmp3.xyz = max(tmp3.xyz, _Temperature.xxx);
                tmp3.xyz = min(tmp3.xyz, _Temperature.yyy);
                tmp3.xyz = tmp3.xyz + _Temperature.www;
                tmp3.w = 1.0;
                tmp3 = tmp0.zzzz ? tmp3 : tmp5;
                tmp2.xy = tmp2.xy * _ScreenParams.xy;
                tmp2.xy = floor(tmp2.xy);
                tmp0.z = tmp2.y + tmp2.x;
                tmp0.z = tmp0.z * 0.5;
                tmp1.w = tmp0.z >= -tmp0.z;
                tmp0.z = frac(abs(tmp0.z));
                tmp0.z = tmp1.w ? tmp0.z : -tmp0.z;
                tmp0.z = tmp0.z == 0.5;
                tmp1.w = 1.0 - _Tinted;
                tmp0.z = tmp0.z ? tmp1.w : _Tinted;
                tmp0.z = tmp3.w - tmp0.z;
                tmp0.z = tmp0.z + 0.5;
                tmp0.z = tmp0.z < 0.0;
                if (tmp0.z) {
                    discard;
                }
                tmp0.z = unity_ProbeVolumeParams.x == 1.0;
                if (tmp0.z) {
                    tmp0.z = unity_ProbeVolumeParams.y == 1.0;
                    tmp2.xyz = inp.texcoord3.www * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp2.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.www + tmp2.xyz;
                    tmp2.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord4.www + tmp2.xyz;
                    tmp2.xyz = tmp2.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp2.xyz = tmp0.zzz ? tmp2.xyz : tmp8.yzw;
                    tmp2.xyz = tmp2.xyz - unity_ProbeVolumeMin;
                    tmp2.yzw = tmp2.xyz * unity_ProbeVolumeSizeInv;
                    tmp0.z = tmp2.y * 0.25;
                    tmp1.w = unity_ProbeVolumeParams.z * 0.5;
                    tmp2.y = -unity_ProbeVolumeParams.z * 0.5 + 0.25;
                    tmp0.z = max(tmp0.z, tmp1.w);
                    tmp2.x = min(tmp2.y, tmp0.z);
                    tmp4 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp2.xzw);
                    tmp5.xyz = tmp2.xzw + float3(0.25, 0.0, 0.0);
                    tmp5 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp5.xyz);
                    tmp2.xyz = tmp2.xzw + float3(0.5, 0.0, 0.0);
                    tmp2 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp2.xyz);
                    tmp6.w = 1.0;
                    tmp4.x = dot(tmp4, tmp6);
                    tmp4.y = dot(tmp5, tmp6);
                    tmp4.z = dot(tmp2, tmp6);
                } else {
                    tmp6.w = 1.0;
                    tmp4.x = dot(unity_SHAr, tmp6);
                    tmp4.y = dot(unity_SHAg, tmp6);
                    tmp4.z = dot(unity_SHAb, tmp6);
                }
                tmp2.xyz = tmp4.xyz + inp.texcoord8.xyz;
                tmp2.xyz = max(tmp2.xyz, float3(0.0, 0.0, 0.0));
                tmp2.xyz = log(tmp2.xyz);
                tmp2.xyz = tmp2.xyz * float3(0.4166667, 0.4166667, 0.4166667);
                tmp2.xyz = exp(tmp2.xyz);
                tmp2.xyz = tmp2.xyz * float3(1.055, 1.055, 1.055) + float3(-0.055, -0.055, -0.055);
                tmp2.xyz = max(tmp2.xyz, float3(0.0, 0.0, 0.0));
                tmp4.xyz = tmp0.yyy * _SpecColor.xyz;
                o.sv_target1.xyz = tmp4.xyz * float3(0.3183099, 0.3183099, 0.3183099);
                o.sv_target2.xyz = tmp6.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                tmp2.xyz = tmp2.xyz * tmp3.xyz;
                tmp0.xyz = tmp1.xyz * tmp0.xxx + tmp2.xyz;
                o.sv_target3.xyz = exp(-tmp0.xyz);
                o.sv_target.xyz = tmp3.xyz;
                o.sv_target.w = 1.0;
                o.sv_target1.w = tmp0.w;
                o.sv_target2.w = 1.0;
                o.sv_target3.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "ShadowCaster"
			Tags { "LIGHTMODE" = "SHADOWCASTER" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" "SHADOWSUPPORT" = "true" }
			Cull Off
			GpuProgramID 329471
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _Color;
			float _OpacityScale;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			
			// Keywords: SHADOWS_DEPTH
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                tmp0.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp0.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp0.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp1 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp1 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp1;
                tmp1 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp1;
                tmp2 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp1;
                tmp3.xyz = -tmp2.xyz * _WorldSpaceLightPos0.www + _WorldSpaceLightPos0.xyz;
                tmp0.w = dot(tmp3.xyz, tmp3.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * tmp3.xyz;
                tmp0.w = dot(tmp0.xyz, tmp3.xyz);
                tmp0.w = -tmp0.w * tmp0.w + 1.0;
                tmp0.w = sqrt(tmp0.w);
                tmp0.w = tmp0.w * unity_LightShadowBias.z;
                tmp0.xyz = -tmp0.xyz * tmp0.www + tmp2.xyz;
                tmp0.w = unity_LightShadowBias.z != 0.0;
                tmp0.xyz = tmp0.www ? tmp0.xyz : tmp2.xyz;
                tmp3 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp3 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp3;
                tmp0 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp3;
                tmp0 = unity_MatrixVP._m03_m13_m23_m33 * tmp2.wwww + tmp0;
                tmp2.x = unity_LightShadowBias.x / tmp0.w;
                tmp2.x = min(tmp2.x, 0.0);
                tmp2.x = max(tmp2.x, -1.0);
                tmp0.z = tmp0.z + tmp2.x;
                tmp2.x = min(tmp0.w, tmp0.z);
                o.position.xyw = tmp0.xyw;
                tmp0.x = tmp2.x - tmp0.z;
                o.position.z = unity_LightShadowBias.y * tmp0.x + tmp0.z;
                o.texcoord1.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord2.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp1.xyz;
                tmp0 = tmp1 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                o.texcoord3 = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                return o;
			}
			// Keywords: SHADOWS_DEPTH
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_MainTex, inp.texcoord1.xy);
                tmp0.x = tmp0.w * _Color.w;
                tmp0.x = saturate(tmp0.x * _OpacityScale);
                tmp0.x = tmp0.x - 0.5;
                tmp0.x = tmp0.x < 0.0;
                tmp0.y = _ThermalVisionOn > 0.0;
                tmp0.x = tmp0.y ? 0.0 : tmp0.x;
                if (tmp0.x) {
                    discard;
                }
                o.sv_target = float4(0.0, 0.0, 0.0, 0.0);
                return o;
			}
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "DEFERRED" "QUEUE" = "Geometry" "RenderType" = "TransparentCutout" }
			Blend DstColor Zero, DstColor Zero
			ColorMask A -1
			ZTest Equal
			ZWrite Off
			Cull Off
			GpuProgramID 424499
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float2 texcoord : TEXCOORD0;
				float4 position : SV_POSITION0;
			};
			struct fout
			{
				float4 sv_target2 : SV_Target2;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float _Tinted;
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
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
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
                float4 tmp0;
                tmp0.x = _Tinted == 1.0;
                o.sv_target2 = tmp0.xxxx ? float4(0.25, 0.25, 0.25, 0.25) : 0.0;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Reflective/Bumped Diffuse"
}