Shader "Decal/Deferred DecalShader Diffuse+Normals" {
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
			GpuProgramID 48989
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 position : SV_POSITION0;
				float4 texcoord3 : TEXCOORD3;
				float3 texcoord4 : TEXCOORD4;
				float3 normal : NORMAL0;
				float4 tangent : TANGENT0;
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
                o.texcoord = v.texcoord;
                o.texcoord1 = v.texcoord1;
                o.texcoord2 = v.texcoord2;
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
                o.texcoord3.zw = tmp1.zw;
                o.texcoord3.xy = tmp2.zz + tmp2.xw;
                tmp1.xyz = tmp0.yyy * unity_MatrixV._m01_m11_m21;
                tmp1.xyz = unity_MatrixV._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                tmp0.xyz = unity_MatrixV._m02_m12_m22 * tmp0.zzz + tmp1.xyz;
                tmp0.xyz = unity_MatrixV._m03_m13_m23 * tmp0.www + tmp0.xyz;
                o.texcoord4.xyz = tmp0.xyz * float3(-1.0, -1.0, 1.0);
                o.normal.xyz = v.normal.xyz;
                o.tangent = v.tangent;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0.x = _ProjectionParams.z / inp.texcoord4.z;
                tmp0.xyz = tmp0.xxx * inp.texcoord4.xyz;
                tmp1.xy = inp.texcoord3.xy / inp.texcoord3.ww;
                tmp2 = tex2D(_CameraDepthTexture, tmp1.xy);
                tmp1 = tex2D(_NormalsCopy, tmp1.xy);
                tmp1.xyz = tmp1.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
                tmp0.w = dot(tmp1.xyz, inp.texcoord1.xyz);
                tmp0.w = tmp0.w - 0.8;
                tmp0.w = tmp0.w < 0.0;
                if (tmp0.w) {
                    discard;
                }
                tmp0.w = _ZBufferParams.x * tmp2.x + _ZBufferParams.y;
                tmp0.w = 1.0 / tmp0.w;
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp1.xyz = tmp0.yyy * unity_CameraToWorld._m01_m11_m21;
                tmp0.xyw = unity_CameraToWorld._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                tmp0.xyz = unity_CameraToWorld._m02_m12_m22 * tmp0.zzz + tmp0.xyw;
                tmp0.xyz = tmp0.xyz + unity_CameraToWorld._m03_m13_m23;
                tmp1.x = inp.texcoord.w;
                tmp1.y = inp.texcoord1.w;
                tmp1.z = inp.texcoord2.w;
                tmp0.xyz = tmp1.xyz - tmp0.xyz;
                tmp1.y = dot(inp.texcoord1.xyz, tmp0.xyz);
                tmp1.x = dot(inp.texcoord.xyz, tmp0.xyz);
                tmp1.z = dot(inp.texcoord2.xyz, tmp0.xyz);
                tmp0.xyz = inp.normal.xyz - abs(tmp1.xyz);
                tmp1.xy = tmp1.xz / inp.normal.xz;
                tmp1.xy = tmp1.xy + float2(1.0, 1.0);
                tmp1.xy = tmp1.xy * float2(0.5, 0.5);
                tmp0.xyz = tmp0.xyz < float3(0.0, 0.0, 0.0);
                tmp0.x = uint1(tmp0.y) | uint1(tmp0.x);
                tmp0.x = uint1(tmp0.z) | uint1(tmp0.x);
                if (tmp0.x) {
                    discard;
                }
                tmp0.xy = inp.tangent.zw - inp.tangent.xy;
                tmp0.xy = tmp1.xy * tmp0.xy + inp.tangent.xy;
                tmp0 = tex2D(_BumpMap, tmp0.xy);
                tmp1 = tmp1 * _Color;
                tmp2.xyz = tmp1.xyz * _Temperature.zzz;
                tmp2.xyz = max(tmp2.xyz, _Temperature.xxx);
                tmp2.xyz = min(tmp2.xyz, _Temperature.yyy);
                tmp2.xyz = tmp2.xyz + _Temperature.www;
                tmp0.z = _ThermalVisionOn > 0.0;
                o.sv_target.xyz = tmp0.zzz ? tmp2.xyz : tmp1.xyz;
                o.sv_target.w = tmp1.w;
                o.sv_target3.w = tmp1.w;
                o.sv_target1.w = tmp1.w * _SpecularColor.w;
                o.sv_target2.w = tmp1.w * _NormalPower;
                o.sv_target1.xyz = _SpecularColor.xyz;
                tmp0.x = tmp0.w * tmp0.x;
                tmp0.xy = tmp0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.xyz = tmp0.yyy * -inp.texcoord2.xyz;
                tmp1.xyz = tmp0.xxx * -inp.texcoord.xyz + tmp1.xyz;
                tmp0.x = dot(tmp0.xy, tmp0.xy);
                tmp0.x = min(tmp0.x, 1.0);
                tmp0.x = 1.0 - tmp0.x;
                tmp0.x = sqrt(tmp0.x);
                tmp0.xyz = tmp0.xxx * inp.texcoord1.xyz + tmp1.xyz;
                o.sv_target2.xyz = tmp0.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                o.sv_target3.xyz = float3(1.0, 1.0, 1.0);
                return o;
			}
			ENDCG
		}
	}
}