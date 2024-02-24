Shader "Particles/Smoke Bumped" {
	Properties {
		[Header(Vertex Color (R)smoke lightness   (G)flame intensity  (B)distortion   (A)alpha )] [Queue] _Color ("Color", Vector) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		[HDR] _FireColor ("Fire Color", Vector) = (1,0.5,0,1)
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
		_NearCameraFade ("_NearCameraFade", Range(0.01, 3)) = 1
		_GIIndirect ("GI Indirect", Range(0, 1)) = 1
		_Scaterring ("Scaterring", Range(0, 1)) = 0.5
		_NoiseTex ("Noise Texture", 2D) = "white" {}
		_AnimationSpeed ("Animation Speed", Float) = 1
		_Distortion ("Distortion", Range(0, 1)) = 1
		_NoiseScale ("Noise Scale", Float) = 1
		_Distortion ("Distortion", Range(0, 1)) = 1
	}
	SubShader {
		Tags { "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "FORWARD"
			Tags { "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 64463
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float4 color : COLOR0;
				float4 texcoord4 : TEXCOORD4;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _LightColor0;
			float4 _Color;
			float _DirectionLightShadow;
			float _InvFade;
			float _NearCameraFade;
			float _Scaterring;
			float _AnimationSpeed;
			float _Distortion;
			float _NoiseScale;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _NoiseTex;
			sampler2D _MainTex;
			sampler2D _BumpMap;
			sampler2D _CameraDepthTexture;
			
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
                o.texcoord1.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp0 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp0;
                tmp0 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp0;
                tmp0 = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp0;
                o.position = tmp0;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp2.xyz = _WorldSpaceLightPos0.yyy * unity_MatrixV._m01_m11_m21;
                tmp2.xyz = unity_MatrixV._m00_m10_m20 * _WorldSpaceLightPos0.xxx + tmp2.xyz;
                o.texcoord2.xyz = unity_MatrixV._m02_m12_m22 * _WorldSpaceLightPos0.zzz + tmp2.xyz;
                o.color = v.color;
                tmp0.z = tmp1.y * unity_MatrixV._m21;
                tmp0.z = unity_MatrixV._m20 * tmp1.x + tmp0.z;
                tmp0.z = unity_MatrixV._m22 * tmp1.z + tmp0.z;
                tmp0.z = unity_MatrixV._m23 * tmp1.w + tmp0.z;
                o.texcoord4.z = -tmp0.z;
                tmp0.y = tmp0.y * _ProjectionParams.x;
                tmp1.xzw = tmp0.xwy * float3(0.5, 0.5, 0.5);
                o.texcoord4.w = tmp0.w;
                o.texcoord4.xy = tmp1.zz + tmp1.xw;
                return o;
			}
			// Keywords: DIRECTIONAL
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0.xyz = _Time.xxx * float3(0.96, 1.0, 1.03);
                tmp0.xyz = tmp0.xyz * _AnimationSpeed.xxx;
                tmp1.xy = inp.texcoord.xy * _NoiseScale.xx;
                tmp2 = tmp0.xxyy * float4(0.0, 1.0, 0.866, -0.5) + tmp1.xyxy;
                tmp0.xy = tmp0.zz * float2(-0.866, -0.5) + tmp1.xy;
                tmp0 = tex2D(_NoiseTex, tmp0.xy);
                tmp1 = tex2D(_NoiseTex, tmp2.xy);
                tmp2 = tex2D(_NoiseTex, tmp2.zw);
                tmp0.xy = tmp1.xy + tmp2.yz;
                tmp0.xy = tmp0.zw + tmp0.xy;
                tmp0.xy = tmp0.xy - float2(1.5, 1.5);
                tmp0.z = inp.color.z * _Distortion;
                tmp0.xy = tmp0.xy * tmp0.zz + inp.texcoord.xy;
                tmp1 = tex2D(_BumpMap, tmp0.xy);
                tmp0 = tex2D(_MainTex, tmp0.xy);
                tmp0 = tmp0 * _Color;
                tmp0 = tmp0 * inp.color.xxxw;
                tmp1.x = tmp1.w * tmp1.x;
                tmp1.xy = tmp1.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
                tmp1.w = dot(tmp1.xy, tmp1.xy);
                tmp1.w = min(tmp1.w, 1.0);
                tmp1.w = 1.0 - tmp1.w;
                tmp1.z = sqrt(tmp1.w);
                tmp1.x = dot(tmp1.xyz, inp.texcoord2.xyz);
                tmp1.x = max(tmp1.x, 0.0);
                tmp1.y = 1.0 - tmp1.x;
                tmp1.x = _Scaterring * tmp1.y + tmp1.x;
                tmp0.xyz = tmp0.xyz * _LightColor0.xyz;
                tmp0.xyz = tmp1.xxx * tmp0.xyz;
                tmp1.x = 1.0 - _DirectionLightShadow;
                o.sv_target.xyz = tmp0.xyz * tmp1.xxx;
                tmp0.xy = inp.texcoord4.xy / inp.texcoord4.ww;
                tmp1 = tex2D(_CameraDepthTexture, tmp0.xy);
                tmp0.x = _ZBufferParams.z * tmp1.x + _ZBufferParams.w;
                tmp0.x = 1.0 / tmp0.x;
                tmp0.x = tmp0.x - inp.texcoord4.z;
                tmp0.x = saturate(tmp0.x * _InvFade);
                tmp0.x = tmp0.x * tmp0.w;
                tmp0.y = saturate(inp.texcoord4.z * _NearCameraFade);
                o.sv_target.w = tmp0.y * tmp0.x;
                return o;
			}
			ENDCG
		}
		Pass {
			Tags { "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend One One, One One
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 126551
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float color : COLOR0;
				float2 texcoord : TEXCOORD0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _FireColor;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = v.vertex.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp0 = unity_ObjectToWorld._m00_m10_m20_m30 * v.vertex.xxxx + tmp0;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * v.vertex.zzzz + tmp0;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                o.color.x = v.color.y;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0.x = tmp0.w + inp.color.x;
                tmp0.x = saturate(tmp0.x - 1.0);
                tmp0.y = tmp0.x * tmp0.x;
                tmp0.yzw = tmp0.yyy * _FireColor.xyz;
                o.sv_target.xyz = tmp0.xxx * tmp0.yzw;
                o.sv_target.w = tmp0.x;
                return o;
			}
			ENDCG
		}
	}
}