Shader "Custom/SimpleParticleMoveAdd" {
	Properties {
		[Queue] [HDR] _TintColor ("Tint Color (HDR)", Vector) = (0.5,0.5,0.5,0.5)
		_MainTex ("Texture", 2D) = "white" {}
		_Size ("Size", Float) = 1
		[Toggle(TURBULENCE)] _Turbulence ("Turbulence", Float) = 0
		[Space(8)] _TurbulenceFrequency0 ("Turbulence Frequency 0", Float) = 0
		_TurbulenceAmplitude0 ("Turbulence Amplitude 0", Float) = 0
		[Space(8)] _TurbulenceFrequency1 ("Turbulence Frequency 1", Float) = 0
		_TurbulenceAmplitude1 ("Turbulence Amplitude 1", Float) = 0
		[Space(16)] _FadeOut ("Fade Out Turbulence (1/sec)", Float) = 16
	}
	SubShader {
		Tags { "QUEUE" = "Transparent" }
		Pass {
			Tags { "QUEUE" = "Transparent" }
			Blend One One, One One
			ColorMask RGB -1
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 20508
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _MainTime;
			float _LastMainTime;
			float _Size;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _TintColor;
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
                tmp0.x = _MainTime - _LastMainTime;
                tmp0.x = max(tmp0.x, 0.0333333);
                tmp0.x = -tmp0.x * v.texcoord2.x + tmp0.x;
                tmp0.x = _MainTime - tmp0.x;
                tmp0.x = tmp0.x - v.tangent.x;
                tmp0.x = max(tmp0.x, 0.0);
                tmp0.y = tmp0.x / v.tangent.y;
                tmp0.z = 1.0 - tmp0.y;
                tmp0.y = tmp0.y * tmp0.z;
                tmp0.z = tmp0.y > 0.0;
                if (tmp0.z) {
                    tmp0.y = tmp0.y * 4.0;
                    tmp0.z = log(v.tangent.w);
                    tmp0.w = tmp0.z * tmp0.x;
                    tmp0.w = exp(tmp0.w);
                    tmp0.w = tmp0.w - 1.0;
                    tmp1.xyz = tmp0.www * v.normal.xyz;
                    tmp0.w = tmp0.z * 0.6931472;
                    tmp1.xyz = tmp1.xyz / tmp0.www;
                    tmp2.x = tmp0.x * tmp0.x;
                    tmp1.w = -tmp2.x * v.tangent.z + tmp1.y;
                    tmp0.x = tmp0.x - 0.04;
                    tmp0.z = tmp0.z * tmp0.x;
                    tmp0.z = exp(tmp0.z);
                    tmp0.z = tmp0.z - 1.0;
                    tmp2.xyz = tmp0.zzz * v.normal.xyz;
                    tmp2.xyz = tmp2.xyz / tmp0.www;
                    tmp0.x = tmp0.x * tmp0.x;
                    tmp2.w = -tmp0.x * v.tangent.z + tmp2.y;
                    tmp0.xzw = tmp1.xwz - tmp2.xwz;
                    tmp1.xyz = tmp1.xwz + v.vertex.xyz;
                    tmp2 = tmp1.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                    tmp2 = unity_MatrixVP._m00_m10_m20_m30 * tmp1.xxxx + tmp2;
                    tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp1.zzzz + tmp2;
                    tmp1 = tmp1 + unity_MatrixVP._m03_m13_m23_m33;
                    tmp2.xyz = tmp0.zzz * unity_MatrixVP._m01_m11_m01;
                    tmp2.xyz = unity_MatrixVP._m00_m10_m00 * tmp0.xxx + tmp2.xyz;
                    tmp0.xzw = unity_MatrixVP._m02_m12_m02 * tmp0.www + tmp2.xyz;
                    tmp2.x = dot(tmp0.xy, tmp0.xy);
                    tmp2.x = rsqrt(tmp2.x);
                    tmp2.xyw = tmp0.xzw * tmp2.xxx;
                    tmp2.z = -tmp2.y;
                    tmp2 = tmp2 * v.texcoord1.xxyy;
                    tmp2 = tmp2 * _Size.xxxx;
                    tmp2 = tmp2 * v.color.yyyy;
                    tmp0.xz = tmp2.zw + tmp2.xy;
                    o.position.xy = tmp0.xz + tmp1.xy;
                    o.color.x = tmp0.y * v.color.x;
                    o.position.zw = tmp1.zw;
                    o.texcoord.xy = v.texcoord.xy;
                } else {
                    o.position = float4(0.0, 0.0, 0.0, 0.0);
                    o.color = float3(0.0, 0.0, 0.0);
                }
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0 = tmp0 * inp.color.xxxx;
                o.sv_target = tmp0 * _TintColor;
                return o;
			}
			ENDCG
		}
	}
}