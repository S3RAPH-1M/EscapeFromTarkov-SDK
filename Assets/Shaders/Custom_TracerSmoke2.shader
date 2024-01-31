Shader "Custom/TracerSmoke2" {
	Properties {
		_Color ("Main Color", Vector) = (1,1,1,1)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_NoiseTex ("Noise Texture", 2D) = "white" {}
		_NoiseScale ("_NoiseScale", Float) = 1
		_TracerPeriod ("_TracerPeriod", Float) = 1
		_VanishSpeed ("_VanishSpeed", Float) = 1
		_SizeMin ("_SizeMin", Float) = 1
		_SizeMax ("_SizeMax", Float) = 1
		_ViewDirCosAlpha ("_ViewDirCosAlpha", Range(0, 1)) = 0
		_AnimationSpeed ("Animation Speed", Float) = 1
		_DistortionMin ("_DistortionMin", Range(0, 1)) = 0.2
		_DistortionMax ("_DistortionMax", Range(0, 1)) = 0.8
		_FadeIn ("_FadeIn", Float) = 0.2
		_FadeOut ("_FadeOut", Float) = 0.2
	}
	SubShader {
		Tags { "QUEUE" = "Transparent" }
		Pass {
			Tags { "QUEUE" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			GpuProgramID 26895
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 position : SV_POSITION0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord2 : TEXCOORD2;
				float4 texcoord1 : TEXCOORD1;
				float4 color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _NoiseScale;
			float4 _Color;
			float _TracerPeriod;
			float _VanishSpeed;
			float _MainTime;
			float _SizeMin;
			float _SizeMax;
			float _ViewDirCosAlpha;
			float _AnimationSpeed;
			float _DistortionMin;
			float _DistortionMax;
			// $Globals ConstantBuffers for Fragment Shader
			float _FadeIn;
			float _FadeOut;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _NoiseTex;
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                float4 tmp4;
                tmp0.xyz = v.tangent.xyz * v.texcoord.yyy + v.vertex.xyz;
                tmp1.xyz = tmp0.yzx - _WorldSpaceCameraPos;
                tmp0.w = dot(v.tangent.xyz, v.tangent.xyz);
                tmp0.w = sqrt(tmp0.w);
                tmp2.xyz = v.tangent.xyz / tmp0.www;
                tmp3.yw = tmp0.ww * v.texcoord.yy;
                tmp4.xyz = tmp1.xyz * tmp2.zxy;
                tmp1.xyz = tmp2.yzx * tmp1.yzx + -tmp4.xyz;
                tmp0.w = dot(unity_MatrixV._m02_m12_m22, tmp2.xyz);
                tmp0.w = tmp0.w * _ViewDirCosAlpha;
                tmp0.w = -tmp0.w * tmp0.w + 1.0;
                tmp1.w = dot(tmp1.xyz, tmp1.xyz);
                tmp1.w = rsqrt(tmp1.w);
                tmp1.xyz = tmp1.www * tmp1.xyz;
                tmp1.xyz = tmp1.xyz * v.texcoord.xxx;
                tmp1.w = _SizeMax - _SizeMin;
                tmp2.x = _MainTime - v.tangent.w;
                tmp2.x = -v.texcoord.y * _TracerPeriod + tmp2.x;
                tmp2.y = tmp2.x * _VanishSpeed;
                tmp2.x = -tmp2.x * _VanishSpeed + 1.0;
                tmp0.w = tmp0.w * tmp2.x;
                tmp1.w = tmp2.y * tmp1.w + _SizeMin;
                tmp0.xyz = tmp1.xyz * tmp1.www + tmp0.xyz;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp1 = tmp1 + unity_MatrixVP._m03_m13_m23_m33;
                tmp0.x = tmp2.y < 2.0;
                tmp0.x = tmp0.x ? 1.0 : 0.0;
                o.position = tmp0.xxxx * tmp1;
                tmp0.x = _DistortionMax - _DistortionMin;
                o.texcoord2.x = tmp2.y * tmp0.x + _DistortionMin;
                tmp0.x = v.texcoord1.x - v.texcoord1.y;
                tmp0.y = tmp0.x * 3.3;
                tmp0.x = 0.0;
                tmp3.xz = max(v.texcoord.xx, float2(0.0, 0.0));
                o.texcoord.xy = tmp3.zw * float2(1.0, 0.04) + tmp0.xy;
                tmp1 = tmp3 * _NoiseScale.xxxx;
                o.texcoord2.y = v.texcoord.y;
                tmp0.x = _MainTime * _AnimationSpeed;
                tmp2 = tmp0.xxxx * float4(-1.0, -0.08, 1.0, 0.1);
                tmp1 = tmp1 * float4(0.2, 1.0, 0.18, 0.9) + tmp2;
                o.texcoord1 = tmp1 + v.texcoord1.xyyx;
                tmp1 = v.color * _Color;
                o.color.w = tmp0.w * tmp1.w;
                o.color.xyz = tmp1.xyz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0.x = 1.0 - inp.texcoord2.y;
                tmp0.x = tmp0.x / _FadeOut;
                tmp0.y = inp.texcoord2.y / _FadeIn;
                tmp0.xy = min(tmp0.xy, float2(1.0, 1.0));
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.w = saturate(tmp0.x * inp.color.w);
                tmp1 = tex2D(_NoiseTex, inp.texcoord1.xy);
                tmp2 = tex2D(_NoiseTex, inp.texcoord1.zw);
                tmp1.xy = tmp1.xy + tmp2.yx;
                tmp1.xy = tmp1.xy - float2(1.0, 1.0);
                tmp1.xy = tmp1.xy * inp.texcoord2.xx + inp.texcoord.xy;
                tmp1 = tex2D(_MainTex, tmp1.xy);
                tmp0.xyz = inp.color.xyz;
                o.sv_target = tmp0 * tmp1;
                return o;
			}
			ENDCG
		}
	}
}