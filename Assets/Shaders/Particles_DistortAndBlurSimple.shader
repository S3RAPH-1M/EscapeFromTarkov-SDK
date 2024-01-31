Shader "Particles/DistortAndBlurSimple" {
	Properties {
		_DistortTex ("_DistortTex", 2D) = "white" {}
		_AlphaTex ("_AlphaTex", 2D) = "white" {}
		_Distort ("Distortion Strength", Range(0, 1)) = 1
		_Blur ("Blur Strength", Range(0, 1)) = 1
		_InvFade ("Soft Particles Factor", Range(0.01, 3)) = 1
	}
	SubShader {
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 12297
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float4 color : COLOR0;
				float2 texcoord : TEXCOORD0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _Distort;
			float _Blur;
			float4 _DistortTex_ST;
			// $Globals ConstantBuffers for Fragment Shader
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _DistortTex;
			sampler2D _AlphaTex;
			
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
                o.color.xyz = v.color.xyz * float3(_Distort.xx, _Blur.x);
                o.color.w = v.color.w;
                o.texcoord.xy = v.texcoord.xy * _DistortTex_ST.xy + _DistortTex_ST.zw;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_DistortTex, inp.texcoord.xy);
                tmp0.xy = tmp0.xy - float2(0.5, 0.5);
                o.sv_target.xy = inp.color.xy * tmp0.xy + float2(0.5, 0.5);
                tmp0 = tex2D(_AlphaTex, inp.texcoord.xy);
                o.sv_target.w = tmp0.x * inp.color.w;
                o.sv_target.z = inp.color.z;
                return o;
			}
			ENDCG
		}
	}
}