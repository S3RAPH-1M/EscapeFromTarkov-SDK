Shader "CW FX/OpticSight" {
	Properties {
		_MarkTex ("Mark Texture", 2D) = "white" {}
		_MaskTex ("Mask Texture(A)", 2D) = "white" {}
		_MaskTex2 ("Mask Texture2(A)", 2D) = "white" {}
		_MarkLightness ("Mark Lightness", Range(0, 0.1)) = 0.015
		_ShiftDirection ("_ShiftDirection", Vector) = (0,0,1,0)
		_Shifts ("_Shifts", Vector) = (0,0,0,0)
		_Scales ("_Scales", Vector) = (100,100,100,100)
		_NormalHideness ("_NormalHideness", Range(1, 256)) = 6
	}
	SubShader {
		Tags { "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent+100" }
		Pass {
			Tags { "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent+100" }
			ColorMask 0 -1
			ZTest Always
			ZWrite Off
			Stencil {
				Comp Always
				Pass Zero
				Fail Zero
				ZFail Keep
			}
			GpuProgramID 44911
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			// $Globals ConstantBuffers for Fragment Shader
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                o.sv_position.xy = v.vertex.zx * float2(1000.0, 1000.0);
                o.sv_position.zw = float2(0.1, 1.0);
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                o.sv_target = float4(0.0, 0.0, 0.0, 0.0);
                return o;
			}
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent+100" }
			ColorMask A -1
			Stencil {
				Ref 1
				WriteMask 1
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 117577
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			// $Globals ConstantBuffers for Fragment Shader
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                tmp0.x = dot(unity_ObjectToWorld._m00_m10_m20, unity_ObjectToWorld._m00_m10_m20);
                tmp0.y = dot(unity_ObjectToWorld._m01_m11_m21, unity_ObjectToWorld._m01_m11_m21);
                tmp0.xy = sqrt(tmp0.xy);
                tmp0.x = tmp0.x / tmp0.y;
                tmp0.xyz = tmp0.xxx * unity_ObjectToWorld._m01_m21_m11;
                tmp1.y = tmp0.z;
                tmp1.x = unity_ObjectToWorld._m10;
                tmp1.z = unity_ObjectToWorld._m12;
                tmp1.w = unity_ObjectToWorld._m13;
                tmp2.xyz = v.vertex.xyz;
                tmp2.w = 1.0;
                tmp1.x = dot(tmp1, tmp2);
                tmp1 = tmp1.xxxx * unity_MatrixVP._m01_m11_m21_m31;
                tmp3.y = tmp0.x;
                tmp3.x = unity_ObjectToWorld._m00;
                tmp3.z = unity_ObjectToWorld._m02;
                tmp3.w = unity_ObjectToWorld._m03;
                tmp3.x = dot(tmp3, tmp2);
                tmp1 = unity_MatrixVP._m00_m10_m20_m30 * tmp3.xxxx + tmp1;
                tmp0.x = unity_ObjectToWorld._m20;
                tmp0.z = unity_ObjectToWorld._m22;
                tmp0.w = unity_ObjectToWorld._m23;
                tmp0.x = dot(tmp0, tmp2);
                tmp0 = unity_MatrixVP._m02_m12_m22_m32 * tmp0.xxxx + tmp1;
                tmp1.x = unity_ObjectToWorld._m30;
                tmp1.y = unity_ObjectToWorld._m31;
                tmp1.z = unity_ObjectToWorld._m32;
                tmp1.w = unity_ObjectToWorld._m33;
                tmp1.x = dot(tmp1, tmp2);
                o.sv_position = unity_MatrixVP._m03_m13_m23_m33 * tmp1.xxxx + tmp0;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                o.sv_target = float4(1.0, 1.0, 1.0, 1.0);
                return o;
			}
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent+100" }
			ColorMask RGB -1
			ZTest Always
			ZWrite Off
			Stencil {
				Ref 1
				ReadMask 1
				Comp Equal
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 194464
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float4 color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _ShiftDirection;
			float4 _Shifts;
			float4 _Scales;
			// $Globals ConstantBuffers for Fragment Shader
			float _SwitchToSight;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _CamTex;
			sampler2D _MaskTex2;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                tmp0.x = dot(unity_ObjectToWorld._m01_m11_m21, unity_ObjectToWorld._m01_m11_m21);
                tmp0.y = dot(unity_ObjectToWorld._m00_m10_m20, unity_ObjectToWorld._m00_m10_m20);
                tmp0.xy = sqrt(tmp0.xy);
                tmp0.x = tmp0.y / tmp0.x;
                tmp0.xzw = tmp0.xxx * unity_ObjectToWorld._m01_m11_m21;
                tmp1.x = dot(tmp0.xyz, tmp0.xyz);
                tmp1.x = sqrt(tmp1.x);
                tmp0.y = tmp0.y / tmp1.x;
                tmp0.xyz = tmp0.yyy * tmp0.xwz;
                tmp1.y = tmp0.z;
                tmp1.x = unity_ObjectToWorld._m10;
                tmp1.z = unity_ObjectToWorld._m12;
                tmp1.w = unity_ObjectToWorld._m13;
                tmp2.xyz = _ShiftDirection.xyz * _Shifts.xxx;
                tmp2.xyz = v.vertex.xyz * _Scales.xxx + tmp2.xyz;
                tmp2.w = 1.0;
                tmp1.x = dot(tmp1, tmp2);
                tmp1.xyz = tmp1.xxx * unity_MatrixVP._m01_m11_m31;
                tmp3.y = tmp0.x;
                tmp3.x = unity_ObjectToWorld._m00;
                tmp3.z = unity_ObjectToWorld._m02;
                tmp3.w = unity_ObjectToWorld._m03;
                tmp1.w = dot(tmp3, tmp2);
                tmp1.xyz = unity_MatrixVP._m00_m10_m30 * tmp1.www + tmp1.xyz;
                tmp0.x = unity_ObjectToWorld._m20;
                tmp0.z = unity_ObjectToWorld._m22;
                tmp0.w = unity_ObjectToWorld._m23;
                tmp0.x = dot(tmp0, tmp2);
                tmp0.xyz = unity_MatrixVP._m02_m12_m32 * tmp0.xxx + tmp1.xyz;
                tmp1.x = unity_ObjectToWorld._m30;
                tmp1.y = unity_ObjectToWorld._m31;
                tmp1.z = unity_ObjectToWorld._m32;
                tmp1.w = unity_ObjectToWorld._m33;
                tmp0.w = dot(tmp1, tmp2);
                o.sv_position.xyw = unity_MatrixVP._m03_m13_m33 * tmp0.www + tmp0.xyz;
                o.sv_position.z = 0.001;
                o.texcoord.xy = v.texcoord.xy * float2(10.0, 10.0) + float2(-4.5, -4.5);
                o.color = v.color;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_CamTex, inp.texcoord.xy);
                tmp1 = tex2D(_MaskTex2, inp.texcoord.xy);
                tmp0 = tmp0 * tmp1.wwww;
                tmp1.x = 1.0 - _SwitchToSight;
                o.sv_target = tmp0 * tmp1.xxxx;
                return o;
			}
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent+100" }
			Blend DstColor Zero, DstColor Zero
			ColorMask RGB -1
			ZTest Always
			ZWrite Off
			Stencil {
				Ref 1
				ReadMask 1
				Comp Equal
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 223851
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float4 color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _ShiftDirection;
			float4 _Shifts;
			float4 _Scales;
			// $Globals ConstantBuffers for Fragment Shader
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MaskTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                float4 tmp4;
                tmp0.x = dot(unity_ObjectToWorld._m01_m11_m21, unity_ObjectToWorld._m01_m11_m21);
                tmp0.y = dot(unity_ObjectToWorld._m00_m10_m20, unity_ObjectToWorld._m00_m10_m20);
                tmp0.xy = sqrt(tmp0.xy);
                tmp0.x = tmp0.y / tmp0.x;
                tmp0.xzw = tmp0.xxx * unity_ObjectToWorld._m01_m11_m21;
                tmp1.x = dot(tmp0.xyz, tmp0.xyz);
                tmp1.x = sqrt(tmp1.x);
                tmp0.y = tmp0.y / tmp1.x;
                tmp0.xyz = tmp0.yyy * tmp0.xwz;
                tmp1.y = tmp0.z;
                tmp1.x = unity_ObjectToWorld._m10;
                tmp1.z = unity_ObjectToWorld._m12;
                tmp1.w = unity_ObjectToWorld._m13;
                tmp2.xyz = float3(1.0, 1.0, 1.0) - v.color.xyz;
                tmp3.xyz = _ShiftDirection.xyz * _Shifts.yyy;
                tmp3.xyz = v.vertex.xyz * _Scales.yyy + tmp3.xyz;
                tmp4.xyz = v.vertex.xyz - tmp3.xyz;
                tmp2.xyz = tmp2.xyz * tmp4.xyz + tmp3.xyz;
                tmp2.w = 1.0;
                tmp1.x = dot(tmp1, tmp2);
                tmp1.xyz = tmp1.xxx * unity_MatrixVP._m01_m11_m31;
                tmp3.y = tmp0.x;
                tmp3.x = unity_ObjectToWorld._m00;
                tmp3.z = unity_ObjectToWorld._m02;
                tmp3.w = unity_ObjectToWorld._m03;
                tmp1.w = dot(tmp3, tmp2);
                tmp1.xyz = unity_MatrixVP._m00_m10_m30 * tmp1.www + tmp1.xyz;
                tmp0.x = unity_ObjectToWorld._m20;
                tmp0.z = unity_ObjectToWorld._m22;
                tmp0.w = unity_ObjectToWorld._m23;
                tmp0.x = dot(tmp0, tmp2);
                tmp0.xyz = unity_MatrixVP._m02_m12_m32 * tmp0.xxx + tmp1.xyz;
                tmp1.x = unity_ObjectToWorld._m30;
                tmp1.y = unity_ObjectToWorld._m31;
                tmp1.z = unity_ObjectToWorld._m32;
                tmp1.w = unity_ObjectToWorld._m33;
                tmp0.w = dot(tmp1, tmp2);
                o.sv_position.xyw = unity_MatrixVP._m03_m13_m33 * tmp0.www + tmp0.xyz;
                o.sv_position.z = 0.001;
                o.texcoord.xy = v.texcoord.xy;
                o.color = v.color;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                tmp0 = tex2D(_MaskTex, inp.texcoord.xy);
                o.sv_target = tmp0.wwww;
                return o;
			}
			ENDCG
		}
		Pass {
			Tags { "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent+100" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask RGB -1
			ZTest Always
			ZWrite Off
			Stencil {
				Ref 1
				ReadMask 1
				Comp Equal
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 300897
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			struct v2f
			{
				float4 sv_position : SV_Position0;
				float2 texcoord : TEXCOORD0;
				float4 color : COLOR0;
			};
			struct fout
			{
				float4 sv_target : SV_Target0;
			};
			// $Globals ConstantBuffers for Vertex Shader
			float4 _ShiftDirection;
			float4 _Shifts;
			float4 _Scales;
			float _NormalHideness;
			// $Globals ConstantBuffers for Fragment Shader
			float _SwitchToSight;
			float _MarkLightness;
			float _ThermalVisionOn;
			// Custom ConstantBuffers for Vertex Shader
			// Custom ConstantBuffers for Fragment Shader
			// Texture params for Vertex Shader
			// Texture params for Fragment Shader
			sampler2D _MarkTex;
			
			// Keywords: 
			v2f vert(appdata_full v)
			{
                v2f o;
                float4 tmp0;
                float4 tmp1;
                float4 tmp2;
                float4 tmp3;
                float4 tmp4;
                tmp0.x = dot(unity_ObjectToWorld._m01_m11_m21, unity_ObjectToWorld._m01_m11_m21);
                tmp0.y = dot(unity_ObjectToWorld._m00_m10_m20, unity_ObjectToWorld._m00_m10_m20);
                tmp0.xy = sqrt(tmp0.xy);
                tmp0.x = tmp0.y / tmp0.x;
                tmp0.xzw = tmp0.xxx * unity_ObjectToWorld._m01_m11_m21;
                tmp1.x = dot(tmp0.xyz, tmp0.xyz);
                tmp1.x = sqrt(tmp1.x);
                tmp0.y = tmp0.y / tmp1.x;
                tmp0.xyz = tmp0.yyy * tmp0.xwz;
                tmp1.y = tmp0.z;
                tmp1.w = unity_ObjectToWorld._m13;
                tmp1.x = unity_ObjectToWorld._m10;
                tmp1.z = unity_ObjectToWorld._m12;
                tmp2.xyz = _ShiftDirection.xyz * _Shifts.xxx;
                tmp2.xyz = v.vertex.xyz * _Scales.xxx + tmp2.xyz;
                tmp2.w = 1.0;
                tmp1.w = dot(tmp1, tmp2);
                tmp1.y = dot(tmp1.xyz, _ShiftDirection.xyz);
                tmp3.xyz = tmp1.www * unity_MatrixVP._m01_m11_m31;
                tmp4.y = tmp0.x;
                tmp4.w = unity_ObjectToWorld._m03;
                tmp4.x = unity_ObjectToWorld._m00;
                tmp4.z = unity_ObjectToWorld._m02;
                tmp1.w = dot(tmp4, tmp2);
                tmp1.x = dot(tmp4.xyz, _ShiftDirection.xyz);
                tmp3.xyz = unity_MatrixVP._m00_m10_m30 * tmp1.www + tmp3.xyz;
                tmp0.w = unity_ObjectToWorld._m23;
                tmp0.x = unity_ObjectToWorld._m20;
                tmp0.z = unity_ObjectToWorld._m22;
                tmp0.w = dot(tmp0, tmp2);
                tmp1.z = dot(tmp0.xyz, _ShiftDirection.xyz);
                tmp0.xyz = unity_MatrixVP._m02_m12_m32 * tmp0.www + tmp3.xyz;
                tmp3.x = unity_ObjectToWorld._m30;
                tmp3.y = unity_ObjectToWorld._m31;
                tmp3.z = unity_ObjectToWorld._m32;
                tmp3.w = unity_ObjectToWorld._m33;
                tmp0.w = dot(tmp3, tmp2);
                o.sv_position.xyw = unity_MatrixVP._m03_m13_m33 * tmp0.www + tmp0.xyz;
                o.sv_position.z = 0.001;
                o.texcoord.xy = v.texcoord.xy * float2(10.0, 10.0) + float2(-4.5, -4.5);
                tmp0.xyz = _WorldSpaceCameraPos - unity_ObjectToWorld._m03_m13_m23;
                tmp0.w = dot(tmp0.xyz, tmp0.xyz);
                tmp0.w = rsqrt(tmp0.w);
                tmp0.xyz = tmp0.www * tmp0.xyz;
                tmp0.x = dot(tmp1.xyz, tmp0.xyz);
                tmp0.x = saturate(tmp0.x * 2.0 + -1.0);
                tmp0.x = log(tmp0.x);
                tmp0.x = tmp0.x * _NormalHideness;
                o.color.x = exp(tmp0.x);
                o.color.yzw = v.color.yzw;
                return o;
			}
			// Keywords: 
			fout frag(v2f inp)
			{
                fout o;
                float4 tmp0;
                float4 tmp1;
                tmp0 = tex2D(_MarkTex, inp.texcoord.xy);
                tmp1.x = _MarkLightness;
                tmp1.w = 0.0;
                tmp0 = tmp0 + tmp1.xxxw;
                tmp0.xyz = tmp0.xyz * inp.color.xxx;
                tmp1.x = 1.0 - _SwitchToSight;
                tmp0 = tmp0 * tmp1.xxxx;
                tmp1.x = _ThermalVisionOn > 0.0;
                o.sv_target = tmp1.xxxx ? float4(0.0, 0.0, 0.0, 1.0) : tmp0;
                return o;
			}
			ENDCG
		}
	}
	CustomEditor "OpticSightEditor"
}