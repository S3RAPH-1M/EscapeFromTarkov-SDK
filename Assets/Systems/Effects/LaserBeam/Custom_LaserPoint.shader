Shader "Custom/LaserPoint" {
	Properties {
		[Queue] _MainTex ("Particle Texture", 2D) = "white" {}
		_NoiseTex ("Noise Texture (R)", 2D) = "white" {}
		[HDR] _Color ("Color", Vector) = (1,1,1,1)
		_FactorOffset ("Z Offset Angle", Float) = 0
		_UnitsOffset ("Z Offset Forward", Float) = 0
		_Factor ("_Factor", Float) = 1
		_IkFactor ("_IkFactor", Float) = 1
		_MinFov ("_MinFov(fov when pointSize=0)", Float) = -50
		_SizeFactorViewMin ("_SizeFactorViewMin for ThirdParty view", Float) = 0.5
		_SizeFactorViewMax ("_SizeFactorViewMax for ThirdParty view", Float) = 2
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+2" "RenderType" = "Transparent" }
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent+2" "RenderType" = "Transparent" }
			Blend One One, One One
			ColorMask RGB -1
			ZWrite Off
			GpuProgramID 19168
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float4 color : COLOR0;
				float2 texcoord : TEXCOORD0;
				float2 texcoord1 : TEXCOORD1;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float _Size;
			float _MinFov;
			float _SizeFactorViewMin;
			float _SizeFactorViewMax;
			float _MaxDist;
			// $Globals ConstantBuffers for Fragment Shader
			float4 _Color;
			float _Intensity;
			float _Factor;
			float _IkFactor;
			float _ThermalVisionOn;
			float _NightVisionOn;
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
                tmp0.x = 1.0 / unity_CameraProjection._m11;
                tmp0.y = max(abs(tmp0.x), 1.0);
                tmp0.y = 1.0 / tmp0.y;
                tmp0.z = min(abs(tmp0.x), 1.0);
                tmp0.y = tmp0.y * tmp0.z;
                tmp0.z = tmp0.y * tmp0.y;
                tmp0.w = tmp0.z * 0.0208351 + -0.085133;
                tmp0.w = tmp0.z * tmp0.w + 0.180141;
                tmp0.w = tmp0.z * tmp0.w + -0.3302995;
                tmp0.z = tmp0.z * tmp0.w + 0.999866;
                tmp0.w = tmp0.z * tmp0.y;
                tmp0.w = tmp0.w * -2.0 + 1.570796;
                tmp1.x = abs(tmp0.x) > 1.0;
                tmp0.x = min(tmp0.x, 1.0);
                tmp0.x = tmp0.x < -tmp0.x;
                tmp0.w = tmp1.x ? tmp0.w : 0.0;
                tmp0.y = tmp0.y * tmp0.z + tmp0.w;
                tmp0.x = tmp0.x ? -tmp0.y : tmp0.y;
                tmp0.x = tmp0.x * 114.5916 + -_MinFov;
                tmp0.y = 75.0 - _MinFov;
                tmp0.x = saturate(tmp0.x / tmp0.y);
                tmp0.yzw = v.vertex.yyy * unity_ObjectToWorld._m01_m11_m21;
                tmp0.yzw = unity_ObjectToWorld._m00_m10_m20 * v.vertex.xxx + tmp0.yzw;
                tmp0.yzw = unity_ObjectToWorld._m02_m12_m22 * v.vertex.zzz + tmp0.yzw;
                tmp0.yzw = unity_ObjectToWorld._m03_m13_m23 * v.vertex.www + tmp0.yzw;
                tmp0.yzw = tmp0.yzw - _WorldSpaceCameraPos;
                tmp0.y = dot(tmp0.xyz, tmp0.xyz);
                tmp0.y = sqrt(tmp0.y);
                tmp0.y = min(tmp0.y, _MaxDist);
                tmp0.y = tmp0.y / _MaxDist;
                tmp0.z = _SizeFactorViewMax - _SizeFactorViewMin;
                tmp0.y = tmp0.y * tmp0.z + _SizeFactorViewMin;
                tmp0.y = tmp0.y * _Size;
                tmp0.xy = tmp0.xx * tmp0.yy;
                tmp0.z = 1.0;
                tmp0.xyz = tmp0.xyz * v.vertex.xyz;
                tmp1 = tmp0.yyyy * unity_ObjectToWorld._m01_m11_m21_m31;
                tmp1 = unity_ObjectToWorld._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp0 = unity_ObjectToWorld._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                tmp0 = tmp0 + unity_ObjectToWorld._m03_m13_m23_m33;
                tmp1 = tmp0.yyyy * unity_MatrixVP._m01_m11_m21_m31;
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp0.xxxx + tmp1;
                tmp1 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.zzzz + tmp1;
                o.sv_position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.color = v.color;
                o.texcoord1 = v.texcoord.xyxy * float4(1.0, 1.0, 1234.568, 1234.568);
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0 = tmp0.xxxx * _Color;
                tmp1 = tex2D(_NoiseTex, inp.texcoord1.xy);
                tmp0 = tmp0 * tmp1.xxxx;
                tmp0 = tmp0 * _Intensity.xxxx;
                tmp1.xy = float2(_ThermalVisionOn.x, _NightVisionOn.x) > float2(0.0, 0.0);
                tmp1.x = tmp1.x ? 0.0 : 1.0;
                tmp1.y = tmp1.y ? _IkFactor : _Factor;
                tmp0 = tmp0 * tmp1.xxxx;
                o.sv_target = tmp1.yyyy * tmp0;
                return o;
			}
			ENDCG
		}
	}
}