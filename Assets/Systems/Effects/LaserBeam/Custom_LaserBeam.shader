Shader "Custom/LaserBeam" {
	Properties {
		[Queue] _MainTex ("Particle Texture", 2D) = "white" {}
		_Tex3D ("Noise 3D", 3D) = "white" {}
		_NoiseScale0 ("_NoiseScale0", Float) = 10
		_Factor ("_Factor", Float) = 1
		_IkFactor ("_IkFactor", Float) = 1
		[HDR] _Color ("Color", Vector) = (1,1,1,1)
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+1011" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+1011" "RenderType" = "Transparent" }
			Blend One One, One One
			ZWrite Off
			Cull Off
			GpuProgramID 56837
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float4 color : COLOR0;
				float texcoord : TEXCOORD0;
				float3 texcoord1 : TEXCOORD1;
				float3 texcoord2 : TEXCOORD2;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _Intensity;
			float _Distance;
			float _NoiseScale0;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _Color;
			float _Factor;
			float _IkFactor;
			float _NightVisionOn;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler3D _Tex3D;
			sampler2D _MainTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0.xyz = v.vertex.yyy * unity_ObjectToWorld._m02_m12_m22;
                tmp0.xyz = tmp0.xyz * _Distance.xxx + unity_ObjectToWorld._m03_m13_m23;
                tmp1.xyz = _WorldSpaceCameraPos - tmp0.yzx;
                tmp2.xyz = tmp1.xyz * unity_ObjectToWorld._m22_m02_m12;
                tmp1.xyz = unity_ObjectToWorld._m12_m22_m02 * tmp1.yzx + -tmp2.xyz;
                tmp0.w = dot(tmp1.xyz, tmp1.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp1.xyz = tmp0.www * tmp1.xyz;
                tmp0.xyz = v.vertex.xxx * tmp1.xyz + tmp0.xyz;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp0.xyz = tmp0.xyz * _NoiseScale0.xxx;
                o.sv_position = tmp1 + unity_MatrixVP._m03_m13_m23_m33;
                tmp0.w = _Intensity - 4.0;
                o.color = v.vertex.yyyy * tmp0.wwww + float4(4.0, 4.0, 4.0, 4.0);
                o.texcoord1.xyz = _Time.xxx * float3(0.0, -0.5, 0.0) + tmp0.xyz;
                o.texcoord.x = v.texcoord.x;
                tmp1.x = _SinTime.x * 2.0;
                tmp1.y = 0.0;
                tmp1.z = _Time.x;
                o.texcoord2.xyz = tmp0.xyz * float3(3.94, 3.94, 3.94) + tmp1.xyz;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0 = tex3D(_Tex3D, inp.texcoord1.xyz);
                tmp1 = tex3D(_Tex3D, inp.texcoord2.xyz);
                tmp0.x = tmp1.w * 0.4 + tmp0.w;
                tmp0.y = tmp0.x * tmp0.x;
                tmp0.x = tmp0.x * tmp0.y;
                tmp0.yz = float2(_NightVisionOn.x, _ThermalVisionOn.x) > float2(0.0, 0.0);
                tmp0.y = tmp0.y ? _IkFactor : _Factor;
                tmp0.z = tmp0.z ? 0.0 : 1.0;
                tmp0.x = tmp0.y * tmp0.x;
                tmp0.x = tmp0.z * tmp0.x;
                tmp1.x = inp.texcoord.x;
                tmp1.y = 0.5;
                tmp1 = tex2D(_MainTex, tmp1.xy);
                tmp2 = inp.color * _Color;
                tmp1 = tmp1.xxxx * tmp2;
                o.sv_target = tmp0.xxxx * tmp1;
                return o;
			}
			ENDCG
		}
	}
}