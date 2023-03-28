Shader "Hidden/ChromaticAberration" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Shift ("Shift", Float) = 0
	}
	SubShader {
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 26893
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _Shift;
			// $Globals ConstantBuffers for Fragment Shader
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
                o.sv_position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.texcoord.xy = v.texcoord.xy;
                tmp0 = v.texcoord.xyxy - float4(0.5, 0.5, 0.5, 0.5);
                o.texcoord1 = tmp0 * _Shift + float4(0.5, 0.5, 0.5, 0.5);
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_MainTex, inp.texcoord1.xy);
                o.sv_target.x = tmp0.x;
                tmp0 = tex2D(_MainTex, inp.texcoord.xy);
                o.sv_target.yw = tmp0.yw;
                tmp0 = tex2D(_MainTex, inp.texcoord1.zw);
                o.sv_target.z = tmp0.z;
                return o;
			}
			ENDCG
		}
		Pass {
			ZTest Always
			ZWrite Off
			Cull Off
			Fog {
				Mode Off
			}
			GpuProgramID 118586
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _Shift;
			// $Globals ConstantBuffers for Fragment Shader
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
                o.sv_position = unity_MatrixVP._m03_m13_m23_m33 * tmp0.wwww + tmp1;
                o.texcoord.xy = v.texcoord.xy;
                tmp0 = v.texcoord.xyxy - float4(0.5, 0.5, 0.5, 0.5);
                o.texcoord1 = tmp0.zwzw * _Shift + float4(0.5, 0.5, 0.5, 0.5);
                o.texcoord2 = tmp0 * _Shift + float4(0.5, 0.5, 0.5, 0.5);
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                tmp0 = tex2D(_MainTex, inp.texcoord1.xy);
                tmp1 = tex2D(_MainTex, inp.texcoord1.zw);
                tmp0.z = tmp1.z;
                tmp1 = tex2D(_MainTex, inp.texcoord2.xy);
                tmp2 = tex2D(_MainTex, inp.texcoord.xy);
                tmp0.yw = tmp2.yw * float2(0.5, 0.5);
                tmp0 = tmp1 * float4(0.5, 0.5, 0.0, 0.0) + tmp0;
                tmp1 = tex2D(_MainTex, inp.texcoord2.zw);
                tmp0 = tmp1 * float4(0.0, 0.5, 0.5, 0.0) + tmp0;
                tmp1 = -tmp0 * float4(0.666, 0.666, 0.666, 0.666) + tmp2;
                tmp0 = tmp0 * float4(0.666, 0.666, 0.666, 0.666);
                tmp2.xy = inp.texcoord.xy - float2(0.5, 0.5);
                tmp2.x = dot(tmp2.xy, tmp2.xy);
                tmp2.x = -tmp2.x * 4.0 + 1.0;
                tmp2.x = tmp2.x * tmp2.x;
                o.sv_target = tmp2.xxxx * tmp1 + tmp0;
                return o;
			}
			ENDCG
		}
	}
}