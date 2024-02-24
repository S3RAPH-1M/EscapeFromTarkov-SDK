Shader "Decal/Deferred DecalShader Diffuse+Normals Dynamic" {
	Properties {
		[MaterialEnum(Static, 0, Characters, 1, Hands, 2)] _StencilType ("Stencil type to draw decals", Float) = 0
		_MainTex ("Diffuse", 2D) = "white" {}
		_Color ("Main color", Vector) = (1,1,1,1)
		_BumpMap ("Normals", 2D) = "bump" {}
		_NormalPower ("Normal power", Float) = 3
		_SpecularColor ("Specular color", Vector) = (1,1,1,1)
		_SpecSmoothness ("Specular smoothness", Range(0, 1)) = 0
		_Temperature ("_Temperature(min, max, factor)", Vector) = (0.1,0.13,0.33,0)
	}
	SubShader {
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Stencil {
				ReadMask 3
				Comp Equal
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			Fog {
				Mode Off
			}
			GpuProgramID 46520
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 texcoord2 : TEXCOORD2;
				float3 texcoord3 : TEXCOORD3;
				float2 texcoord : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord6 : TEXCOORD6;
				float3 texcoord4 : TEXCOORD4;
				float3 texcoord5 : TEXCOORD5;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
				float4 sv_target1 : SV_Target1;
				float4 sv_target2 : SV_Target2;
				float4 sv_target3 : SV_Target3;
			};
			// $Globals ConstantBuffers for Vertex Shader
			// $Globals ConstantBuffers for Fragment Shader
			float _NormalPower;
			float4 _Color;
			float4 _SpecularColor;
			float4 _UvStartEnd;
			float4 _Temperature;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _CameraDepthTexture;
			sampler2D _NormalsCopy;
			sampler2D _BumpMap;
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp1 = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.position = tmp1;
                tmp1.y = tmp1.y * _ProjectionParams.x;
                tmp2.xzw = tmp1.xwy * float3(0.5, 0.5, 0.5);
                o.texcoord2.zw = tmp1.zw;
                o.texcoord2.xy = tmp2.zz + tmp2.xw;
                tmp1.xyz = tmp0.yyy * unity_MatrixV._m01_m11_m21;
                tmp1.xyz = unity_MatrixV._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                tmp0.xyz = unity_MatrixV._m02_m12_m22 * tmp0.zzz + tmp1.xyz;
                tmp0.xyz = unity_MatrixV._m03_m13_m23 * tmp0.www + tmp0.xyz;
                o.texcoord3.xyz = tmp0.xyz * float3(-1.0, -1.0, 1.0);
                o.texcoord.xy = v.vertex.xz + float2(0.5, 0.5);
                o.texcoord1.xyz = unity_ObjectToWorld._m01_m11_m21;
                o.texcoord6.xyz = unity_ObjectToWorld._m01_m11_m21;
                o.texcoord4.xyz = unity_ObjectToWorld._m00_m10_m20;
                o.texcoord5.xyz = unity_ObjectToWorld._m02_m12_m22;
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
                tmp0.x = _ProjectionParams.z / inp.texcoord3.z;
                tmp0.xyz = tmp0.xxx * inp.texcoord3.xyz;
                tmp1.xy = inp.texcoord2.xy / inp.texcoord2.ww;
                tmp2 = tex2D(_CameraDepthTexture, tmp1.xy);
                tmp0.w = _ZBufferParams.x * tmp2.x + _ZBufferParams.y;
                tmp0.w = 1.0 / tmp0.w;
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp2.xyz = tmp0.yyy * unity_CameraToWorld._m01_m11_m21;
                tmp0.xyw = unity_CameraToWorld._m00_m10_m20 * tmp0.xxx + tmp2.xyz;
                tmp0.xyz = unity_CameraToWorld._m02_m12_m22 * tmp0.zzz + tmp0.xyw;
                tmp0.xyz = tmp0.xyz + unity_CameraToWorld._m03_m13_m23;
                tmp2.xyz = tmp0.yyy * unity_WorldToObject._m01_m11_m21;
                tmp2.xyz = unity_WorldToObject._m00_m10_m20 * tmp0.xxx + tmp2.xyz;
                tmp2.xyz = unity_WorldToObject._m02_m12_m22 * tmp0.zzz + tmp2.xyz;
                tmp2.xyz = tmp2.xyz + unity_WorldToObject._m03_m13_m23;
                tmp3.xyz = float3(0.5, 0.5, 0.5) - abs(tmp2.xyz);
                tmp3.xyz = tmp3.xyz < float3(0.0, 0.0, 0.0);
                tmp0.w = uint1(tmp3.y) | uint1(tmp3.x);
                tmp0.w = uint1(tmp3.z) | uint1(tmp0.w);
                if (tmp0.w) {
                    discard;
                }
                tmp1 = tex2D(_NormalsCopy, tmp1.xy);
                tmp1.xyz = tmp1.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
                tmp0.w = dot(inp.texcoord1.xyz, inp.texcoord1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp3.xyz = tmp0.www * inp.texcoord1.xyz;
                tmp0.w = dot(tmp1.xyz, tmp3.xyz);
                tmp0.w = tmp0.w - 0.8;
                tmp0.w = tmp0.w < 0.0;
                if (tmp0.w) {
                    discard;
                }
                tmp2.xy = tmp2.xz * float2(2.0, 2.0) + float2(1.0, 1.0);
                tmp2.xy = tmp2.xy * float2(0.5, 0.5);
                tmp2.zw = _UvStartEnd.zw - _UvStartEnd.xy;
                tmp2.xy = tmp2.xy * tmp2.zw + _UvStartEnd.xy;
                UNITY_INITIALIZE_OUTPUT(float4, tmp3)
                tmp3 = tmp3 * _Color;
                tmp2 = tex2D(_BumpMap, tmp2.xy);
                tmp2.x = tmp2.w * tmp2.x;
                tmp2.xy = tmp2.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp0.w = dot(tmp2.xy, tmp2.xy);
                tmp0.w = min(tmp0.w, 1.0);
                tmp0.w = 1.0 - tmp0.w;
                tmp0.w = sqrt(tmp0.w);
                tmp2.yzw = tmp2.yyy * inp.texcoord5.xyz;
                tmp2.xyz = tmp2.xxx * inp.texcoord4.xyz + tmp2.yzw;
                tmp2.xyz = tmp0.www * inp.texcoord6.xyz + tmp2.xyz;
                o.sv_target2.xyz = tmp2.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                o.sv_target2.w = tmp3.w * _NormalPower;
                o.sv_target1.w = tmp3.w * _SpecularColor.w;
                tmp0.w = unity_ProbeVolumeParams.x == 1.0;
                if (tmp0.w) {
                    tmp0.w = unity_ProbeVolumeParams.y == 1.0;
                    tmp2.xyz = tmp0.yyy * unity_ProbeVolumeWorldToObject._m01_m11_m21;
                    tmp2.xyz = unity_ProbeVolumeWorldToObject._m00_m10_m20 * tmp0.xxx + tmp2.xyz;
                    tmp2.xyz = unity_ProbeVolumeWorldToObject._m02_m12_m22 * tmp0.zzz + tmp2.xyz;
                    tmp2.xyz = tmp2.xyz + unity_ProbeVolumeWorldToObject._m03_m13_m23;
                    tmp0.xyz = tmp0.www ? tmp2.xyz : tmp0.xyz;
                    tmp0.xyz = tmp0.xyz - unity_ProbeVolumeMin;
                    tmp0.yzw = tmp0.xyz * unity_ProbeVolumeSizeInv;
                    tmp0.y = tmp0.y * 0.25;
                    tmp2.x = unity_ProbeVolumeParams.z * 0.5;
                    tmp2.y = -unity_ProbeVolumeParams.z * 0.5 + 0.25;
                    tmp0.y = max(tmp0.y, tmp2.x);
                    tmp0.x = min(tmp2.y, tmp0.y);
                    tmp2 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp0.xzw);
                    tmp4.xyz = tmp0.xzw + float3(0.25, 0.0, 0.0);
                    tmp4 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp4.xyz);
                    tmp0.xyz = tmp0.xzw + float3(0.5, 0.0, 0.0);
                    tmp0 = UNITY_SAMPLE_TEX3D_SAMPLER(unity_ProbeVolumeSH, unity_ProbeVolumeSH, tmp0.xyz);
                    tmp1.w = 1.0;
                    tmp2.x = dot(tmp2, tmp1);
                    tmp2.y = dot(tmp4, tmp1);
                    tmp2.z = dot(tmp0, tmp1);
                } else {
                    tmp1.w = 1.0;
                    tmp2.x = dot(unity_SHAr, tmp1);
                    tmp2.y = dot(unity_SHAg, tmp1);
                    tmp2.z = dot(unity_SHAb, tmp1);
                }
                tmp0.xyz = max(tmp2.xyz, float3(0.0, 0.0, 0.0));
                tmp0.xyz = log(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * float3(0.4166667, 0.4166667, 0.4166667);
                tmp0.xyz = exp(tmp0.xyz);
                tmp0.xyz = tmp0.xyz * float3(1.055, 1.055, 1.055) + float3(-0.055, -0.055, -0.055);
                tmp0.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
                o.sv_target3.xyz = tmp0.xyz * tmp3.xyz;
                tmp0.x = _ThermalVisionOn > 0.0;
                tmp0.yzw = tmp3.xyz * _Temperature.zzz;
                tmp0.yzw = max(tmp0.yzw, _Temperature.xxx);
                tmp0.yzw = min(tmp0.yzw, _Temperature.yyy);
                tmp0.yzw = tmp0.yzw + _Temperature.www;
                o.sv_target.xyz = tmp0.xxx ? tmp0.yzw : tmp3.xyz;
                o.sv_target.w = tmp3.w;
                o.sv_target1.xyz = _SpecularColor.xyz;
                o.sv_target3.w = tmp3.w;
                return o;
			}
			ENDCG
		}
	}
}