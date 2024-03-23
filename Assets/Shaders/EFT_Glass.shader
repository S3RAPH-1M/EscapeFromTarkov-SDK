Shader "EFT/Glass" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Diffuse (RGB) Specular (A)", 2D) = "white" {}
		_Cube ("Reflection Cubemap", Cube) = "_Skybox" {}
		_GlobalReflectionStrength ("_GlobalReflectionStrength", Float) = 0
		_SpecColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		_ReflectColor ("Reflection Color", Vector) = (1,1,1,0.5)
		_Specular ("_Specular", Range(0.01, 5)) = 0.078125
		_FresPow ("_FresPow", Range(0.5, 6)) = 4
		_FresAdd ("_FresAdd", Range(0, 1)) = 0.3
	}
	SubShader {
		LOD 300
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "FORWARD"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Blend One One, One One
			ZWrite Off
			Stencil {
				Ref 6
				WriteMask 6
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 22456
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
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord4 : TEXCOORD4;
				float4 texcoord6 : TEXCOORD6;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float _ReflectionBottomShade;
			float4 _ReflectColor;
			float _Specular;
			float _FresPow;
			float _FresAdd;
			float _GlobalReflectionStrength;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
			samplerCUBE _Cube;
			samplerCUBE _MyGlobalReflectionProbe;
			
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
                o.texcoord4.xyz = unity_SHC.xyz * tmp0.www + tmp0.xyz;
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
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = dot(tmp0.xyz, inp.texcoord2.xyz);
                tmp0.x = 1.0 - tmp0.x;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _FresPow;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp0.x + _FresAdd;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0.x = tmp0.x * tmp1.w;
                tmp0.x = tmp0.x * _Specular;
                tmp0.yzw = tmp0.xxx * _ReflectColor.xyz;
                tmp1.x = max(tmp0.z, tmp0.y);
                tmp1.x = max(tmp0.w, tmp1.x);
                tmp1.x = 1.0 - tmp1.x;
                tmp1.x = saturate(1.0 - tmp1.x);
                tmp1.xyz = -tmp0.xxx * _ReflectColor.xyz + tmp1.xxx;
                tmp2.xyz = inp.texcoord3.xyz - _WorldSpaceCameraPos;
                tmp0.x = dot(tmp2.xyz, tmp2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2.xyz = tmp0.xxx * tmp2.xyz;
                tmp0.x = dot(inp.texcoord2.xyz, inp.texcoord2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp3.xyz = tmp0.xxx * inp.texcoord2.xyz;
                tmp0.x = dot(tmp3.xyz, -tmp2.xyz);
                tmp0.x = 1.0 - abs(tmp0.x);
                tmp1.w = tmp0.x * tmp0.x;
                tmp1.w = tmp1.w * tmp1.w;
                tmp0.x = tmp0.x * tmp1.w;
                tmp0.xyz = tmp0.xxx * tmp1.xyz + tmp0.yzw;
                tmp0.w = dot(tmp2.xyz, tmp3.xyz);
                tmp0.w = tmp0.w + tmp0.w;
                tmp1.xyz = tmp3.xyz * -tmp0.www + tmp2.xyz;
                tmp2 = texCUBElod(_MyGlobalReflectionProbe, float4(tmp1.xyz, 6.0));
                tmp0.w = saturate(tmp1.y + _ReflectionBottomShade);
                tmp1.xyz = tmp0.www * tmp2.xyz;
                tmp1.xyz = tmp1.xyz * float3(0.72, 0.72, 0.72);
                tmp0.xyz = tmp0.xyz * tmp1.xyz;
                tmp1 = texCUBE(_Cube, inp.texcoord1.xyz);
                tmp1.xyz = tmp1.xyz * _ReflectColor.xyz;
                tmp0.xyz = tmp0.xyz * _GlobalReflectionStrength.xxx + tmp1.xyz;
                tmp0.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
                o.sv_target.xyz = min(tmp0.xyz, float3(60000.0, 60000.0, 60000.0));
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
		Pass {
			Name "FORWARD"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "FORWARDADD" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend One One, One One
			ZWrite Off
			Stencil {
				Ref 6
				WriteMask 6
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 71793
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float3 texcoord : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
				float4 texcoord3 : TEXCOORD3;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4x4 unity_WorldToLight;
			// $Globals ConstantBuffers for Fragment Shader
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			
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
                tmp1.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp1.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp1.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                o.texcoord.xyz = tmp1.www * tmp1.xyz;
                o.texcoord1.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0 = unity_ObjectToWorld._m03_m13_m23_m33 * v.vertex.wwww + tmp0;
                tmp1.xyz = tmp0.yyy * unity_WorldToLight._m01_m11_m21;
                tmp1.xyz = unity_WorldToLight._m00_m10_m20 * tmp0.xxx + tmp1.xyz;
                tmp0.xyz = unity_WorldToLight._m02_m12_m22 * tmp0.zzz + tmp1.xyz;
                o.texcoord2.xyz = unity_WorldToLight._m03_m13_m23 * tmp0.www + tmp0.xyz;
                o.texcoord3 = float4(0.0, 0.0, 0.0, 0.0);
                return o;
			}
			// Keywords: POINT
			fout frag(v2f inp)
			{
                fout o;
                o.sv_target = float4(0.0, 0.0, 0.0, 1.0);
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "PREPASSBASE" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend DstColor SrcColor, One One
			ZWrite Off
			Stencil {
				Ref 6
				WriteMask 6
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 189474
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
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float _Specular;
			float _FresPow;
			float _FresAdd;
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
                tmp1 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                o.texcoord2.xyz = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.xyz;
                tmp0 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp0 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp0;
                tmp0 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp0;
                o.position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.wwww + tmp0;
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp0.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp0.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp0.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                o.texcoord1.xyz = tmp0.www * tmp0.xyz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0.xyz = _WorldSpaceCameraPos - inp.texcoord2.xyz;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = dot(tmp0.xyz, inp.texcoord1.xyz);
                tmp0.x = 1.0 - tmp0.x;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _FresPow;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp0.x + _FresAdd;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0.x = tmp0.x * tmp1.w;
                o.sv_target.w = tmp0.x * _Specular;
                o.sv_target.xyz = inp.texcoord1.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
                return o;
			}
			ENDCG
		}
		Pass {
			Name "PREPASS"
			LOD 300
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "PREPASSFINAL" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend One One, One One
			ZWrite Off
			Stencil {
				Ref 6
				WriteMask 6
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 254112
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
				float3 texcoord3 : TEXCOORD3;
				float3 texcoord4 : TEXCOORD4;
				float4 texcoord5 : TEXCOORD5;
				float4 texcoord6 : TEXCOORD6;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _MainTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			float _ReflectionBottomShade;
			float4 _ReflectColor;
			float _Specular;
			float _FresPow;
			float _FresAdd;
			float _GlobalReflectionStrength;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MainTex;
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
                o.texcoord.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
                tmp2.x = dot(v.normal.xyz, unity_WorldToObject._m00_m10_m20);
                tmp2.y = dot(v.normal.xyz, unity_WorldToObject._m01_m11_m21);
                tmp2.z = dot(v.normal.xyz, unity_WorldToObject._m02_m12_m22);
                tmp0.w = dot(tmp2.xyz, tmp2.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp2.xyz = tmp0.www * tmp2.xyz;
                tmp3.xyz = _WorldSpaceCameraPos - tmp0.xyz;
                o.texcoord3.xyz = tmp0.xyz;
                tmp0.x = dot(-tmp3.xyz, tmp2.xyz);
                tmp0.x = tmp0.x + tmp0.x;
                o.texcoord1.xyz = tmp2.xyz * -tmp0.xxx + -tmp3.xyz;
                o.texcoord2.xyz = tmp2.xyz;
                o.texcoord4.xyz = tmp3.xyz;
                tmp0.x = tmp1.y * _ProjectionParams.x;
                tmp0.w = tmp0.x * 0.5;
                tmp0.xz = tmp1.xw * float2(0.5, 0.5);
                o.texcoord5.zw = tmp1.zw;
                o.texcoord5.xy = tmp0.zz + tmp0.xw;
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
                tmp0.x = dot(inp.texcoord4.xyz, inp.texcoord4.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp0.xyz = tmp0.xxx * inp.texcoord4.xyz;
                tmp0.x = dot(tmp0.xyz, inp.texcoord2.xyz);
                tmp0.x = 1.0 - tmp0.x;
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _FresPow;
                tmp0.x = exp(tmp0.x);
                tmp0.x = tmp0.x + _FresAdd;
                tmp1 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0.x = tmp0.x * tmp1.w;
                tmp0.x = tmp0.x * _Specular;
                tmp0.yzw = tmp0.xxx * _ReflectColor.xyz;
                tmp1.x = max(tmp0.z, tmp0.y);
                tmp1.x = max(tmp0.w, tmp1.x);
                tmp1.x = 1.0 - tmp1.x;
                tmp1.x = saturate(1.0 - tmp1.x);
                tmp1.xyz = -tmp0.xxx * _ReflectColor.xyz + tmp1.xxx;
                tmp2.xyz = inp.texcoord3.xyz - _WorldSpaceCameraPos;
                tmp0.x = dot(tmp2.xyz, tmp2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp2.xyz = tmp0.xxx * tmp2.xyz;
                tmp0.x = dot(inp.texcoord2.xyz, inp.texcoord2.xyz);
                tmp0.x = rsqrt(tmp0.x);
                tmp3.xyz = tmp0.xxx * inp.texcoord2.xyz;
                tmp0.x = dot(tmp3.xyz, -tmp2.xyz);
                tmp0.x = 1.0 - abs(tmp0.x);
                tmp1.w = tmp0.x * tmp0.x;
                tmp1.w = tmp1.w * tmp1.w;
                tmp0.x = tmp0.x * tmp1.w;
                tmp0.xyz = tmp0.xxx * tmp1.xyz + tmp0.yzw;
                tmp0.w = dot(tmp2.xyz, tmp3.xyz);
                tmp0.w = tmp0.w + tmp0.w;
                tmp1.xyz = tmp3.xyz * -tmp0.www + tmp2.xyz;
                tmp2 = texCUBElod(_MyGlobalReflectionProbe, float4(tmp1.xyz, 6.0));
                tmp0.w = saturate(tmp1.y + _ReflectionBottomShade);
                tmp1.xyz = tmp0.www * tmp2.xyz;
                tmp1.xyz = tmp1.xyz * float3(0.72, 0.72, 0.72);
                tmp0.xyz = tmp0.xyz * tmp1.xyz;
                tmp1 = texCUBE(_Cube, inp.texcoord1.xyz);
                tmp1.xyz = tmp1.xyz * _ReflectColor.xyz;
                tmp0.xyz = tmp0.xyz * _GlobalReflectionStrength.xxx + tmp1.xyz;
                tmp0.xyz = max(tmp0.xyz, float3(0.0, 0.0, 0.0));
                o.sv_target.xyz = min(tmp0.xyz, float3(60000.0, 60000.0, 60000.0));
                o.sv_target.w = 1.0;
                return o;
			}
			ENDCG
		}
	}
	Fallback "Reflective/VertexLit"
}