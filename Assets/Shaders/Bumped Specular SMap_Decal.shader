Shader "p0/Reflective/Bumped Specular SMap_Decal" {
	Properties {
		[MaterialEnum(Static, 0, Characters, 1, Hands, 2)] _StencilType ("_StencilType", Float) = 0
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecMap ("GlossMap", 2D) = "white" {}
		_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
		_Glossness ("Specularness", Range(0.01, 10)) = 1
		_Specularness ("Glossness", Range(0.01, 10)) = 0.078125
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_MainTex ("Base (RGB) Specular (A)", 2D) = "white" {}
		_Cube ("Reflection Cubemap", Cube) = "" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_SpecVals ("Specular Vals", Vector) = (1.1,2,0,0)
		_DefVals ("Defuse Vals", Vector) = (0.5,0.7,0,0)
		_BumpTiling ("_BumpTiling", Float) = 1
		_DecalPower ("Decal Power", Range(0, 1)) = 0
		_DecalsTex ("Decals", 2D) = "black" {}
		_Temperature ("_Temperature", Vector) = (0.1,0.27,0.4,0)
	}
	SubShader {
		LOD 400
		Tags { "RenderType" = "Opaque" }
		Pass {
			Name "FORWARD"
			LOD 400
			Tags { "LIGHTMODE" = "FORWARDBASE" "RenderType" = "Opaque" "SHADOWSUPPORT" = "true" }
			Stencil {
				WriteMask 3
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 18581
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float4 texcoord7 : TEXCOORD7;
				float4 texcoord8 : TEXCOORD8;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			float4 _DecalsTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float4 _Color;
			float4 _ReflectColor;
			float _Specularness;
			float _Glossness;
			float _DecalPower;
			float3 _SpecVals;
			float3 _DefVals;
			float _BumpTiling;
			float4 _Temperature;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _DecalsTex;
			sampler2D _SpecMap;
			sampler2D _BumpMap;
			samplerCUBE _Cube;
			
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
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord1.xy = v.texcoord1.xy * _DecalsTex_ST.xy + _DecalsTex_ST.zw;
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
                o.texcoord7 = float4(0.0, 0.0, 0.0, 0.0);
                o.texcoord8 = float4(0.0, 0.0, 0.0, 0.0);
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
                tmp4 = tex2D(_MainTex, inp.texcoord.xy);
                tmp5 = tex2D(_DecalsTex, inp.texcoord1.xy);
                tmp6 = tex2D(_DecalsTex, float2(0.0, 0.0));
                tmp6 = tmp6 - float4(0.13, 0.23, 0.93, 0.0);
                tmp6 = abs(tmp6) < float4(0.005, 0.005, 0.005, 0.005);
                tmp6.xy = tmp6.zw ? tmp6.xy : 0.0;
                tmp1.w = tmp6.y ? tmp6.x : 0.0;
                tmp2.w = _ThermalVisionOn > 0.0;
                tmp3.w = _DecalPower * 5.0;
                tmp3.w = tmp2.w ? tmp3.w : _DecalPower;
                tmp3.w = tmp3.w * tmp5.w;
                tmp1.w = tmp1.w ? 1.0 : 0.0;
                tmp1.w = tmp1.w * tmp3.w;
                tmp5.xyz = tmp5.xyz - tmp4.xyz;
                tmp4.xyz = tmp1.www * tmp5.xyz + tmp4.xyz;
                tmp4.xyz = tmp4.xyz * _Color.xyz;
                tmp1.w = tmp4.w * _Glossness;
                tmp5 = tex2D(_SpecMap, inp.texcoord.xy);
                tmp3.w = tmp5.x * _Specularness;
                tmp5.xy = inp.texcoord.xy * _BumpTiling.xx;
                tmp5 = tex2D(_BumpMap, tmp5.xy);
                tmp5.x = tmp5.w * tmp5.x;
                tmp5.xy = tmp5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp5.w = dot(tmp5.xy, tmp5.xy);
                tmp5.w = min(tmp5.w, 1.0);
                tmp5.w = 1.0 - tmp5.w;
                tmp5.z = sqrt(tmp5.w);
                tmp6.x = dot(inp.texcoord2.xyz, tmp5.xyz);
                tmp6.y = dot(inp.texcoord3.xyz, tmp5.xyz);
                tmp6.z = dot(inp.texcoord4.xyz, tmp5.xyz);
                tmp5.w = dot(-tmp2.xyz, tmp6.xyz);
                tmp5.w = tmp5.w + tmp5.w;
                tmp2.xyz = tmp6.xyz * -tmp5.www + -tmp2.xyz;
                tmp7 = texCUBE(_Cube, tmp2.xyz);
                tmp2.xyz = tmp4.www * tmp7.xyz;
                tmp2.xyz = tmp2.xyz * _ReflectColor.xyz;
                tmp4.w = dot(tmp3.xyz, tmp3.xyz);
                tmp4.w = rsqrt(tmp4.w);
                tmp3.xyz = tmp3.xyz * tmp4.www;
                tmp3.x = dot(tmp3.xyz, tmp5.xyz);
                tmp3.x = 1.0 - tmp3.x;
                tmp3.x = tmp3.x * tmp3.x;
                tmp3.x = tmp3.x * 0.5;
                tmp3.y = _SpecVals.y * tmp3.x + _SpecVals.x;
                tmp3.y = tmp3.y * 0.5;
                tmp3.x = _DefVals.y * tmp3.x + _DefVals.x;
                tmp4.xyz = tmp3.xxx * tmp4.xyz;
                tmp1.w = tmp1.w * tmp3.y;
                tmp5.xyz = tmp4.xyz * _Temperature.zzz;
                tmp5.xyz = max(tmp5.xyz, _Temperature.xxx);
                tmp5.xyz = min(tmp5.xyz, _Temperature.yyy);
                tmp5.xyz = tmp5.xyz + _Temperature.www;
                tmp4.xyz = tmp2.www ? tmp5.xyz : tmp4.xyz;
                tmp2.w = unity_ProbeVolumeParams.x == 1.0;
                if (tmp2.w) {
                    tmp2.w = unity_ProbeVolumeParams.y == 1.0;
                    tmp5.xyz = inp.texcoord3.www * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp5.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.www + tmp5.xyz;
                    tmp5.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord4.www + tmp5.xyz;
                    tmp5.xyz = tmp5.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp0.yzw = tmp2.www ? tmp5.xyz : tmp0.yzw;
                    tmp0.yzw = tmp0.yzw - unity_ProbeVolumeMin;
                    tmp5.yzw = tmp0.yzw * unity_ProbeVolumeSizeInv;
                    tmp0.y = tmp5.y * 0.25 + 0.75;
                    tmp0.z = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp5.x = max(tmp0.z, tmp0.y);
                    tmp5 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp5.xzw);
                } else {
                    tmp5 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp0.y = saturate(dot(tmp5, unity_OcclusionMaskSelector));
                tmp0.z = dot(tmp6.xyz, tmp6.xyz);
                tmp0.z = rsqrt(tmp0.z);
                tmp5.xyz = tmp0.zzz * tmp6.xyz;
                tmp0.yzw = tmp0.yyy * _LightColor0.xyz;
                tmp1.xyz = tmp1.xyz * tmp0.xxx + _WorldSpaceLightPos0.xyz;
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp1.xyz = tmp0.xxx * tmp1.xyz;
                tmp0.x = dot(tmp5.xyz, _WorldSpaceLightPos0.xyz);
                tmp0.x = max(tmp0.x, 0.0);
                tmp1.x = dot(tmp5.xyz, tmp1.xyz);
                tmp1.x = max(tmp1.x, 0.0);
                tmp1.y = tmp3.w * 128.0;
                tmp1.x = log(tmp1.x);
                tmp1.x = tmp1.x * tmp1.y;
                tmp1.x = exp(tmp1.x);
                tmp1.x = tmp1.w * tmp1.x;
                tmp1.yzw = tmp0.yzw * tmp4.xyz;
                tmp0.yzw = tmp0.yzw * _SpecColor.xyz;
                tmp0.yzw = tmp1.xxx * tmp0.yzw;
                tmp0.xyz = tmp1.yzw * tmp0.xxx + tmp0.yzw;
                o.sv_target.xyz = tmp2.xyz * tmp3.yyy + tmp0.xyz;
                o.sv_target.w = 0.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			LOD 400
			Tags { "LIGHTMODE" = "FORWARDADD" "RenderType" = "Opaque" }
			Blend One One, One One
			ZWrite Off
			Stencil {
				WriteMask 3
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 118993
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord4 : TEXCOORD4;
				float3 texcoord5 : TEXCOORD5;
				float3 texcoord6 : TEXCOORD6;
				float4 texcoord7 : TEXCOORD7;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4x4 unity_WorldToLight;
			float4 _MainTex_ST;
			float4 _DecalsTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float4 _Color;
			float _Specularness;
			float _Glossness;
			float _DecalPower;
			float3 _SpecVals;
			float3 _DefVals;
			float _BumpTiling;
			float4 _Temperature;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _DecalsTex;
			sampler2D _SpecMap;
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
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord1.xy = v.texcoord1.xy * _DecalsTex_ST.xy + _DecalsTex_ST.zw;
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
                o.texcoord6.xyz = unity_WorldToLight._m03_m13_m23 * tmp0.www + tmp0.xyz;
                o.texcoord7 = float4(0.0, 0.0, 0.0, 0.0);
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
                tmp5 = tex2D(_DecalsTex, inp.texcoord1.xy);
                tmp6 = tex2D(_DecalsTex, float2(0.0, 0.0));
                tmp6 = tmp6 - float4(0.13, 0.23, 0.93, 0.0);
                tmp6 = abs(tmp6) < float4(0.005, 0.005, 0.005, 0.005);
                tmp6.xy = tmp6.zw ? tmp6.xy : 0.0;
                tmp1.w = tmp6.y ? tmp6.x : 0.0;
                tmp2.w = _ThermalVisionOn > 0.0;
                tmp3.w = _DecalPower * 5.0;
                tmp3.w = tmp2.w ? tmp3.w : _DecalPower;
                tmp3.w = tmp3.w * tmp5.w;
                tmp1.w = tmp1.w ? 1.0 : 0.0;
                tmp1.w = tmp1.w * tmp3.w;
                tmp5.xyz = tmp5.xyz - tmp4.xyz;
                tmp4.xyz = tmp1.www * tmp5.xyz + tmp4.xyz;
                tmp4.xyz = tmp4.xyz * _Color.xyz;
                tmp1.w = tmp4.w * _Glossness;
                tmp5 = tex2D(_SpecMap, inp.texcoord.xy);
                tmp3.w = tmp5.x * _Specularness;
                tmp5.xy = inp.texcoord.xy * _BumpTiling.xx;
                tmp5 = tex2D(_BumpMap, tmp5.xy);
                tmp5.x = tmp5.w * tmp5.x;
                tmp5.xy = tmp5.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp4.w = dot(tmp5.xy, tmp5.xy);
                tmp4.w = min(tmp4.w, 1.0);
                tmp4.w = 1.0 - tmp4.w;
                tmp5.z = sqrt(tmp4.w);
                tmp4.w = dot(tmp3.xyz, tmp3.xyz);
                tmp4.w = rsqrt(tmp4.w);
                tmp3.xyz = tmp3.xyz * tmp4.www;
                tmp3.x = dot(tmp3.xyz, tmp5.xyz);
                tmp3.x = 1.0 - tmp3.x;
                tmp3.x = tmp3.x * tmp3.x;
                tmp3.x = tmp3.x * 0.5;
                tmp3.y = _SpecVals.y * tmp3.x + _SpecVals.x;
                tmp3.y = tmp3.y * 0.5;
                tmp3.x = _DefVals.y * tmp3.x + _DefVals.x;
                tmp4.xyz = tmp3.xxx * tmp4.xyz;
                tmp1.w = tmp1.w * tmp3.y;
                tmp3.xyz = tmp4.xyz * _Temperature.zzz;
                tmp3.xyz = max(tmp3.xyz, _Temperature.xxx);
                tmp3.xyz = min(tmp3.xyz, _Temperature.yyy);
                tmp3.xyz = tmp3.xyz + _Temperature.www;
                tmp3.xyz = tmp2.www ? tmp3.xyz : tmp4.xyz;
                tmp4.xyz = inp.texcoord5.yyy * unity_WorldToLight._m01_m11_m21;
                tmp4.xyz = unity_WorldToLight._m00_m10_m20 * inp.texcoord5.xxx + tmp4.xyz;
                tmp4.xyz = unity_WorldToLight._m02_m12_m22 * inp.texcoord5.zzz + tmp4.xyz;
                tmp4.xyz = tmp4.xyz + unity_WorldToLight._m03_m13_m23;
                tmp2.w = unity_ProbeVolumeParams.x == 1.0;
                if (tmp2.w) {
                    tmp2.w = unity_ProbeVolumeParams.y == 1.0;
                    tmp6.xyz = inp.texcoord5.yyy * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp6.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord5.xxx + tmp6.xyz;
                    tmp6.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord5.zzz + tmp6.xyz;
                    tmp6.xyz = tmp6.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp6.xyz = tmp2.www ? tmp6.xyz : inp.texcoord5.xyz;
                    tmp6.xyz = tmp6.xyz - unity_ProbeVolumeMin;
                    tmp6.yzw = tmp6.xyz * unity_ProbeVolumeSizeInv;
                    tmp2.w = tmp6.y * 0.25 + 0.75;
                    tmp4.w = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp6.x = max(tmp2.w, tmp4.w);
                    tmp6 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp6.xzw);
                } else {
                    tmp6 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp2.w = saturate(dot(tmp6, unity_OcclusionMaskSelector));
                tmp4.x = dot(tmp4.xyz, tmp4.xyz);
                tmp4 = tex2D(_LightTexture0, tmp4.xx);
                tmp2.w = tmp2.w * tmp4.x;
                tmp4.x = dot(inp.texcoord2.xyz, tmp5.xyz);
                tmp4.y = dot(inp.texcoord3.xyz, tmp5.xyz);
                tmp4.z = dot(inp.texcoord4.xyz, tmp5.xyz);
                tmp4.w = dot(tmp4.xyz, tmp4.xyz);
                tmp4.w = rsqrt(tmp4.w);
                tmp4.xyz = tmp4.www * tmp4.xyz;
                tmp5.xyz = tmp2.www * _LightColor0.xyz;
                tmp0.xyz = tmp0.xyz * tmp0.www + tmp2.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.w = dot(tmp4.xyz, tmp1.xyz);
                tmp0.x = dot(tmp4.xyz, tmp0.xyz);
                tmp0.xw = max(tmp0.xw, float2(0.0, 0.0));
                tmp0.y = tmp3.w * 128.0;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp1.w * tmp0.x;
                tmp1.xyz = tmp3.xyz * tmp5.xyz;
                tmp2.xyz = tmp5.xyz * _SpecColor.xyz;
                tmp0.xyz = tmp0.xxx * tmp2.xyz;
                o.sv_target.xyz = tmp1.xyz * tmp0.www + tmp0.xyz;
                o.sv_target.w = 0.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			LOD 400
			Tags { "LIGHTMODE" = "PREPASSBASE" "RenderType" = "Opaque" }
			Stencil {
				WriteMask 3
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 136045
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float _Specularness;
			float _BumpTiling;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _SpecMap;
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
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord1.w = tmp0.x;
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
                o.texcoord1.y = tmp3.x;
                o.texcoord1.x = tmp2.z;
                o.texcoord1.z = tmp1.y;
                o.texcoord2.x = tmp2.x;
                o.texcoord3.x = tmp2.y;
                o.texcoord2.z = tmp1.z;
                o.texcoord3.z = tmp1.x;
                o.texcoord2.w = tmp0.y;
                o.texcoord3.w = tmp0.z;
                o.texcoord2.y = tmp3.y;
                o.texcoord3.y = tmp3.z;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0.xy = inp.texcoord.xy * _BumpTiling.xx;
                tmp0 = tex2D(_BumpMap, tmp0.xy);
                tmp0.x = tmp0.w * tmp0.x;
                tmp0.xy = tmp0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp0.w = dot(tmp0.xy, tmp0.xy);
                tmp0.w = min(tmp0.w, 1.0);
                tmp0.w = 1.0 - tmp0.w;
                tmp0.z = sqrt(tmp0.w);
                tmp1.x = dot(inp.texcoord1.xyz, tmp0.xyz);
                tmp1.y = dot(inp.texcoord2.xyz, tmp0.xyz);
                tmp1.z = dot(inp.texcoord3.xyz, tmp0.xyz);
                tmp0.x = dot(tmp1.xyz, tmp1.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp0.xyz = tmp0.xxx * tmp1.xyz;
                o.sv_target.xyz = tmp0.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                tmp0 = tex2D(_SpecMap, inp.texcoord.xy);
                o.sv_target.w = tmp0.x * _Specularness;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			LOD 400
			Tags { "LIGHTMODE" = "PREPASSFINAL" "RenderType" = "Opaque" }
			ZWrite Off
			Stencil {
				WriteMask 3
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 224079
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
				float3 texcoord7 : TEXCOORD7;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			float4 _DecalsTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _SpecColor;
			float4 _Color;
			float4 _ReflectColor;
			float _Glossness;
			float _DecalPower;
			float3 _SpecVals;
			float3 _DefVals;
			float _BumpTiling;
			float4 _Temperature;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _DecalsTex;
			sampler2D _BumpMap;
			samplerCUBE _Cube;
			sampler2D _LightBuffer;
			
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
                o.texcoord1.xy = v.texcoord1.xy * _DecalsTex_ST.xy + _DecalsTex_ST.zw;
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
                tmp0.x = tmp1.y * _ProjectionParams.x;
                tmp0.w = tmp0.x * 0.5;
                tmp0.xz = tmp1.xw * float2(0.5, 0.5);
                o.texcoord5.zw = tmp1.zw;
                o.texcoord5.xy = tmp0.zz + tmp0.xw;
                o.texcoord6 = float4(0.0, 0.0, 0.0, 0.0);
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
                o.texcoord7.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
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
                tmp0 = tex2D(_DecalsTex, float2(0.0, 0.0));
                tmp0 = tmp0 - float4(0.13, 0.23, 0.93, 0.0);
                tmp0 = abs(tmp0) < float4(0.005, 0.005, 0.005, 0.005);
                tmp0.xy = tmp0.zw ? tmp0.xy : 0.0;
                tmp0.x = tmp0.y ? tmp0.x : 0.0;
                tmp0.x = tmp0.x ? 1.0 : 0.0;
                tmp0.y = _DecalPower * 5.0;
                tmp0.z = _ThermalVisionOn > 0.0;
                tmp0.y = tmp0.z ? tmp0.y : _DecalPower;
                tmp1 = tex2D(_DecalsTex, inp.texcoord1.xy);
                tmp0.y = tmp0.y * tmp1.w;
                tmp0.x = tmp0.x * tmp0.y;
                tmp2 = tex2D(_MainTex, inp.texcoord.xy);
                tmp1.xyz = tmp1.xyz - tmp2.xyz;
                tmp0.xyw = tmp0.xxx * tmp1.xyz + tmp2.xyz;
                tmp0.xyw = tmp0.xyw * _Color.xyz;
                tmp1.x = inp.texcoord2.w;
                tmp1.y = inp.texcoord3.w;
                tmp1.z = inp.texcoord4.w;
                tmp1.xyz = _WorldSpaceCameraPos - tmp1.xyz;
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp2.xyz = tmp1.yyy * inp.texcoord3.xyz;
                tmp2.xyz = inp.texcoord2.xyz * tmp1.xxx + tmp2.xyz;
                tmp2.xyz = inp.texcoord4.xyz * tmp1.zzz + tmp2.xyz;
                tmp1.w = dot(tmp2.xyz, tmp2.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp2.xyz = tmp1.www * tmp2.xyz;
                tmp3.xy = inp.texcoord.xy * _BumpTiling.xx;
                tmp3 = tex2D(_BumpMap, tmp3.xy);
                tmp3.x = tmp3.w * tmp3.x;
                tmp3.xy = tmp3.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.w = dot(tmp3.xy, tmp3.xy);
                tmp1.w = min(tmp1.w, 1.0);
                tmp1.w = 1.0 - tmp1.w;
                tmp3.z = sqrt(tmp1.w);
                tmp1.w = dot(tmp2.xyz, tmp3.xyz);
                tmp1.w = 1.0 - tmp1.w;
                tmp1.w = tmp1.w * tmp1.w;
                tmp1.w = tmp1.w * 0.5;
                tmp2.x = _DefVals.y * tmp1.w + _DefVals.x;
                tmp1.w = _SpecVals.y * tmp1.w + _SpecVals.x;
                tmp1.w = tmp1.w * 0.5;
                tmp0.xyw = tmp0.xyw * tmp2.xxx;
                tmp2.xyz = tmp0.xyw * _Temperature.zzz;
                tmp2.xyz = max(tmp2.xyz, _Temperature.xxx);
                tmp2.xyz = min(tmp2.xyz, _Temperature.yyy);
                tmp2.xyz = tmp2.xyz + _Temperature.www;
                tmp0.xyz = tmp0.zzz ? tmp2.xyz : tmp0.xyw;
                tmp0.w = tmp2.w * _Glossness;
                tmp0.w = tmp1.w * tmp0.w;
                tmp2.xy = inp.texcoord5.xy / inp.texcoord5.ww;
                tmp4 = tex2D(_LightBuffer, tmp2.xy);
                tmp4 = log(tmp4);
                tmp0.w = tmp0.w * -tmp4.w;
                tmp2.xyz = inp.texcoord7.xyz - tmp4.xyz;
                tmp4.xyz = tmp2.xyz * _SpecColor.xyz;
                tmp4.xyz = tmp0.www * tmp4.xyz;
                tmp0.xyz = tmp0.xyz * tmp2.xyz + tmp4.xyz;
                tmp2.x = dot(inp.texcoord2.xyz, tmp3.xyz);
                tmp2.y = dot(inp.texcoord3.xyz, tmp3.xyz);
                tmp2.z = dot(inp.texcoord4.xyz, tmp3.xyz);
                tmp0.w = dot(-tmp1.xyz, tmp2.xyz);
                tmp0.w = tmp0.w + tmp0.w;
                tmp1.xyz = tmp2.xyz * -tmp0.www + -tmp1.xyz;
                tmp3 = texCUBE(_Cube, tmp1.xyz);
                tmp1.xyz = tmp2.www * tmp3.xyz;
                tmp1.xyz = tmp1.xyz * _ReflectColor.xyz;
                o.sv_target.xyz = tmp1.xyz * tmp1.www + tmp0.xyz;
                o.sv_target.w = 0.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "DEFERRED"
			LOD 400
			Tags { "LIGHTMODE" = "DEFERRED" "RenderType" = "Opaque" }
			Stencil {
				WriteMask 3
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 305819
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
				float4 texcoord4 : TEXCOORD4;
				float3 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
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
			float4 _DecalsTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _SpecColor;
			float4 _Color;
			float4 _ReflectColor;
			float _Specularness;
			float _Glossness;
			float _DecalPower;
			float3 _SpecVals;
			float3 _DefVals;
			float _BumpTiling;
			float4 _Temperature;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			sampler2D _DecalsTex;
			sampler2D _SpecMap;
			sampler2D _BumpMap;
			samplerCUBE _Cube;
			
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
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.texcoord1.xy = v.texcoord1.xy * _DecalsTex_ST.xy + _DecalsTex_ST.zw;
                o.texcoord2.w = tmp0.x;
                tmp0.w = v.tangent.w * unity_WorldTransformParams.w;
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp2.xyz = v.tangent.yyy * unity_ObjectToWorld._m01_m11_m21;
                tmp2.xyz = unity_ObjectToWorld._m00_m10_m20 * v.tangent.xxx + tmp2.xyz;
                tmp2.xyz = unity_ObjectToWorld._m02_m12_m22 * v.tangent.zzz + tmp2.xyz;
                tmp1.w = dot(tmp2.xyz, tmp2.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp2.xyz = tmp1.www * tmp2.xyz;
                tmp3.xyz = tmp1.zxy * tmp2.yzx;
                tmp3.xyz = tmp1.yzx * tmp2.zxy + -tmp3.xyz;
                tmp3.xyz = tmp0.www * tmp3.xyz;
                o.texcoord2.y = tmp3.x;
                o.texcoord2.x = tmp2.x;
                o.texcoord2.z = tmp1.x;
                o.texcoord3.x = tmp2.y;
                o.texcoord3.z = tmp1.y;
                o.texcoord3.w = tmp0.y;
                o.texcoord3.y = tmp3.y;
                o.texcoord4.x = tmp2.z;
                o.texcoord4.z = tmp1.z;
                o.texcoord4.w = tmp0.z;
                tmp0.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                o.texcoord4.y = tmp3.z;
                o.texcoord5.y = dot(tmp0.xyz, tmp3.xyz);
                o.texcoord5.x = dot(tmp0.xyz, tmp2.xyz);
                o.texcoord5.z = dot(tmp0.xyz, tmp1.xyz);
                o.texcoord6 = float4(0.0, 0.0, 0.0, 0.0);
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
                tmp0 = tex2D(_DecalsTex, float2(0.0, 0.0));
                tmp0 = tmp0 - float4(0.13, 0.23, 0.93, 0.0);
                tmp0 = abs(tmp0) < float4(0.005, 0.005, 0.005, 0.005);
                tmp0.xy = tmp0.zw ? tmp0.xy : 0.0;
                tmp0.x = tmp0.y ? tmp0.x : 0.0;
                tmp0.x = tmp0.x ? 1.0 : 0.0;
                tmp0.y = _DecalPower * 5.0;
                tmp0.z = _ThermalVisionOn > 0.0;
                tmp0.y = tmp0.z ? tmp0.y : _DecalPower;
                tmp1 = tex2D(_DecalsTex, inp.texcoord1.xy);
                tmp0.y = tmp0.y * tmp1.w;
                tmp0.x = tmp0.x * tmp0.y;
                tmp2 = tex2D(_MainTex, inp.texcoord.xy);
                tmp1.xyz = tmp1.xyz - tmp2.xyz;
                tmp0.xyw = tmp0.xxx * tmp1.xyz + tmp2.xyz;
                tmp0.xyw = tmp0.xyw * _Color.xyz;
                tmp1.x = dot(inp.texcoord5.xyz, inp.texcoord5.xyz);
                tmp1.x = rsqrt(tmp1.x);
                tmp1.xyz = tmp1.xxx * inp.texcoord5.xyz;
                tmp2.xy = inp.texcoord.xy * _BumpTiling.xx;
                tmp3 = tex2D(_BumpMap, tmp2.xy);
                tmp3.x = tmp3.w * tmp3.x;
                tmp2.xy = tmp3.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.w = dot(tmp2.xy, tmp2.xy);
                tmp1.w = min(tmp1.w, 1.0);
                tmp1.w = 1.0 - tmp1.w;
                tmp2.z = sqrt(tmp1.w);
                tmp1.x = dot(tmp1.xyz, tmp2.xyz);
                tmp1.x = 1.0 - tmp1.x;
                tmp1.x = tmp1.x * tmp1.x;
                tmp1.x = tmp1.x * 0.5;
                tmp1.y = _DefVals.y * tmp1.x + _DefVals.x;
                tmp1.x = _SpecVals.y * tmp1.x + _SpecVals.x;
                tmp1.x = tmp1.x * 0.5;
                tmp0.xyw = tmp0.xyw * tmp1.yyy;
                tmp1.yzw = tmp0.xyw * _Temperature.zzz;
                tmp1.yzw = max(tmp1.yzw, _Temperature.xxx);
                tmp1.yzw = min(tmp1.yzw, _Temperature.yyy);
                tmp1.yzw = tmp1.yzw + _Temperature.www;
                o.sv_target.xyz = tmp0.zzz ? tmp1.yzw : tmp0.xyw;
                o.sv_target.w = 1.0;
                tmp0.x = tmp2.w * _Glossness;
                tmp0.x = tmp1.x * tmp0.x;
                o.sv_target1.xyz = tmp0.xxx * _SpecColor.xyz;
                tmp0 = tex2D(_SpecMap, inp.texcoord.xy);
                o.sv_target1.w = tmp0.x * _Specularness;
                tmp0.x = dot(inp.texcoord2.xyz, tmp2.xyz);
                tmp0.y = dot(inp.texcoord3.xyz, tmp2.xyz);
                tmp0.z = dot(inp.texcoord4.xyz, tmp2.xyz);
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.yzw = tmp0.www * tmp0.xyz;
                o.sv_target2.xyz = tmp1.yzw * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                o.sv_target2.w = 1.0;
                tmp2.x = inp.texcoord2.w;
                tmp2.y = inp.texcoord3.w;
                tmp2.z = inp.texcoord4.w;
                tmp1.yzw = _WorldSpaceCameraPos - tmp2.xyz;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.yzw = tmp0.www * tmp1.yzw;
                tmp0.w = dot(-tmp1.xyz, tmp0.xyz);
                tmp0.w = tmp0.w + tmp0.w;
                tmp0.xyz = tmp0.xyz * -tmp0.www + -tmp1.yzw;
                tmp0 = texCUBE(_Cube, tmp0.xyz);
                tmp0.xyz = tmp2.www * tmp0.xyz;
                tmp0.xyz = tmp0.xyz * _ReflectColor.xyz;
                tmp0.xyz = tmp1.xxx * tmp0.xyz;
                o.sv_target3.xyz = exp(-tmp0.xyz);
                o.sv_target3.w = 1.0;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Reflective/Bumped Diffuse"
	CustomEditor "FresnelMaterialEditor"
}