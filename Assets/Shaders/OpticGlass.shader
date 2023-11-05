Shader "Custom/OpticGlass" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
		_Shininess ("Shininess", Range(0.01, 4)) = 0.078125
		_SpecPower ("Specular Power", Range(0.01, 10)) = 1
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_SpecTex ("Specular (R)", 2D) = "white" {}
		_Cube ("Reflection Cubemap", Cube) = "_Skybox" {}
		_FresPow ("_FresPow", Range(0.5, 6)) = 4
		_FresAdd ("_FresAdd", Range(0, 1)) = 0.3
		_SwitchToSightMultiplier ("_SwitchToSightMultiplier", Range(0, 1)) = 0.1
		_NormalHideness ("_NormalHideness", Float) = 6
	}
	SubShader {
		LOD 300
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Overlay" "RenderType" = "Transparent" }
		Pass {
			Name "FORWARD"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Overlay" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Blend One One, One One
			ZWrite Off
			GpuProgramID 10853
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float texcoord4 : TEXCOORD4;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _NormalHideness;
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float4 _ReflectColor;
			float _Shininess;
			float _SpecPower;
			float _FresPow;
			float _FresAdd;
			float _SwitchToSight;
			float _SwitchToSightMultiplier;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _SpecTex;
			samplerCUBE _Cube;
			
			// Keywords: DIRECTIONAL
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                tmp1.xyz = unity_ObjectToWorld._m03_m13_m23 - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp1.xyz;
                tmp2.x = unity_ObjectToWorld._m10;
                tmp2.y = unity_ObjectToWorld._m11;
                tmp2.z = unity_ObjectToWorld._m12;
                tmp0.w = dot(tmp2.xyz, tmp1.xyz);
                tmp0.w = min(abs(tmp0.w), 1.0);
                tmp0.w = log(tmp0.w);
                tmp0.w = tmp0.w * _NormalHideness;
                tmp0.w = exp(tmp0.w);
                o.texcoord4.x = 1.0 - tmp0.w;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp1.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                o.texcoord3.xyz = tmp0.xyz;
                tmp0.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp0.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp0.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.w = dot(-tmp1.xyz, tmp0.xyz);
                tmp0.w = tmp0.w + tmp0.w;
                o.texcoord1.xyz = tmp0.xyz * -tmp0.www + -tmp1.xyz;
                o.texcoord2.xyz = tmp0.xyz;
                tmp0.w = tmp0.y * tmp0.y;
                tmp0.w = tmp0.x * tmp0.x + -tmp0.w;
                tmp1 = tmp0.yzzx * tmp0.xyzz;
                tmp0.x = dot(unity_SHBr, tmp1);
                tmp0.y = dot(unity_SHBg, tmp1);
                tmp0.z = dot(unity_SHBb, tmp1);
                o.texcoord5.xyz = unity_SHC.xyz * tmp0.www + tmp0.xyz;
                o.texcoord6 = float4(0.0, 0.0, 0.0, 0.0);
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
                tmp0.xyz = _WorldSpaceCameraPos - inp.texcoord3.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp0.xyz;
                tmp1.x = dot(tmp1.xyz, inp.texcoord2.xyz);
                tmp1.x = 1.0 - tmp1.x;
                tmp1.x = log(tmp1.x);
                tmp1.x = tmp1.x * _FresPow;
                tmp1.x = exp(tmp1.x);
                tmp1.x = _FresAdd * inp.texcoord4.x + tmp1.x;
                tmp2 = tex2D(_SpecTex, inp.texcoord.xy);
                tmp1.x = tmp1.x * tmp2.x;
                tmp1.y = _SpecPower * _Shininess;
                tmp1.z = tmp1.x * 3.0;
                tmp1.w = 1.0 - _SwitchToSight;
                tmp2.x = _SwitchToSightMultiplier - 1.0;
                tmp1.w = tmp1.w * tmp2.x + 1.0;
                tmp1.z = tmp1.w * tmp1.z;
                tmp2 = texCUBE(_Cube, inp.texcoord1.xyz);
                tmp2.xyz = tmp1.www * tmp2.xyz;
                tmp2.xyz = tmp2.xyz * _ReflectColor.xyz;
                tmp2.xyz = tmp1.xxx * tmp2.xyz;
                tmp1.x = _ThermalVisionOn > 0.0;
                tmp2.xyz = tmp1.xxx ? float3(0.0, 0.0, 0.0) : tmp2.xyz;
                tmp1.x = unity_ProbeVolumeParams.x == 1.0;
                if (tmp1.x) {
                    tmp1.x = unity_ProbeVolumeParams.y == 1.0;
                    tmp3.xyz = inp.texcoord3.yyy * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp3.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord3.xxx + tmp3.xyz;
                    tmp3.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord3.zzz + tmp3.xyz;
                    tmp3.xyz = tmp3.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp3.xyz = tmp1.xxx ? tmp3.xyz : inp.texcoord3.xyz;
                    tmp3.xyz = tmp3.xyz - unity_ProbeVolumeMin;
                    tmp3.yzw = tmp3.xyz * unity_ProbeVolumeSizeInv;
                    tmp1.x = tmp3.y * 0.25 + 0.75;
                    tmp1.w = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp3.x = max(tmp1.w, tmp1.x);
                    tmp3 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp3.xzw);
                } else {
                    tmp3 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp1.x = saturate(dot(tmp3, unity_OcclusionMaskSelector));
                tmp3.xyz = tmp1.xxx * _LightColor0.xyz;
                tmp0.xyz = tmp0.xyz * tmp0.www + _WorldSpaceLightPos0.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = dot(inp.texcoord2.xyz, tmp0.xyz);
                tmp0.x = max(tmp0.x, 0.0);
                tmp0.y = tmp1.y * 128.0;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp1.z * tmp0.x;
                tmp0.yzw = tmp3.xyz * _SpecColor.xyz;
                o.sv_target.xyz = tmp0.yzw * tmp0.xxx + tmp2.xyz;
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDADD" "QUEUE" = "Overlay" "RenderType" = "Transparent" }
			Blend One One, One One
			ZWrite Off
			GpuProgramID 78480
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float texcoord3 : TEXCOORD3;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float3 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4x4 unity_WorldToLight;
			float _NormalHideness;
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _SpecColor;
			float _Shininess;
			float _SpecPower;
			float _FresPow;
			float _FresAdd;
			float _SwitchToSight;
			float _SwitchToSightMultiplier;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _SpecTex;
			sampler2D _LightTexture0;
			
			// Keywords: POINT
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                tmp2 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp2;
                tmp1.xyz = unity_ObjectToWorld._m03_m13_m23 - _WorldSpaceCameraPos;
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp2.x = unity_ObjectToWorld._m10;
                tmp2.y = unity_ObjectToWorld._m11;
                tmp2.z = unity_ObjectToWorld._m12;
                tmp1.x = dot(tmp2.xyz, tmp1.xyz);
                tmp1.x = min(abs(tmp1.x), 1.0);
                tmp1.x = log(tmp1.x);
                tmp1.x = tmp1.x * _NormalHideness;
                tmp1.x = exp(tmp1.x);
                o.texcoord3.x = 1.0 - tmp1.x;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                o.texcoord1.xyz = tmp1.www * tmp1.xyz;
                o.texcoord2.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp0;
                tmp1.xyz = tmp0.yyy * unity_WorldToLight._m01_m11_m21;
                tmp1.xyz = unity_WorldToLight._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                tmp0.xyz = unity_WorldToLight._m02_m12_m22 * tmp0.zzz + tmp1.xyz;
                o.texcoord4.xyz = unity_WorldToLight._m03_m13_m23 * tmp0.www + tmp0.xyz;
                o.texcoord5 = float4(0.0, 0.0, 0.0, 0.0);
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
                tmp0.xyz = _WorldSpaceLightPos0.xyz - inp.texcoord2.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = _WorldSpaceCameraPos - inp.texcoord2.xyz;
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp1.w = dot(tmp1.xyz, inp.texcoord1.xyz);
                tmp1.w = 1.0 - tmp1.w;
                tmp1.w = log(tmp1.w);
                tmp1.w = tmp1.w * _FresPow;
                tmp1.w = exp(tmp1.w);
                tmp1.w = _FresAdd * inp.texcoord3.x + tmp1.w;
                tmp2 = tex2D(_SpecTex, inp.texcoord.xy);
                tmp1.w = tmp1.w * tmp2.x;
                tmp2.x = _SpecPower * _Shininess;
                tmp1.w = tmp1.w * 3.0;
                tmp2.y = 1.0 - _SwitchToSight;
                tmp2.z = _SwitchToSightMultiplier - 1.0;
                tmp2.y = tmp2.y * tmp2.z + 1.0;
                tmp1.w = tmp1.w * tmp2.y;
                tmp2.yzw = inp.texcoord2.yyy * unity_WorldToLight._m01_m11_m21;
                tmp2.yzw = unity_WorldToLight._m00_m10_m20 * inp.texcoord2.xxx + tmp2.yzw;
                tmp2.yzw = unity_WorldToLight._m02_m12_m22 * inp.texcoord2.zzz + tmp2.yzw;
                tmp2.yzw = tmp2.yzw + unity_WorldToLight._m03_m13_m23;
                tmp3.x = unity_ProbeVolumeParams.x == 1.0;
                if (tmp3.x) {
                    tmp3.x = unity_ProbeVolumeParams.y == 1.0;
                    tmp3.yzw = inp.texcoord2.yyy * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp3.yzw = unity_ProbeVolumeWorldToObject._m00_m10_m20 * inp.texcoord2.xxx + tmp3.yzw;
                    tmp3.yzw = unity_ProbeVolumeWorldToObject._m02_m12_m22 * inp.texcoord2.zzz + tmp3.yzw;
                    tmp3.yzw = tmp3.yzw + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp3.xyz = tmp3.xxx ? tmp3.yzw : inp.texcoord2.xyz;
                    tmp3.xyz = tmp3.xyz - unity_ProbeVolumeMin;
                    tmp3.yzw = tmp3.xyz * unity_ProbeVolumeSizeInv;
                    tmp3.y = tmp3.y * 0.25 + 0.75;
                    tmp4.x = unity_ProbeVolumeParams.z * 0.5 + 0.75;
                    tmp3.x = max(tmp3.y, tmp4.x);
                    tmp3 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp3.xzw);
                } else {
                    tmp3 = float4(1.0, 1.0, 1.0, 1.0);
                }
                tmp3.x = saturate(dot(tmp3, unity_OcclusionMaskSelector));
                tmp2.y = dot(tmp2.xyz, tmp2.xyz);
                tmp4 = tex2D(_LightTexture0, tmp2.yy);
                tmp2.y = tmp3.x * tmp4.x;
                tmp2.yzw = tmp2.yyy * _LightColor0.xyz;
                tmp0.xyz = tmp0.xyz * tmp0.www + tmp1.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = dot(inp.texcoord1.xyz, tmp0.xyz);
                tmp0.x = max(tmp0.x, 0.0);
                tmp0.y = tmp2.x * 128.0;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp1.w * tmp0.x;
                tmp0.yzw = tmp2.yzw * _SpecColor.xyz;
                o.sv_target.xyz = tmp0.xxx * tmp0.yzw;
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "PREPASSBASE" "QUEUE" = "Overlay" "RenderType" = "Transparent" }
			Blend DstColor SrcColor, One One
			ZWrite Off
			GpuProgramID 149523
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float3 texcoord : TEXCOORD0;
				float texcoord2 : TEXCOORD2;
				float3 texcoord1 : TEXCOORD1;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _NormalHideness;
			// $Globals ConstantBuffers for Fragment Shader
			float _Shininess;
			float _SpecPower;
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
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                o.texcoord1.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp0 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp0;
                tmp0 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp0;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp0;
                tmp0.xyz = unity_ObjectToWorld._m03_m13_m23 - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp1.x = unity_ObjectToWorld._m10;
                tmp1.y = unity_ObjectToWorld._m11;
                tmp1.z = unity_ObjectToWorld._m12;
                tmp0.x = dot(tmp1.xyz, tmp0.xyz);
                tmp0.x = min(abs(tmp0.x), 1.0);
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _NormalHideness;
                tmp0.x = exp(tmp0.x);
                o.texcoord2.x = 1.0 - tmp0.x;
                tmp0.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp0.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp0.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                o.texcoord.xyz = tmp0.www * tmp0.xyz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                o.sv_target.w = _SpecPower * _Shininess;
                o.sv_target.xyz = inp.texcoord.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "PREPASSFINAL" "QUEUE" = "Overlay" "RenderType" = "Transparent" }
			Blend One One, One One
			ZWrite Off
			GpuProgramID 233123
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float texcoord4 : TEXCOORD4;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
				float4 texcoord7 : TEXCOORD7;
				float3 texcoord8 : TEXCOORD8;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _NormalHideness;
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _SpecColor;
			float4 _ReflectColor;
			float _FresPow;
			float _FresAdd;
			float _SwitchToSight;
			float _SwitchToSightMultiplier;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _SpecTex;
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
                tmp2.xyz = unity_ObjectToWorld._m03_m13_m23 - _WorldSpaceCameraPos;
                tmp0.w = dot(tmp2.xyz, tmp2.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp2.xyz = tmp0.www * tmp2.xyz;
                tmp3.x = unity_ObjectToWorld._m10;
                tmp3.y = unity_ObjectToWorld._m11;
                tmp3.z = unity_ObjectToWorld._m12;
                tmp0.w = dot(tmp3.xyz, tmp2.xyz);
                tmp0.w = min(abs(tmp0.w), 1.0);
                tmp0.w = log(tmp0.w);
                tmp0.w = tmp0.w * _NormalHideness;
                tmp0.w = exp(tmp0.w);
                o.texcoord4.x = 1.0 - tmp0.w;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp2.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                o.texcoord3.xyz = tmp0.xyz;
                tmp0.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp0.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp0.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp2.w = dot(-tmp2.xyz, tmp0.xyz);
                tmp2.w = tmp2.w + tmp2.w;
                o.texcoord1.xyz = tmp0.xyz * -tmp2.www + -tmp2.xyz;
                o.texcoord5.xyz = tmp2.xyz;
                o.texcoord2.xyz = tmp0.xyz;
                tmp1.y = tmp1.y * _ProjectionParams.x;
                tmp2.xzw = tmp1.xwy * float3(0.5, 0.5, 0.5);
                o.texcoord6.zw = tmp1.zw;
                o.texcoord6.xy = tmp2.zz + tmp2.xw;
                o.texcoord7 = float4(0.0, 0.0, 0.0, 0.0);
                tmp1.x = tmp0.y * tmp0.y;
                tmp1.x = tmp0.x * tmp0.x + -tmp1.x;
                tmp2 = tmp0.yzzx * tmp0.xyzz;
                tmp3.x = dot(unity_SHBr, tmp2);
                tmp3.y = dot(unity_SHBg, tmp2);
                tmp3.z = dot(unity_SHBb, tmp2);
                tmp1.xyz = unity_SHC.xyz * tmp1.xxx + tmp3.xyz;
                tmp0.w = 1.0;
                tmp2.x = dot(unity_SHAr, tmp0);
                tmp2.y = dot(unity_SHAg, tmp0);
                tmp2.z = dot(unity_SHAb, tmp0);
                tmp0.xyz = tmp1.xyz + tmp2.xyz;
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
                tmp0.x = dot(inp.texcoord5.xyz, inp.texcoord5.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp0.xyz = tmp0.xxx * inp.texcoord5.xyz;
                tmp0.x = dot(tmp0.xyz, inp.texcoord2.xyz);
                tmp0.x = 1.0 - tmp0.x;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _FresPow;
                tmp0.x = exp(tmp0.x);
                tmp0.x = _FresAdd * inp.texcoord4.x + tmp0.x;
                tmp1 = tex2D(_SpecTex, inp.texcoord.xy);
                tmp0.x = tmp0.x * tmp1.x;
                tmp0.y = 1.0 - _SwitchToSight;
                tmp0.z = _SwitchToSightMultiplier - 1.0;
                tmp0.y = tmp0.y * tmp0.z + 1.0;
                tmp1 = texCUBE(_Cube, inp.texcoord1.xyz);
                tmp1.xyz = tmp0.yyy * tmp1.xyz;
                tmp1.xyz = tmp1.xyz * _ReflectColor.xyz;
                tmp1.xyz = tmp0.xxx * tmp1.xyz;
                tmp0.x = tmp0.x * 3.0;
                tmp0.x = tmp0.y * tmp0.x;
                tmp0.y = _ThermalVisionOn > 0.0;
                tmp0.yzw = tmp0.yyy ? float3(0.0, 0.0, 0.0) : tmp1.xyz;
                tmp1.xy = inp.texcoord6.xy / inp.texcoord6.ww;
                tmp1 = tex2D(_LightBuffer, tmp1.xy);
                tmp1 = log(tmp1);
                tmp0.x = tmp0.x * -tmp1.w;
                tmp1.xyz = inp.texcoord8.xyz - tmp1.xyz;
                tmp1.xyz = tmp1.xyz * _SpecColor.xyz;
                o.sv_target.xyz = tmp1.xyz * tmp0.xxx + tmp0.yzw;
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Reflective/VertexLit"
}