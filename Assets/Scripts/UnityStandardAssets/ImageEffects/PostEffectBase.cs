using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x02000033 RID: 51
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public class PostEffectsBase : MonoBehaviour
	{
		// Token: 0x06000116 RID: 278 RVA: 0x0000BE74 File Offset: 0x0000A074
		protected Material CreateMaterial(Shader s, Material m2Create)
		{
			if (!s || !s.isSupported)
			{
				Debug.Log("Missing shader in " + this.ToString());
				return null;
			}
			if (m2Create && m2Create.shader == s && s.isSupported)
			{
				return m2Create;
			}
			m2Create = new Material(s)
			{
				hideFlags = HideFlags.DontSave
			};
			return m2Create;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000BED9 File Offset: 0x0000A0D9
		protected bool CheckSupport()
		{
			return this.CheckSupport(false);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000BEE2 File Offset: 0x0000A0E2
		public virtual bool CheckResources()
		{
			Debug.LogWarning("CheckResources () for " + this.ToString() + " should be overwritten.");
			return this.isSupported;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000BF04 File Offset: 0x0000A104
		protected void Start()
		{
			this.supportsRenderTextureFormatDepth = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth);
			this.supportHDRTextures = SystemInfo.SupportsRenderTextureFormat(RuntimeUtilities.defaultHDRRenderTextureFormat);
			this.isSupported = true;
			this.CheckResources();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000BF30 File Offset: 0x0000A130
		protected bool CheckSupport(bool needDepth)
		{
			this.isSupported = true;
			this.supportDX11 = (SystemInfo.graphicsShaderLevel >= 50 && SystemInfo.supportsComputeShaders);
			if (!SystemInfo.supportsImageEffects)
			{
				this.NotSupported();
				return false;
			}
			if (needDepth && !this.supportsRenderTextureFormatDepth)
			{
				this.NotSupported();
				return false;
			}
			if (needDepth)
			{
				base.GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
			}
			return true;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000BF94 File Offset: 0x0000A194
		protected bool CheckSupport(bool needDepth, bool needHdr)
		{
			if (!this.CheckSupport(needDepth))
			{
				return false;
			}
			if (needHdr && !this.supportHDRTextures)
			{
				this.NotSupported();
				return false;
			}
			return true;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000BFB5 File Offset: 0x0000A1B5
		public bool Dx11Support()
		{
			return this.supportDX11;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000BFBD File Offset: 0x0000A1BD
		protected void ReportAutoDisable()
		{
			Debug.LogWarning("The image effect " + this.ToString() + " has been disabled as it's not supported on the current platform.");
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000BFD9 File Offset: 0x0000A1D9
		protected void NotSupported()
		{
			base.enabled = false;
			this.isSupported = false;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000BFEC File Offset: 0x0000A1EC
		protected void DrawBorder(RenderTexture dest, Material material)
		{
			RenderTexture.active = dest;
			GL.PushMatrix();
			GL.LoadOrtho();
			for (int i = 0; i < material.passCount; i++)
			{
				material.SetPass(i);
				float y = 1f;
				float y2 = 0f;
				float x = 0f;
				float x2 = 0f + 1f / ((float)dest.width * 1f);
				float y3 = 0f;
				float y4 = 1f;
				GL.Begin(7);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				float x3 = 1f - 1f / ((float)dest.width * 1f);
				x2 = 1f;
				y3 = 0f;
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x3, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x3, y4, 0.1f);
				float x4 = 0f;
				x2 = 1f;
				y3 = 0f;
				y4 = 0f + 1f / ((float)dest.height * 1f);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x4, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x4, y4, 0.1f);
				float x5 = 0f;
				x2 = 1f;
				y3 = 1f - 1f / ((float)dest.height * 1f);
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x5, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x5, y4, 0.1f);
				GL.End();
			}
			GL.PopMatrix();
		}

		// Token: 0x040001FF RID: 511
		protected bool supportHDRTextures = true;

		// Token: 0x04000200 RID: 512
		protected bool supportDX11;

		// Token: 0x04000201 RID: 513
		protected bool isSupported = true;

		// Token: 0x04000202 RID: 514
		private bool supportsRenderTextureFormatDepth = true;
	}
}
