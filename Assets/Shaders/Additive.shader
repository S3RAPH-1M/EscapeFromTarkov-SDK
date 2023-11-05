// Upgrade NOTE: replaced 'glstate_matrix_projection' with 'UNITY_MATRIX_P'

Shader "Custom/Additive" {
	Properties {
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01, 10)) = 1
		_InvWindowSize ("Inv Window Size", Float) = 1
		_RandomizePhase ("Randomize Phase", Float) = 1
		_HDR ("HDR", Float) = 1
		_ZShift ("Z Shift", Range(0.9, 1)) = 1
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend One One, One One
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 27261
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float4 color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _TintColor;
			float4 _RotMx;
			float4 _RandomVals;
			float2 _CellShift;
			float _InvWindowSize;
			float _RandomizePhase;
			float4 _ShotVals;
			float _ZShift;
			// $Globals ConstantBuffers for Fragment Shader
			float _HDR;
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
                float4 tmp2;
                tmp0.xyz = v.color.xxx * _RandomVals.yzx;
                tmp0.xyz = frac(tmp0.xyz);
                tmp0.xyz = tmp0.xyz - float3(0.5, 0.5, 0.5);
                tmp1.xyz = tmp0.xyz * v.normal.zxy;
                tmp0.xyz = v.normal.yzx * tmp0.yzx + -tmp1.xyz;
                tmp1.xy = v.color.yx * _RandomVals.zz;
                tmp1.xy = frac(tmp1.xy);
                tmp0.w = tmp1.y * v.tangent.x;
                tmp1.xy = tmp1.xy - float2(0.5, 0.5);
                tmp0.w = tmp1.x * v.tangent.w + tmp0.w;
                tmp1.x = tmp1.y * _RandomizePhase + v.color.z;
                tmp1.x = -_ShotVals.y * 2.0 + tmp1.x;
                tmp1.x = tmp1.x + 0.5;
                o.color.w = abs(tmp1.x) * _InvWindowSize + _ShotVals.x;
                tmp1.xyz = v.normal.xyz * tmp0.www + v.vertex.xyz;
                tmp0.xyz = tmp0.xyz * v.tangent.yyy + tmp1.xyz;
                tmp1.xyz = v.color.yyy * _RandomVals.zwy;
                tmp1.xyz = frac(tmp1.xyz);
                tmp1.xyz = tmp1.xyz - float3(0.5, 0.5, 0.5);
                tmp2.xyz = tmp1.xyz * v.normal.zxy;
                tmp1.xyz = v.normal.yzx * tmp1.yzx + -tmp2.xyz;
                tmp0.xyz = tmp1.xyz * v.tangent.zzz + tmp0.xyz;
                tmp1 = tmp0.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp1 = unity_ObjectToWorld._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp0 = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                tmp1 = v.texcoord1.xxyy * _RotMx;
                tmp1.xy = tmp1.zw + tmp1.xy;
                tmp2.x = tmp1.x * UNITY_MATRIX_P._m00;
                tmp2.y = tmp1.y * -UNITY_MATRIX_P._m11;
                o.position.xy = tmp0.xy + tmp2.xy;
                o.position.z = tmp0.z * _ZShift;
                o.position.w = tmp0.w;
                o.texcoord.xy = v.texcoord.xy + _CellShift;
                o.color.xyz = _TintColor.xyz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp1.x = tmp0.w - inp.color.w;
                tmp0 = tmp0 * tmp1.xxxx;
                tmp1.xyz = tmp0.xyz < float3(0.01, 0.01, 0.01);
                tmp1.x = tmp1.y ? tmp1.x : 0.0;
                tmp1.x = tmp1.z ? tmp1.x : 0.0;
                if (tmp1.x) {
                    discard;
                }
                tmp0 = tmp0 * _HDR.xxxx;
                o.sv_target = tmp0 * inp.color;
                return o;
			}
			ENDCG
		}
	}
}